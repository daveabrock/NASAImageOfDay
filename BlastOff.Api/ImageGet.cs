using BlastOff.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BlastOff.Api
{
    public class ImageGet
    {
        private readonly IRepository<Image> _imageRepository;

        public ImageGet(IRepository<Image> imageRepository) => _imageRepository = imageRepository;

        [FunctionName("ImageGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "image")] HttpRequest req,
            ILogger log)
        {
            var hasDays = int.TryParse(req.Query["days"], out var days);
            log.LogInformation($"Requested images from last {days} days.");

            var imageResponse = await _imageRepository.GetAsync
                (img => img.Date > DateTime.Now.AddDays(-days));

            return new OkObjectResult(imageResponse);
        }
    }
}