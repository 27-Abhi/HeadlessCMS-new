using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Service
{
    public interface IContentRepository
    {

        Task<IActionResult> UpdateContent(Content content, int id);
        Task<bool> DeleteContent(int id);
        Task<IEnumerable<Content>> ListContent();
        Task<IActionResult> CreateContents(Content content);
        Task<Content> GetContentById(int id);


    }
}
