using Eureka.Core.Domain.Payables;
using Eureka.Froms.Views.Payables;
using Eureka.Services.Payables;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Payables
{
    public class TermListPresenter
    {
        private readonly ITermListView _view;
        private readonly IPayablesSrv _repository;

        public TermListPresenter(ITermListView view)
        {
            _view = view;
            _repository = new PayablesSrv();

            _view.Form_Load += Form_Load;
            _view.Filter_Click += Filter_Click;
            _view.Clear_Click += Clear_Click;
            _view.Selecting_Row += Selecting_Row;
            _view.OK_Click += OK_Click;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            if (_view.termSelected != null)
                _view.CloseMe();
        }

        private void Selecting_Row(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;
            try
            {
                _view.termSelected = (TermModel)grid.CurrentRow.DataBoundItem;
            }
            catch
            {
                _view.termSelected = null;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            _view.TermCode = string.Empty;
            Filter_Click(sender, e); 
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            var result = _view.terms;
            if (result != null)
            {
                if (!string.IsNullOrEmpty(_view.TermCode)) result = result.Where(x => x.TermCode.Contains(_view.TermCode)).ToList();
            }

            result = result.ToList();
            _view.BindingData(result);
        }

        private void Form_Load(object sender, EventArgs e)
        {
            _view.terms = new List<TermModel>();
            _view.terms = _repository.GetTermAll();

            //Filter_Click(sender, e);
        }
    }
}
