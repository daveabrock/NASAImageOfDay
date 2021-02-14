using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlastOff.Shared
{
    public interface IImageService
    {
        public Task<IEnumerable<Image>> GetImages(int days);
    }

    public class ImageService : IImageService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<ImageService> _logger;

        public ImageService(ILogger<ImageService> logger, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<IEnumerable<Image>> GetImages(int days)
        {
            try
            {
                var client = _clientFactory.CreateClient("imageofday");
                var images = await client.GetFromJsonAsync
                    <IEnumerable<Image>>($"api/image?days={days}");
                return images.OrderByDescending(img => img.Date);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return default;
        }
    }
}