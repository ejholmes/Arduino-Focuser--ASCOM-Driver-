using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Collections;
using System.Reflection;
using System.Threading;

using ASCOM;
using ASCOM.Interface;
using ASCOM.Utilities;

namespace ASCOM.Arduino
{
    public struct Commands
    {
        public const byte Move = (byte)'M';
        public const byte Halt = (byte)'H';
        public const byte Position = (byte)'P';
        public const byte Reverse = (byte)'R';
        public const byte PrintPosition = (byte)'G';
        public const byte Release = (byte)'L';
    }
}