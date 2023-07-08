using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            Article article = _CmsService.GetArticleById(articleId);
            pageModel.SelectedArticle = ArticleDto.ToArticleDto(article);

            foreach (Category category in pageModel.Categories)
            {
                pageModel.SelectedArticle.AvailableCategoriesList.Add(new SelectListItem() { Selected = false, Text = category.Title, Value = category.Id.ToString() });
            }
            return View("/Views/Cms/Article/ArticleEditLayout.cshtml", pageModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult ArticleEdit(ArticleDto articleDto)
        {
            PageModel pageModel = _CmsService.GetPageData();
            Article editedArticle = pageModel.Articles.FirstOrDefault(x => x.Id == articleDto.Id);
            Article article = ArticleDto.ToArticle(articleDto, editedArticle);
            if (int.TryParse(articleDto.AddedCategory, out int addedCategoryId))
            {
                article.Categories.Add(pageModel.Categories.FirstOrDefault(c => c.Id == addedCategoryId));
            }
            if (int.TryParse(articleDto.AddedImage, out int addedImageId))
            {
                article.Images.Add(pageModel.Images.FirstOrDefault(i => i.Id == addedImageId));
            }
            _CmsService.UpdateArticle(editedArticle);
            return RedirectToAction("ArticleList");
        }
        [Authorize]
        public IActionResult ArticleDelete(int articleId)
        {
            _CmsService.DeleteArticleById(articleId);
            return RedirectToAction("ArticleList");
        }
        [Authorize]
        public IActionResult ArticleAdd()
        {
            PageModel pageModel = _CmsService.GetPageData();
            pageModel.SelectedArticle = new ArticleDto();
            foreach (Category category in pageModel.Categories)
            {
                pageModel.SelectedArticle.AvailableCategoriesList.Add(new SelectListItem() { Selected = false, Text = category.Title, Value = category.Id.ToString() });
            }

            return View("/Views/Cms/Article/ArticleAddLayout.cshtml", pageModel);
        }
        [HttpPost]
        [Authorize]
        public IActionResult ArticleAdd(ArticleDto articleDto)
        {
            PageModel pageModel = _CmsService.GetPageData();
            articleDto.Categories.Add(pageModel.Categories.FirstOrDefault(c => c.Id == int.Parse(articleDto.AddedCategory)));
            _CmsService.CreateArticle(articleDto);
            pageModel.Articles.Add(articleDto);
            return View("/Views/Cms/Article/ArticleList.cshtml", pageModel);
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
