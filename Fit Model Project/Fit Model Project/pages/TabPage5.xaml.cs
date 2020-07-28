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
	public partial class TabPage5 : ContentPage
	{
		public TabPage5()
		{
			InitializeComponent();
			getUser();
		}
		public async void getUser()
		{
			try
			{
				string token = SecureStorage.GetAsync("token").Result;
				string temp = @"https://fitmodelproject.ee/wp-json/wp/v2/";
				string temp1 = "users/";
				string temp2 = "get?";
				string param1 = "token=";
				string value1 = token;
				string sb2 = temp + temp1 + temp2 + param1 + value1;
				HttpClient client2 = new HttpClient();
				HttpResponseMessage response2 = await client2.GetAsync(sb2);
				string json5 = await response2.Content.ReadAsStringAsync();
				JObject o = JObject.Parse(json5);
				var result = JsonConvert.DeserializeObject<userInfoResult>(o.ToString());
				nameLabel.Text = result.user.first_name;
				surenameLabel.Text = result.user.last_name;
				emailLabel.Text = result.user.email;
				if(result.user.subscribe_app_status == "0")
				{
					statusLabel.Text = "Неактивна";
					statusLabel.TextColor = Color.FromHex("#DC143C");
					dateLabel.Text = "не продлевается";
					but1.Text = "Оформить подписку";
					but2.IsEnabled = false;
					but2.IsVisible = false;
				}
				else
				{
					statusLabel.Text = "Активна";
					statusLabel.TextColor = Color.FromHex("#32CD32");
					dateLabel.Text = result.user.subscribe_app_date;
					but1.Text = "Изменить тариф";
					but2.IsEnabled = true;
					but2.IsVisible = true;
				}
			}
			catch (Exception exp)
			{
				
			}
		}
		private async void ib_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new EditPage(), false);
		}

		private async void but1_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new subscribePage(), false);
		}

		private void but2_Clicked(object sender, EventArgs e)
		{

		}

		private void Button_Clicked(object sender, EventArgs e)
		{

		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
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
				SecureStorage.Remove("token");
				SecureStorage.Remove("login");
				App.Current.MainPage = new NavigationPage(new LoginPage());
			}
			catch (Exception exp)
			{

			}
		}
	}
}