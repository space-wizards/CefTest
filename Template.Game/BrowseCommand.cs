using JetBrains.Annotations;
using Robust.Client.CEF;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.CustomControls;
using Robust.Shared.Console;
using Robust.Shared.IoC;

namespace Template.Game
{
    [UsedImplicitly]
    public sealed class BrowseCommand : IConsoleCommand
    {
        public string Command => "browse";
        public string Description => "";
        public string Help => "";

        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            if (args.Length != 1)
            {
                shell.WriteError("Incorrect amount of arguments! Must be a single one.");
                return;
            }

            var window = new SS14Window();

            var browser = new BrowserControl();

            if (args.Length < 1)
                return;

            window.MinSize = (1366, 768);

            browser.MouseFilter = Control.MouseFilterMode.Stop;
            window.MouseFilter = Control.MouseFilterMode.Pass;
            window.Contents.AddChild(browser);

            browser.Url = args[0];

            window.Open();
        }
    }

    [UsedImplicitly]
    public sealed class BrowseWinCommand : IConsoleCommand
    {
        public string Command => "browsewin";
        public string Description => "";
        public string Help => "";

        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            if (args.Length != 1)
            {
                shell.WriteError("Incorrect amount of arguments! Must be a single one.");
                return;
            }

            var parameters = new BrowserWindowCreateParameters(1280, 720)
            {
                Url = args[0]
            };

            var cef = IoCManager.Resolve<CefManager>();
            cef.CreateBrowserWindow(parameters);
        }
    }
}