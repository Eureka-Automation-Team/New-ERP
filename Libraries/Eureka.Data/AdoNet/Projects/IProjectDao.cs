using Eureka.Core.Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data.AdoNet.Projects
{
    public interface IProjectDao
    {
        // gets a specific Member
        ProjectModel GetByID(int id);

        // gets a specific Member by email
        ProjectModel GetByNum(string number);

        // gets a sorted list of all Members
        List<ProjectModel> GetAll();

        // gets a sorted list of all Members
        List<ProjectModel> GetByDate(DateTime startDate, DateTime endDate);

        // inserts a new Member
        // following insert, Member object will contain the new identifier
        int Insert(ProjectModel model);

        // updates a Member
        void Update(ProjectModel model);

        // deletes a Member
        void Delete(ProjectModel model);
    }
}
