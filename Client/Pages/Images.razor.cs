using Client.Services;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Pages
{
    partial class Images : ComponentBase
    {
        protected string _searchText;

        public IEnumerable<Data.Image> ImageList { get; set; } = new List<Data.Image>();
        
        [Inject]
        public IApiClientService ApiClientService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ImageList = await ApiClientService.GetImages(days: 70);
        }

        protected async Task HandleSearch()
        {
            ImageList = await ApiClientService.SearchImages(_searchText);
        }
    }
}
