using AplicativoWeb.Context;
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
    public class ClienteService: IClienteService
    {
        private readonly IContextDB _contextDB;

        public ClienteService(IContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public void AddCliente(Cliente cliente)
        {
            _contextDB.Clientes.Add(cliente);
            _contextDB.SaveChanges();
        }

        public IEnumerable<ClienteViewModel> ListCliente()
        {
            List<ClienteViewModel> lst = (from d in _contextDB.Clientes
                                          select new ClienteViewModel
                                          {
                                              Id = d.Id,
                                              Nombre = d.Nombre,
                                              Correo = d.Correo
                                          }).ToList();
            return lst;
        }


        public MyResponse Add([FromBody]ClienteViewModel model)
        {
            MyResponse objMyResponse = new MyResponse();
            try
            {
                Cliente objCliente = new Cliente();
                objCliente.Nombre = model.Nombre;
                objCliente.Correo = model.Correo;
                _contextDB.Clientes.Add(objCliente);
                _contextDB.SaveChanges();
                objMyResponse.Success = 1;
            }
            catch (Exception ex)
            {

                objMyResponse.Success = 0;
                objMyResponse.Message = ex.Message;
            }
            return objMyResponse;
        }

    }
}
