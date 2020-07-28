using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fit_Model_Project.pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartTabbedPage : TabbedPage
	{
		public StartTabbedPage()
		{
			InitializeComponent();
			Children.Add(new TabPage1 { IconImageSource = "TabIcon1.png", Title = "Главная" });
			Children.Add(new TabPage2 { IconImageSource = "TabIcon2.png", Title = "Инфо" });
			Children.Add(new TabPage3 { IconImageSource = "TabIcon3.png", Title = "Статьи" });
			Children.Add(new TabPage4 { IconImageSource = "TabIcon4.png", Title = "Соц Сети" });
			Children.Add(new TabPage5 { IconImageSource = "TabIcon5.png", Title = "Профиль" });
		}
	}
}