using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViDu1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new QuestionForm());

            fLogin frm = new fLogin();
            fMain MAIN = new fMain();
            Application.Run(frm);
            if (frm.IsSuccessfull == true)
            {
                Application.Run(MAIN);
            }
            else
            {
                MAIN.Close();
            }
        }
    }
}
