namespace HeadlessCMS.Service
{
    public interface IComponentsService
    {
        Task<IEnumerable<Components>> ListComponents();
        
        Task<IActionResult> CreateComponents(Components components);
        Task<IActionResult> UpdateComponents(Components components, int id);
        Task<bool> DeleteComponents(int id);
    }
}
