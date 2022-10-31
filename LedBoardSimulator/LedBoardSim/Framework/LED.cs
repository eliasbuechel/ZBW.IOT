using System;
using System.Drawing;
using System.Linq;

namespace LedBoardSim.Framework
{
    public class LED
    {
        public const byte LED_COUNT = 10;

        private Color[] _LedColor = new Color[LED_COUNT];

        private LedPanel _panel;

        public LED()
        {
        }

        public bool begin()
        {
            _panel = new LedPanel();
            Program.MainScreen.AddPanel(_panel);
            return true;
        }

        /// <summary>
        /// Change the color of a specific LED each color must be a value between 0-255 LEDS indexed starting at 1
        /// </summary>
        /// <param name="number">LED number 0..9</param>
        /// <param name="red">red value</param>
        /// <param name="green">green value</param>
        /// <param name="blue">blue value</param>
        /// <returns>true in case of success</returns>
        public bool setLEDColor(byte number, byte red, byte green, byte blue)
        {
            if (number >= LED_COUNT) return false;

            _LedColor[number] = Color.FromArgb(red, green, blue);
            _panel.LedColorSet(number, _LedColor[number]);

            return true;
        }

        /// <summary>
        /// Change the color of all LEDs each color must be a value between 0-255
        /// </summary>
        /// <param name="red">red value</param>
        /// <param name="green">green value</param>
        /// <param name="blue">blue value</param>
        /// <returns>true in case of success</returns>
        public bool setLEDColor(byte red, byte green, byte blue)
        {
            return ForEachLed((byte number) => setLEDColor(number, red, green, blue));
        }

        /// <summary>
        /// Change the color of all LEDs at once to individual values Pass in 3 arrays of color values of length 'length' each color must be a value between 0-255
        /// </summary>
        /// <param name="redArray">red values</param>
        /// <param name="greenArray">green values</param>
        /// <param name="blueArray">blue values</param>
        /// <param name="length">Length of the arrays passed</param>
        /// <returns>true in case of success</returns>
        public bool setLEDColor(byte[] redArray, byte[] greenArray, byte[] blueArray, byte length)
        {
            bool result = true;
            byte maxIndex = Math.Min(length, LED_COUNT);

            for (byte i = 0; i < maxIndex; i++)
            {
                result = result && setLEDColor(i, redArray[i], greenArray[i], blueArray[i]);
            }

            return result;
        }

        /// <summary>
        /// Change the brightness of a specific LED, while keeping their current color brightness must be a value between 0-31 To turn LEDs off but remember their previous color, set brightness to 0 LEDS indexed starting at 1
        /// </summary>
        /// <param name="number">LED to set brightness for</param>
        /// <param name="brightness">Brightness level (0..31)</param>
        /// <returns>true in case of success</returns>
        public bool setLEDBrightness(byte number, byte brightness)
        {
            if (number >= LED_COUNT) return false;

            throw new NotImplementedException("Setting brightness is not supported on this platform");
        }

        /// <summary>
        /// Change the brightness of all LEDs, while keeping their current color brightness must be a value between 0-31 To turn all LEDs off but remember their previous color, set brightness to 0
        /// </summary>
        /// <param name="brightness">Brightness level (0..31)</param>
        /// <returns>true in case of success</returns>
        public bool setLEDBrightness(byte brightness)
        {
            return ForEachLed((number) => setLEDBrightness(number, brightness));
        }

        //
        /// <summary>
        /// Turn all LEDS off by setting color to 0
        /// </summary>
        /// <returns>true in case of success</returns>
        public bool LEDOff()
        {
            return setLEDColor(0, 0, 0);
        }

        private bool ForEachLed(Func<byte, bool> todo)
        {
            bool result = true;
            for (byte i = 0; i < LED_COUNT; i++)
            {
                result = result && todo(i);
            }
            return result;
        }
    };
}
