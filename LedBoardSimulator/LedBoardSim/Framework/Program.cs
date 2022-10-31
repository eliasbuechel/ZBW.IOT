using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedBoardSim.Framework
{
    static class Program
    {
        public static LedBoardSimMain MainScreen { get; private set; }

        private static CancellationTokenSource _cts = new CancellationTokenSource();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MainScreen = new LedBoardSimMain(_cts);
            MainScreen.FormClosing += LedBoard_FormClosing;
            Application.Run(MainScreen);
        }

        private static void LedBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            _cts.Cancel();
        }
    }
}
