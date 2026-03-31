using System.Drawing;
using System.Security.Cryptography.Xml;
using System.Windows;
using System.Windows.Interop;

using ScreenHelper;

using Size = System.Windows.Size;

namespace Frank.TorrentClient.Gui3.Extensions;

public static class WindowExtensions
{
    public static List<Screen> GetScreens(this Window window) => Screen.AllScreens.ToList();

    public static bool IsOnPrimaryScreen(this Window window) => GetScreen(window).Primary;

    public static Size GetScreenWorkingAreaSize(this Window window) => new(GetScreen(window).WorkingArea.Size.Width, GetScreen(window).WorkingArea.Size.Height);

    public static Size GetScreenSize(this Window window) => new(GetScreen(window).Bounds.Size.Width, GetScreen(window).WorkingArea.Size.Height);

    public static Screen GetScreen(this Window window)
    {
        var screens = Screen.AllScreens.ToList();
        var currentScreen = screens.FirstOrDefault(s => s.Bounds.Contains(Convert.ToInt32(window.Left), Convert.ToInt32(window.Top)));
        return currentScreen ?? screens.First();
    }
}
