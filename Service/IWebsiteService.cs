using HeadlessCMS.Models;

namespace HeadlessCMS.Service
{
    public interface IWebsiteService
    {
        Task<IEnumerable<Website>> ListWebsites();

    }
}
