using Eureka.Core.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Views.Inventory
{
    public interface IMaterialIssueEntryView : IView
    {
        event EventHandler Form_Load;
        event EventHandler Save_Click;
        event EventHandler GenerateNumber;
        //event EventHandler Refresh_Click;
        event EventHandler Validate_Lines;

        BindingSource bindingHead { get; set; }
        MaterialIssueModel head { get; set; }
        IEnumerable<ItemOnhandModel> onhandsSelected { get; set; }

        void BindingData();
        void ValidateLines();
        void CloseForm();
        void DataGridViewLoop();
    }
}
