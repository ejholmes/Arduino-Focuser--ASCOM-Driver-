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
using System.Threading;

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
        private bool ILinkState = false;

        // Max Steps per move
        private int IMaxIncrement;

        private int IMaxStep;

        // Step size (microns) for the focuser
        private int IStepSize;
#if DEBUG
        public string ComPort;
#else
        private string ComPort;
#endif

        private bool IIsMoving = false;

        private bool gtg = true;

        public int IPosition = 0;

        private bool reversed = false;

        private FocusControl FocuserControl;

        private ArduinoSerial SerialConnection;

        private ASCOM.Utilities.Util HC = new ASCOM.Utilities.Util();

        private ASCOM.Utilities.Profile IProfile = new ASCOM.Utilities.Profile();

        //
        // Constructor - Must be public for COM registration!
        //
        public Focuser()
        {
            IProfile.DeviceType = "Focuser";


            try { ComPort = IProfile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "ComPort"); }
            catch { ComPort = null; }

            try { IStepSize = Int32.Parse(IProfile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "StepSize"));}
            catch { IStepSize = 2; } // Step size in microns

            try { IMaxStep = Int32.Parse(IProfile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "MaxStep")); }
            catch { IMaxStep = 13000; }

            try { IMaxIncrement = Int32.Parse(IProfile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "MaxIncrement")); }
            catch { IMaxIncrement = IMaxStep; }

            try { IPosition = Int32.Parse(IProfile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "Position")); }
            catch { IPosition = 0; }

            try { reversed = (Int32.Parse(IProfile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "Reversed")) == 0) ? false : true; }
            catch { reversed = false; }

            FocuserControl = new FocusControl(this, IProfile);
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
            SerialConnection.SendCommand(ArduinoSerial.SerialCommand.Halt);
        }

        public bool IsMoving
        {
            get { return IIsMoving; }
        }

        public bool Link
        {
            get { return ILinkState; }
            set 
            {
                switch (value)
                {
                    case true:
                        ILinkState = connectFocuser();
                        break;
                    case false:
                        ILinkState = !disconnectFocuser();
                        break;
                }
            }
        }

        // Method for actually attempting to connect to the focuser
        public bool connectFocuser()
        {
            SerialConnection = new ArduinoSerial(this.ProcessQueue);
            SerialConnection.Parity = Parity.None;
            SerialConnection.PortName = this.ComPort;
            SerialConnection.StopBits = StopBits.One;
            SerialConnection.BaudRate = 9600;

            SerialConnection.Open();
            HC.WaitForMilliseconds(2000);

            ReverseMotorDirection(this.reversed);
            SetPositionOnFocuser(this.IPosition);
            
            FocuserControl.Show();

            return true;
        }

        private void ProcessQueue()
        {
            while (SerialConnection.CommandQueue.Count > 0)
            {
                string[] com_args = ((string)SerialConnection.CommandQueue.Pop()).Split(' ');

                string command = com_args[0];

                switch (command)
                {
                    case "P":
                        IPosition = Int32.Parse(com_args[1]);
                        gtg = true;
                        break;
                }
            }
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
            IProfile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "Reversed", rev);
            SerialConnection.SendCommand(ArduinoSerial.SerialCommand.Reverse, rev);
        }

        public int MaxIncrement
        {
            get { return this.IMaxIncrement; }
        }

        public int MaxStep
        {
            get { return this.IMaxStep; }
        }

        public void Move(int val)
        {
            IIsMoving = true;
            MoveAndWait(val);
            IProfile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "Position", IPosition.ToString());
            IIsMoving = false;
        }

        private void MoveAndWait(int val)
        {
            gtg = false;
            SerialConnection.SendCommand(ArduinoSerial.SerialCommand.Move, val);

            while (!gtg)
                HC.WaitForMilliseconds(100);
        }

        public void SetPositionOnFocuser(int val)
        {
            SerialConnection.SendCommand(ArduinoSerial.SerialCommand.Position, val);
        }

        public void Reset()
        {
            SerialConnection.ResetConnection();
        }

        public int Position
        {
            get {  return this.IPosition; }
        }

        public void SetupDialog()
        {
            SetupDialogForm F = new SetupDialogForm();
            F.ShowDialog();
        }

        public double StepSize
        {
            get { return IStepSize; }
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
