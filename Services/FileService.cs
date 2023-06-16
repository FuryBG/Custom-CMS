namespace WebApplication1.Services
{
    public class FileService
    {
        IWebHostEnvironment _env;
        public FileService(IWebHostEnvironment env)
        {
            this._env = env;
        }

        public async Task SaveFile(IFormFile file)
        {
            string route = Path.Combine(_env.WebRootPath + "/images");
            if(!Directory.Exists(route))
            {
                Directory.CreateDirectory(route);
            }
            string fileRoute = PathBuild(file.FileName);

            using (FileStream fs = File.Create(fileRoute))
            {
                await file.OpenReadStream().CopyToAsync(fs);
            }
        }

        public string PathBuild(string fileName)
        {
            string route = Path.Combine(_env.WebRootPath + "/images");
            return Path.Combine(route, fileName);
        }
    }
}
