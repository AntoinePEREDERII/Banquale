using Model;

namespace Banquale.Views;

/// <summary>
/// Page d'aide permettant aux utilisateurs d'envoyer des messages de demande d'aide.
/// </summary>
public partial class HelpPage : ContentPage
{
    /// <summary>
    /// Obtient le gestionnaire de l'application à partir de l'instance de l'application.
    /// </summary>
    public Manager Mgr => (App.Current as App).MyManager;

    /// <summary>
    /// Initialise une nouvelle instance de la classe HelpPage.
    /// </summary>
    public HelpPage()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Gère l'événement du bouton d'envoi.
    /// </summary>
    public async void Send_Clicked(Object sender, EventArgs e)
    {
        if (Subject.Text.Length >= 50 || Description.Text.Length >= 200)
        {
            await DisplayAlert("Erreur", "Trop de caractères", "OK");
        }
        else
        {
            // Crée un nouveau message de demande d'aide
            Message message = Account.AskForHelp(Subject.Text, Description.Text);

            // Ajoute le message à la liste des messages du consultant
            Mgr.Consultant.MessagesList.Add(message);

            // Navigue vers la page de solde
            await Shell.Current.GoToAsync("//balance");
        }
    }
}

