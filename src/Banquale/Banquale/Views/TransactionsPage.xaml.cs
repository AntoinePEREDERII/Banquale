using Model;
using Banquale.Views.Category;

namespace Banquale.Views
{
    /// <summary>
    /// Page affichant le détail d'une transaction.
    /// </summary>
    public partial class TransactionsPage : ContentPage
    {
        /// <summary>
        /// Obtient le gestionnaire de l'application à partir de l'instance de l'application (Manager Mgr).
        /// </summary>
        public Manager Mgr => (App.Current as App).MyManager;

        /// <summary>
        /// Initialise une nouvelle instance de la classe TransactionsPage.
        /// </summary>
        public TransactionsPage()
        {
            InitializeComponent();

            // Lie le contexte de liaison aux transactions sélectionnées dans le gestionnaire
            BindingContext = Mgr.SelectedTransaction;

            // Configure l'affichage en fonction des conditions
            if (Mgr.IsConsultant && !Mgr.SelectedTransaction.IsOpposition)
            {
                oppose.Text = "Aucune demande en cours";
            }
            else if (Mgr.IsConsultant && Mgr.SelectedTransaction.IsOpposition)
            {
                oppose.Text = "Accepter l'opposition";
                refuseOpposition.IsVisible = true;
            }

            if (!Mgr.IsConsultant && Mgr.SelectedTransaction.IsOpposition)
            {
                oppose.Text = "Demande en cours";
            }

            if (Mgr.SelectedTransaction.Type)
            {
                string price1 = sum.Text;
                sum.Text = "- " + price1;
                sum.TextColor = Colors.Red;
            }
            else if (!Mgr.SelectedTransaction.Type)
            {
                string price2 = sum.Text;
                sum.Text = "+ " + price2;
                sum.TextColor = Colors.Green;
            }
        }

        /// <summary>
        /// Gère l'événement du bouton de la catégorie.
        /// </summary>
        async void Categ_Clicked(System.Object sender, System.EventArgs e)
        {
            await Shell.Current.Navigation.PushAsync(new CategoryPage());
        }

        /// <summary>
        /// Gère l'événement du bouton d'opposition.
        /// </summary>
        async void Objection_Clicked(System.Object sender, System.EventArgs e)
        {
            if (!Mgr.IsConsultant && !Mgr.SelectedTransaction.IsOpposition)
            {
                Mgr.SelectedTransaction.IsOpposition = true;
                await DisplayAlert("Opposition", "Votre demande d'opposition a bien été prise en compte", "OK");
                await Shell.Current.Navigation.PopAsync();
            }
            else if (Mgr.IsConsultant && Mgr.SelectedTransaction.IsOpposition)
            {
                Mgr.SelectedAccount.TransactionsList.Remove(Mgr.SelectedTransaction);
                await DisplayAlert("Opposition", "La demande d'opposition a été réalisée avec succès", "OK");
                await Shell.Current.Navigation.PopAsync();
            }
            else if (Mgr.IsConsultant && !Mgr.SelectedTransaction.IsOpposition)
            {
                await DisplayAlert("Erreur", "Aucune demande d'opposition en cours pour cette transaction", "OK");
                await Shell.Current.Navigation.PopAsync();
            }
            else if (!Mgr.IsConsultant && Mgr.SelectedTransaction.IsOpposition)
            {
                await DisplayAlert("Opposition", "Votre demande est en cours. Veuillez patienter SVP.", "OK");
                await Shell.Current.Navigation.PopAsync();
            }
        }

        /// <summary>
        /// Gère l'événement du bouton de refus d'opposition du coté du consultant.
        /// </summary>
        async void Refuse_Clicked(System.Object sender, System.EventArgs e)
        {
            Mgr.SelectedTransaction.IsOpposition = false;
            await DisplayAlert("Opposition", "La demande d'opposition a bien été refusée", "OK");
            refuseOpposition.IsVisible = false;
            await Shell.Current.Navigation.PopAsync();
        }
    }
}
