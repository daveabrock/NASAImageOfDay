using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.CosmosRepository;
using Data;
using System.Threading;
using System.Collections.Generic;

namespace Api
{
    public class ImageGet
    {
        readonly IRepository<Image> _repository;

        public ImageGet(IRepositoryFactory factory) => _repository = factory.RepositoryOf<Image>();

        [FunctionName("ImageGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "image")] HttpRequest req,
            ILogger log,
            CancellationToken hostCancellationToken)
        {
            using CancellationTokenSource cancellationSource =
                CancellationTokenSource.CreateLinkedTokenSource(hostCancellationToken, req.HttpContext.RequestAborted);

            log.LogInformation("Executing ImageOfDayGet.");

            IEnumerable<Image> image = await _repository.GetAsync(i => i.Date == new DateTime(2010, 09, 01), cancellationSource.Token);

            //var apiKey = Environment.GetEnvironmentVariable("ApiKey");
            //var response = await httpClient.GetAsync($"https://api.nasa.gov/planetary/apod?api_key={apiKey}&hd=true&date={GetRandomDate()}");
            //var result = await response.Content.ReadAsStringAsync();
            //return new OkObjectResult(JsonConvert.DeserializeObject(result));
            return new OkObjectResult(image);
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