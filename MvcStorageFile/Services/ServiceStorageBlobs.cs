using Azure.Storage.Blobs;
using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStorageFile.Services
{
    public class ServiceStorageBlobs
    {
        private BlobContainerClient client;
        private BlobServiceClient service;
        private CloudStorageAccount account;

        public ServiceStorageBlobs(String conexion)
        {
            this.client =new BlobContainerClient(new Uri(conexion));
            this.service = new BlobServiceClient(conexion);
            this.account = CloudStorageAccount.Parse(conexion);
        }

      /*  public async Task CreateContainerAsync(String containername)
        {
            this.account.CreateCloudBlobClient(containername);

        }*/

       
    }
}
