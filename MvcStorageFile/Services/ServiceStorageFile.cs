using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Files.Shares;
using Azure;
using Azure.Storage.Files.Shares.Models;
using Microsoft.WindowsAzure.Storage.File;
using Microsoft.WindowsAzure.Storage;
using System.IO;

namespace MvcStorageFile.Services
{
    public class ServiceStorageFile
    {
        private ShareClient cliente;

        // private CloudFileDirectory root;

        //DefaultEndpointsProtocol=https;AccountName=storagetajamarans;AccountKey=9nNsPth/T8BKQ75uFQTvYAEz3JtPFX8aiO7/fywMk5/BlXkI46IGX98dz0zODIO4UJH/0EjvS+giZQ/M6Rn+tQ==;EndpointSuffix=core.windows.net
        //9nNsPth/T8BKQ75uFQTvYAEz3JtPFX8aiO7/fywMk5/BlXkI46IGX98dz0zODIO4UJH/0EjvS+giZQ/M6Rn+tQ==
        public ServiceStorageFile(String keys)
        {
           // String key = ;
            /*CloudStorageAccount account = CloudStorageAccount.Parse(key);

            CloudFileClient fileClient = account.CreateCloudFileClient();

            CloudFileShare shared = fileClient.GetShareReference("ejemplo");
            this.root = shared.GetRootDirectoryReference();*/
            this.cliente = new ShareClient(keys, "ejemplo");

        }

        public async Task<List<String>> GetFilesAsync()
        {
            ShareDirectoryClient raiz = this.cliente.GetRootDirectoryClient();
            List<String> files = new List<string>();
          await  foreach (var file in raiz.GetFilesAndDirectoriesAsync())
            {
                files.Add(file.Name);
            }

            return files;
        }

        public async Task UploadFileAsync(String filename, Stream stream)
        {
            ShareDirectoryClient raiz = this.cliente.GetRootDirectoryClient();
            ShareFileClient file = raiz.GetFileClient(filename);
            await file.CreateAsync(stream.Length);
            await file.UploadAsync(stream);
        }
        public async Task DeleteFileAsync(String filename)
        {
            ShareDirectoryClient raiz = this.cliente.GetRootDirectoryClient();
            ShareFileClient file = raiz.GetFileClient(filename);

            await file.DeleteAsync();
        }

        public async Task<String> GetFileContentAsync(String filename)
        {
            ShareDirectoryClient raiz = this.cliente.GetRootDirectoryClient();
            ShareFileClient file = raiz.GetFileClient(filename);

            String content = "";

            var data=await file.DownloadAsync();

            Stream stream = data.Value.Content;

            StreamReader reader = new StreamReader(stream);

            content = await reader.ReadToEndAsync();

            return content;
        }


        /*  public async Task<List<String>> GetFilesAsync()
          {
              var segmentos = await this.root.ListFilesAndDirectoriesSegmentedAsync(null);

              List<IListFileItem> azureFiles = segmentos.Results.ToList();
              List<String> files = new List<string>();


              foreach (IListFileItem f in azureFiles)
              {
                  String uri = f.StorageUri.PrimaryUri.AbsoluteUri;

                  int ultimo = uri.LastIndexOf("/") + 1;
                  String filename = uri.Substring(ultimo);
                  filename = filename.Replace("%20", " ");

                  files.Add(filename);
              }
              return files;
          }


          public async Task UploadFileAsync(String filename,Stream stream)
          {
              CloudFile cloudFile = this.root.GetFileReference(filename);


              await cloudFile.UploadFromStreamAsync(stream);
          }


          public async Task DeleteFileAsync(String filename)
          {
              CloudFile cloudfile = this.root.GetFileReference(filename);
              await cloudfile.DeleteAsync();
          }*/

    }
}
