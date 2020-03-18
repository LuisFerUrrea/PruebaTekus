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
    public class ClienteXServicioController : Controller
    {

        private readonly IClienteXServicioService _clienteXServicioService;
        public ClienteXServicioController(IClienteXServicioService clienteXServicioService)
        {
            _clienteXServicioService = clienteXServicioService;
        }

        [HttpGet("[action]")]
        public IEnumerable<ClienteXServicioViewModel> ListCliente()
        {
            return _clienteXServicioService.ListClienteXServicio();
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody]ClienteXServicioViewModel model)
        {
            return _clienteXServicioService.Add(model);
        }
    }
}