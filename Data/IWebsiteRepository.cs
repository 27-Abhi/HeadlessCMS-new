using HeadlessCMS.Models;

namespace HeadlessCMS.Service
{
    public interface IWebsiteRepository
    {

        Task<IEnumerable<Website>> ListWebsites();

    }
}
