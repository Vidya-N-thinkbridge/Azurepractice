using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticeAzure.Services;
using System.Reflection.Metadata.Ecma335;
using static PracticeAzure.Models.Models;

namespace PracticeAzure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureController : ControllerBase
    {
        private readonly IAzureTableService _AzureTableService;
        private readonly IBlobService _blobService;
        private readonly IQueueService _queueService;
        private readonly IAzureFunctions _azureFunction;

        public AzureController(
          IAzureTableService azuretableService,
          IBlobService blobService,
          IQueueService queueService,
          IAzureFunctions azureFunction)
        {
            
              _AzureTableService = azuretableService;
            _blobService = blobService;
            _queueService = queueService;
            _azureFunction = azureFunction;
        }

        [HttpGet("GetEmployee")]
        public IActionResult GetRowFromAzureTable(string name, int id)
        {
            
            var res = _AzureTableService.GetRowFromAzureTable(name, id);
            return Ok(res);
        }

        [HttpPost("AddEmployee")]
        public IActionResult AddRowToAzureTable(AzureRow AzRow)
        { 
        var result = _AzureTableService.AddRowToAzureTable(AzRow);
            return Ok(result);
    }

        [HttpPut("UpdateEmployee")]
        public IActionResult Update(AzureRow AzRow)
        {
            var result = _AzureTableService.UpdateRowinAzureTable(AzRow);
            return Ok(result);
        }

        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteRowinAzureTable(string Name, int id)
        {
            var result = _AzureTableService.DeleteRowinAzureTable(Name, id);
            return Ok(result);  
        }

        [HttpPost("CreateSampleContainer")]
        public IActionResult CreateSampleContainer(string containerName)
        { 
          var res=  _blobService.createContainer(containerName);
            return Ok(res);
        }

        [HttpPost("UploadBlob")]
        public IActionResult UploadBlob(string containerName, IFormFile filepath)
        {
            var res =_blobService.UploadBlob(containerName, filepath.FileName);
            return Ok(res);
        }

        [HttpPost("Deleteblob")]
        public IActionResult DeleteSampleBlob(string containerName, string blobName)
        { 
            var res=_blobService.DeleteSampleBlob(containerName, blobName);
            return Ok(res);
        }
        [HttpGet("Downloadblob")]
        public IActionResult DownloadSampleBlob(string containerName, string blobName)
        {
            var res = _blobService.DownloadSampleBlob(containerName, blobName);
            return Ok(res);
        }
        [HttpPost("PushToQueue")]
        public IActionResult PushToQueue(string queueName, string message)
        {
            var res = _queueService.PushToQueue(queueName, message);
            return Ok(res);
        }

        [HttpGet("PeekMessage")]
        public IActionResult PeekMessage(string queueName)
        { 
        var res=_queueService.PeekMessage(queueName);
            return Ok(res);
        }
        [HttpGet("Call Azure Function")]
        public IActionResult CallAzureFunction()
        {
            var res = _azureFunction.CallAzureFunction();
            return Ok(res);
        }
    }
}
