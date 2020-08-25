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
	public partial class LoginPage : ContentPage
	{
	public LoginPage()
		{
			InitializeComponent();
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new RegistrPage(), false);
		}

		private async void Button_Clicked_1(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new PasswordRecoveryPage(), false);
		}

		private async void Button_Clicked_2(object sender, EventArgs e)
		{
			actInd.HeightRequest = 100;
			actInd.IsRunning = true;
			loginPageAll.IsVisible = false;
			try
			{
				string login = loginEntry.Text;
				string pass = passwordEntry.Text;
				string temp = @"https://fitmodelproject.ee/wp-json/wp/v2/";
				string temp1 = "users/";
				string temp2 = "login?";
				string param1 = "email=";
				string value1 = login+"&";
				string param2 = "password=";
				string value2 = pass;
				string sb2 = temp + temp1 + temp2 + param1 + value1 + param2 + value2;
				HttpClient client2 = new HttpClient();
				HttpResponseMessage response2 = await client2.PostAsync(sb2, new MultipartFormDataContent());
				string json5 = await response2.Content.ReadAsStringAsync();
				JObject o = JObject.Parse(json5);
				var result = JsonConvert.DeserializeObject<serverResult>(o.ToString());
				await SecureStorage.SetAsync("token", result.token);
				await SecureStorage.SetAsync("login", "yes");
				App.Current.MainPage = new syncTab();
			}
			catch (Exception exp)
			{
				await DisplayAlert("login error", exp.Message, "1");
			}
			finally
			{
				actInd.HeightRequest = 0;
			}
		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NewPojSoonPage(), false);
		}
	}
}