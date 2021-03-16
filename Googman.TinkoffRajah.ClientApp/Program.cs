using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Googman.TinkoffRajah.Logic.Tinkoff;

namespace Googman.TinkoffRajah.ClientApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var tokenTester = new TinkoffTokenTester();
            if (await tokenTester.IsTokenValidAsync(TokenStorage.Token) == false)
            {
                if (new TokenForm().ShowDialog() != DialogResult.OK)
                {
                    return;
                }
            }

            Application.Run(new Mainform());
        }
    }
}
