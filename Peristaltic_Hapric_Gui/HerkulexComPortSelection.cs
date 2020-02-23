using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peristaltic_Haptic_Gui
{
    public class HerkulexComPortSelection
    {
        public string port12;
        public string port34;
        public string port56;
        public string port78;
        public string batteryPort;
        public HerkulexComPortSelection(string port12, string port34,string port56, 
            string port78, string batteryPort)
        {
            this.port12 = port12;
            this.port34 = port34;
            this.port56 = port56;
            this.port78 = port78;
            this.batteryPort = batteryPort; 
        }

    }
}
