using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Service
{
    public interface IContentService
    {
        Task<IEnumerable<Content>> CreateContent();
        Task<IActionResult> ListContent();
    }
}
