using Eureka.Core.Domain.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eureka.CNC.Views
{
    public interface IView
    {
        Session EpiSession { get; }
    }
}
