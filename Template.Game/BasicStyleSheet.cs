using Robust.Client.Graphics;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Shared.IoC;
using static Robust.Client.UserInterface.StylesheetHelpers;

namespace Template.Game
{
    public static class BasicStyleSheet
    {
        public static Stylesheet Make()
        {
            var res = IoCManager.Resolve<IResourceCache>();
            var notoSansFont = res.GetResource<FontResource>("/NotoSans/NotoSans-Regular.ttf");
            var notoSans12 = new VectorFont(notoSansFont, 12);

            return new Stylesheet(new StyleRule[]
            {
                Element().Prop("font", notoSans12)
            });
        } 
    }
}