using Fit_Model_Project.pages;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fit_Model_Project
{
	public partial class App : Application
	{
		public App()
		{
			Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjkxMDQ2QDMxMzgyZTMyMmUzMFFnelRZbzVFYktodnNIVi9kUnpxU2VJZmdrT0FMVk9XTksyMjdod2pVZlU9");
			InitializeComponent();
			if(SecureStorage.GetAsync("started").Result == "yes")
			{
				if(SecureStorage.GetAsync("login").Result == "yes")
				{
					MainPage = new NavigationPage(new StartTabbedPage());
				}
				else
				{
					MainPage = new NavigationPage(new LoginPage());
				}
			}
			else
			{
				MainPage = new NavigationPage(new MainPage());
			}
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
