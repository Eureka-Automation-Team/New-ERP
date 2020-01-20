using Eureka.Core.Domain.Commons;
using Eureka.Froms.Views.Payables;
using Eureka.Services.Purchasing;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Payables
{
    public class TaxCodeListPresenter
    {
        private readonly IPurchasingSrv _repository;
        private readonly ITaxCodeListView _view;

        public TaxCodeListPresenter(ITaxCodeListView view)
        {
            _view = view;
            _repository = new PurchasingSrv();

            _view.Form_Load += Form_Load;
            _view.Filter_Click += Filter_Click;
            _view.Clear_Click += Clear_Click;
            _view.Selecting_Row += Selecting_Row;
            _view.OK_Click += OK_Click;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (_view.taxSelected != null)
                _view.CloseMe();
        }

        private void Selecting_Row(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;            
            try
            {
                _view.taxSelected = (TaxCodeModel)grid.CurrentRow.DataBoundItem;
            }
            catch
            {
                _view.taxSelected = null;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.taxCode = string.Empty;

            Filter_Click(sender, e);
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            var result = _view.taxCodes;
            if (result != null)
            {
                if (!string.IsNullOrEmpty(_view.taxCode)) result = result.Where(x => x.TaxCode.Contains(_view.taxCode)).ToList();
            }

            result = result.ToList();
            _view.BindingData(result);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            _view.taxCodes = _repository.GetTaxCodes();

            //Filter_Click(sender, e);
        }
    }
}
