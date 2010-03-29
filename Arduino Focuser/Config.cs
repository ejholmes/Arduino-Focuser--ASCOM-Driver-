using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;

using ASCOM.Utilities;

namespace ASCOM.Arduino
{
    [ComVisible(false)]
    public class Config
    {
        public static string XmlPresetsLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ASCOM.Arduino.Focuser.s_csDriverID + @"\Presets.xml");

        private bool _LinkState                 = false;    // Driver link state, true = connected
        private bool _IsMoving                  = false;    // True if focuser is moving
        private bool _Reversed                  = false;    // True if focuser movement is reversed
        private bool _BacklashCompensation      = false;    // True if backlash compensation is enabled for presets
        private bool _BacklashCompensationDir   = false;    // True = Outward moves, False = Inward moves, Reversed if this.Reversed

        private int _BacklashCompensationSteps  = 100;      // Number of steps to travel for backlash compensation
        private int _MaxIncrement               = 13000;    // Maximum number of steps the focuser can travel
        private int _MaxStep                    = 13000;    
        private int _StepSize                   = 2;        // Distance in microns the focuser moves in one step
        private int _Position                   = 0;        // Current focuser position

        private string _ComPort                 = null;     // Com port

        private Profile _Profile = new Profile();

        public Config()
        {
            this._Profile.DeviceType = "Focuser"; 

            try 
            { 
                this.ComPort = this._Profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "ComPort"); 
            }
            catch { }

            try 
            {
                this.StepSize = Int32.Parse(this._Profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "StepSize")); 
            }
            catch { }

            try 
            {
                this.MaxStep = Int32.Parse(this._Profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "MaxStep")); 
            }
            catch { }

            try 
            {
                this.MaxIncrement = Int32.Parse(this._Profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "MaxIncrement")); 
            }
            catch { }

            try 
            {
                this.Position = Int32.Parse(this._Profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "Position")); 
            }
            catch { }

            try 
            {
                this.Reversed = (Int32.Parse(this._Profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "Reversed")) == 0) ? false : true; 
            }
            catch { }

            try
            {
                this.BacklashCompensation = (Int32.Parse(this._Profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "BacklashCompensation")) == 0) ? false : true;
            }
            catch { }

            try
            {
                this.BacklashCompensationDir = (Int32.Parse(this._Profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "BacklashCompensationDir")) == 0) ? false : true;
            }
            catch { }

            try
            {
                this.BacklashCompensationSteps = Int32.Parse(this._Profile.GetValue(ASCOM.Arduino.Focuser.s_csDriverID, "BacklashCompensationSteps"));
            }
            catch { }
        }

        public Profile Profile
        {
            get { return this._Profile; }
            set { this._Profile = value; }
        }

        public bool LinkState
        {
            get { return this._LinkState; }
            set { this._LinkState = value; }
        }

        public bool IsMoving
        {
            get { return this._IsMoving; }
            set { this._IsMoving = value; }
        }

        public bool Reversed
        {
            get { return this._Reversed; }
            set 
            {
                this._Profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "Reversed", ((value) ? 1 : 0).ToString());
                this._Reversed = value; 
            }
        }

        public int MaxIncrement
        {
            get { return this._MaxIncrement; }
            set 
            {
                this._Profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "MaxIncrement", value.ToString());
                this._MaxIncrement = value; 
            }
        }

        public int MaxStep
        {
            get { return this._MaxStep; }
            set 
            {
                this._Profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "MaxStep", value.ToString());
                this._MaxStep = value; 
            }
        }

        public int StepSize
        {
            get { return this._StepSize; }
            set 
            {
                this._Profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "StepSize", value.ToString());
                this._StepSize = value; 
            }
        }

        public int Position
        {
            get { return this._Position; }
            set 
            {
                this._Profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "Position", value.ToString());
                this._Position = value; 
            }
        }

        public string ComPort
        {
            get { return this._ComPort; }
            set 
            {
                this._Profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "ComPort", value);
                this._ComPort = value; 
            }
        }

        public bool BacklashCompensation
        {
            get { return this._BacklashCompensation; }
            set
            {
                this._Profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "BacklashCompensation", (value == true) ? "1" : "0");
                this._BacklashCompensation = value;
            }
        }

        public int BacklashCompensationSteps
        {
            get { return this._BacklashCompensationSteps; }
            set
            {
                this._Profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "BacklashCompensationSteps", value.ToString());
                this._BacklashCompensationSteps = value;
            }
        }

        public bool BacklashCompensationDir
        {
            get { return this._BacklashCompensationDir; }
            set
            {
                this._Profile.WriteValue(ASCOM.Arduino.Focuser.s_csDriverID, "BacklashCompensationDir", (value == true) ? "1" : "0");
                this._BacklashCompensationDir = value;
            }
        }

    }
}
