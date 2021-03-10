using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using MvcStorageFile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStorageFile.Services
{
    public class ServiceStorageTables
    {
        private CloudTable table;

        public ServiceStorageTables(String keys)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse(keys);
            CloudTableClient client = account.CreateCloudTableClient();
            this.table = client.GetTableReference("clientes");
            this.table.CreateIfNotExistsAsync();
        }

        public async Task CreateClienteAsync(String idcliente,string nombre,string edad, string empresa)
        {
            Cliente cliente = new Cliente(idcliente, empresa);

            cliente.Nombre = nombre;
            cliente.Edad = edad;

            TableOperation insert = TableOperation.Insert(cliente);
            await this.table.ExecuteAsync(insert);
        }

        public async Task<List<Cliente>> GetCLienteAsync()
        {
            TableQuery<Cliente> query = new TableQuery<Cliente>();

            TableQuerySegment<Cliente> segment = await this.table.ExecuteQuerySegmentedAsync(query, null);

            return segment.Results;
        }

        public async Task<List<String>> GetEmpresasAsync()
        {
            TableQuery<Cliente> query = new TableQuery<Cliente>();
            TableQuerySegment<Cliente> segments = await this.table.ExecuteQuerySegmentedAsync(query, null);

            return segments.Select(x => x.Empresa).Distinct().ToList();
        }

        public async Task<List<Cliente>> GetClienteEmpresaAsync(String empresa)
        {
            TableQuery<Cliente> query = new TableQuery<Cliente>();
            TableQuerySegment<Cliente> segments = await this.table.ExecuteQuerySegmentedAsync(query, null);

            return segments.Where(x => x.Empresa == empresa).ToList();
        }
    }
}
