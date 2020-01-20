using Eureka.Core.Domain.Commons;
using Eureka.Froms.Views.Purchasing;
using Eureka.Services.Purchasing;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Purchasing
{
    public class CurrencyPresenter
    {
        private readonly IPurchasingSrv _repository;
        private readonly ICurrencyListView _view;

        public CurrencyPresenter(ICurrencyListView view)
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
            if (_view.currSelected != null)
                _view.CloseMe();
        }

        private void Selecting_Row(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            DataGridViewCellValidatingEventArgs erg = e as DataGridViewCellValidatingEventArgs;

            _view.currSelected = (CurrencyModel)grid.CurrentRow.DataBoundItem;
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.currencyCode = string.Empty;

            Filter_Click(sender, e);
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            var result = _repository.GetCurrencies();
            if (result != null)
            {
                if (!string.IsNullOrEmpty(_view.currencyCode)) result = result.Where(x => x.CurrencyCode.Contains(_view.currencyCode)).ToList();
            }

            _view.currencies = result.ToList();
            _view.bindingCurrency.DataSource = _view.currencies;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            _view.currencies = _repository.GetCurrencies();

            _view.BindingData();
            Filter_Click(sender, e);
        }
    }
}
