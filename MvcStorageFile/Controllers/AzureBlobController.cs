
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcStorageFile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStorageFile.Controllers
{
    public class AzureBlobController : Controller
    {
        private ServiceStorageBlobs services;


        public AzureBlobController(ServiceStorageBlobs service)
        {
            this.services = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.services.GetContainerAsync());
        }


        public IActionResult CreateContainer()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContainer(string containername)
        {
            await this.services.CreateContainerAsync(containername);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteContainer(string containername)
        {
            await this.services.DeleteContainerAsync(containername);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ListBlobs(string containername)
        {
            ViewData["containername"] = containername;
            return View(await this.services.GetBlobsAsync(containername));
        }

        public async Task<IActionResult> DeleteBlobs(String container, String blobname)
        {
            await this.services.DeleteBlobAsync(container, blobname);

            return RedirectToAction("ListBlobs", new { containername = container });
        }

        public IActionResult UploadBlobs(String containername)
        {
            ViewData["containername"] = containername;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadBlobs(String containername, IFormFile blobfile)
        {
            String blobname = blobfile.FileName;
            using (var stream = blobfile.OpenReadStream())
            {
                await this.services.UploadBlobAsync(containername, blobname, stream);
            }
            
            return RedirectToAction("ListBlobs", new { containername = containername });
        }

    }
}
