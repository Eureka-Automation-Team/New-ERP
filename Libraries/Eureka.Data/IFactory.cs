using Eureka.Data.AdoNet.Commons;
using Eureka.Data.AdoNet.Inventory;
using Eureka.Data.AdoNet.Manufacturing;
using Eureka.Data.AdoNet.Payables;
using Eureka.Data.AdoNet.Projects;
using Eureka.Data.AdoNet.Purchasing;

namespace Eureka.Data
{
    // abstract factory interface. Creates data access objects.
    // ** GoF Design Pattern: Factory.

    public interface IFactory
    {
        IUserDao UserDao { get; }
        IRoleDao RoleDao { get; }
        IMenuDao MenuDao { get; }
        IDocSeqDao DocSeqDao { get; }
        IProjectDao ProjectDao { get; }
        IProjectCostDao ProjectCostDao { get; }
        ICostGroupDao CostGroupDao { get; }
        IVendorDao VendorDao { get; }
        IVendorSiteDao VendorSiteDao { get; }
        IPOHeaderDao POHeaderDao { get; }
        IPOLineDao POLineDao { get; }
        ITermDao TermDao { get; }
        ICurrencyDao CurrencyDao { get; }
        ITaxCodeDao TaxCodeDao { get; }
        IItemMasterDao ItemMasterDao { get; }
        IItemTransactionDao ItemTransactionDao { get; }
        IItemOnhandDao ItemOnhandDao { get; }
        IPOReceiptHaeaderDao POReceiptHaeaderDao { get; }
        IPOReceiptLineDao POReceiptLineDao { get; }
        IPOLineLocationDao POLineLocationDao { get; }
        IRequisitionHeaderDao RequisitionHeaderDao { get; }
        IRequisitionLineDao RequisitionLineDao { get; }
        IBomNumberDao BomNumberDao { get; }
        ICostsBomsRelatedDao CostsBomsRelatedDao { get; }
        IPOLoggingDao POLoggingDao { get; }
        IJobEntityDao JobEntityDao { get; }
        IJobTaskDao JobTaskDao { get; }
        IShelfLocationDao ShelfLocationDao { get; }
        IMachineDao MachineDao { get; }
    }
}