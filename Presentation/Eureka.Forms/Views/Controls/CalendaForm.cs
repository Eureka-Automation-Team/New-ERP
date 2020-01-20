using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Controls
{
    public partial class CalendaForm : MetroForm, ICalendaView
    {
        public CalendaForm()
        {
            InitializeComponent();
        }

        public DateTime dateSeleted
        {
            get { return dtpMonth.SelectionRange.Start; }
            set { dtpMonth.SelectionRange.Start = value; }
        }

        //public event EventHandler Form_Load;
        //public event EventHandler Today_Click;
        //public event EventHandler OK_Click;
        //public event EventHandler Cancel_Click;

        private void dtpMonth_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtDateSelected.Text = dateSeleted.ToShortDateString();
        }

        private void CalendaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //dateSeleted = null;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
