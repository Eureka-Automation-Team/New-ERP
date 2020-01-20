using Eureka.Core.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data
{
    public interface IDocSeqDao
    {
        // gets a specific Member
        SequenceDocModel GetByType(string type);

        // gets a sorted list of all Members
        List<SequenceDocModel> GetAll();

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        void Insert(SequenceDocModel doc);

        // updates
        void Update(SequenceDocModel doc);

        // deletes a Member
        void Delete(SequenceDocModel doc);
    }
}
