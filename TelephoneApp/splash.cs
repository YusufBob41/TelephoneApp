using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TelephoneApp
{
   
    public partial class splash : Form
    {
        private int progressValue = 0;
        public splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressValue += 1;

            if (progressValue <= 100)
            {
                progressBar1.Value = progressValue;
                labelYuzde.Text = "%" + progressValue.ToString();
            }
            else
            {
                timer1.Stop();
                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splash_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            labelYuzde.Text = "%0";
            timer1.Start();
        }
    }
}
