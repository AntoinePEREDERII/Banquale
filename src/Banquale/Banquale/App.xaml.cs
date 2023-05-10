using Banquale.Model;
using Banquale.Stub;
namespace Banquale;

public partial class App : Application
{

	public Manager MyManager { get; private set; } = new Manager(new Stub.Stub()/*DataContractPersistance.DataContractPers()*/);

	

	public App()
	{

        MyManager.ChargeDonnee();
		//MyManager.Persistance = new DataContractPersistance.DataContractPers();
		//MyManager.SauvegardeDonnee();

        InitializeComponent();

		MainPage = new AppShell();

	}
}

