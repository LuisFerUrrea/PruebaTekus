using AplicativoWeb.Context;
using AplicativoWeb.Models;
using AplicativoWeb.Models.Response;
using AplicativoWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicativoWeb.Services
{
    public class ClienteService: IClienteService
    {
        private readonly IContextDB _contextDB;       
        private readonly IMemoryCache _memoryCache;
        private MyResponse _myResponse;

        public ClienteService(IContextDB contextDB,IMemoryCache memoryCache)
        {
            _contextDB = contextDB;
            _memoryCache = memoryCache;
        }

        public MyResponse AddCliente(Cliente cliente)
        {
            try
            {
                _contextDB.Clientes.Add(cliente);
                _contextDB.SaveChanges();
                _myResponse.Success = 1;
            }
            catch (Exception ex)
            {

                _myResponse.Success = 0;
                _myResponse.Message = ex.Message;
            }
            return _myResponse;
        }

        public MyResponse DeleteCliente([FromBody]ClienteViewModel model)
        {
            try
            {
                Cliente objCliente = _contextDB.Clientes.Find(model.Id);
                _contextDB.Clientes.Remove(objCliente);
                _contextDB.SaveChanges();
                _myResponse.Success = 1;
            }
            catch (Exception ex)
            {
                _myResponse.Success = 0;
                _myResponse.Message = ex.Message;
            }
            return _myResponse;
        }

        public IEnumerable<ClienteViewModel> ListCliente()
        {
            try
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
            catch (Exception)
            {

                throw;
            }           
        }

        public MyResponse Add([FromBody]ClienteViewModel model)
        {           
            try
            {
                _myResponse.Success = 0;               
                if (model.tipoAlmacenamiento == "bd")
                {
                    Cliente objCliente = new Cliente();
                    objCliente.Nombre = model.Nombre;
                    objCliente.Correo = model.Correo;
                    _contextDB.Clientes.Add(objCliente);
                    _contextDB.SaveChanges();
                    _myResponse.Success = 1;
                }
                else if(model.tipoAlmacenamiento == "cache")
                {
                    _memoryCache.Set("AddCliente", model);
                    _myResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {               
                _myResponse.Message = ex.Message;
            }
            return _myResponse;
        }

    }
}
