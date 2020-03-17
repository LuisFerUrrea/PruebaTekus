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
        void AddCliente(Cliente cliente);
        IEnumerable<ClienteViewModel> ListCliente();
        MyResponse Add([FromBody]ClienteViewModel model);
    }
}
