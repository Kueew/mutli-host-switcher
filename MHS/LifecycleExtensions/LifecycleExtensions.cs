using System;
using Microsoft.Maui.LifecycleEvents;

namespace MHS.LifecycleExtensions
{
    public static class LifecycleExtensions
    {

        public static void AddCustomForm(this ILifecycleBuilder builder)
        {
#if MACCATALYST
            builder.AddiOS((app) =>
            {
                app.OnActivated(e =>
                {
                    //var vKeyWindow = e.KeyWindow;
                    var vKeyWindow = e.Windows.FirstOrDefault();
                    if (vKeyWindow is null)
                        return;

                    var vTitleBar = vKeyWindow.WindowScene?.Titlebar;
                    if (vTitleBar is null)
                        return;

                    vTitleBar.TitleVisibility =UIKit.UITitlebarTitleVisibility.Hidden;
                    vTitleBar.Toolbar = null;

                });
            });
#endif

            builder.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    window.ExtendsContentIntoTitleBar = false; /*This is important to prevent your app content extends into the title bar area.*/
                    IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                    AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);
                    if (winuiAppWindow.Presenter is OverlappedPresenter p)
                    {
                        p.SetBorderAndTitleBar(false, false);
                    }
                    const int width = 1200;
                    const int height = 800;
                    /*I suggest you to use MoveAndResize instead of Resize because this way you make sure to center the window*/
                    winuiAppWindow.MoveAndResize(new RectInt32(1920 / 2 - width / 2, 1080 / 2 - height / 2, width, height));
                });
            });

        }
    }

}

