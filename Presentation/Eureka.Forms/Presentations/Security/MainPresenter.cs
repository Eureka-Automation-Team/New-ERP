using Eureka.Core.Domain.Security;
using Eureka.Forms.Views.Controls;
using Eureka.Forms.Views.Purchasing;
using Eureka.Froms.Views;
using Eureka.Froms.Views.Inventory;
using Eureka.Froms.Views.Projects;
using Eureka.Froms.Views.Purchasing;
using Eureka.Services;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Eureka.Froms.Presentations.Security
{
    public class MainPresenter
    {
        private readonly ISecuritieSrv _repository;
        private readonly IMainView _view;

        public MainPresenter(IMainView view, ISecuritieSrv repository)
        {
            _view = view;
            _repository = repository;

            _view.Form_Load += Form_Load;
            _view.Monitoring += Monitoring;
            _view.Menu_Click += Menu_Click;
            _view.ParentMenu_Click += ParentMenu_Click;
            _view.Item_Click += Item_Click;
        }

        private void Item_Click(object sender, MenuEventArgs args)
        {
            switch (args.formID)
            {
                case "FRM001":
                    BudgetControlForm frm1 = new BudgetControlForm(true);
                    frm1.Show();
                    break;
                case "FRM008":
                    BudgetControlForm frm9 = new BudgetControlForm(false);
                    frm9.Show();
                    break;
                case "FRM004":
                    POEntryForm frm2 = new POEntryForm(null);
                    frm2.Show();
                    break;
                case "FRM005":
                    POReceiptForm frm3 = new POReceiptForm();
                    frm3.Show();
                    break;
                case "FRM006":
                    MaterialIssueForm frm4 = new MaterialIssueForm();
                    frm4.Show();
                    break;
                case "butPOBalance":
                    POBalanceInquiry frm5 = new POBalanceInquiry();
                    frm5.Show();
                    break;
                case "FRM002":
                    RequisitionEntryForm frm6 = new RequisitionEntryForm();
                    frm6.Show();
                    break;
                case "FRM003":
                    RequisitionFinalForm frm7 = new RequisitionFinalForm();
                    frm7.Show();
                    break;
                case "FRM007":
                    MaterialReturnForm frm8 = new MaterialReturnForm();
                    frm8.Show();
                    break;
                case "FRM009":
                    RequisitionConfirmForm frm10 = new RequisitionConfirmForm();
                    frm10.Show();
                    break;
                default:
                    break;
            }
        }

        private void ParentMenu_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            List<MenuModel> itemsMenus = new List<MenuModel>();

            if (Convert.ToInt32(but.Tag) > 0)
            {
                itemsMenus = _view.EpiSession.Menus.Where(x => x.ParentId == Convert.ToInt32(but.Tag) && x.EnableFlag == true).ToList();
            }
            
            _view.menuList.ItemMenus = itemsMenus;
            _view.menuList.RefreshButtons();
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Button but = sender as Button;
            switch (but.Name)
            {
                case "butBudgetCtrl":
                    BudgetControlForm frm1 = new BudgetControlForm(true);
                    frm1.Show();
                    break;
                case "butPurchaseOrder1":
                    POEntryForm frm2 = new POEntryForm(null);
                    frm2.Show();
                    break;
                case "butPOReceiving":
                    POReceiptForm frm3 = new POReceiptForm();
                    frm3.Show();
                    break;
                case "butMaterialIssue":
                    MaterialIssueForm frm4 = new MaterialIssueForm();
                    frm4.Show();
                    break;
                case "butPOBalance":
                    POBalanceInquiry frm5 = new POBalanceInquiry();
                    frm5.Show();
                    break;
                case "butRequisition":
                    RequisitionEntryForm frm6 = new RequisitionEntryForm();
                    frm6.Show();
                    break;
                case "butRequisitionFinaly":
                    RequisitionFinalForm frm7 = new RequisitionFinalForm();
                    frm7.Show();
                    break;
                case "butMaterialReturn":
                    MaterialReturnForm frm8 = new MaterialReturnForm();
                    frm8.Show();
                    break;
                default:
                    break;
            }

        }

        private void Monitoring(object sender, EventArgs e)
        {
            if(_view.EpiSession.User != null)
            {
                _view.ConnectionState = _view.EpiSession.StatusConnected;
                _view.HostName = _view.EpiSession.IPAddress == "." ? "127.0.0.1" : _view.EpiSession.IPAddress;
                _view.DatabaseName = _view.EpiSession.DatabaseName;
                _view.LogOnName = "Log On by : " + _view.EpiSession.User.Description;
            }
            else
            {
                Application.Exit();
            }
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
                        var menus = _view.EpiSession.Menus;
                    }
                    else
                    {
                        _view.SetTimer(false);
                    }
                    Monitoring(null, null);
                }
            }
        }
    }
}