//tabs=4
// --------------------------------------------------------------------------------
// TODO fill in this information for your driver, then remove this line!
//
// ASCOM Focuser driver for Arduino
//
// Description:	Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam 
//				nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam 
//				erat, sed diam voluptua. At vero eos et accusam et justo duo 
//				dolores et ea rebum. Stet clita kasd gubergren, no sea takimata 
//				sanctus est Lorem ipsum dolor sit amet.
//
// Implements:	ASCOM Focuser interface version: 1.0
// Author:		(XXX) Your N. Here <your@email.here>
//
// Edit Log:
//
// Date			Who	Vers	Description
// -----------	---	-----	-------------------------------------------------------
// dd-mmm-yyyy	XXX	1.0.0	Initial edit, from ASCOM Focuser Driver template
// --------------------------------------------------------------------------------
//
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Collections;
using System.Reflection;

using ASCOM;
using ASCOM.Helper;
using ASCOM.Helper2;
using ASCOM.Interface;
using ASCOM.Utilities;

namespace ASCOM.Arduino
{
    //
    // Your driver's ID is ASCOM.Arduino.Focuser
    //
    // The Guid attribute sets the CLSID for ASCOM.Arduino.Focuser
    // The ClassInterface/None addribute prevents an empty interface called
    // _Focuser from being created and used as the [default] interface
    //
    [Guid("71a8f18b-8534-40d8-8651-d65bb07a0b69")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Focuser : IFocuser
    {
        //
        // Driver ID and descriptive string that shows in the Chooser
        //
        public static string s_csDriverID = "ASCOM.Arduino.Focuser";
        // TODO Change the descriptive string for your driver then remove this line
        public static string s_csDriverDescription = "Arduino Focuser";

        // Link connection
        private bool linkState = false;

        // Max Steps per move
        private int maxIncrement;

        private int maxStep;

        // Step size (microns) for the focuser
        private int stepSize;

        private string comPort;

        private bool isMoving = false;

        public int position = 0;

        private bool reversed = false;

        private FocusControl FocuserControl;

        private SerialPort SerialConnection;

        private ASCOM.Utilities.Util HC = new ASCOM.Utilities.Util();

        private ASCOM.Utilities.Profile profile = new ASCOM.Utilities.Profile();

        //
        // Constructor - Must be public for COM registration!
        //
        public Focuser()
        {
            profile.DeviceType = "Focuser";


            try { this.comPort = profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "ComPort"); }
            catch 
            { 
                this.comPort = null; 
#if DEBUG
                this.comPort = "COM4";
#endif
            }

            try { this.stepSize = Int32.Parse(profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "StepSize"));}
            catch { this.stepSize = 2; } // Step size in microns

            try { this.maxStep = Int32.Parse(profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "MaxStep")); }
            catch { this.maxStep = 13000; }

            try { this.maxIncrement = Int32.Parse(profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "MaxIncrement")); }
            catch { this.maxIncrement = this.maxStep; }

            try { this.position = Int32.Parse(profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "Position")); }
            catch { this.position = 0; }

            try { this.reversed = (Int32.Parse(profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "Reversed")) == 0) ? false : true; }
            catch { this.reversed = false; }

            FocuserControl = new FocusControl(this, profile);
        }

        #region ASCOM Registration
        //
        // Register or unregister driver for ASCOM. This is harmless if already
        // registered or unregistered. 
        //
        private static void RegUnregASCOM(bool bRegister)
        {
            Helper.Profile P = new Helper.Profile();
            P.DeviceTypeV = "Focuser";					//  Requires Helper 5.0.3 or later
            if (bRegister)
                P.Register(s_csDriverID, s_csDriverDescription);
            else
                P.Unregister(s_csDriverID);
            try										// In case Helper becomes native .NET
            {
                Marshal.ReleaseComObject(P);
            }
            catch (Exception) { }
            P = null;
        }

        [ComRegisterFunction]
        public static void RegisterASCOM(Type t)
        {
            RegUnregASCOM(true);
        }

        [ComUnregisterFunction]
        public static void UnregisterASCOM(Type t)
        {
            RegUnregASCOM(false);
        }
        #endregion

        //
        // PUBLIC COM INTERFACE IFocuser IMPLEMENTATION
        //

        #region IFocuser Members

        public bool Absolute
        {
            get { return true; }
        }

        public void Halt()
        {
            SerialConnection.Write(": H #");
        }

        public bool IsMoving
        {
            get { return this.isMoving; }
        }

        public bool Link
        {
            get { return this.linkState; }
            set 
            {
                switch (value)
                {
                    case true:
                        this.linkState = this.connectFocuser();
                        break;
                    case false:
                        this.linkState = !this.disconnectFocuser();
                        break;
                }
            }
        }

        // Method for actually attempting to connect to the focuser
        public bool connectFocuser()
        {
            SerialConnection = new SerialPort();
            SerialConnection.Parity = Parity.None;
            SerialConnection.PortName = this.comPort;
            SerialConnection.StopBits = StopBits.One;
            SerialConnection.BaudRate = 9600;

            SerialConnection.Open();

            HC.WaitForMilliseconds(3000);
            SerialConnection.DiscardInBuffer();

            this.ReverseMotorDirection(this.reversed);
            this.SetPositionOnFocuser(this.position);

            FocuserControl.Show();

            return true;
        }

        // Method for disconnecting the focuser
        public bool disconnectFocuser()
        {
            SerialConnection.Close();

            FocuserControl.Dispose();

            return true;
        }

        public void ReverseMotorDirection(bool reverse)
        {
            string rev = ((reverse) ? 1 : 0).ToString();
            this.profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "Reversed", rev);
            SerialConnection.Write(": R " + rev + " #");
        }

        public int MaxIncrement
        {
            get { return this.maxIncrement; }
        }

        public int MaxStep
        {
            get { return this.maxStep; }
        }

        public void Move(int val)
        {
            this.isMoving = true;

            this.MoveAndWait(val);

            profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "Position", this.position.ToString());

            this.isMoving = false;
        }

        private void MoveAndWait(int val)
        {
            SerialConnection.DiscardInBuffer();
            SerialConnection.Write(": M " + val + " #");

            this.position = this.GetPositionFromFocuser();
        }

        public int GetPositionFromFocuser()
        {
            while (SerialConnection.BytesToRead == 0)
            {
                HC.WaitForMilliseconds(100);
            }

            string ret = SerialConnection.ReadLine();
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"[-+]?\b\d+\b");
            System.Text.RegularExpressions.Match m = regex.Match(ret);

            return Int32.Parse(m.ToString());
        }

        public void SetPositionOnFocuser(int val)
        {
            SerialConnection.Write(": P " + val + " #");

            this.position = this.GetPositionFromFocuser();
        }

        public void Reset()
        {
            SerialConnection.Close();

            HC.WaitForMilliseconds(1000);

            SerialConnection.Open();

            HC.WaitForMilliseconds(3000);
        }

        public int Position
        {
            get 
            {
                return this.position; 
            }
        }

        public void SetupDialog()
        {
            SetupDialogForm F = new SetupDialogForm();
            F.ShowDialog();
        }

        public double StepSize
        {
            get 
            {
                return stepSize; 
            }
        }

        public bool TempComp
        {
            get { return false; }
            set { throw new PropertyNotImplementedException("TempComp", true); }
        }

        public bool TempCompAvailable
        {
            get { return false; }
        }

        public double Temperature
        {
            get { return 0; }
        }

        #endregion
    }
}
