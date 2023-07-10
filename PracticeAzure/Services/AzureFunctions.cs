using Azure;
using Azure.Data.Tables;
using System.ComponentModel.DataAnnotations;

namespace PracticeAzure.Services
{
    public class AzureFunctions:IAzureFunctions
        
    {
        private readonly IConfiguration _configuration;
        public AzureFunctions( IConfiguration configuration)
        {
            _configuration= configuration;
        }
        public string CallAzureFunction()
        {
            string url = "https://azurepractice.azurewebsites.net/api/HttpTrigger2?code=2wQIbD5bd_VGTdRe4GGFxNttLOuUzq8TB7xCKbEEjvvrAzFun5P_pQ==";
            HttpClient client = new HttpClient();   
            var response= client.GetAsync(url).Result;
            var content= response.Content.ReadAsStringAsync().Result;
            return content;
        }

    }
}
