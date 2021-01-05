using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.CosmosRepository;
using BlastOff.Shared;
using System.Collections.Generic;

namespace BlastOff.Api
{
    public class ImageGet
    {
        readonly IRepository<Image> _imageRepository;

        public ImageGet(IRepository<Image> imageRepository) => _imageRepository = imageRepository;

        [FunctionName("ImageGet")]
        public async ValueTask<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "image")] HttpRequest req,
            ILogger log)
        {
            bool hasDays = int.TryParse(req.Query["days"], out int days);
            log.LogInformation($"Requested images from last {days} days.");

            if (!hasDays && days <= 1 && days > 90)
                return new BadRequestResult();

            var imageResponse = await _imageRepository.GetAsync
                 (img => img.Date > DateTime.Now.AddDays(-days));

            return new OkObjectResult(imageResponse);
        }

        [FunctionName("ImageSearch")]
        public async ValueTask<IActionResult> Search(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "search")] HttpRequest req,
            ILogger log)
        {
            var title = req.Query["title"];
            log.LogInformation($"Requested image containing title: {title}.");

            var imageResponse = await _imageRepository.GetAsync
                 (img => img.Title.Contains(title, StringComparison.InvariantCultureIgnoreCase));

            return new OkObjectResult(imageResponse);
        }
    }
}
