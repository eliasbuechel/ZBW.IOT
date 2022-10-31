using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LedBoardSim.Framework
{
    public partial class LedPanel : Form
    {
        private bool _isVisible = false;
        private Panel[] _leds = new Panel[LED.LED_COUNT];

        public LedPanel()
        {
            InitializeComponent();

            for (int i = 0; i < LED.LED_COUNT; i++)
            {
                var led = new Panel();
                flow.Controls.Add(led);
                led.BackColor = Color.FromArgb(255, 0, 0);
                led.BorderStyle = BorderStyle.Fixed3D;
                led.Padding = new Padding(5);
                led.MinimumSize = new Size(20, 20);
                led.Size = led.MinimumSize;
                _leds[i] = led;
            }
        }

        public void LedColorSet(byte number, Color color)
        {
            if (!_isVisible) return;

            _leds[number].Invoke(new Action(() =>
            {
                _leds[number].BackColor = color;
            }));
        }

        private void LedPanel_Load(object sender, EventArgs e)
        {
            _isVisible = true;
        }

        private void LedPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isVisible = false;
            Program.MainScreen.RemovePanel(this);
        }
    }
}
