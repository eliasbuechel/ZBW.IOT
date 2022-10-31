using LedBoardSim.Framework;
using System;
using System.Linq;
using System.Threading;

namespace LedBoardSim
{
    public class Main : MainBase
    {
        LED _leds;

        public override void setup()
        {
            Serial.begin(115200);
            Wire.begin();

            Serial.println("Initializing");
            _leds = new LED();
            _leds.begin();
            Serial.println("Starting");
        }

        public override void loop()
        {
            Serial.println("Red");
            _leds.setLEDColor(255, 0, 0);
            delay(500);
            Serial.println("Green");
            _leds.setLEDColor(0, 255, 0);
            delay(500);
            Serial.println("Blue");
            _leds.setLEDColor(0, 0, 255);
            delay(500);
        }
    }
}
