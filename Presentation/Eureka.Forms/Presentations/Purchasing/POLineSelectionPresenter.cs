using Eureka.Core.Domain.Purchasing;
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
    public class POLineSelectionPresenter
    {
        private readonly IPurchasingSrv _repository;
        private IPOLineSelectionView _view;

        public POLineSelectionPresenter(IPOLineSelectionView view)
        {
            _view = view;
            _repository = new PurchasingSrv();

            _view.Form_Load += Form_Load;
            _view.SearchPO_Click += SearchPO_Click;
            _view.OK_Click += OK_Click;
        }

        private void OK_Click(object sender, EventArgs e)
        {
            MetroGrid grid = sender as MetroGrid;

            if (grid.SelectedRows.Count > 0)
            {
                List<POLineModel> lines = new List<POLineModel>(); //grid.SelectedRows.DataBoundItem;
               
                foreach (DataGridViewRow item in grid.Rows)
                {
                    try
                    {
                        if ((bool)item.Cells[0].Value)
                        {
                            POLineModel line = (POLineModel)item.DataBoundItem;
                            lines.Add(line);
                        }
                    }
                    catch
                    {
                        //MessageBox.Show(ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (lines.Count != 0)
                {
                    _view.linesSelected = lines;
                    _view.CloseMe();
                }
            }
        }

        private void SearchPO_Click(object sender, EventArgs e)
        {
            POHeaderModel po = null; 
            if (!string.IsNullOrEmpty(_view.poNumber))
            {
                po = _repository.GetPOByNumber(_view.poNumber);
            }
            
            if(po != null)
            {
                _view.po = po;
                GetPOLines();
            }
            else
            {
                using (POListForm frm = new POListForm(null))
                {
                    frm.vendorId = _view.vendorId;
                    //frm.poNum = _view.poNumber;
                    frm.startDate = DateTime.Now.AddDays(-5);
                    frm.ShowDialog();
                    if (frm.posSelected != null)
                    {
                        _view.po = frm.posSelected.FirstOrDefault();
                        GetPOLines();
                    }
                }
            }
        }

        private void GetPOLines()
        {
            List<string> state = new List<string> { "Pending" , "Partial" };
            _view.line = _repository.GetPOLineByPOID(_view.po.PoHeaderId)
                .Where(
                x => x.Status.Trim() == "APPROVED" && 
                state.Contains(x.ReceivedStatus) &&
                x.VendorId == _view.vendorId
                ).ToList();
            _view.BindingData(_view.line.OrderBy(o => o.PoLineNum).ToList());
        }

        private void Form_Load(object sender, EventArgs e)
        {
            
        }
    }
}
