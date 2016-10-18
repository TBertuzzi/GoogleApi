using KBITS.Google.API.Sample.Calendar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBITS.Google.API.Sample
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCalendar_Click(object sender, EventArgs e)
        {
            frmCalendar frmCalendar = new Calendar.frmCalendar();
            frmCalendar.ShowDialog();
        }
    }
}
