using Model;

namespace Banquale.Views.Category
{
    /// <summary>
    /// Page de catégorie.
    /// </summary>
    public partial class CategoryPage : ContentPage
    {
        public Manager Mgr => (App.Current as App).MyManager;

        /// <summary>
        /// Constructeur de la page CategoryPage.
        /// </summary>
        public CategoryPage()
        {
            InitializeComponent();
        }
    }
}
