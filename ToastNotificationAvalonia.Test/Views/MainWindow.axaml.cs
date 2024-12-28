using Avalonia.Controls;
using ToastNotificationAvalonia.Manager;

namespace ToastNotificationAvalonia.Test.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
        ToastManager.Initialize(ToastContainer);
    }
}