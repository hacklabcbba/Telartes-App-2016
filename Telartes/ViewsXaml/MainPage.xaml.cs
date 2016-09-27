using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Telartes
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			//se inicializan los botones, textbox, etc.
			InitializeViews();

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			var mainPage = Navigation.NavigationStack[0];
			if (typeof(MainPage) == mainPage.GetType()) return;
			Navigation.RemovePage(mainPage);

			//NavigationPage.SetHasNavigationBar(this, false); //para deshabilitar el toolbar
		}

		void OnCallButtonClicked(object sender, EventArgs args)
		{
			App.refresh_calllist = true; //Se conecta con el web server para refrescar los datos
			Navigation.PushAsync(new CallListPage());

		}

		//Se inicializan las views con las constantes de texto, etc. predefinidos
		private void InitializeViews()
		{
			btnNews.Text = Resx.AppResources.News;
			btnCulturalAgenda.Text = Resx.AppResources.CulturalAgenda;
			//btnCalls.Text = Resx.AppResources.Calls;


		}

		//Click sobre el menu (ToolBar)
		void OnToolbarItemClicked(object sender, EventArgs args)
		{
			ToolbarItem ti = (ToolbarItem)sender;
			if (ti.Text != "")
			{
				switch (ti.Text)
				{
					case Constants.INFORMACION:
						var tMenu = new Toolbar_Menu_Info();
						Navigation.PushAsync(tMenu);
						break;
					case Constants.NOTICIAS:
						var tnews = new Toolbar_Menu_News();
						Navigation.PushAsync(tnews);
						break;
					case Constants.AGENDA_CULTURAL:
						var tagn = new Toolbar_Menu_Agenda();
						Navigation.PushAsync(tagn);
						break;
					case Constants.CONVOCATORIAS:
						var tcnv = new Toolbar_Menu_Call();
						Navigation.PushAsync(tcnv);
						break;
					case Constants.AJUSTES:
						var tajs = new Toolbar_Menu_Settings();
						Navigation.PushAsync(tajs);
						break;
					case Constants.NOTIFICACIONES:
						var tntf = new Toolbar_Menu_Notices();
						Navigation.PushAsync(tntf);
						break;
					default:
						break;
				}
			}
		}
	}
}

