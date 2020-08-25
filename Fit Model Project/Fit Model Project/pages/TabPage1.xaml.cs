using Fit_Model_Project.connections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	public partial class TabPage1 : ContentPage
	{
		public workoutResult workout = new workoutResult();
		public TabPage1()
		{
			InitializeComponent();
			getVideos();
		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new ZavtrakiPage(), false);
		}

		private async void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new ZavtrakiPage(), false);
		}

		private async void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new ZavtrakiPage(), false);
		}

		private async void TapGestureRecognizer_Tapped_3(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new ZavtrakiPage(), false);
		}
		public async void getVideos()
		{
			try
			{
				string token = SecureStorage.GetAsync("token").Result;
				string temp = @"https://fitmodelproject.ee/wp-json/wp/v2/";
				string temp1 = "workout/";
				string temp2 = "list?";
				string param1 = "token=";
				string value1 = token;
				string sb2 = temp + temp1 + temp2 + param1 + value1;
				HttpClient client2 = new HttpClient();
				HttpResponseMessage response2 = await client2.GetAsync(sb2);
				string json5 = await response2.Content.ReadAsStringAsync();
				JObject o = JObject.Parse(json5);
				workout = JsonConvert.DeserializeObject<workoutResult>(o.ToString());
			}
			catch (Exception exp)
			{
				await DisplayAlert("get about error", exp.Message, "Ok");
			}
		}
		private async void TapGestureRecognizer_Tapped_4(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new videosPage(workout.workouts[0]), false);
		}

		private async void TapGestureRecognizer_Tapped_5(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new NewPojSoonPage(), false);
		}
	}
}