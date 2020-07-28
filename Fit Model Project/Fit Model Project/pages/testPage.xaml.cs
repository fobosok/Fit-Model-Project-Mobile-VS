using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fit_Model_Project.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class testPage : ContentPage
	{
		public testPage(string url)
		{
			InitializeComponent();
			player.Source = url;

		}
		protected override void OnAppearing()
		{
			base.OnAppearing();
			MessagingCenter.Send(this, "allowLandScapePortrait");

	  }
		//during page close setting back to portrait
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			MessagingCenter.Send(this, "preventLandScape");
		}
	}
}