using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedBoardSim
{
    public partial class LedBoardSimMain : Form
    {
        private Dictionary<Control, Control> _panels = new Dictionary<Control, Control>();
        private CancellationTokenSource _cts;

        private int _panelCount = 0;
        private bool _isClosing = false;

        public LedBoardSimMain(CancellationTokenSource cts)
        {
            InitializeComponent();
            _cts = cts;
        }

        public void AddPanel(Framework.LedPanel ledPanel)
        {
            var panelNo = _panelCount++;
            var panelBtn = new Button()
            {
                Text = $"LED Panel {panelNo}",
            };
            panelBtn.AutoSize = true;
            panelBtn.Click += (object sender, EventArgs e) => InvokeVisu(() => ledPanel.Show());

            InvokeVisu(() =>
            {
                _panels.Add(ledPanel, panelBtn);

                Widgets.Controls.Add(panelBtn);
                ledPanel.Text = panelBtn.Text;
                ledPanel.Show();
                ledPanel.Top = Top + Height + panelNo * ledPanel.Height;
                ledPanel.Left = Left;
            });

        }

        public void RemovePanel(Framework.LedPanel ledPanel)
        {
            InvokeVisu(() =>
            {
                PanelRemove(ledPanel);
                CloseIfNoMorePanels();
            });
        }

        private void PanelRemove(Framework.LedPanel ledPanel)
        {
            if (_panels.TryGetValue(ledPanel, out var button))
            {
                _panels.Remove(ledPanel);
                Widgets.Controls.Remove(button);
                _panelCount--;
            }
        }

        private void CloseIfNoMorePanels()
        {
            if (_panels.Count == 0)
            {
                Close();
            }
        }

        private void InvokeVisu(Action action)
        {
            var todo = new Action(() =>
            {
                if (_isClosing) return;
                action();
            });

            if (InvokeRequired)
            {
                Invoke(todo);
            }
            else
            {
                todo();
            }
        }

        private void LedBoard_Load(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                var program = new Main();
                program.setup();

                Task.Run(() =>
                {
                    var period = TimeSpan.FromMilliseconds(0.1);
                    while (!_cts.IsCancellationRequested)
                    {
                        program.loop();
                        Thread.Sleep(period);
                    }
                });
            });
        }

        private void LedBoardSimMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cts.Cancel();
            _isClosing = true;
        }

        public void Write(string str)
        {
            MonitorAppend($"{str}");
        }

        public void WriteLine(string str)
        {
            MonitorAppend($"{str}{Environment.NewLine}");
        }

        private void MonitorAppend(string str)
        {
            InvokeVisu(() =>
            {
                Monitor.AppendText(str);
            });
        }
    }
}
