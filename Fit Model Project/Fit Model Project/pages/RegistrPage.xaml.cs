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
	public partial class RegistrPage : ContentPage
	{
		public RegistrPage()
		{
			InitializeComponent();
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync(false);
		}

		private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			if(checkBox.IsChecked == false)
			{
				checkBox.IsChecked = true;
			}
			else
			{
				checkBox.IsChecked = false;
			}
		}
		protected override bool OnBackButtonPressed()
		{
			return true;
		}
	}
}