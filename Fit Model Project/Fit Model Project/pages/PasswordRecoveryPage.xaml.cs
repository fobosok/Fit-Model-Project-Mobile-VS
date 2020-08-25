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
	public partial class PasswordRecoveryPage : ContentPage
	{
		public PasswordRecoveryPage()
		{
			InitializeComponent();
		}

		private async void ImageButton_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync(false);
		}

		protected override bool OnBackButtonPressed()
		{
			ib.PropagateUpClicked();
			return true;
		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NewPojSoonPage(), false);
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			try
			{
				string email = emailEntry.Text;
				string temp = @"https://fitmodelproject.ee/wp-json/wp/v2/";
				string temp1 = "users/";
				string temp2 = "restore?";
				string param1 = "email=";
				string value1 = email;
				string sb2 = temp + temp1 + temp2 + param1 + value1;
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