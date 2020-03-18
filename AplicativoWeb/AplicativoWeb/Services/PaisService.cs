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
    public class PaisService: IPaisService
    {
        private readonly IContextDB _contextDB;
        private readonly MyResponse _myResponse;

        public PaisService(IContextDB contextDB, MyResponse myResponse)
        {
            _contextDB = contextDB;
            _myResponse = myResponse;
        }

        public MyResponse AddPais(Pais pais)
        {
            try
            {
                _contextDB.Pais.Add(pais);
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

        public MyResponse DeletePais([FromBody]PaisViewModel model)
        {
            try
            {
                Pais objPais = _contextDB.Pais.Find(model.Id);
                _contextDB.Pais.Remove(objPais);
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

        public IEnumerable<PaisViewModel> ListPais()
        {
            try
            {
                List<PaisViewModel> lst = (from d in _contextDB.Pais
                                              select new PaisViewModel
                                              {
                                                  Id = d.Id,
                                                  Nombre = d.Nombre                                                 
                                              }).ToList();
                return lst;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public MyResponse Add([FromBody]PaisViewModel model)
        {
            try
            {
                Pais objPais = new Pais();
                objPais.Nombre = model.Nombre;              
                _contextDB.Pais.Add(objPais);
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
