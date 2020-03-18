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
    public class ClienteXServicioService : IClienteXServicioService
    {
        private readonly IContextDB _contextDB;
        private readonly IMemoryCache _memoryCache;
        private readonly MyResponse _myResponse;

        public ClienteXServicioService(IContextDB contextDB, IMemoryCache memoryCache, MyResponse myResponse)
        {
            _contextDB = contextDB;
            _myResponse = myResponse;
            _memoryCache = memoryCache;
        }

        public IEnumerable<ClienteXServicioViewModel> ListClienteXServicio()
        {
            try
            {

                List<ClienteXServicioViewModel> lst = (from c in _contextDB.Clientes
                                                       join cs in _contextDB.ClienteXServicios on c.Id equals cs.ClienteId
                                                       join se in _contextDB.Servicios on cs.ServicioId equals se.Id
                                                       join csp in _contextDB.ClienteSevicioXPais on cs.Id equals csp.ClienteXServicioId
                                                       join p in _contextDB.Pais on csp.PaisId equals p.Id
                                                       select new ClienteXServicioViewModel
                                                       {
                                                           Id = cs.Id,
                                                           NombreCliente = c.Nombre,
                                                           Correo = c.Correo,
                                                           ClienteId = c.Id,
                                                           ServicioId=se.Id,
                                                           NombreServicio=se.Nombre,
                                                           ValorHora=se.ValorHora,
                                                           PaisId=p.Id,
                                                           NombrePais=p.Nombre
                                                           
                                                       }).ToList();
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public MyResponse Add([FromBody]ClienteXServicioViewModel model)
        {
            try
            {
                if (model.tipoAlmacenamiento == "bd")
                {

                    ClienteXServicio objClienteXServicio = new ClienteXServicio();
                    ClienteSevicioXPais objClienteSevicioXPais = new ClienteSevicioXPais();

                    objClienteXServicio.ClienteId = model.ClienteId;
                    objClienteXServicio.ServicioId = model.ServicioId;
                    _contextDB.ClienteXServicios.Add(objClienteXServicio);
                    _contextDB.SaveChanges();

                    objClienteSevicioXPais.ClienteXServicioId = objClienteXServicio.Id;
                    objClienteSevicioXPais.PaisId = model.PaisId;
                    _contextDB.SaveChanges();
                    _myResponse.Success = 1;
                }
                else if(model.tipoAlmacenamiento == "cache")
                {
                    _memoryCache.Set("AddClienteXServicio", model);
                    _myResponse.Success = 1;
                }
            }
            catch (Exception ex)
            {

                _myResponse.Success = 0;
                _myResponse.Message = ex.Message;
            }
            return _myResponse;
        }
    }
}
