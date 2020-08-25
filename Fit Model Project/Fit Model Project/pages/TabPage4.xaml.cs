using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fit_Model_Project.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TabPage4 : ContentPage
	{
		public TabPage4()
		{
			InitializeComponent();
		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await Browser.OpenAsync(@"https://www.instagram.com/fitmodelprojectestonia_rus/", BrowserLaunchMode.SystemPreferred);
		}

		private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
		{
			await Browser.OpenAsync(@"https://www.facebook.com/FitModelProject", BrowserLaunchMode.SystemPreferred);
		}

		private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NewPojSoonPage(), false);
		}
	}
}