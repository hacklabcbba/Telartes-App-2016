using System.Threading.Tasks;

using Xamarin.Forms;

namespace Telartes
{
	public partial class StartupScreen : ContentPage
	{
		public StartupScreen()
		{
			InitializeComponent();
			Image image = new Image
			{
				Source = new FileImageSource
				{


					File = Device.OnPlatform(iOS: "",
										 Android: "logo_start.png",
										 WinPhone: "")
				},

				HorizontalOptions = LayoutOptions.Center,
				WidthRequest = 200


			};

			Content = image;
		}

		protected override void OnAppearing()
		{
			NavigationPage.SetHasNavigationBar(this, false);    //Para hacer deshaparecer el toolbar

			base.OnAppearing();

			DelayedNaviagition(); //visualiza el logo por x segundos
		}

		private async void DelayedNaviagition()
		{
			await Task.Delay(Constants.WAIT_TIME);
			await Navigation.PushAsync(new MainPage());
		}
	}
}

