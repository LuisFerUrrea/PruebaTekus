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
    public interface IClienteService
    {
        MyResponse AddCliente(Cliente cliente);
        MyResponse DeleteCliente([FromBody]ClienteViewModel model);
        IEnumerable<ClienteViewModel> ListCliente();
        MyResponse Add([FromBody]ClienteViewModel model);

        Cliente GetCliente(int id);
    }
}
