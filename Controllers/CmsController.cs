using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Models.Dto;
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
        [Authorize]
        public IActionResult Category(int categoryId)
        {
            PageModel pageModel = _CmsService.GetPageData();
            Category selectedCategory = _CmsService.GetCategoryById(categoryId);
            pageModel.SelectedCategory = selectedCategory;
            return View("/Views/Cms/Category/Category.cshtml", pageModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult CategoryEdit(Category editedCategory)
        {
            _CmsService.UpdateCategory(editedCategory);
            PageModel pageModel = _CmsService.GetPageData();
            pageModel.SelectedCategory = editedCategory;
            return RedirectToAction("Category", new { categoryId = editedCategory.Id });
        }
        [Authorize]
        public IActionResult CategoryAdd(int categoryId)
        {
            PageModel pageModel = _CmsService.GetPageData();
            Category category = new Category();
            category.ParentId = categoryId;
            pageModel.SelectedCategory = category;
            ViewBag.IsForAdd = true;
            return View("/Views/Cms/Category/Category.cshtml", pageModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult CategoryAdd(Category addedCategory)
        {
            addedCategory.Type = "category";
            _CmsService.CreateCategory(addedCategory);
            PageModel pageModel = _CmsService.GetPageData();
            pageModel.SelectedCategory = addedCategory;
            return RedirectToAction("Category", new { categoryId = addedCategory.Id });
        }
        [Authorize]
        public IActionResult ArticleEdit(int articleId)
        {
            PageModel pageModel = _CmsService.GetPageData();
            pageModel.SelectedArticle = (ArticleDto)_CmsService.GetArticleById(articleId);
            return View("/Views/Cms/Article/ArticleEdit.cshtml", pageModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult ArticleEdit(Article article)
        {
            PageModel pageModel = _CmsService.GetPageData();
            //TODO LOGIC SAVING ARTICLE
            return View("/Views/Cms/Article/ArticleEdit.cshtml", pageModel);
        }
        [Authorize]
        public IActionResult ArticleDelete(int articleId)
        {
            PageModel pageModel = _CmsService.GetPageData();
            _CmsService.DeleteArticleById(articleId);
            return RedirectToAction("ArticleList");
        }
        [Authorize]
        public IActionResult ArticleAdd()
        {
            PageModel pageModel = _CmsService.GetPageData();
            return View("/Views/Cms/Article/ArticleAdd.cshtml", pageModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult ArticleAdd(Article article)
        {
            PageModel pageModel = _CmsService.GetPageData();
            //TODO LOGIC SAVING ARTICLE
            return View("/Views/Cms/Article/ArticleAdd.cshtml", pageModel);
        }
        [Authorize]
        public IActionResult ArticleList(int categoryId)
        {
            PageModel pageModel = _CmsService.GetPageData();
            pageModel.SelectedCategory = _CmsService.GetCategoryById(categoryId);
            return View("/Views/Cms/Article/ArticleList.cshtml", pageModel);
        }
        [Authorize]
        public IActionResult Image(int imageId)
        {
            PageModel pageModel = _CmsService.GetPageData();
            return View("/Views/Cms/Image/Image.cshtml", pageModel);
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
