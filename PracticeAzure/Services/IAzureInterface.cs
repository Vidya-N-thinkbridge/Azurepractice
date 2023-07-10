using Azure.Storage.Blobs;
using static PracticeAzure.Models.Models;

namespace PracticeAzure.Services
{
    
        public interface IAzureTableService
        {
           public AzureRow AddRowToAzureTable(AzureRow AzRow);

            public bool DeleteRowinAzureTable(string Name, int id);

            public AzureRow UpdateRowinAzureTable(AzureRow AzRow);

            public AzureRow GetRowFromAzureTable(string Name, int id);
        }

    public interface IBlobService
    {
       public bool createContainer(string containername);

        public bool UploadBlob(string containerName, string filepath);

        public bool DeleteSampleBlob(string containerName, string blobName);

        public bool DownloadSampleBlob(string containerName, string blobName);
    }
    public interface IQueueService
    {
        public bool PushToQueue(string queue, string message);

        public string PeekMessage(string queueName);
    }
    public interface IAzureFunctions
    {
        public string CallAzureFunction();
    }
}

