using Eureka.CNC.Presentations;
using Eureka.DNC;
using FocasInterface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eureka.CNC.Views
{
    public partial class ConnectCNCForm : Form, IConnectCNCView
    {
        [AccessedThroughProperty("_focasInt1")]
        private MachineInterface __focasInt1;
        private List<Exception> _ExList;
        private List<FocasDataItem> _DataListInt1;
        private List<FocasDataItem> _CustomDataListInt1;
        private List<FocasDataItem> _DataListInt2;

        private readonly ConnectCncPresenter _presenter;
        private bool _connected;

        ushort cncHandle = 0;
        private short preState = 0;
        private Focas1.ODBST cncStatus = new Focas1.ODBST();
        private Focas1.ODBAHIS alarmHis = new Focas1.ODBAHIS();

        public ConnectCNCForm()
        {
            InitializeComponent();
            _presenter = new ConnectCncPresenter(this);
        }

        public string IpAddress
        {
            get { return txtIPAddress.Text; }
            set { txtIPAddress.Text = value; }
        }
        public string FilePath
        {
            get { return txtFile.Text; }
            set { txtFile.Text = value; }
        }

        public string Port
        {
            get { return txtPort.Text; }
            set { txtPort.Text = value; }
        }

        public bool Connected
        {
            get { return _connected; }
            set
            {
                _connected = value;

                if (_connected)
                {
                    txtIPAddress.ReadOnly = true;
                    txtPort.ReadOnly = true;
                    button1.Enabled = false;
                }
                else
                {
                    txtIPAddress.ReadOnly = false;
                    txtPort.ReadOnly = false;
                    button1.Enabled = true;
                }
            }
        }

        public virtual MachineInterface _focasInt1
        {
            get
            {
                return this.__focasInt1;
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler<ErrorEventArgs> eventHandler = new EventHandler<ErrorEventArgs>(this._focasInt1_ErrorRaised);
                if (this.__focasInt1 != null)
                    this.__focasInt1.ErrorRaised -= eventHandler;
                this.__focasInt1 = value;
                if (this.__focasInt1 == null)
                    return;
                this.__focasInt1.ErrorRaised += eventHandler;
            }
        }

        public BindingSource bindingProgram
        {
            get { return programListDetBindingSource; }
            set { programListDetBindingSource = value; }
        }

        private void _focasInt1_ErrorRaised(object sender, ErrorEventArgs e)
        {
            //this.cmbErrorList.SelectedIndex = this.cmbErrorList.Items.Add((object)e.Message);
            //this._ExList.Insert(this.cmbErrorList.SelectedIndex, e.Exception);
        }

        //MachineInterface IConnectCNCView._focasInt1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler Form_Load;
        public event EventHandler Connect_Click;
        public event EventHandler BrowseFile_Click;
        public event EventHandler Upload_Click;
        public event EventHandler GetProgramList_Click;
        public event EventHandler DeleteProgram_Click;

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (Connect_Click != null)
                Connect_Click(sender, e);
            //string IpAddress = this.txtIPAddress.Text.Trim();
            //string str = this.txtIPAddress.Text.Trim();
            //try
            //{
            //    //this.cmbErrorList.Items.Clear();
            //    //this.cmbErrorList.ResetText();
            //    this._focasInt1 = new MachineInterface(IpAddress, (ushort)8193, (ushort)5);
            //    this._focasInt1.Connect();
            //    //this._focasInt1.SetCustomDataItems(ref this._CustomDataListInt1);
            //    //if (!this._focasInt1.GetSchemaList(ref this._DataListInt1))
            //    //    return;
            //    //this.DisplaySchema(this._focasInt1.MachineID, this._DataListInt1);
            //}
            //catch (Exception ex)
            //{
            //    //ProjectData.SetProjectError(ex);
            //    int num = (int)MessageBox.Show("Error: " + ex.Message);
            //    //ProjectData.ClearProjectError();
            //}
        }

        private void ConnectCNCForm_Load(object sender, EventArgs e)
        {
            if (Form_Load != null)
                Form_Load(sender, e);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (BrowseFile_Click != null)
                BrowseFile_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Upload_Click != null)
                Upload_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (GetProgramList_Click != null)
                GetProgramList_Click(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DeleteProgram_Click != null)
                DeleteProgram_Click(dataGridView1, e);
        }
    }
}
