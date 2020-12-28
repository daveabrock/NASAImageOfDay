using Microsoft.AspNetCore.Components;
using BlastOff.Shared; 

namespace BlastOff.Client.Pages
{
    partial class ImageCard : ComponentBase
    {
        [Parameter]
        public Image ImageDetails { get; set; }
    }
}
