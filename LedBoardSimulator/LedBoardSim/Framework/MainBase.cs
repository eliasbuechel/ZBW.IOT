using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LedBoardSim.Framework
{
    public abstract class MainBase
    {
        public void delay(int time)
        {
            Thread.Sleep(time);
        }

        public abstract void setup();

        public abstract void loop();
    }
}
