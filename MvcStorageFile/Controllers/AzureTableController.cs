using Microsoft.AspNetCore.Mvc;
using MvcStorageFile.Models;
using MvcStorageFile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStorageFile.Controllers
{
    public class AzureTableController : Controller
    {
        private ServiceStorageTables service;

        public AzureTableController(ServiceStorageTables service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            List<String> empresa = await this.service.GetEmpresasAsync();

            ViewData["empresa"] = empresa;

            return View(await this.service.GetCLienteAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string empresaname)
        {
    
            ViewData["empresa"] = await this.service.GetEmpresasAsync(); ;

            return View(await this.service.GetClienteEmpresaAsync(empresaname));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            await this.service.CreateClienteAsync(cliente.IdCliente, cliente.Nombre,
                cliente.Edad, cliente.Empresa);

            return RedirectToAction("Index");
        }
    }
}
