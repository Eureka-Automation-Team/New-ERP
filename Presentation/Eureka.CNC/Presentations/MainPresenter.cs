using Eureka.CNC.Views;
using Eureka.Services;
using Eureka.Services.CNC;
using Eureka.Services.Manufacturing;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Presentations.Security
{
    public class MainPresenter
    {
        private readonly ISecuritieSrv _repository;
        private readonly IJobEntitySrv _repoJob;
        private readonly IMachineSrv _repoMachine;
        private readonly IMainView _view;

        public MainPresenter(IMainView view)
        {
            _view = view;
            _repository = new SecuritieSrv();
            _repoJob = new JobEntitySrv();
            _repoMachine = new MachineSrv();


            _view.Form_Load += Form_Load;
            _view.Monitoring += MonitoringAsync;
            _view.Menu_Click += Menu_Click;
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            switch (but.Name)
            {
                case "btnJobEntry":
                    JobEntityForm frm1 = new JobEntityForm();
                    frm1.Show();
                    break;
                case "btnTaskManagement":
                    TaskManagementForm frm2 = new TaskManagementForm();
                    frm2.Show();
                    break;
                case "btnDashboards":
                    DashboardsForm frm3 = new DashboardsForm();
                    frm3.Show();
                    break;
                case "btnTestUpload":
                    ConnectCNCForm frm4 = new ConnectCNCForm();
                    frm4.Show();
                    break;
                default:
                    break;
            }

        }

        private async void MonitoringAsync(object sender, EventArgs e)
        {
            if (_view.EpiSession.User != null)
            {
                _view.HostName = _view.EpiSession.IPAddress == "." ? "127.0.0.1" : _view.EpiSession.IPAddress;
                _view.DatabaseName = _view.EpiSession.DatabaseName;
                _view.LogOnName = _view.EpiSession.User.Description;

                var trf = await TransferNcFileService();
            }
            else
            {
                Application.Exit();
            }
        }

        public async Task<Boolean> TransferNcFileService()
        {
            return await Task.Factory.StartNew(() =>
            {
                bool transferCompleted = false;
                var taskUploadNc = _repoJob.GetReadyToTransferNC();
                if (taskUploadNc != null)
                {
                    bool uploadFlag = false;
                    string resultMessage = string.Empty;
                    string strBasePath = Application.StartupPath + "\\NCFiles\\"
                                            + taskUploadNc.JobNumber
                                            + "\\" + taskUploadNc.TaskNumber;

                    string strFilePath = strBasePath + "\\" + taskUploadNc.NcFile;

                    string NewFile = ReplaceNCFile(strFilePath, strBasePath);

                    int retValueInt = 0;
                    if (!string.IsNullOrEmpty(NewFile))
                    {
                        var machine = _repoMachine.GetByCode(taskUploadNc.MachineNoReady);
                        if(machine != null)
                        {
                            ProgramTransferSrv srv = new ProgramTransferSrv(machine.IpAddress);
                            string fileName = Path.GetFileName(NewFile);
                            resultMessage = srv.UploadCNCProgram(0, NewFile, out retValueInt);

                            if (retValueInt == 0)//EW_OK  = Upload file Successfully.
                            {
                                uploadFlag = true;
                            }
                            else if (retValueInt == 5)
                            {
                                try
                                {
                                    resultMessage = srv.DeleteProgram("0", fileName);
                                    resultMessage = srv.UploadCNCProgram(0, NewFile, out retValueInt);
                                }
                                catch
                                {
                                    uploadFlag = false;
                                    retValueInt = -1;
                                    resultMessage = "Data is protected.";
                                }

                                if (retValueInt == 0)
                                    uploadFlag = true;
                                else
                                    uploadFlag = false;
                            }
                            else
                            {
                                uploadFlag = false;
                            }
                        }
                        else
                        {
                            uploadFlag = false;
                            resultMessage = "Get Machine Address is null.";
                        }
                    }
                    else
                    {
                        uploadFlag = false;
                        resultMessage = "Cannot replace NC file.";
                    }

                    taskUploadNc.TransferNCFileToMachineFlag = uploadFlag;
                    taskUploadNc.TransferMessage = resultMessage;
                    _repoJob.UpdateTask(taskUploadNc);
                }

                return transferCompleted;
            });

        }

        private string ReplaceNCFile(string strFilePath, string strBasePath)
        {
            string newFile = string.Empty;
            String line;
            int linenum = 1;
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamReader sr = new StreamReader(strFilePath);
                StreamWriter sw = new StreamWriter(strBasePath + "/O101.NC");

                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                    //Console.WriteLine(line);
                    if (linenum == 2)
                    {
                        line = "O101";
                    }

                    //Read the next line
                    sw.WriteLine(line);
                    line = sr.ReadLine();
                    linenum++;
                }

                //Close the file
                sr.Close();
                sw.Close();
                newFile = strBasePath + "/O101.NC";
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

            return newFile;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            if (!_view.EpiSession.isLoggedIn)
            {
                using (Login frm = new Login())
                {
                    frm.ShowDialog();
                    if (_view.EpiSession.isLoggedIn)
                    {
                        _view.SetTimer(true);
                    }
                    else
                    {
                        _view.SetTimer(false);
                    }
                    //Monitoring(null, null);
                }
            }
        }
    }
}