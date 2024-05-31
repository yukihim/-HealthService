using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MyCompanyName.AbpZeroTemplate.Authorization;
using MyCompanyName.AbpZeroTemplate.Web.Controllers;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Aspose.Words;
using Aspose.Words.Saving;

public class FileUploadController : AbpZeroTemplateControllerBase
{
    private readonly IHostEnvironment _env;
    public FileUploadController(IHostEnvironment env)
    {
        _env = env;
    }

    [HttpPost]
    public async Task<string> UploadFile()
    {
        var image = Request.Form.Files.First();
        var uniqueFileName = GetUniqueFileName(image.FileName);
        var dir = Path.Combine(_env.ContentRootPath, "Books");
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        var filePath = Path.Combine(dir, uniqueFileName);
        await image.CopyToAsync(new FileStream(filePath, FileMode.Create));
        return uniqueFileName;
    }

    private string GetUniqueFileName(string fileName)
    {
        fileName = Path.GetFileName(fileName);
        return Path.GetFileNameWithoutExtension(fileName)
               + "_"
               + Guid.NewGuid().ToString().Substring(0, 4)
               + Path.GetExtension(fileName);
    }

    [HttpGet]
    public async Task<IActionResult> DownloadFile(String fileName)
    {
        //var filePath = Path.Combine(_env.ContentRootPath, "Books", fileName);
        var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        string directory = builder.Build().GetSection("Path").GetSection("Upload").Value;
        var filePath = Path.Combine(_env.ContentRootPath, directory, fileName);
        var contentType = GetContentType(fileName);
        var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
        return File(bytes, contentType, Path.GetFileName(filePath));
    }

    [HttpGet]
    public async Task<IActionResult> PreviewFile(String fileName)
    {
        //var filePath = Path.Combine(_env.ContentRootPath, "Books", fileName);
        var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        string directory = builder.Build().GetSection("Path").GetSection("Upload").Value;
        var filePath = Path.Combine(_env.ContentRootPath, directory, fileName);
        var contentType = GetContentType(fileName);
        var fileExtension = Path.GetExtension(filePath);
        if (fileExtension == ".docx" || fileExtension == ".doc")
        {
            var doc = new Document(filePath);
            var pdfStream = new MemoryStream();
            doc.Save(pdfStream, SaveFormat.Pdf);
            pdfStream.Position = 0;
            return File(pdfStream, "application/pdf", Path.GetFileNameWithoutExtension(filePath) + ".pdf");
        }
        else
        {
            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }
    }
    private string GetContentType(string fileName)
    {
        var provider = new FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(fileName, out var contentType))
        {
            contentType = "application/octet-stream";
        }
        return contentType;
    }

}

