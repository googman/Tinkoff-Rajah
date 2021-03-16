using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Googman.TinkoffRajah.Logic.Tinkoff;

namespace Googman.TinkoffRajah.ClientApp
{
    public partial class TokenForm : Form
    {
        public TokenForm()
        {
            InitializeComponent();
        }

        private void ctrlCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void ctrlOkButton_Click(object sender, EventArgs e)
        {
            if (await IsTokenSuccessAsync(ctrlTokenText.Text))
            {
                TokenStorage.Token = ctrlTokenText.Text;
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            MessageBox.Show(@"Token is invalid.");
        }

        private async Task<bool> IsTokenSuccessAsync(string token)
        {
            var tokenTester = new TinkoffTokenTester();
            return await tokenTester.IsTokenValidAsync(token);
        }
    }
}
