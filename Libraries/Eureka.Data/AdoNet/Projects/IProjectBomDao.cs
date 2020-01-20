using Eureka.Core.Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Projects
{
    public interface IProjectBomDao
    {
        // gets a specific Member
        ProjectBomModel GetByID(int id);

        // gets a specific Member by email
        ProjectBomModel GetByNum(string number);

        // gets a sorted list of all Members
        List<ProjectBomModel> GetAll();

        // gets a sorted list of all Members
        List<ProjectBomModel> GetByDate(DateTime startDate, DateTime endDate);

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(ProjectBomModel model);

        // updates a Member
        void Update(ProjectBomModel model);

        // deletes a Member
        void Delete(ProjectBomModel model);
    }
}
