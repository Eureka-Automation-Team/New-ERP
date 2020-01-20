using Eureka.Core.Domain.Commons;
using Eureka.Froms.Views.Inventory;
using Eureka.Services.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Froms.Presentations.Inventory
{
    public class MaterialReturnEntryPresenter
    {
        private readonly IMaterialReturnEntryView _view;
        private readonly IItemTransactionSrv _repository;

        public MaterialReturnEntryPresenter(IMaterialReturnEntryView view)
        {
            _view = view;
            _repository = new ItemTransactionSrv();

            _view.Form_Load += Form_Load;
            _view.OK_Click += OK_Click;
            _view.Cancel_Click += Cancel_Click;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            UpdateReturnNumber();
            _view.CloseForm();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            _view.returnNumber = string.Empty;
            _view.CloseForm();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            _view.running = 0;
            _view.returnNumber = GetReturnNumber();
            _view.TransactionDate = DateTime.Now;
        }

        private string GetReturnNumber()
        {
            string docNo = string.Empty;
            string preFix = string.Empty;
            _view.rowDoc = _repository.GetSequenceDoc("MATERIAL_RETURN");

            if (_view.rowDoc != null)
            {
                string[] words = _view.rowDoc.Prefix.Split('#');
                preFix = DateTime.Now.ToString(words[0]) + words[1];

                if (_view.rowDoc.LastUpdateDate.Month != DateTime.Now.Month)
                    _view.running = 1;
                else
                    _view.running = _view.rowDoc.NextVal;

                docNo = string.Format("{0}{1}", preFix, _view.running.ToString().PadLeft(_view.rowDoc.RunningDigit, '0'));
            }
            return docNo;
        }

        private void UpdateReturnNumber()
        {
            _view.rowDoc.NextVal = _view.running + 1;
            _view.rowDoc.LastUpdateDate = DateTime.Now;
            _repository.UpdateDoc(_view.rowDoc);
        }
    }
}
 