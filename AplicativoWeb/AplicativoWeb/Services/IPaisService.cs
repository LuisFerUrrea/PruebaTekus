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
    public interface IPaisService
    {
        MyResponse AddPais(Pais pais);
        MyResponse DeletePais([FromBody]PaisViewModel model);
        IEnumerable<PaisViewModel> ListPais();
        MyResponse Add([FromBody]PaisViewModel model);
    }
}
