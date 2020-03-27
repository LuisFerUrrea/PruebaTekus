using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTableStorage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;

namespace ApiTableStorage.Controllers
{
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=123459876;AccountKey=X9XmzmV0xX6AG/WYCXSA8BrrrCF0M4j3X4zFDgJZ5g9hRwPafsIjAWk2kgjLZmj6YSxJGIikJDsLmvxgEfGWTQ==";
        // GET: api/Producto
        [HttpGet("[action]")]
        public async Task<List<Producto>> Read()
        {
            try
            {
                
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                CloudTable tableProductos = tableClient.GetTableReference("Productos");
                List<Producto> listProducto = new List<Producto>();
                TableQuery<Producto> query = new TableQuery<Producto>();
                string filter = "";
                TableContinuationToken token = null;
                query = query.Where(filter);
                var prods = await tableProductos.ExecuteQuerySegmentedAsync(query, token);
                listProducto = prods.Results.ToList();
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
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable tableProductos = tableClient.GetTableReference("Productos");

            Producto prod1 = new Producto(model.PartitionKey, model.RowKey)
            {
                Id = model.Id,
                Caracteristicas = model.Caracteristicas,
                CorreoFabricante = model.CorreoFabricante,
                EstadoRevision = model.EstadoRevision,
                HoraRevision = DateTime.Now,
                Nombre = model.Nombre,
                Precio = model.Precio,
                UnidadesDisponibles = model.UnidadesDisponibles,
                UnidadesVendidas = model.UnidadesVendidas,
                Categorias = model.Categorias,
                Creador = model.Categorias,
                Descripcion = model.Descripcion,
                Estudio = model.Estudio,
                FechaLanzamiento = DateTime.Now,
                IdVideojuego = model.IdVideojuego
            };
            TableBatchOperation batchOperation = new TableBatchOperation();
            batchOperation.Insert(prod1);
            await tableProductos.ExecuteBatchAsync(batchOperation);
            return prod1;
        }

        [HttpPost("[action]")]
        public async Task<Producto> Update([FromBody]Producto model)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable tableProductos = tableClient.GetTableReference("Productos");

            Producto prod1 = new Producto(model.PartitionKey, model.RowKey)
            {
                Id = model.Id,
                Caracteristicas = model.Caracteristicas,
                CorreoFabricante = model.CorreoFabricante,
                EstadoRevision = model.EstadoRevision,
                HoraRevision = DateTime.Now,
                Nombre = model.Nombre,
                Precio = model.Precio,
                UnidadesDisponibles = model.UnidadesDisponibles,
                UnidadesVendidas = model.UnidadesVendidas,
                Categorias = model.Categorias,
                Creador = model.Categorias,
                Descripcion = model.Descripcion,
                Estudio = model.Estudio,
                FechaLanzamiento = DateTime.Now,
                IdVideojuego = model.IdVideojuego
            };
            TableBatchOperation batchOperation = new TableBatchOperation();
            batchOperation.InsertOrMerge(prod1);
            await tableProductos.ExecuteBatchAsync(batchOperation);
            return prod1;
        }


        [HttpPost("[action]")]
        public async Task<Producto> Delete([FromBody]Producto model)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable tableProductos = tableClient.GetTableReference("Productos");

            Producto prod1 = new Producto(model.PartitionKey, model.RowKey)
            {
                Id = model.Id,
                Caracteristicas = model.Caracteristicas,
                CorreoFabricante = model.CorreoFabricante,
                EstadoRevision = model.EstadoRevision,
                HoraRevision = DateTime.Now,
                Nombre = model.Nombre,
                Precio = model.Precio,
                UnidadesDisponibles = model.UnidadesDisponibles,
                UnidadesVendidas = model.UnidadesVendidas,
                Categorias = model.Categorias,
                Creador = model.Categorias,
                Descripcion = model.Descripcion,
                Estudio = model.Estudio,
                FechaLanzamiento = DateTime.Now,
                IdVideojuego = model.IdVideojuego
            };
            TableBatchOperation batchOperation = new TableBatchOperation();
            batchOperation.Delete(prod1);
            await tableProductos.ExecuteBatchAsync(batchOperation);
            return prod1;
        }


    }
}
