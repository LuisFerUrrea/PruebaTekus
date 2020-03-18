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
    public class PaisController : Controller
    {
        private readonly IPaisService _paisService;
        public PaisController(IPaisService paisService)
        {
            _paisService = paisService;
        }

        [HttpGet("[action]")]
        public IEnumerable<PaisViewModel> ListPais()
        {
            return _paisService.ListPais();
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody]PaisViewModel model)
        {
            return _paisService.Add(model);
        }

        [HttpPost("[action]")]
        public MyResponse Delete([FromBody]PaisViewModel model)
        {
            return _paisService.DeletePais(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}