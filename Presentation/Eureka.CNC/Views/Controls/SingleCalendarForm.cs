using Eureka.CNC.Presentations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Views.Controls
{
    public partial class SingleCalendarForm : Form, ISingleCalendarView
    {
        private SingleCalendarPresenter _presenter;
        private Nullable<DateTime> _currentDate;
        private DateTime _timeSelected;
        private bool _boolOK;

        public SingleCalendarForm(Nullable<DateTime> currentDate)
        {
            InitializeComponent();
            _presenter = new SingleCalendarPresenter(this);

            _currentDate = currentDate;
        }

        public DateTime dateSelected
        {
            get { return monthCalendar.SelectionRange.Start; }
            set { monthCalendar.SelectionRange.Start = value; }
        }

        public string TimeEntry
        {
            get { return txtDateTime.Text; }
            set { txtDateTime.Text = value; }
        }

        public bool boolOK
        {
            get { return _boolOK; }
            set { _boolOK = value; }
        }

        public DateTime timeSelected
        {
            get { return _timeSelected; }
            set { _timeSelected = value; }
        }

        public event EventHandler Form_Load;
        public event EventHandler Today_Click;
        public event EventHandler OK_Click;
        public event EventHandler Cancel_Click;
        public event EventHandler Date_Change;

        private void button3_Click(object sender, EventArgs e)
        {
            if (Cancel_Click != null)
                Cancel_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OK_Click != null)
                OK_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Today_Click != null)
                Today_Click(sender, e);
        }

        private void SingleCalendarForm_Load(object sender, EventArgs e)
        {
            dateSelected = _currentDate ?? DateTime.Now;

            if (Form_Load != null)
                Form_Load(sender, e);
        }

        public void FormClose()
        {
            this.Close();
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (Date_Change != null)
                Date_Change(sender, e);
        }
    }
}
