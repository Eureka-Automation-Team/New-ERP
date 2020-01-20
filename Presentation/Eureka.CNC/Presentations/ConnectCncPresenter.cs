using Eureka.CNC.Views;
using Eureka.Core.Domain.CNC;
using Eureka.Services.CNC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Presentations
{
    public class ConnectCncPresenter
    {
        private readonly IProgramTransferSrv _repository;
        private readonly IConnectCNCView _view;

        public ConnectCncPresenter(IConnectCNCView view)
        {
            _view = view;
            _repository = new ProgramTransferSrv(_view.IpAddress);

            _view.Form_Load += Form_Load;
            _view.Connect_Click += Connect;
            _view.BrowseFile_Click += BrowseFile;
            _view.Upload_Click += UpdateNCFile;
            _view.GetProgramList_Click += GetProgramList;
            _view.DeleteProgram_Click += DeleteProg;
        }

        private void DeleteProg(object sender, EventArgs e)
        {
            if (!_view.Connected)
            {
                MessageBox.Show("Please connect Machine!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataGridView grd = sender as DataGridView;
            if (grd.SelectedRows.Count > 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure to delete program", "Please confirm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    foreach (DataGridViewRow item in grd.SelectedRows)
                    {
                        try
                        {
                            ProgramListDet line = (ProgramListDet)item.DataBoundItem;
                            ProgramTransferSrv srv = new ProgramTransferSrv(_view.IpAddress);
                            string strDel = srv.DeleteProgram("0", line.ProgNo);
                            MessageBox.Show(strDel, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            GetProgramList(null, null);
                        }
                        catch
                        {
                        }
                    }
                }
            }            
        }

        private void GetProgramList(object sender, EventArgs e)
        {
            if (!_view.Connected)
            {
                MessageBox.Show("Please connect Machine!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ProgramTransferSrv srv = new ProgramTransferSrv(_view.IpAddress);
                string fileName = System.IO.Path.GetFileName(_view.FilePath);
                _view.bindingProgram.DataSource = srv.GetProgramList();
        }

        private void UpdateNCFile(object sender, EventArgs e)
        {
            if (!_view.Connected)
            {
                MessageBox.Show("Please connect Machine!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int retValueInt = 0;
            if (!string.IsNullOrEmpty(_view.FilePath))
            {
                ProgramTransferSrv srv = new ProgramTransferSrv(_view.IpAddress);
                string fileName = System.IO.Path.GetFileName(_view.FilePath);
                //string strDel = srv.DeleteProgram("0", fileName);
                string str = srv.UploadCNCProgram(0, _view.FilePath, out retValueInt);
                //var result = srv.GetProgramList();
                MessageBox.Show(str, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GetProgramList(null, null);
            }
            else
            {
                MessageBox.Show("Please select NC file.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }       
        }

        private void BrowseFile(object sender, EventArgs e)
        {
            if (!_view.Connected)
            {
                MessageBox.Show("Please connect Machine!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (string.IsNullOrEmpty(_view.FilePath))
            //{
                OpenFileDialog saveFileDialog1 = new OpenFileDialog();
                //saveFileDialog1.Filter = "NC File|*.NC";
                saveFileDialog1.Title = "Open File";
                //saveFileDialog1.ShowDialog();
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog1.FileName != "")
                    {
                        _view.FilePath = saveFileDialog1.FileName;
                    }
                }
            //}
        }

        private void Connect(object sender, EventArgs e)
        {
            ProgramTransferSrv srv = new ProgramTransferSrv(_view.IpAddress);
            _view.bindingProgram.DataSource = srv.GetProgramList();
            if (_view.bindingProgram.DataSource != null)
                _view.Connected = true;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            _view.IpAddress = "192.168.1.151";
            _view.Port = "8193";
            _view.FilePath = string.Empty;
            _view.Connected = false;
        }


    }
}
