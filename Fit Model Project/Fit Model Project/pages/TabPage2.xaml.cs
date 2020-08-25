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
	public partial class TabPage2 : ContentPage
	{
		public List<abautPost> temp1List = new List<abautPost>();
		public List<abautPost> temp2List = new List<abautPost>();
		public TabPage2()
		{
			InitializeComponent();
			getAbout();
			getReviews();
		}
		public async void getAbout()
		{
			try
			{
				string token = SecureStorage.GetAsync("token").Result;
				string temp = @"https://fitmodelproject.ee/wp-json/wp/v2/";
				string temp1 = "info/";
				string temp2 = "about?";
				string param1 = "token=";
				string value1 = token;
				string sb2 = temp + temp1 + temp2 + param1 + value1;
				HttpClient client2 = new HttpClient();
				HttpResponseMessage response2 = await client2.GetAsync(sb2);
				string json5 = await response2.Content.ReadAsStringAsync();
				JObject o = JObject.Parse(json5);
				var result = JsonConvert.DeserializeObject<infoAboutResult>(o.ToString());
				temp1List = result.posts;
				aboutList.ItemsSource = null;
				aboutList.ItemsSource = result.posts;
			}
			catch (Exception exp)
			{
				await DisplayAlert("get about error", exp.Message, "Ok");
			}
		}
		public async void getReviews()
		{
			try
			{
				string token = SecureStorage.GetAsync("token").Result;
				string temp = @"https://fitmodelproject.ee/wp-json/wp/v2/";
				string temp1 = "info/";
				string temp2 = "reviews?";
				string param1 = "token=";
				string value1 = token;
				string sb2 = temp + temp1 + temp2 + param1 + value1;
				HttpClient client2 = new HttpClient();
				HttpResponseMessage response2 = await client2.GetAsync(sb2);
				string json5 = await response2.Content.ReadAsStringAsync();
				JObject o = JObject.Parse(json5);
				var result = JsonConvert.DeserializeObject<reviewsResult>(o.ToString());
				temp2List = result.reviews;
			}
			catch (Exception exp)
			{
				await DisplayAlert("get about error", exp.Message, "Ok");
			}
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			if(but1.BackgroundColor == Color.Transparent)
			{
				but1.BackgroundColor = Color.FromHex("#C63C7B");
				but1.BorderColor = Color.FromHex("#C63C7B");
				but2.BackgroundColor = Color.Transparent;
				but2.BorderColor = Color.White;
				aboutList.ItemsSource = null;
				aboutList.ItemsSource = temp1List;
			}
		}

		private void Button_Clicked_1(object sender, EventArgs e)
		{
			if(but2.BackgroundColor == Color.Transparent)
			{
				but2.BackgroundColor = Color.FromHex("#C63C7B");
				but2.BorderColor = Color.FromHex("#C63C7B");
				but1.BackgroundColor = Color.Transparent;
				but1.BorderColor = Color.White;
				aboutList.ItemsSource = null;
				aboutList.ItemsSource = temp2List;
			}
		}

		private void aboutList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NewPojSoonPage(), false);
		}
	}
}