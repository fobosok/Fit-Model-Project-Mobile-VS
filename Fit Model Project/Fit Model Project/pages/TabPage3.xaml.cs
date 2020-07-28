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
	public partial class TabPage3 : ContentPage
	{
		public List<articlePost> temp1List = new List<articlePost>();
		public List<articlePost> temp2List = new List<articlePost>();
		public faqResult fr = new faqResult();
		public TabPage3()
		{
			InitializeComponent();
			getArticlesNew();
			getArticlesArchive();
			getFaqs();
		}
		public async void getArticlesNew()
		{
			try
			{
				string token = SecureStorage.GetAsync("token").Result;
				string temp = @"https://fitmodelproject.ee/wp-json/wp/v2/";
				string temp1 = "articles/";
				string temp2 = "new?";
				string param1 = "token=";
				string value1 = token;
				string sb2 = temp + temp1 + temp2 + param1 + value1;
				HttpClient client2 = new HttpClient();
				HttpResponseMessage response2 = await client2.GetAsync(sb2);
				string json5 = await response2.Content.ReadAsStringAsync();
				JObject o = JObject.Parse(json5);
				var result = JsonConvert.DeserializeObject<articlesResult>(o.ToString());
				temp1List = result.articles;
				articlesList.ItemsSource = null;
				articlesList.ItemsSource = result.articles;
			}
			catch (Exception exp)
			{
				
			}
		}
		public async void getArticlesArchive()
		{
			try
			{
				string token = SecureStorage.GetAsync("token").Result;
				string temp = @"https://fitmodelproject.ee/wp-json/wp/v2/";
				string temp1 = "articles/";
				string temp2 = "archive?";
				string param1 = "token=";
				string value1 = token;
				string sb2 = temp + temp1 + temp2 + param1 + value1;
				HttpClient client2 = new HttpClient();
				HttpResponseMessage response2 = await client2.GetAsync(sb2);
				string json5 = await response2.Content.ReadAsStringAsync();
				JObject o = JObject.Parse(json5);
				var result = JsonConvert.DeserializeObject<articlesResult>(o.ToString());
				temp2List = result.articles;
			}
			catch (Exception exp)
			{

			}
		}
		public async void getFaqs()
		{
			try
			{
				string token = SecureStorage.GetAsync("token").Result;
				string temp = @"https://fitmodelproject.ee/wp-json/wp/v2/";
				string temp1 = "articles/";
				string temp2 = "faqs?";
				string param1 = "token=";
				string value1 = token;
				string sb2 = temp + temp1 + temp2 + param1 + value1;
				HttpClient client2 = new HttpClient();
				HttpResponseMessage response2 = await client2.GetAsync(sb2);
				string json5 = await response2.Content.ReadAsStringAsync();
				JObject o = JObject.Parse(json5);
				fr = JsonConvert.DeserializeObject<faqResult>(o.ToString());
			}
			catch (Exception exp)
			{
			}
		}
		private void but1_Clicked(object sender, EventArgs e)
		{
			if (but1.BackgroundColor == Color.Transparent)
			{
				but1.BackgroundColor = Color.FromHex("#C63C7B");
				but1.BorderColor = Color.FromHex("#C63C7B");
				but2.BackgroundColor = Color.Transparent;
				but2.BorderColor = Color.White;
				articlesList.ItemsSource = null;
				articlesList.ItemsSource = temp1List;
			}
		}

		private void but2_Clicked(object sender, EventArgs e)
		{
			if (but2.BackgroundColor == Color.Transparent)
			{
				but2.BackgroundColor = Color.FromHex("#C63C7B");
				but2.BorderColor = Color.FromHex("#C63C7B");
				but1.BackgroundColor = Color.Transparent;
				but1.BorderColor = Color.White;
				articlesList.ItemsSource = null;
				articlesList.ItemsSource = temp2List;
			}
		}

		private async void but3_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new FaqPage(fr), false);
		}

		private void articlesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}
	}
}