using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedBoardSim.Framework
{
    public static class Serial
    {
        public static void begin(int bitrate)
        {
        }

        public static void print(string str)
        {
            Program.MainScreen.Write(str);
        }

        public static void println(string str)
        {
            Program.MainScreen.WriteLine(str);
        }
    }
}
