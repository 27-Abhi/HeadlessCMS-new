using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Service
{
    public class ContentService : IContentService
    {
        public Task<IEnumerable<Content>> CreateContent()
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> ListContent()
        {
            throw new NotImplementedException();
        }
    }
}
