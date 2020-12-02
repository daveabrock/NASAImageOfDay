using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Data;

namespace Client.Services
{
    public interface IApiClientService
    {
        public Task<Image> GetImageOfDay();
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

        public async Task<Image> GetImageOfDay()
        {
            try
            {
                var client = _clientFactory.CreateClient("imageofday");
                var image = await client.GetFromJsonAsync<Image>("api/image");
                return image;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
            }

            return null;
        }
    }
}
