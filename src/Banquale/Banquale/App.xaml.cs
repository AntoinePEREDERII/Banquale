﻿using Banquale.Model;
namespace Banquale;

public partial class App : Application
{

	public Manager MyManager { get; private set; } = new Manager();

	

	public App()
	{

        MyManager.Donnee();

        InitializeComponent();

		MainPage = new AppShell();

	}
}

