using System;
using Microsoft.Maui.LifecycleEvents;
using UIKit;

namespace MHS.Extensions
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

                    vTitleBar.TitleVisibility = UIKit.UITitlebarTitleVisibility.Hidden; 

                });
            });
#endif

#if WINDOWS
            builder.AddWindows(win =>
            {
                win.OnWindowCreated((o) =>
                {
                    o.ExtendsContentIntoTitleBar = true;
                    Microsoft.UI.Xaml.Controls.Grid gr = new Microsoft.UI.Xaml.Controls.Grid();
                    o.SetTitleBar(gr);
                    o.Content.CanDrag = true;
                });
            });
#endif
        }

    }
}

