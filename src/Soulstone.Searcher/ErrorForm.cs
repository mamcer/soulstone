using System.Windows.Forms;

namespace Soulstone.Searcher
{
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();
        }

        public string ErrorText
        {
            set
            {
                txtError.Text = value;
            }
        }

        private void lnkCopyToClipboard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clipboard.SetText(txtError.Text);
        }
    }
}
