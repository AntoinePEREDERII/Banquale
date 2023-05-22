﻿using Banquale.Model;
namespace Banquale.Views;


public partial class BalancePage : ContentPage
{
	//public Manager Mgr { get; private set; } = new Manager();

    public BalancePage()
	{
		InitializeComponent();
		BindingContext = new Account(999, "Tatouille", "FR76 9161 9581 6296 8415 2361 004"); ;
	}

	public async void OnButtonClicked(object sender, EventArgs e)
	{
		await Shell.Current.Navigation.PushAsync(new NewPage1());
	}

}
