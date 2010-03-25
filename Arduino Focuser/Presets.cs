using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;

namespace ASCOM.Arduino
{
    public class Preset
    {
        private string _name;
        private int _position;

        public Preset()
        {
        }

        public Preset(string name, int position)
        {
            this._name = name;
            this._position = position;
        }

        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        public int Position
        {
            get { return this._position; }
            set { this._position = value; }
        }
    }

    [ComVisible(false)]
    public class Presets : List<Preset>
    {
        private static string xmlLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ASCOM.Arduino.Focuser.s_csDriverID + @"\Presets.xml");

        public void AddPreset(Preset preset)
        {
            foreach (Preset p in this)
            {
                if (p.Name == preset.Name)
                {
                    this.Remove(p);
                }
            }
            base.Add(preset);
            this.SaveToXml();
        }

        private static void CheckFilePaths()
        {
            string dir = Path.GetDirectoryName(xmlLocation);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
        }

        public static Presets LoadFromXml()
        {
            try
            {
                Presets.CheckFilePaths();

                TextReader reader = new StreamReader(xmlLocation);

                XmlSerializer serializer = new XmlSerializer(typeof(Presets));

                Presets p = (Presets)serializer.Deserialize(reader);

                reader.Close();

                return p;
            }
            catch
            {
                return new Presets();
            }
        }

        public void SaveToXml()
        {
            try
            {
                Presets.CheckFilePaths();

                XmlSerializer serializer = new XmlSerializer(typeof(Presets));

                TextWriter writer = new StreamWriter(xmlLocation);
                serializer.Serialize(writer, this);
                writer.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
    }
}
