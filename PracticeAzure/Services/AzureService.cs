using Azure;
using Azure.Data.Tables;
using static PracticeAzure.Models.Models;

namespace PracticeAzure.Services
{
    public class AzureService:IAzureTableService
    {
        private const string TableName = "Employee";
        private readonly IConfiguration _configuration;

        public AzureService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TableClient GetTableClient()
        {
            var TableServiceClient = new TableServiceClient(_configuration["StorageConnectionStrings"]);
            var tableClient=TableServiceClient.GetTableClient("Employee");
            tableClient.CreateIfNotExists();
            return tableClient;
        }
        public AzureRow AddRowToAzureTable(AzureRow AzRow)
        {
            GetTableClient().AddEntity<AzureRow>(AzRow);
            return AzRow;
        }
        public bool DeleteRowinAzureTable(string Name, int id)
        {
            GetTableClient().DeleteEntity(Name, Convert.ToString(id));
            return true;
        }
        public AzureRow UpdateRowinAzureTable(AzureRow AzRow)
        {
            try
            {
                var tableclient =  GetTableClient();
                var result = tableclient.UpdateEntity<AzureRow>(AzRow, ETag.All);
                if (result.Status.ToString().StartsWith("2"))
                {
                    return AzRow;
                }
                throw new Exception("Error occurred");
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred");
            }
        }
        public AzureRow GetRowFromAzureTable(string Name, int id)
        {
            var row = GetTableClient().GetEntity<AzureRow>(Name, Convert.ToString(id));
            return (row);
        }
    }

}
