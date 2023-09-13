using HeadlessCMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeadlessCMS.Service
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _iContentRepository;//dep injection
        public ContentService(IContentRepository iContentRepository)
        {
            _iContentRepository = iContentRepository;
        }
        public async Task<IActionResult> CreateContents(Content content)
        {
            return await _iContentRepository.CreateContents(content);
        }

        public async Task<bool> DeleteContent(int id)
        {
            return await _iContentRepository.DeleteContent(id);
        }

        public async Task<IEnumerable<Content>> ListContent()
        {
            return await _iContentRepository.ListContent();
        }

        public async Task<IActionResult> UpdateContent(Content content, int id)
        {
            return await _iContentRepository.UpdateContent(content,id);
        }

        public async Task<Content> GetContentById(int id)
        {
            return await _iContentRepository.GetContentById(id);
        }
    }
}
