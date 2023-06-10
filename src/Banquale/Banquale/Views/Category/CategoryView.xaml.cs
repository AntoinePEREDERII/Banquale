using Model;

namespace Banquale.Views.Category
{
    /// <summary>
    /// Vue partielle pour afficher les différentes catégories.
    /// </summary>
    public partial class CategoryView : ContentView
    {
        public Manager Mgr => (App.Current as App).MyManager;

        /// <summary>
        /// Constructeur de la vue CategoryView.
        /// </summary>
        public CategoryView()
        {
            InitializeComponent();
            BindingContext = Mgr;
        }

        /// <summary>
        /// Gère l'événement de clic sur une catégorie.
        /// </summary>
        public async void Category_Clicked(object sender, EventArgs e)
        {
            var selectedItem = (sender as Grid)?.BindingContext as string;

            if (selectedItem != null)
            {
                Mgr.SelectedTransaction.ChangeCategory(selectedItem);
                Mgr.Persistence.DataSave(Mgr.CustomersList, Mgr.Consultant);
                await Shell.Current.Navigation.PopAsync();
            }
        }
    }
}
