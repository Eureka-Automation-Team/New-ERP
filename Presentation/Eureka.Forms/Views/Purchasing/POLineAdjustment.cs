using Eureka.Core.Domain.Purchasing;
using Eureka.Core.Domain.Security;
using Eureka.Forms.Presentations.Purchasing;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.Forms.Views.Purchasing
{
    public partial class POLineAdjustment : MetroForm, IPOLineAdjustmentView
    {
        private List<POLineModel> lines;
        private List<POLineModel> linesTemp;
        private readonly POLineAdjustmentPresenter _presenter;

        public POLineAdjustment(List<POLineModel> _poLines)
        {
            InitializeComponent();
            _presenter = new POLineAdjustmentPresenter(this);
            lines = _poLines;
            poLinesTemp = _poLines;

            this.dgvLine.RowPrePaint
                += new DataGridViewRowPrePaintEventHandler(
                    this.dgvLine_RowPrePaint);
        }

        private void dgvLine_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

                string received = dgvLine.Rows[e.RowIndex].Cells["colRreceivedStatus"].Value.ToString();
    

            if (received == "Fill")
            {
                dgvLine.Rows[e.RowIndex].Cells["colQuantity"].ReadOnly = true;
                dgvLine.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Gray;
            }
            else
            {
                dgvLine.Rows[e.RowIndex].Cells["colQuantity"].ReadOnly = false;
                dgvLine.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        public List<POLineModel> poLines 
        { 
            get { return lines; } 
            set { lines = value; } 
        }

        public Session EpiSession
        {
            get { return Session.Instance; }
        }

        public BindingSource bindingSource 
        { 
            get { return bndPoLines; } 
            set { bndPoLines = value; } 
        }

        public List<POLineModel> poLinesTemp
        {
            get { return linesTemp; }
            set { linesTemp = value; }
        }

        public event EventHandler FormLoad;
        public event EventHandler SaveAdjust;

        private void POLineAdjustment_Load(object sender, EventArgs e)
        {
            if (FormLoad != null)
                FormLoad(sender, e);
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            dgvLine.EndEdit();

            if (SaveAdjust != null)
                SaveAdjust(dgvLine, e);
        }

        private void dgvLine_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //colQuantityReceived
            //MessageBox.Show(dgvLines.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() +" / "+ e.FormattedValue);

            
        }

        private void dgvLine_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dgvLine_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                double receivedQty = Convert.ToDouble(dgvLine.Rows[e.RowIndex].Cells["colQuantityReceived"].Value);
                double quantity = Convert.ToDouble(dgvLine.Rows[e.RowIndex].Cells["colQuantity"].Value);

                if (quantity < receivedQty)
                {
                    MessageBox.Show("Adjust quantity must not be less than received.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        public void FormClose()
        {
            this.Close();
        }
    }
}
