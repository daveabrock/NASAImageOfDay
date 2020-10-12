using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Newtonsoft.Json;

namespace Api
{
    public static class ImageGet
    {
        private static readonly HttpClient httpClient = new HttpClient();

        [FunctionName("ImageGet")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "image")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Executing ImageOfDayGet.");

            var apiKey = Environment.GetEnvironmentVariable("ApiKey");
            var response = await httpClient.GetAsync($"https://api.nasa.gov/planetary/apod?api_key={apiKey}&hd=true&date={GetRandomDate()}");
            var result = await response.Content.ReadAsStringAsync();
            return new OkObjectResult(JsonConvert.DeserializeObject(result));
        }

        private static string GetRandomDate()
        {
            var random = new Random();
            var startDate = new DateTime(1995, 06, 16);
            var range = (DateTime.Today - startDate).Days;
            return startDate.AddDays(random.Next(range)).ToString("yyyy-MM-dd");
        }
    }
}
