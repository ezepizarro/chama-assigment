using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus.Management;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Chama.WorkerFunction
{
    public static class StudentQueueTrigger
    {
        [FunctionName("StudentQueueTrigger")]
        public static async Task Run(
        [ServiceBusTrigger("student-signup-queue", Connection = "ServiceBusConnection")]
        string myQueueItem,
        Int32 deliveryCount,
        DateTime enqueuedTimeUtc,
        string messageId,
        ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            log.LogInformation($"EnqueuedTimeUtc={enqueuedTimeUtc}");
            log.LogInformation($"DeliveryCount={deliveryCount}");
            log.LogInformation($"MessageId={messageId}");

            const string url = "https://localhost:44315/api/Courses/SignUp";

            var item = JsonConvert.DeserializeObject<Request>(myQueueItem);

            var client = new HttpClient();

            var response = await client.PostAsJsonAsync(url, item);


            if(response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                //Send Email Success to item.Email
            }
            else
            {
                //Send Email Failure to item.Email
            }

        }
    }
    public class Request
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string Email { get; set; }
    }
}
