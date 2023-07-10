using Azure.Storage.Queues;

namespace PracticeAzure.Services
{
    public class AzureQueueService:IQueueService
    {
        private readonly IConfiguration _configuration;
        private QueueClient queue;
        public AzureQueueService(IConfiguration configuration)
        {
            _configuration= configuration;
        }
        public bool CreateQueue(string queueName)
        {
            queue = new QueueClient(_configuration["StorageConnectionStrings"], queueName);
            if (!queue.Exists())
            {

                queue.Create();
            }
            return true;
        }

        public bool PushToQueue(string queueName, string message)
        {
            
            CreateQueue(queueName);
            queue.SendMessage(message);
            return true;
        }

        public string PeekMessage(string queueName)
        {
            CreateQueue(queueName);

            if (queue.Exists())
            {
                var res = queue.PeekMessage().Value.MessageText.ToString();
                return res;
            }
            else
              return  "Queue not found";
        }
    }
}
