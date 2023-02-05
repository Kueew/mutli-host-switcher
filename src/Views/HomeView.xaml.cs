namespace MHS.Views;

public partial class HomeView : ContentPage
{
	public HomeView()
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);

    }

    private void DragGestureRecognizer_DragStarting(object sender, DragStartingEventArgs e)
    {

    }

    private void DropGestureRecognizer_Drop(object sender, DropEventArgs e)
    {

    }
}
