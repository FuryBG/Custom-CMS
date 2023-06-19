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
        public IActionResult Index()
        {
            PageModel pageModel = _CmsService.GetPageData();
            return View(pageModel);
        }
        public IActionResult Categories()
        {
            PageModel pageModel = _CmsService.GetPageData();
            return View(pageModel);
        }
        public IActionResult Articles()
        {
            PageModel pageModel = _CmsService.GetPageData();
            return View(pageModel);
        }
        public IActionResult Images()
        {
            PageModel pageModel = _CmsService.GetPageData();
            return View(pageModel);
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
