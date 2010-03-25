using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ASCOM.Arduino
{
    class Preset : ASCOM.Utilities.KeyValuePair
    {
        public Preset()
        {
        }

        public Preset(string name, int position)
        {
            base.Key = name;
            base.Value = position.ToString();
        }

        public string Name
        {
            get { return base.Key; }
            set { base.Key = value; }
        }

        public int Position
        {
            get { return Int32.Parse(base.Value); }
            set { base.Key = value.ToString(); }
        }
    }
}
