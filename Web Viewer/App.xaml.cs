using LCTWorks.WinUI;
using Microsoft.UI.Xaml;

namespace WebViewer;

public partial class App : Application, IAppExtended
{
    private readonly Window? _window;

    public App()
    {
        InitializeComponent();
    }

    public Window MainWindow => _window ?? new MainWindow();

    protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
    {
        MainWindow.Activate();
    }
}