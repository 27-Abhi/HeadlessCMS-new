using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Service
{
    public interface IComponentsRepository
    {
        Task<IEnumerable<Components>> ListComponents();
        //  public Task<Task> CreatePages(Page page);\
        Task<IActionResult> CreateComponents(Components components);
        Task<IActionResult> UpdateComponents(Components components, int id);
        Task<bool> DeleteComponents(int id);
    }
}
