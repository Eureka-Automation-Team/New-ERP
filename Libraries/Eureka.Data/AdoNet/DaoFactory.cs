using Eureka.Data.AdoNet.Commons;
using Eureka.Data.AdoNet.Inventory;
using Eureka.Data.AdoNet.Manufacturing;
using Eureka.Data.AdoNet.Payables;
using Eureka.Data.AdoNet.Projects;
using Eureka.Data.AdoNet.Purchasing;

namespace Eureka.Data.AdoNet
{
    // Data access object factory
    // ** Factory Pattern

    public class Factory : IFactory
    {
        public IUserDao UserDao { get { return new UserDao(); } }
        public IRoleDao RoleDao { get { return new RoleDao(); } }
        public IMenuDao MenuDao { get { return new MenuDao(); } }
        public IDocSeqDao DocSeqDao { get { return new DocSeqDao(); } }
        public IProjectDao ProjectDao { get { return new ProjectDao(); } }
        public IProjectCostDao ProjectCostDao { get { return new ProjectCostDao(); } }
        public ICostGroupDao CostGroupDao { get { return new CostGroupDao(); } }
        public IVendorDao VendorDao { get { return new VendorDao(); } }
        public IVendorSiteDao VendorSiteDao { get { return new VendorSiteDao(); } }
        public IPOHeaderDao POHeaderDao { get { return new POHeaderDao(); } }
        public IPOLineDao POLineDao { get { return new POLineDao(); } }
        public ITermDao TermDao { get { return new TermDao(); } }
        public ICurrencyDao CurrencyDao { get { return new CurrencyDao(); } }
        public ITaxCodeDao TaxCodeDao { get { return new TaxCodeDao(); } }
        public IItemMasterDao ItemMasterDao { get { return new ItemMasterDao(); } }
        public IItemTransactionDao ItemTransactionDao { get { return new ItemTransactionDao(); } }
        public IItemOnhandDao ItemOnhandDao { get { return new ItemOnhandDao(); } }
        public IPOReceiptHaeaderDao POReceiptHaeaderDao { get { return new POReceiptHaeaderDao(); } }
        public IPOReceiptLineDao POReceiptLineDao { get { return new POReceiptLineDao(); } }
        public IPOLineLocationDao POLineLocationDao { get { return new POLineLocationDao(); } }
        public IRequisitionHeaderDao RequisitionHeaderDao { get { return new RequisitionHeaderDao(); } }
        public IRequisitionLineDao RequisitionLineDao { get { return new RequisitionLineDao(); } }
        public IBomNumberDao BomNumberDao { get { return new BomNumberDao(); } }
        public ICostsBomsRelatedDao CostsBomsRelatedDao { get { return new CostsBomsRelatedDao(); } }    
        public IPOLoggingDao POLoggingDao { get { return new POLoggingDao(); } }
        public IJobEntityDao JobEntityDao { get { return new JobEntityDao(); } }
        public IJobTaskDao JobTaskDao { get { return new JobTaskDao(); } }
        public IShelfLocationDao ShelfLocationDao { get { return new ShelfLocationDao(); } }
        public IMachineDao MachineDao { get { return new MachineDao(); } }
    }
}