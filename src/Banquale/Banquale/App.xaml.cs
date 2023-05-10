using Banquale.Model;
using Banquale.Stub;
using Banquale.DataContractPersistance;
namespace Banquale;

public partial class App : Application
{

	public Manager MyManager { get; private set; } = new Manager(new Stub.Stub());

	

	public App()
	{

		MyManager.ChargeDonnee();
		MyManager.Persistance = new DataContractPersistance.DataContractPers();
		MyManager.SauvegardeDonnee();

		InitializeComponent();

		MainPage = new AppShell();

	}
}

