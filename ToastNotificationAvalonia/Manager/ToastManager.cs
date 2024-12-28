using Avalonia.Controls;
using ToastNotificationAvalonia.UserControls;

namespace ToastNotificationAvalonia.Manager;

public class ToastManager
{
    private static List<ToastControl> _activeToasts = new List<ToastControl>();
    private static Canvas toastContainer;
    
    /// <summary>
    /// pass the canvas container where to draw
    /// </summary>
    /// <param name="container">Canvas container</param>
    public static void Initialize(Canvas container)
    {
        toastContainer = container;
    }

    /// <summary>
    /// Pass usercontrol to this function
    /// </summary>
    /// <param name="toastControl"></param>
    public static async Task ShowToastAsync(ToastControl toastControl)
    {
        _activeToasts.Add(toastControl);
        
        toastContainer.Children.Add(toastControl);
        Canvas.SetTop(toastControl, 10 + (_activeToasts.Count - 1) * 80);  // stack toasts vertically

        // show the toast with animation
        await toastControl.ShowAsync();
        toastContainer.Children.Remove(toastControl);
        _activeToasts.Remove(toastControl);
        
        await toastControl.HideAsync();
    }
}
