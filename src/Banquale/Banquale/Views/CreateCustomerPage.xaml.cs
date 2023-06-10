using System.Diagnostics;
using Model;

namespace Banquale.Views
{
    /// <summary>
    /// Page de création de client.
    /// </summary>
    public partial class CreateCustomerPage : ContentPage
    {
        /// <summary>
        /// Obtient le gestionnaire de l'application à partir de l'instance de l'application.
        /// </summary>
        public Manager Mgr => (App.Current as App).MyManager;

        private int nbAccount = 1;
        private bool Account2 = false;
        private Label account = new Label { };
        private Grid gridAccount = new Grid();
        private Label balance = new Label { };
        private Entry balanceEntry = new Entry { };
        private Label nameLabel = new Label { };
        private Entry nameEntry = new Entry { };
        private Label iban = new Label { };
        private Entry ibanEntry = new Entry { };

        /// <summary>
        /// Initialise une nouvelle instance de la classe CreateCustomerPage.
        /// </summary>
        public CreateCustomerPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gère l'événement du bouton de création de client.
        /// </summary>
        public async void Create_Customer_Clicked(System.Object sender, System.EventArgs e)
        {
            // Récupération des valeurs des champs
            double BalanceAccount2 = Convert.ToDouble(balanceEntry.Text);
            string NameAccount2 = nameEntry.Text;
            string IbanAccount2 = ibanEntry.Text;
            string name = NameEntry.Text;
            string firstName = FirstNameEntry.Text;
            string password = PasswordEntry.Text;
            string accountName = AccountNameEntry.Text;
            double accountBalance = Convert.ToDouble(AccountBalanceEntry.Text);
            string accountIban = AccountIbanEntry.Text;

            // Validation des champs
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(password)
                || double.IsNegative(accountBalance) || string.IsNullOrWhiteSpace(accountName)
                || string.IsNullOrWhiteSpace(accountIban) || string.IsNullOrWhiteSpace(AccountBalanceEntry.Text)
                || Account2 == true && string.IsNullOrWhiteSpace(NameAccount2) || Account2 == true && string.IsNullOrWhiteSpace(IbanAccount2)
                || Account2 == true && double.IsNegative(BalanceAccount2) || Account2 == true && string.IsNullOrWhiteSpace(balanceEntry.Text))
            {
                await DisplayAlert("Erreur", "Tous les champs doivent être renseignés et corrects (pas de solde négatif)", "OK");
            }
            else if (AccountIbanEntry.Text.Length != 27 || IbanAccount2.Length != 27)
            {
                await DisplayAlert("Erreur", "L'IBAN doit contenir exactement 27 caractères.", "OK");
            }
            else
            {
                // Création du client
                Customer customer = new Customer(name, firstName, password);
                Account account1 = new Account(accountBalance, accountName, accountIban);
                customer.AccountsList.Add(account1);

                if (Account2 == true)
                {
                    Account account2 = new Account(BalanceAccount2, NameAccount2, IbanAccount2);
                    customer.AccountsList.Add(account2);
                    Debug.WriteLine(account2.IBAN);
                }

                // Ajout du client au gestionnaire
                Mgr.CustomersList.Add(customer);

                Debug.WriteLine(customer.Id);
                Debug.WriteLine(customer.Password);
                Debug.WriteLine(account1.IBAN);
                Debug.WriteLine(customer.AccountsList[0].Balance);
                Debug.WriteLine(customer.AccountsList[1].Balance);

                await DisplayAlert("Création", "Client " + customer.Name + " créé avec succès.", "OK");
                await Shell.Current.Navigation.PopAsync();
            }
        }

        /// <summary>
        /// Gère l'événement du bouton d'ajout de compte.
        /// </summary>
        public void Account_Clicked(object sender, EventArgs e)
        {
            Account2 = true;
            nbAccount++;

            if (nbAccount >= 3)
            {
                DisplayAlert("Erreur", "Impossible d'ajouter plus de compte. Un client ne peut avoir plus de 2 comptes.", "OK");
                return;
            }

            account.Text = "Compte " + Convert.ToString(nbAccount);
            account.FontSize = 25;
            account.TextColor = Colors.DarkRed;

            ColumnDefinition col1 = new ColumnDefinition(GridLength.Star);
            ColumnDefinition col2 = new ColumnDefinition(GridLength.Star);
            RowDefinition row1 = new RowDefinition(GridLength.Auto);
            RowDefinition row2 = new RowDefinition(GridLength.Auto);

            gridAccount.RowDefinitions.Add(row1);
            gridAccount.RowDefinitions.Add(row2);
            gridAccount.ColumnDefinitions.Add(col1);
            gridAccount.ColumnDefinitions.Add(col2);

            balance.Text = "Solde";
            balance.FontSize = 16;
            balanceEntry.Placeholder = "Entrez le solde du compte";
            balanceEntry.Keyboard = Keyboard.Numeric;

            nameLabel.Text = "Nom du compte";
            nameLabel.FontSize = 16;
            nameEntry.Placeholder = "Entrez le nom du compte";

            iban.Text = "IBAN";
            iban.FontSize = 16;
            ibanEntry.Text = "FR";
            ibanEntry.TextChanged += IbanChanged;
            ibanEntry.Placeholder = "Entrez l'IBAN du compte";
            ibanEntry.Keyboard = Keyboard.Numeric;

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
            StackLayout.Add(iban);
            StackLayout.Add(ibanEntry);
        }

        /// <summary>
        /// Gère l'événement de modification de l'IBAN.
        /// </summary>
        public void IbanChanged(object sender, EventArgs e)
        {
            if (AccountIbanEntry.Text.Length < 2 || ibanEntry.Text.Length < 2)
            {
                DisplayAlert("Erreur", "Vous ne pouvez pas effacer le FR !", "OK");
                var cast = ((Entry)sender);
                cast.Text = "FR";
                cast.CursorPosition = 3;
            }
        }
    }
}
