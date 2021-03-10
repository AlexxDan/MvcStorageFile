using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcStorageFile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStorageFile.Controllers
{
    public class AzureFileController : Controller
    {
        private ServiceStorageFile serviceFiles;


        public AzureFileController(ServiceStorageFile servicefiles)
        {
            this.serviceFiles = servicefiles;
        }

        public async Task<IActionResult> Index()
        {
            //List<String> files = await this.serviceFiles.GetFilesAsync();
            List<String> files =await this.serviceFiles.GetFilesAsync();
            return View(files);
        }

        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            String filename = file.FileName;

            using(var stream = file.OpenReadStream())
            {
                await this.serviceFiles.UploadFileAsync(filename, stream);

             //   await this.serviceFiles.UploadFileAsync(filename, stream);
            }

            ViewData["message"] = "Archivo subido correctamente";

            return View();
        }

        public async Task<IActionResult> DeleteFile(String filename)
        {
            // await this.serviceFiles.DeleteFileAsync(filename);

            await this.serviceFiles.DeleteFileAsync(filename);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ReadFile(String filename)
        {
            String valor = await this.serviceFiles.GetFileContentAsync(filename);

            ViewData["text"] = valor;
            return View();
        }

        
    }
}
