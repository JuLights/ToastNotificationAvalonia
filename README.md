# Toast Notification Avalonia

This package provides a simple way to display customizable toast notifications in Avalonia UI. With easy integration and simple usage, you can enhance your Avalonia applications with toast notifications that are both functional and stylish.

---

## Features

- Display custom toast notifications in Avalonia.
- Support for easy integration into existing Avalonia projects.
- Fully customizable user control for toasts.
- Simple API to manage toast visibility and show notifications.

---

## Installation

To add this package to your Avalonia project, follow the instructions below:

1. **Add the NuGet Package**  
   You can add the package directly via NuGet Package Manager or using the .NET CLI:
   
   ```bash
   dotnet add package ToastNotificationAvalonia

### Basic Usage:

#### Create a Custom Toast UserControl

```csharp
public partial class MyToast : ToastControl
{
    public MyToast()
    {
        InitializeComponent();
    }
}
```

```xaml
<userControls:ToastControl xmlns="https://github.com/avaloniaui"
                            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                            xmlns:userControls="clr-namespace:ToastNotificationAvalonia.UserControls;assembly=ToastNotificationAvalonia"
                            mc:Ignorable="d" d:DesignWidth="800" d:DesignHeight="450"
                            x:Class="ToastNotificationAvalonia.Test.Views.ToastControls.MyToast">
    <Grid>
        <Border Background="Black" CornerRadius="12" BorderBrush="LightGray" BorderThickness="1"
                Width="200" Height="80">
            <StackPanel Orientation="Vertical" HorizontalAlignment="Center" VerticalAlignment="Center" Background="Transparent">
                <TextBlock Foreground="White" Text="Hello, dear user"/>
                <TextBlock Foreground="White" Text="What's your name?"/>
            </StackPanel>
        </Border>
    </Grid>
</userControls:ToastControl>
```
#### Set Up the Toast Container in the Main Window

```xaml
<Grid>
    <Canvas Margin="0,0,0,15" Width="500" Height="160" 
            HorizontalAlignment="Left" VerticalAlignment="Top" 
            Name="ToastContainer" Background="Transparent"/>
    
    <Button Command="{Binding ShowToastCommand}" HorizontalAlignment="Center" VerticalAlignment="Center" Content="Raise Toast"/>
</Grid>
```

#### Initialize Toast Manager in Code-Behind
```csharp
public MainWindow()
{
    InitializeComponent();
    
    ...
    ToastManager.Initialize(ToastContainer);
}

public async Task ShowToastAsync()
{
    // Show the toast notification asynchronously
    await ToastManager.ShowToastAsync(new MyToast());
}
```

```csharp
public partial class MainWindowViewModel : ViewModelBase
{
    [RelayCommand]
    private async Task ShowToast()
    {
        await ToastManager.ShowToastAsync(new MyToast());
    }
}
```
