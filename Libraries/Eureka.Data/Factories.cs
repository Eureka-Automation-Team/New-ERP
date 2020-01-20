using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.Data
{
    // Factory of factories. This class is a factory class that creates
    // data-base specific factories which in turn create data acces objects.
    // ** GoF Design Patterns: Factory.

    public class Factories
    {
        // gets a provider specific (i.e. database specific) factory 

        // ** GoF Design Pattern: Factory

        public static IFactory GetFactory(string dataProvider)
        {
            // return the requested DaoFactory

            switch (dataProvider.ToLower())
            {
                case "ado.net": return new AdoNet.Factory();
                //case "mysql": return new MySQL.Factory();
                //case "linq2sql": return new Linq2Sql.DaoFactory();
                //case "entityframework": return new EntityFramework.DaoFactory();

                default: return new AdoNet.Factory();
            }
        }
    }
}
