using System;
using System.Windows.Forms;

namespace Soulstone.Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            catch(Exception ex)
            {
                ErrorForm errorForm = new ErrorForm();
                errorForm.ErrorText = ex.Message + ex.StackTrace;
                errorForm.ShowDialog();
            }
        }
    }
}
