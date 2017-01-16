using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace crystalReports
{
    public partial class formulario1 : Form
    {
        private CrystalReport1 crystalReport1;
        private CrystalReport2 crystalReport2;

        public formulario1(object report)
        {
            InitializeComponent();
            this.crystalReportViewer1.ReportSource = report;
        }
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }


    }
}
