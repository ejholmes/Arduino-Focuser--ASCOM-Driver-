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

    public enum StepTypes
    {
        SINGLE = 1,
        DOUBLE = 2,
        INTERLEAVE = 3,
        MICROSTEP = 8
    }

    public enum SpeedCutoff
    {
        FAST = 100, // If # of steps is greater than this, slew speed is fast
        SLOW = 10 // The # of steps for precise steps
    }

    public enum SlewSpeeds // RPM's
    {
        FAST = 100,
        SLOW = 10
    }
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

        private int position = 0;

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
            catch { this.comPort = null; }

            try { this.stepSize = Int32.Parse(profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "StepSize"));}
            catch { this.stepSize = 100; } // Step size in microns

            try { this.maxStep = Int32.Parse(profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "MaxStep")); }
            catch { this.maxStep = 25000; }

            try { this.maxIncrement = Int32.Parse(profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "MaxIncrement")); }
            catch { this.maxIncrement = 254; }

            try { this.position = Int32.Parse(profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "Position")); }
            catch { this.position = 0; }

            /*SerialConnection.Parity = SerialParity.None;
            SerialConnection.PortName = this.comPort;
            SerialConnection.StopBits = SerialStopBits.One;
            SerialConnection.Speed = SerialSpeed.ps9600;*/

            


            FocuserControl = new FocusControl(this);
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

            /*while (SerialConnection.BytesToRead <= 0)
            {
                HC.WaitForMilliseconds(100);
            }

            string response = SerialConnection.ReadLine();

            if (response == "Ready\r")
            {
                return true;
            }
            else
            {
                return false;
            }*/

            return true;

            //FocuserControl.Show();
        }

        // Method for disconnecting the focuser
        public bool disconnectFocuser()
        {
            SerialConnection.Close();

            //FocuserControl.Dispose();

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

            int move = val - this.position; // Calculate the move distance based on where we are and where we want to be

            if (Math.Abs(move) > (int)SpeedCutoff.FAST) // Move faster if we have to slew for a long time
            {
                FastMove(move);
            }
            else
            {
                SlowMove(move);
            }

            this.position = val;

            profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "Position", this.position.ToString());

            this.isMoving = false;
        }

        public void MoveAndWait(int val)
        {
            SerialConnection.Write(": M " + val + " #");

            while (SerialConnection.BytesToRead == 0)
            {
                HC.WaitForMilliseconds(100);
            }

            if (SerialConnection.ReadLine() == "M DONE\r")
            {
                SerialConnection.DiscardInBuffer();
                return;
            }
        }

        public void FastMove(int val)
        {
            int fastMove = val - (int)SpeedCutoff.SLOW; // Calculate the number of steps for fast movement
            SerialConnection.Write(": S " + (int)SlewSpeeds.FAST + " #"); // Set rpm to 100
            SerialConnection.Write(": T " + (int)StepTypes.SINGLE + " #"); // Set step type to single.

            this.MoveAndWait(fastMove); // Move and wait for return

            this.SlowMove((int)SpeedCutoff.SLOW); // do the last 50 steps precisely
        }

        public void SlowMove(int val)
        {
            SerialConnection.Write(": S " + (int)SlewSpeeds.SLOW + " #"); // Set rpm to 10
            SerialConnection.Write(": T " + (int)StepTypes.MICROSTEP + " #"); // Set step type to microstepping

            this.MoveAndWait(val); // Move and wait for return
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
