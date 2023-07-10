using Azure.Data.Tables;
using Azure;
using System.ComponentModel.DataAnnotations;

namespace PracticeAzure.Models
{
    public class Models
    {
        public class AzureRow : ITableEntity
        {
            [Key]
            public int EmpId { get; set; }

            public string EmpName { get; set; }

            public string EmpDesc { get; set; }

            public int EmpSalary { get; set; }

            public string PartitionKey { get; set; }

            public string RowKey { get; set; }

            public DateTimeOffset? Timestamp { get; set; }

            public ETag ETag { get; set; }
        }
    }
}

