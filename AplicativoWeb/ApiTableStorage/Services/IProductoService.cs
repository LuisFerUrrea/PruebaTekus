using ApiTableStorage.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTableStorage.Services
{
    public interface IProductoService
    {
       Task<List<Producto>> Read();
       Task<Producto> Create([FromBody]Producto model);

       Task<Producto> Update([FromBody]Producto model);

       Task<Producto> Delete([FromBody]Producto model);

    }
}
