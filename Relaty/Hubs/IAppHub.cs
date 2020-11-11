using System.Threading.Tasks;

namespace Relaty.Hubs
{
    public interface IAppHub
    {
        Task Refresh();
    }
}