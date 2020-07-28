using Fit_Model_Project.connections;
using MediaManager;
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
	public partial class videosPage : ContentPage
	{
		public workoutPost workoutPost = new workoutPost();
		public videosPage(workoutPost workoutPost)
		{
			InitializeComponent();
			this.workoutPost = workoutPost;
			try
			{
				foreach (var item in workoutPost.free)
				{
					if (item.is_viewed == "0")
					{
						item.imageSource = "watched.png";
					}
				}
				freeList.ItemsSource = null;
				freeList.ItemsSource = workoutPost.free;
				freeListStack.HeightRequest = workoutPost.free.Count * 138;
			}
			catch
			{
				freeListStack.HeightRequest = 0;
			}
			try
			{
				foreach(var item in workoutPost.paid)
				{
					if(item.is_viewed == "0")
					{
						item.imageSource = "notwatched.png";
					}
				}
				paidList.ItemsSource = null;
				paidList.ItemsSource = workoutPost.paid;
				paidListStack.HeightRequest = workoutPost.paid.Count * 138;
			}
			catch
			{
				paidListStack.HeightRequest = 0;
			}

		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			string video_url = (((sender as Frame).Content as StackLayout).Children[3] as Label).Text;
			await Navigation.PushModalAsync(new testPage(video_url), false);
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
		private void freeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
		}
	}
}