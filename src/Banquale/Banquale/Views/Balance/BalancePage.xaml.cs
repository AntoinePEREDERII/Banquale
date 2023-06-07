using Model;

namespace Banquale.Views.Balance;


public partial class BalancePage : ContentPage
{
	public Manager Mgr => (App.Current as App).MyManager;

    public BalancePage()
	{
		InitializeComponent();
        BindingContext = Mgr.SelectedAccount;
        if(Mgr.IsConsultant == true)
        {
            //Label lext = new Label { Text = "Hello" };
            //Grid.Add(lext);
            Image backArrow = new Image { HeightRequest = 100 };
            backArrow.SetBinding(Image.SourceProperty, "backArrowIcon");
            Grid.Add(backArrow);
        }
    }

    public async void Balance_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.Navigation.PushAsync(new NewPage1());
    }

}
