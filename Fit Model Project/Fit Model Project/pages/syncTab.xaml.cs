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
	public partial class syncTab : ContentPage
	{
		public workoutResult workout = new workoutResult();
		public List<abautPost> temp1List = new List<abautPost>();
		public List<abautPost> temp2List = new List<abautPost>();
		public List<articlePost> temp1List2 = new List<articlePost>();
		public List<articlePost> temp2List2 = new List<articlePost>();
		public faqResult fr = new faqResult();
		public syncTab()
		{
			InitializeComponent();
			getVideos();
			getAbout();
			getReviews();
			getArticlesNew();
			getArticlesArchive();
			getFaqs();
			getUser();
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
			if (but1.BackgroundColor == Color.Transparent)
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
			if (but2.BackgroundColor == Color.Transparent)
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
				temp1List2 = result.articles;
				articlesList.ItemsSource = null;
				articlesList.ItemsSource = result.articles;
			}
			catch
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
				temp2List2 = result.articles;
			}
			catch
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
			catch
			{
			}
		}
		private void but1_Clicked(object sender, EventArgs e)
		{
			if (but11.BackgroundColor == Color.Transparent)
			{
				but11.BackgroundColor = Color.FromHex("#C63C7B");
				but11.BorderColor = Color.FromHex("#C63C7B");
				but22.BackgroundColor = Color.Transparent;
				but22.BorderColor = Color.White;
				articlesList.ItemsSource = null;
				articlesList.ItemsSource = temp1List2;
			}
		}

		private void but2_Clicked(object sender, EventArgs e)
		{
			if (but22.BackgroundColor == Color.Transparent)
			{
				but22.BackgroundColor = Color.FromHex("#C63C7B");
				but22.BorderColor = Color.FromHex("#C63C7B");
				but11.BackgroundColor = Color.Transparent;
				but11.BorderColor = Color.White;
				articlesList.ItemsSource = null;
				articlesList.ItemsSource = temp2List2;
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


		private async void TapGestureRecognizer_Tapped_6(object sender, EventArgs e)
		{
			await Browser.OpenAsync(@"https://www.instagram.com/fitmodelprojectestonia_rus/", BrowserLaunchMode.SystemPreferred);
		}

		private async void TapGestureRecognizer_Tapped_7(object sender, EventArgs e)
		{
			await Browser.OpenAsync(@"https://www.facebook.com/FitModelProject", BrowserLaunchMode.SystemPreferred);
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
					if (result.user.subscribe_app_status == "0")
					{
						statusLabel.Text = "Неактивна";
						statusLabel.TextColor = Color.FromHex("#DC143C");
					dateLabel.Text = "не продлевается";
					but111.Text = "Оформить подписку";
					but222.IsEnabled = false;
					but222.IsVisible = false;
				}
				else
				{
					statusLabel.Text = "Активна";
					statusLabel.TextColor = Color.FromHex("#32CD32");
					dateLabel.Text = result.user.subscribe_app_date;
					but111.Text = "Изменить тариф";
					but222.IsEnabled = true;
					but222.IsVisible = true;
				}
			}
			catch
			{

			}
		}
		private async void ib_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new EditPage(), false);
		}





		private async void but111_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new subscribePage(), false);
		}

		private void but222_Clicked(object sender, EventArgs e)
		{

		}

		private async void TapGestureRecognizer_Tapped_8(object sender, EventArgs e)
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
			catch
			{

			}
		}
	}
}