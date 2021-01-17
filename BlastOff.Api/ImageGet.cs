using BlastOff.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CosmosRepository;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlastOff.Api
{
    public class ImageGet
    {
        readonly IRepository<Image> _imageRepository;

        public ImageGet(IRepository<Image> imageRepository) => _imageRepository = imageRepository;

        [FunctionName("ImageGet")]
        public IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "image")] HttpRequest req,
            ILogger log)
        {

            bool hasDays = int.TryParse(req.Query["days"], out int days);
            log.LogInformation($"Requested images from last {days} days.");

            if (!hasDays && days <= 1 && days > 90)
                return new BadRequestResult();

            ValueTask<IEnumerable<Image>> imageResponse;
            imageResponse = _imageRepository.GetAsync
                 (img => img.Date > DateTime.Now.AddDays(-days));

            return new OkObjectResult(imageResponse.Result);
        }
    }
}