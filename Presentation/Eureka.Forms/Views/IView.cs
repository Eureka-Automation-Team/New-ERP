using Eureka.Core.Domain.Security;

namespace Eureka.Froms.Views
{
    public interface IView
    {
        Session EpiSession { get; }
    }
}