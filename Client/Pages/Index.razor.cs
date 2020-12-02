using Client.Services;
using Data;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Client.Pages
{
    partial class Index : ComponentBase
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
