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

        public ServicioService(IContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public void AddServicio(Servicio servicio)
        {
            _contextDB.Servicios.Add(servicio);
            _contextDB.SaveChanges();
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
            MyResponse objMyResponse = new MyResponse();
            try
            {
                Servicio objServicio = new Servicio();
                objServicio.Nombre = model.Nombre;
                objServicio.ValorHora = model.ValorHora;
                _contextDB.Servicios.Add(objServicio);
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
