using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Views.Controls
{
    public interface ICalendaView
    {
        //event EventHandler Form_Load;
        //event EventHandler Today_Click;
        //event EventHandler OK_Click;
        //event EventHandler Cancel_Click;

        DateTime dateSeleted { get; set; }
    }
}
