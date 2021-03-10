using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.WindowsAzure.Storage;
using MvcStorageFile.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MvcStorageFile.Services
{
    public class ServiceStorageBlobs
    {

        private BlobServiceClient service;

        public ServiceStorageBlobs(String conexion)
        {

            this.service = new BlobServiceClient(conexion);

        }

        public async Task CreateContainerAsync(String containername)
        {
            await this.service.CreateBlobContainerAsync(containername,PublicAccessType.Blob);

        }

        public async Task<List<string>> GetContainerAsync()
        {
            List<String> containers = new List<string>();
            await foreach (BlobContainerItem contaniner in
                this.service.GetBlobContainersAsync())
            {
                containers.Add(contaniner.Name);
            }
            return containers;
        }

        public async Task DeleteContainerAsync(String containername)
        {
            await this.service.DeleteBlobContainerAsync(containername);
        }

        public async Task<List<Blobs>> GetBlobsAsync(string containername)
        {
            List<Blobs> blobs = new List<Blobs>();

            BlobContainerClient containerClient = this.service.GetBlobContainerClient(containername);


            await foreach (BlobItem item in containerClient.GetBlobsAsync())
            {
                BlobClient blobClient = containerClient.GetBlobClient(item.Name);
                String name = item.Name;
                String uri = blobClient.Uri.AbsoluteUri;
                
                blobs.Add(new Blobs()
                {
                    Name=item.Name,
                    Uri=blobClient.Uri.AbsoluteUri
                });
            }

            return blobs;
        }

        public async Task DeleteBlobAsync(String containername, string blobname)
        {
            BlobContainerClient blobclient = this.service.GetBlobContainerClient(containername);

            await blobclient.DeleteBlobAsync(blobname);
        }


        public async Task UploadBlobAsync(String containername, string blobname, Stream stream)
        {
            BlobContainerClient blobclient = this.service.GetBlobContainerClient(containername);

            await blobclient.UploadBlobAsync(blobname, stream);
        }

     
    }
}
