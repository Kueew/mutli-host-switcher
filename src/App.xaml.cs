namespace MHS;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new Views.HomeView());
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        var win = base.CreateWindow(activationState);
        win.Width = 800;
        win.Height = 600;
        win.Title = "Mutli-Host Switcher";
        return win;
    }
}

