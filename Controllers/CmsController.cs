using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CmsController : Controller
    {
        FileService _FileService;

        public CmsController(FileService fileService)
        {
            _FileService = fileService;
        }
        public IActionResult Index(string fileName)
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult UploadImage([FromForm(Name = "File")] IFormFile File)
        {
            _FileService.SaveFile(File);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetImage(string fileName)
        {
            try
            {
                var file = System.IO.File.OpenRead(_FileService.PathBuild(fileName));
                return File(file, "image/jpeg");
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}
