using System.Diagnostics;
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
		string accountName = AccountNameEntry.Text;
		double accountBalance = Convert.ToDouble(AccountBalanceEntry.Text);
		string accountIban = AccountIbanEntry.Text;

		if(string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(password)
			|| double.IsNegative(accountBalance) || string.IsNullOrWhiteSpace(accountName)
			|| string.IsNullOrWhiteSpace(accountIban) || string.IsNullOrWhiteSpace(AccountBalanceEntry.Text))
		{
			DisplayAlert("Erreur", "Tous les champs doivent être renseignés et corect (pas de solde négatif)", "OK");
		}
		else
		{
			Customer customer = new Customer(name, firstName, password);
			Account account = new Account(accountBalance, accountName, accountIban);
			customer.AccountsList.Add(account);
			Mgr.CustomersList.Add(customer);
			Debug.WriteLine(customer.Id);
			Debug.WriteLine(customer.Password);
			Debug.WriteLine(account.IBAN);
			DisplayAlert("Création", "Client " + customer.Name +" crée avec succès.", "OK");
			Shell.Current.Navigation.PopAsync();
		}
    }

	public void Account_Clicked(object sender, EventArgs e)
	{
		nbAccount++;
		if(nbAccount >= 4)
		{
			DisplayAlert("Erreur", "Impossible d'ajouter plus de compte. Un client ne peut avoir plus de 3 comptes.", "OK");
			return;
		}
		Label account = new Label { Text = "Compte " + Convert.ToString(nbAccount)};
		account.FontSize = 20;
		Grid gridAccount = new Grid();
        ColumnDefinition col1 = new ColumnDefinition(GridLength.Star);
		ColumnDefinition col2 = new ColumnDefinition(GridLength.Star);
		RowDefinition row1 = new RowDefinition(GridLength.Auto);
        RowDefinition row2 = new RowDefinition(GridLength.Auto);
        gridAccount.RowDefinitions.Add(row1);
        gridAccount.RowDefinitions.Add(row2);
		gridAccount.ColumnDefinitions.Add(col1);
        gridAccount.ColumnDefinitions.Add(col2);
        Label balance = new Label { Text = "Solde" };
		balance.FontSize = 12;
		Entry balanceEntry = new Entry { Placeholder = "Entrez le solde du compte" };
        Label nameLabel = new Label { Text = "Nom du compte" };
        Entry nameEntry = new Entry { Placeholder = "Entrez le nom du compte" };
        Label iban = new Label { Text = "IBAN" };
        Entry ibanEntry = new Entry { Placeholder = "Entrez l'IBAN du compte" };
        StackLayout.Add(account);
		gridAccount.SetColumn(balance, 0);
		gridAccount.SetRow(balance, 0);
        gridAccount.SetColumn(balanceEntry, 0);
        gridAccount.SetRow(balanceEntry, 1);
		gridAccount.SetColumn(nameLabel, 1);
		gridAccount.SetRow(nameLabel, 0);
		gridAccount.SetColumn(nameEntry, 1);
        gridAccount.SetColumn(nameEntry, 1);
        gridAccount.Children.Add(balance);
        gridAccount.Children.Add(balanceEntry);
        gridAccount.Children.Add(nameLabel);
        gridAccount.Children.Add(nameEntry);
        StackLayout.Add(gridAccount);
        //StackLayout.Add(balance);
        //      StackLayout.Add(balanceEntry);
        //StackLayout.Add(nameLabel);
        //StackLayout.Add(nameEntry);
        StackLayout.Add(iban);
        StackLayout.Add(ibanEntry);
    }

}
