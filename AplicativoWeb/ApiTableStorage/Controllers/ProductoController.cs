using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTableStorage.Models;
using ApiTableStorage.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace ApiTableStorage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {        
        private readonly IProductoService _productoService;
        public ProductoController(IProductoService productoService)
        {
            this._productoService = productoService;
        }
        
        [HttpGet("[action]")]
        public async Task<List<Producto>> Read()
        {
            try
            {
               List<Producto> listProducto=await _productoService.Read();
               return listProducto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost("[action]")]
        public async Task<Producto> Create([FromBody]Producto model)
        {
            try
            {
                Producto producto = await _productoService.Create(model);
                return producto;             
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut("[action]")]
        public async Task<Producto> Update([FromBody]Producto model)
        {
            try
            {
                Producto producto = await _productoService.Update(model);
                return producto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpDelete("[action]")]
        public async Task<Producto> Delete([FromBody]Producto model)
        {
            try
            {
                Producto producto = await _productoService.Delete(model);
                return producto;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
