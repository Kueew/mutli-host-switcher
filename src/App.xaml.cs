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
        win.Width = 1200;
        win.MaximumWidth = 1200;
        win.Height = 800;
        win.MaximumHeight = 800;
        win.Title = "Mutli-Host Switcher";
        return win;
    }
}

