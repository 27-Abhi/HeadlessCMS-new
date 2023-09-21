using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Service
{
    public class ComponentsService : IComponentsService
    {
        private readonly IComponentsRepository _iComponentsRepository;//dep injection
        public ComponentsService(IComponentsRepository iComponentsRepository)
        {
            _iComponentsRepository = iComponentsRepository;
        }

        public async Task<IActionResult> CreateComponents(Components components)
        {
            return await _iComponentsRepository.CreateComponents(components);
        }

        

        public async Task<IEnumerable<Components>> ListComponents()
        {
            return await _iComponentsRepository.ListComponents();
        }

        public async Task<IActionResult> UpdateComponents(Components components, int id)
        {
            return await _iComponentsRepository.UpdateComponents(components,id);
        }

        public async Task<bool> DeleteComponents(int id)
        {
            return await _iComponentsRepository.DeleteComponents(id);
        }
        public async Task<Components> GetComponentsById(int id)
        {
            return await _iComponentsRepository.GetComponentsById(id);
        }

        public async Task<List<Content>> GetContentByComponentId(int id)
        {
            return await _iComponentsRepository.GetContentByComponentId(id);
        }
    }
}
