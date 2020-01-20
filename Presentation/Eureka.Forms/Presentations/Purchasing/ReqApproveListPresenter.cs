using Eureka.Forms.Views.Controls;
using Eureka.Services.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Forms.Presentations.Purchasing
{
    public class ReqApproveListPresenter
    {
        private readonly IRequisitionApproveListView _view;
        //private readonly IRequisitionSrv _repository;

        public ReqApproveListPresenter(IRequisitionApproveListView view)
        {
            _view = view;
            //_repository = new RequisitionSrv();
        }
    }
}
