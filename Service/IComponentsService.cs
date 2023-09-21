using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Service
{
    public interface IComponentsService
    {
        Task<IEnumerable<Components>> ListComponents();
        
        Task<IActionResult> CreateComponents(Components components);
        Task<IActionResult> UpdateComponents(Components components, int id);
        Task<bool> DeleteComponents(int id);
        Task<Components> GetComponentsById(int id);
        Task<List<Content>> GetContentByComponentId(int id);
    }
}
