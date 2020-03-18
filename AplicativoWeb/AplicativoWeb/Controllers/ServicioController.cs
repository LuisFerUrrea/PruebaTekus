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
    public class ServicioController : Controller
    {
        private readonly IServicioService _servicioService;
        public ServicioController(IServicioService servicioService)
        {
            _servicioService = servicioService;
        }

        [HttpGet("[action]")]
        public IEnumerable<ServicioViewModel> ListServicios()
        {
            return _servicioService.ListServicios();
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody]ServicioViewModel model)
        {
            return _servicioService.Add(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}