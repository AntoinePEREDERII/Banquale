using Banquale.Views;
using Banquale.Views.Category;
using Banquale.Views.Transfer;
namespace Banquale;

public partial class AppShell : Shell
{
	public AppShell()
	{
        Routing.RegisterRoute("balance/categorydetails", typeof(CategoryPage));
        Routing.RegisterRoute("balance/newpagedetails", typeof(NewPage1));
        Routing.RegisterRoute("menu/requestdetails", typeof(RequestPage));
        Routing.RegisterRoute("menu/ribdetails", typeof(RibPage));
        Routing.RegisterRoute("menu/transferdetails", typeof(TransferPage));
        Routing.RegisterRoute("connection/consultant", typeof(ConsultantHomePage));
        Routing.RegisterRoute("consultant/idpage", typeof(ConsultantIdPage));
        Routing.RegisterRoute("consultant/createcustomer", typeof(CreateCustomerPage));
        InitializeComponent();
        
    }
}