using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace PracticeAzure.Services
{
    public class BlobService:IBlobService
    {
        private readonly IConfiguration _configuration;
        private readonly BlobServiceClient blobClient;

        public BlobService(IConfiguration configuration)
        {
            _configuration = configuration;
            blobClient = new BlobServiceClient(_configuration["StorageConnectionStrings"]);
        }


   
        public bool createContainer(string containerName)
        {
            var container = blobClient.GetBlobContainerClient(containerName);
            if(!container.Exists())
            {
                blobClient.CreateBlobContainer(containerName);
            }
            return true;
        }
        public bool UploadBlob(string containerName, string filepath)
        {
            BlobContainerClient container = blobClient.GetBlobContainerClient(containerName);
            if (container.Exists())
            {
                string path = Path.Combine("C:\\Users\\vidya\\Downloads\\", filepath);
                container.GetBlobClient(filepath).Upload(path);
                return true;
            }
            return false;
        }
        public bool DeleteSampleBlob(string containerName, string blobName)
        {
            var container = blobClient.GetBlobContainerClient(containerName);
            if (container.Exists())
            {
                var blob = container.GetBlobClient(blobName);
                if (blob.Exists())
                {
                    blob.Delete();
                }
            }
            return true;
        }

        public bool DownloadSampleBlob(string containerName, string blobName)
        {
            var container = blobClient.GetBlobContainerClient(containerName);
            if (container.Exists())
            {
                var blob = container.GetBlobClient(blobName);
                if (blob.Exists())
                {
                    blob.DownloadTo("C:\\Users\\vidya\\Downloads\\downloaded2" + blobName);
                }
            }
            return true;
        }
    }
}
