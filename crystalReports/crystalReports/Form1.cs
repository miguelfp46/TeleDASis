using System;
using System.Windows.Forms;

namespace crystalReports
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formulario1 fr1 = new formulario1(new CrystalReport1());
            fr1.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            formulario1 fr1 = new formulario1(new CrystalReport2());
            fr1.ShowDialog();
            
        }
    }
}
