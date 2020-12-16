//using Xunit;
//using Bunit;
//using Client.

//namespace Test
//{
//    public class HomeTest
//    {
//        [Fact]
//        public void IndexComponentRendersCorrectly()
//        {
//            using var ctx = new TestContext();
//            var cut = ctx.RenderComponent<Index>();
//            var h1Element = cut.Find("h1").TextContent;
//            var buttonElement = cut.Find("button").TextContent;

//            h1Element.MarkupMatches("Welcome to Blast Off with Blazor");
//            buttonElement.MarkupMatches("🚀 Image of the Day");
//        }
//    }
//}
