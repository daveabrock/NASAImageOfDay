using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Microsoft.Azure.CosmosRepository;
using System.Threading;

namespace Api
{
    public class ImageGet
    {
        private static readonly HttpClient httpClient = new HttpClient();
        readonly IRepository<Image> _repository;

        public ImageGet(IRepositoryFactory factory) => _repository = factory.RepositoryOf<Image>();

        [FunctionName("ImageGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "image")] HttpRequest req, 
            ILogger log, CancellationToken hostCancellationToken)
        {
            using CancellationTokenSource cancellationSource =
                CancellationTokenSource.CreateLinkedTokenSource(hostCancellationToken, req.HttpContext.RequestAborted);

            var image = await _repository.GetAsync(i => i.Date == GetRandomDate(), cancellationSource.Token);

            return new OkObjectResult(image);
        }

        private static DateTime GetRandomDate()
        {
            var random = new Random();
            var startDate = new DateTime(1995, 06, 16);
            var range = (new DateTime(2004, 07, 01) - startDate).Days;
            return startDate.AddDays(random.Next(range));
        }
    }

    public class Image : Item
    {
        public string Title { get; set; }
        public string Copyright { get; set; }
        public DateTime Date { get; set; }
        public string Explanation { get; set; }
        public string Url { get; set; }
        public string HdUrl { get; set; }
    }
}