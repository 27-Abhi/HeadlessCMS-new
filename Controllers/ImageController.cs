using HeadlessCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HeadlessCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpPost("single-file")]
       // [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<string>> Upload(IFormFile file)
        {


            using (var memorystream = new MemoryStream())
            {
                await file.CopyToAsync(memorystream);
                var bytes = memorystream.ToArray();
                var base64string = Convert.ToBase64String(bytes);
                // return ok(new { base64string = base64string });
                return Ok(base64string);
            }


            //using (var memoryStream = new MemoryStream())
            //{
            //    await file.CopyToAsync(memoryStream);
            //    var image = new Image { data = Convert.ToBase64String(memoryStream.ToArray()) };
            //    return Ok(image);
            //}
        }



    }
}

