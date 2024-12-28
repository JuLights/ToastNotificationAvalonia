using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using ToastNotificationAvalonia.Manager;
using ToastNotificationAvalonia.Test.Views.ToastControls;

namespace ToastNotificationAvalonia.Test.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [RelayCommand]
    private async Task ShowToast()
    {
        await ToastManager.ShowToastAsync(new MyToast());
    }
}