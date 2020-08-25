using Fit_Model_Project.connections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

		private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NewPojSoonPage(), false);
		}

		private async void SfButton_Clicked(object sender, EventArgs e)
		{
			try
			{
				string firstName = firstNameEntry.Text;
				string lastName = lastNameEntry.Text;
				string email = emailEntry.Text;
				string pass = passwordEntry.Text;
				string temp = @"https://fitmodelproject.ee/wp-json/wp/v2/";
				string temp1 = "users/";
				string temp2 = "register?";
				string param1 = "first_name=";
				string value1 = firstName + "&";
				string param2 = "last_name=";
				string value2 = lastName + "&";
				string param3 = "email=";
				string value3 = email + "&";
				string param4 = "password=";
				string value4 = pass + "&";
				string param5 = "subscribe_news_status=";
				string value5 = checkBox.IsChecked.ToString();
				string sb2 = temp + temp1 + temp2 + param1 + value1 + param2 + value2 + param3 + value3 + param4 + value4 + param5 + value5;
				HttpClient client2 = new HttpClient();
				HttpResponseMessage response2 = await client2.PostAsync(sb2, new MultipartFormDataContent());
				string json5 = await response2.Content.ReadAsStringAsync();
				JObject o = JObject.Parse(json5);
				var result = JsonConvert.DeserializeObject<serverResult>(o.ToString());
				await DisplayAlert(null, result.message, "ok");
			}
			catch 
			{
				
			}

		}
	}
}