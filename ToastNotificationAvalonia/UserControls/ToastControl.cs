using Avalonia.Animation;
using Avalonia.Animation.Easings;
using Avalonia.Controls;
using Avalonia.Styling;

namespace ToastNotificationAvalonia.UserControls;

public class ToastControl : UserControl
{
    internal async Task ShowAsync()
    {
        this.Opacity = 0; // start with it hidden
        this.IsVisible = true;

        var fadeInAnimation = new Animation
        {
            Duration = TimeSpan.FromSeconds(2.5),
            Easing = new LinearEasing(),
            Children =
            {
                new KeyFrame
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Setters = { new Setter(OpacityProperty, 0.0) }
                },
                new KeyFrame
                {
                    KeyTime = TimeSpan.FromSeconds(0.5),
                    Setters = { new Setter(OpacityProperty, 0.5) }
                },
                new KeyFrame
                {
                    KeyTime = TimeSpan.FromSeconds(1),
                    Setters = { new Setter(OpacityProperty, 0.7) }
                },
                new KeyFrame
                {
                    KeyTime = TimeSpan.FromSeconds(1.5),
                    Setters = { new Setter(OpacityProperty, 0.8) }
                },
                new KeyFrame
                {
                    KeyTime = TimeSpan.FromSeconds(2),
                    Setters = { new Setter(OpacityProperty, 1) }
                },
            }
        };

        await fadeInAnimation.RunAsync(this);
    }
    
    // hide animation (fade out)
    internal async Task HideAsync()
    {
        // fade-out animation
        var fadeOutAnimation = new Animation
        {
            Duration = TimeSpan.FromSeconds(1.5),
            Easing = new LinearEasing(),
            Children =
            {
                new KeyFrame
                {
                    KeyTime = TimeSpan.FromSeconds(1),
                    Setters = { new Setter(OpacityProperty, 1) }
                },
                new KeyFrame
                {
                    KeyTime = TimeSpan.FromSeconds(0.5),
                    Setters = { new Setter(OpacityProperty, 0.5) }
                },
                new KeyFrame
                {
                    KeyTime = TimeSpan.FromSeconds(0),
                    Setters = { new Setter(OpacityProperty, 0.0) }
                }
            }
        };

        await fadeOutAnimation.RunAsync(this);
        
        await Task.Delay(500); // wait for a short time after animation finishes

        // set the toast's visibility to false after the animation is done
        this.IsVisible = false;
    }
}