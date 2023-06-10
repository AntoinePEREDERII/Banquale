using Model;
using Microsoft.Maui.Controls;

namespace Banquale.Views.Transfer
{
    /// <summary>
    /// Page de demande de virement.
    /// </summary>
    public partial class RequestPage : ContentPage
    {
        public Manager Mgr => (App.Current as App).MyManager;

        /// <summary>
        /// Initialise une nouvelle instance de la classe RequestPage.
        /// </summary>
        public RequestPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gère l'événement du bouton d'envoi de la demande de virement.
        /// </summary>
        public async void Send_Clicked(Object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(IBAN.Text) || string.IsNullOrEmpty(Sum.Text))
            {
                await DisplayAlert("Erreur", "Tous les champs doivent être complétés", "OK");
                return;
            }
            else if (IBAN.Text.Length != 27)
            {
                await DisplayAlert("Erreur", "L'IBAN doit contenir exactement 25 chiffres.", "OK");
                return;
            }

            if (Name.Text == Mgr.SelectedAccount.Name && IBAN.Text == Mgr.SelectedAccount.IBAN)
            {
                await DisplayAlert("Erreur", "Vous ne pouvez pas effectuer une demande de virement à votre propre compte", "OK");
                return;
            }

            foreach (var cust in Mgr.CustomersList)
            {
                foreach (var acc in cust.AccountsList)
                {
                    if (acc.Name == Name.Text && acc.IBAN == IBAN.Text)
                    {
                        if (acc.Balance - Convert.ToDouble(Sum.Text) < 0)
                        {
                            await DisplayAlert("Erreur", "Le compte ne possède pas suffisamment d'argent pour effectuer la transaction", "OK");
                            return;
                        }

                        acc.DoTransactions(Mgr.SelectedAccount, Convert.ToDouble(Sum.Text), true); // Type true car c'est un virement que le SelectedAccount reçoit
                        Mgr.Persistence.DataSave(Mgr.CustomersList, Mgr.Consultant);
                        await Shell.Current.Navigation.PopAsync();
                        return;
                    }
                }
            }

            await DisplayAlert("Erreur", "Le compte n'existe pas", "OK");
        }

        /// <summary>
        /// Gère l'événement de modification de l'Entry de l'IBAN.
        /// </summary>
        public void IbanChanged(object sender, EventArgs e)
        {
            if (IBAN.Text.Length < 2)
            {
                DisplayAlert("Erreur", "Vous ne pouvez pas effacer le FR !", "OK");
                var cast = ((Entry)sender);
                cast.Text = "FR";
            }
        }
    }
}
