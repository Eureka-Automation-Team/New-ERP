using Eureka.CNC.Views.Controls;
using Eureka.Services.Manufacturing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Presentations
{
    public class SingleCalendarPresenter
    {
        private readonly IJobEntitySrv _repository;
        private readonly ISingleCalendarView _view;

        public SingleCalendarPresenter(ISingleCalendarView view)
        {
            _view = view;
            _repository = new JobEntitySrv();

            _view.Form_Load += FormLoad;
            _view.Cancel_Click += Cancel;
            _view.OK_Click += OK_Click;
            _view.Date_Change += DateChange;
            _view.Today_Click += Today;
        }

        private void Today(object sender, EventArgs e)
        {
            _view.TimeEntry = DateTime.Now.ToString("dd/MM/yyyy hh:mm");
        }

        private void DateChange(object sender, EventArgs e)
        {
            MonthCalendar month = sender as MonthCalendar;
            
            _view.TimeEntry = month.SelectionRange.Start.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("hh:mm");
        }

        private void OK_Click(object sender, EventArgs e)
        {
            _view.boolOK = true;
            if(_view.TimeEntry == "  /  /       :")
            {
                return;
            }
            _view.timeSelected = DateTime.ParseExact(_view.TimeEntry, "dd/MM/yyyy hh:mm", null);
            _view.FormClose();
        }

        private void Cancel(object sender, EventArgs e)
        {
            _view.boolOK = false;
            _view.FormClose();
        }

        private void FormLoad(object sender, EventArgs e)
        {
            _view.boolOK = false;
        }
    }
}
