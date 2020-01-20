using Eureka.Core.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Commons
{
    public interface ICurrencyDao
    {
        // gets a specific Member
        CurrencyModel GetByFormCurrency(string currCode);

        CurrencyModel GetByToCurrency(string currCode);

        // gets a sorted list of all Members
        List<CurrencyModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(CurrencyModel model);

        // updates
        //void Update(CurrencyModel model);
    }
}
