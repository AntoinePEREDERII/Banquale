using Model;
namespace Banquale.Views;

public partial class CreateCustomerPage : ContentPage
{
    public Manager Mgr => (App.Current as App).MyManager;

    int nbAccount = 1;

    public CreateCustomerPage()
	{
		InitializeComponent();
	}

    public void Create_Customer_Clicked(System.Object sender, System.EventArgs e)
    {
		string name = NameEntry.Text;
		string firstName = FirstNameEntry.Text;
		string password = PasswordEntry.Text;

		if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(firstName))
		{
			DisplayAlert("Erreur", "Tous les champs doivent être renseignés", "OK");
		}
		else
		{
			Customer customer = new Customer(name, firstName, password);
			Mgr.CustomersList.Add(customer);
		}
    }

	public void Account_Clicked(object sender, EventArgs e)
	{
		Label account = new Label { Text = "Compte " + Convert.ToString(nbAccount)};
		Label balance = new Label { Text = "Solde" };
		Entry balanceEntry = new Entry { Placeholder = "Entrez le solde du compte" };
		StackLayout.Add(account);
		StackLayout.Add(balance);
        StackLayout.Add(balanceEntry);

    }

}
