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
        private static string s_csDriverID = "ASCOM.Arduino.Focuser";
        // TODO Change the descriptive string for your driver then remove this line
        private static string s_csDriverDescription = "Arduino Focuser";

        // Link connection
        private bool linkState = false;

        // Max Steps per move
        private int maxIncrement;

        private int maxStep;

        // Step size (microns) for the focuser
        private int stepSize;

        private string comPort;

        private bool isMoving = false;

        private int position = 0;

        ASCOM.Utilities.Profile profile;

        SerialPort port;

        //
        // Constructor - Must be public for COM registration!
        //
        public Focuser()
        {

            profile = new ASCOM.Utilities.Profile();
            profile.DeviceType = global::ASCOM.Arduino.Properties.Resources.DeviceType;


            try {
                this.comPort = profile.GetValue(global::ASCOM.Arduino.Properties.Resources.DriverID, "ComPort");
            }
            catch {
                this.comPort = null;
            }
            try { 
                this.stepSize = Int32.Parse(profile.GetValue(global::ASCOM.Arduino.Properties.Resources.DriverID, "StepSize"));
            }
            catch {
                this.stepSize = 2;
            }
            try {
                this.maxStep = Int32.Parse(profile.GetValue(global::ASCOM.Arduino.Properties.Resources.DriverID, "MaxStep"));
            }
            catch {
                this.maxStep = 25000;
            }
            try {
                this.maxIncrement = Int32.Parse(profile.GetValue(global::ASCOM.Arduino.Properties.Resources.DriverID, "MaxIncrement"));
            }
            catch {
                this.maxIncrement = 254;
            }

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
            get { return false; }
        }

        public void Halt()
        {
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
            port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            port.Open();


            return true;
        }

        // Method for disconnecting the focuser
        public bool disconnectFocuser()
        {
            port.Close();

            return true;
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

            if( val > 0){
                port.Write(": M " + val.ToString() +" #");
            }
            else if (val < 0){
                port.Write(": M " + val.ToString() + " #");
            }

            this.isMoving = false;
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
            get { throw new PropertyNotImplementedException("TempComp", false); }
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
