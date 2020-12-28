using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlastOff.Shared;

namespace BlastOff.Client.Pages
{
    partial class Images : ComponentBase
    {
        protected string _searchText;

        public IEnumerable<Image> ImageList { get; set; } = new List<Image>();
        
        [Inject]
        public IImageService ImageService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ImageList = await ImageService.GetImages(days: 70);
        }

        protected async Task HandleSearch()
        {
            ImageList = await ImageService.SearchImages(_searchText);
        }
    }
}
