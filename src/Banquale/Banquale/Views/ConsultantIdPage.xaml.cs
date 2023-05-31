using Banquale.Views;
namespace Banquale.Views;

public partial class ConsultantIdPage : ContentPage
{
	public ConsultantIdPage()
	{
		InitializeComponent();
	}

    public async void Connection_Clicked(Object sender, EventArgs e)
    {
        string id = ident.Text;

        if (string.IsNullOrWhiteSpace(id))
        {
            await DisplayAlert("Erreur", "l'id ne doit pas être nulle", "OK");
            return;
        }

        await Navigation.PushModalAsync(new BalancePage());
    }

}