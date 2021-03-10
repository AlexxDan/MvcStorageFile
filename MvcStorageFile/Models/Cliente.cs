using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStorageFile.Models
{
    public class Cliente:TableEntity
    {
        public Cliente() { }

        public Cliente(String idCliente, string empresa)
        {
            this.IdCliente = idCliente;
            this.Empresa = empresa;
            this.RowKey = idCliente;
            this.PartitionKey = empresa;
        }

        public String IdCliente{ get; set; }

        public String Nombre { get; set; }

        public String Edad { get; set; }

        public String Empresa { get; set; }
    }
}
