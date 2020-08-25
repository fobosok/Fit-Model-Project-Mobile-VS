using Fit_Model_Project.pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Fit_Model_Project
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{
		public int i = 0;
		public MainPage()
		{
			InitializeComponent();
		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			await SecureStorage.SetAsync("started", "yes");
			await Navigation.PushAsync(new LoginPage(), false);
		}

		private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
		{
			i++;
			if(i == 1)
			{
				onbImage.Source = null;
				onbImage.Source = "onb2_min.jpg";

				lab1.Text = "Питаемся правильно";
				lab2.Text = "Мы подобрали для вас лучшие";
				lab3.Text = "рецепты и программы питания чтобы";
				lab4.Text = "всегда оставаться в форме";

				dots.Source = null;
				dots.Source = "dots2";
			}
			else if(i == 2)
			{
				onbImage.Source = null;
				onbImage.Source = "onb3_min.jpg";

				lab1.Text = "Питаемся правильно";
				lab2.Text = "Мы подобрали для вас лучшие";
				lab3.Text = "рецепты и программы питания чтобы";
				lab4.Text = "всегда оставаться в форме";

				dots.Source = null;
				dots.Source = "dots3";
			}
			else if (i == 3)
			{
				onbImage.Source = null;
				onbImage.Source = "onb4_min.jpg";

				lab1.Text = "Питаемся правильно";
				lab2.Text = "Мы подобрали для вас лучшие";
				lab3.Text = "рецепты и программы питания чтобы";
				lab4.Text = "всегда оставаться в форме";

				dots.Source = null;
				dots.Source = "dots4";
			}
		}
	}
}
