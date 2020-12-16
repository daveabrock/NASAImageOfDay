using Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Services;

namespace ImageFetch.Pages
{
    partial class ImageOfDay : ComponentBase
    {
        Image _image;

        [Inject]
        public IApiClientService ApiClientService { get; set; }

        private static string FormatDate(DateTime date) => date.ToLongDateString();

        protected override async Task OnInitializedAsync()
        {
            _image = await ApiClientService.GetImageOfDay();
        }
    }
}
