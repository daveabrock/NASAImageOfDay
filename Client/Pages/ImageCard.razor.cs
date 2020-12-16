using Microsoft.AspNetCore.Components;

namespace Client.Pages
{
    partial class ImageCard : ComponentBase
    {
        [Parameter]
        public Data.Image ImageDetails { get; set; }
    }
}
