using BlastOff.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlastOff.Client.Pages
{
    partial class Index : ComponentBase
    {
        public IEnumerable<Image> ImageList { get; set; } = new List<Image>();

        public string SearchText = "";

        [Inject]
        public IImageService ImageService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ImageList = await ImageService.GetImages(days: 70);
        }

        private IEnumerable<Image> FilteredImages => ImageList.Where(
            img => img.Title.ToLower().Contains(SearchText.ToLower())).ToList();
    }
}