using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class CmsController : Controller
    {
        FileService _FileService;
        CmsService _CmsService;

        public CmsController(FileService fileService, CmsService cmsService)
        {
            _FileService = fileService;
            _CmsService = cmsService;
        }
        public IActionResult Index(string fileName)
        {
            return View();
        }
        public IActionResult Categories()
        {
            List<Category> categories = _CmsService.GetCategories();
            return View(categories);
        }
        public IActionResult Articles()
        {
            return View();
        }
        public IActionResult Images()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult UploadImage([FromForm] IFormFile File)
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
