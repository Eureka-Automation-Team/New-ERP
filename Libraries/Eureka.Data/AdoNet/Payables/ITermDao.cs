using Eureka.Core.Domain.Payables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Payables
{
    public interface ITermDao
    {
        // gets a specific Member
        TermModel GetByID(int id);

        // gets a specific Member by email
        TermModel GetByCode(string code);

        // gets a sorted list of all Members
        List<TermModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(TermModel model);

        // updates a Member
        void Update(TermModel model);

        // deletes a Member
        void Delete(TermModel model);
    }
}
