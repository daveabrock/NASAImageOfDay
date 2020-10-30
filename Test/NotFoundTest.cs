using Xunit;
using Bunit;
using Client.Shared;

namespace Test
{
    public class NotFoundTest
    {
        [Fact]
        public void NotFoundComponentRendersCorrectly()
        {
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<NotFoundPage>();
            var h1Element = cut.Find("h1").TextContent;
            var buttonElement = cut.Find("button").TextContent;

            h1Element.MarkupMatches("Houston, we have a problem");
            buttonElement.MarkupMatches("🚀 Back to Mission Control");
        }
    }
}
