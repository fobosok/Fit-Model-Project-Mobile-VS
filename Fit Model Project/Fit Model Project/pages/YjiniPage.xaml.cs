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
	public partial class YjiniPage : ContentPage
	{
		public YjiniPage()
		{
			InitializeComponent();
		}

		private async void ib_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync(false);
		}
		protected override bool OnBackButtonPressed()
		{
			ib.PropagateUpClicked();
			return true;
		}
	}
}