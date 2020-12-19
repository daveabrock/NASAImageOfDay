using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Data;
using System.Collections.Generic;
using System.Linq;

namespace Client.Services
{
    public interface IApiClientService
    {
        public Task<IEnumerable<Image>> GetImages(int days);
    }
    public class ApiClientService : IApiClientService
    {
        readonly IHttpClientFactory _clientFactory;
        readonly ILogger<ApiClientService> _logger;

        public ApiClientService(ILogger<ApiClientService> logger, IHttpClientFactory clientFactory)
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

            return null;
        }
    }
}
