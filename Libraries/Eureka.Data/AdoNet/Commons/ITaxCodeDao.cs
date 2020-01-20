using Eureka.Core.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Commons
{
    public interface ITaxCodeDao
    {
        //
        // gets a specific Member
        TaxCodeModel GetByCode(string code);

        // gets a sorted list of all Members
        List<TaxCodeModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(TaxCodeModel model);

        // updates
        void Update(TaxCodeModel model);

        void Delete(TaxCodeModel model);
    }
}
