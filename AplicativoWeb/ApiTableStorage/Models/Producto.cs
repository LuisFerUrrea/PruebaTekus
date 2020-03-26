using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTableStorage.Models
{
    public class Producto:TableEntity
    {
        public int Id { get; set; }
        public string Caracteristicas { get; set; }
        public string CorreoFabricante { get; set; }
        public string EstadoRevision { get; set; }
        public DateTime HoraRevision { get; set; }
        public string Nombre { get; set; }
        public int Precio { get; set; }
        public int UnidadesDisponibles { get; set; }
        public int UnidadesVendidas { get; set; }
        public string Categorias { get; set; }
        public string Creador { get; set; }
        public int Descripcion { get; set; }
        public int Estudio { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public string IdVideojuego { get; set; }
        
        public Producto() { }

        public Producto(string deptName,string prodName)
        {
            this.PartitionKey = deptName;
            this.RowKey = prodName;
        }
    }
}
