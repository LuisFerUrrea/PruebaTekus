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
    public class ServicioService: IServicioService
    {
        private readonly IContextDB _contextDB;
        private MyResponse _myResponse;

        public ServicioService(IContextDB contextDB)
        {
            _contextDB = contextDB;            
        }

        public MyResponse AddServicio(Servicio servicio)
        {
            try
            {
                _contextDB.Servicios.Add(servicio);
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

        public MyResponse DeleteServicio([FromBody]ServicioViewModel model)
        {
            try
            {
                Servicio objServicio = _contextDB.Servicios.Find(model.Id);
                _contextDB.Servicios.Remove(objServicio);
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



        public IEnumerable<ServicioViewModel> ListServicios()
        {
            List<ServicioViewModel> lst = (from d in _contextDB.Servicios
                                          select new ServicioViewModel
                                          {
                                              Id = d.Id,
                                              Nombre = d.Nombre,
                                              ValorHora = d.ValorHora
                                          }).ToList();
            return lst;
        }


        public MyResponse Add([FromBody]ServicioViewModel model)
        {          
            try
            {
                Servicio objServicio = new Servicio();
                objServicio.Nombre = model.Nombre;
                objServicio.ValorHora = model.ValorHora;
                _contextDB.Servicios.Add(objServicio);
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

    }
}
