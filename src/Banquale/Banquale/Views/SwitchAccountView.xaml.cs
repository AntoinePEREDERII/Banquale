namespace Banquale.Views;

public partial class SwitchAccountView : ContentView
{
	public SwitchAccountView()
	{
		InitializeComponent();
	}

    public async void Transfer_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//balance");
    }

}