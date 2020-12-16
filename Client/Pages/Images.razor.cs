using Client.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Pages
{
    partial class Images : ComponentBase
    {
        IEnumerable<Data.Image> _images;

        [Inject]
        public IApiClientService ApiClientService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _images = await ApiClientService.GetImageOfDay(days: 90);
        }
    }
}
