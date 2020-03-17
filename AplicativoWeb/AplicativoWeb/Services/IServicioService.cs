using AplicativoWeb.Models;
using AplicativoWeb.Models.Response;
using AplicativoWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicativoWeb.Services
{
    public interface IServicioService
    {
        void AddServicio(Servicio servicio);

        IEnumerable<ServicioViewModel> ListServicios();

        MyResponse Add([FromBody]ServicioViewModel model);

    }
}
