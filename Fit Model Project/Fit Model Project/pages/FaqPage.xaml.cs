using Fit_Model_Project.connections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fit_Model_Project.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FaqPage : ContentPage
	{
		public FaqPage(faqResult fr)
		{
			InitializeComponent();
			faqList.ItemsSource = null;
			faqList.ItemsSource = fr.faqs;
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
		private void faqList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}
	}
}