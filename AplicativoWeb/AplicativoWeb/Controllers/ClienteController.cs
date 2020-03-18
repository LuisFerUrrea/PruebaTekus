using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AplicativoWeb.Models.Response;
using AplicativoWeb.Models.ViewModels;
using AplicativoWeb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicativoWeb.Controllers
{
    [Route("api/[controller]")]    
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet("[action]")]
        public IEnumerable<ClienteViewModel> ListCliente()
        {
            return _clienteService.ListCliente();
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody]ClienteViewModel model)
        {
            return _clienteService.Add(model);
        }

        [HttpPost("[action]")]
        public MyResponse Delete([FromBody]ClienteViewModel model)
        {
            return _clienteService.DeleteCliente(model);
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}