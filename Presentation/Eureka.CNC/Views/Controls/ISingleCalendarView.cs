using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.CNC.Views.Controls
{
    public interface ISingleCalendarView
    {
        event EventHandler Form_Load;
        event EventHandler Today_Click;
        event EventHandler OK_Click;
        event EventHandler Cancel_Click;
        event EventHandler Date_Change;

        bool boolOK { get; set; }
        DateTime timeSelected { get; set; }
        DateTime dateSelected { get; set; }
        string TimeEntry { get; set; }
        void FormClose();
    }
}
