using BloodDoner.Mvc.Services.Interfaces;

namespace BloodDoner.Mvc.Services.Implementation
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;
        public FileService(IWebHostEnvironment env)
        {
            _env = env;
        }
        public async Task<string> SaveFileAsync(IFormFile? file)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var folderPath = Path.Combine(_env.WebRootPath, "profiles");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var fullPath = Path.Combine(folderPath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Save the relative path to store in DB, not full path
                return Path.Combine("profiles", fileName);
            }
            return string.Empty;
        }
    }
}
