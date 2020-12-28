//using Xunit;
//using Bunit;
//using Client.Services;
//using Moq;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using Data;

//namespace Test
//{
//    public class ImageOfDayTest
//    {
//        [Fact]
//        public void ImageOfDayComponentRendersCorrectly()
//        {
//            var mockClient = new Mock<IApiClientService>();
//            mockClient.Setup(i => i.GetImageOfDay(3)).ReturnsAsync(GetImage());

//            using var ctx = new TestContext();
//            ctx.Services.AddSingleton(mockClient.Object);

//            IRenderedComponent<Client.Pages.Image> cut = ctx.RenderComponent<Client.Pages.Image>();
//            var h1Element = cut.Find("h1").TextContent;
//            var imgElement = cut.Find("img");
//            var pElement = cut.Find("p");

//            h1Element.MarkupMatches("My Sample Image");
//            imgElement.MarkupMatches(@"<img src=""https://nasa.gov"" 
//                class=""rounded-lg h-500 w-500 flex items-center justify-center"">");
//            pElement.MarkupMatches(@"<p class=""text-2xl"">Wednesday, January 1, 2020</p>");
//        }

//        private static Image GetImage()
//        {
//            return new Image
//            {
//                Date = new DateTime(2020, 01, 01),
//                Title = "My Sample Image",
//                Url = "https://nasa.gov"
//            };
//        }
//    }
//}
