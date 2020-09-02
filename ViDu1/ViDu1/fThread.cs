using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ViDu1
{
    public partial class fThread : Form
    {
        public fThread()
        {
            InitializeComponent();
        }

        private void s1_Click(object sender, EventArgs e)
        {
            Thread Thread1 = new Thread(new ThreadStart(Start1));  
            Thread1.Start(); 
        }
        public void Start1()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (t1.InvokeRequired)
                {
                    t1.Invoke(new MethodInvoker(() => displaytext("Working.........", i)));
                }
                else
                {
                    displaytext("Working........", i);
                }
                //Thread.Sleep(100);
            }
        }

        public void displaytext(string thetext, int number)
        {
            t1.Text = thetext + " " + number;
        }  
    }  
    
}
