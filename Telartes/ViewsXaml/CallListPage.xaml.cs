using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace Telartes
{
	public partial class CallListPage : ContentPage
	{
		public CallListPage()
		{
			InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();


			bool answer = false;

			if (App.refresh_calllist)
			{
				//Control de la conexión
				EConnection ec = App.Connection_state();

				switch (ec)
				{
					case EConnection.not_defined:
						await DisplayAlert(Resx.AppResources.Connection_Msg_Title, Resx.AppResources.Connection_Msg_No_Connection, Resx.AppResources.Connection_Msg_OK);
						break;
					case EConnection.no_connection:
						await DisplayAlert(Resx.AppResources.Connection_Msg_Title, Resx.AppResources.Connection_Msg_No_Connection, Resx.AppResources.Connection_Msg_OK);
						break;
					case EConnection.OTHERS:
						answer = await DisplayAlert(Resx.AppResources.Connection_Msg_Title, Resx.AppResources.Connection_Msg_Confirm_Connection, Resx.AppResources.Connection_Msg_YES, Resx.AppResources.Connection_Msg_NO);
						break;
					case EConnection.WIFI:
						//esto hay que cambiarlo, solo para pruebas
						//answer = await DisplayAlert(Resx.AppResources.Connection_Msg_Title, "Esta conectado al WiFi", "Si", "No");
						answer = true;
						break;
				}
			}

			//Conexión con el Web Server
			if (answer == true)
			{
				CallItem itm = new CallItem();

				try
				{
					//Rueda de espera infinita
					activityIndicator.IsRunning = true;
					activityIndicator.HeightRequest = 50;


					//Descarga de los datos desde el Wer Server
					List<CallItem> iList = await App.Manager.GetTasksAsync(Constants.REST_CALL_URL, itm);

					//Rueda de espera infinita
					activityIndicator.IsRunning = false;
					activityIndicator.HeightRequest = 0;

					//Envio de los datos en el DB SQLite
					if (iList.Count != 0)
					{
						//Borrar los datos antiguos
						App.Database.DeleteAllItems(itm);

						//Actualizar la base de datos con los nuevos datos
						foreach (CallItem ci in iList)
						{
							App.Database.SaveItem(ci);
						}
					}
				}
				//Si no se ha podido conectar al servidor aparecerá un mensaje de error
				catch (Exception e)
				{
					await DisplayAlert(Resx.AppResources.Connection_Msg_Title, e.Message, Resx.AppResources.Connection_Msg_OK);

					//Rueda de espera infinita
					activityIndicator.IsRunning = false;
					activityIndicator.HeightRequest = 0;
				}
			}

			//Carga los datos de de la base de datos
			IEnumerable<CallItem> cis = null;

			if (App.call_filter.Todas)
			{
				//Visualización de los filtros activos
				lblFiltros.Text = get_active_filters();

				try
				{
					cis = App.Database.GetItems();    //Se cargan todos los datos

					//Se actualiza la lista si hay items memorizados en la BD
					if (cis != null && cis.Count() != 0)
					{
						listView.ItemsSource = null;
						listView.ItemsSource = cis;
					}
					else
					{
						await DisplayAlert("Atención", "Ningún elemento memorizado en la base de datos.", "OK");
						listView.ItemsSource = null;
					}

				}
				catch (Exception ex)
				{
					await DisplayAlert("Error", ex.Message, "OK");
				}
			}
			else //Se cargan solo los datos segun los filtros
			{
				//Visualización de los filtros activos
				lblFiltros.Text = get_active_filters();

				//Se forma la string SQL
				string sql_string = "SELECT * FROM CallItem WHERE ";
				string categoria_str = get_sql_filter();

				try
				{
					if (categoria_str != "")
					{
						sql_string += categoria_str;
						cis = App.Database.GetItems(sql_string);

						//Se actualiza la lista si hay items memorizados en la BD
						if (cis != null && cis.Count() != 0)
						{
							listView.ItemsSource = null;
							listView.ItemsSource = cis;
						}
						else
						{
							await DisplayAlert("Atención", "Ningún elemento de los memorizados en la base de datos coincide con la búsqueda.", "OK");
							listView.ItemsSource = null;
						}
					}

				}
				catch (Exception ex)
				{
					await DisplayAlert("Error", ex.Message, "OK");
				}

			}

		}

		void OnAddItemClicked(object sender, EventArgs e)
		{
			var cItem = new CallItem()
			{
				node_title = Guid.NewGuid().ToString()
			};
			var cPage = new CallItemPage(cItem, true);
			cPage.BindingContext = cItem;
			Navigation.PushAsync(cPage);
		}

		//Cuando se selecciona un item se pasa el context
		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var todoItem = e.SelectedItem as CallItem;
			var todoPage = new CallItemPage(todoItem);
			todoPage.BindingContext = todoItem;
			Navigation.PushAsync(todoPage);

		}

		//Click sobre el menu (ToolBar)
		void OnToolbarItemClicked(object sender, EventArgs args)
		{
			//Desactiva el refresh con conexión al servidor web
			App.refresh_calllist = false;

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

		//String de controls para la selección en el SQL segun los filtros activos
		private string get_sql_filter()
		{
			string cat_str = "";


			if (App.call_filter.Concurso)
				cat_str = "categoria LIKE '%oncurs%'";
			if (App.call_filter.Movilidad)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " categoria LIKE '%movilida%'" : cat_str + "categoria LIKE '%movilidad%'";
			if (App.call_filter.Oportunidad_de_trabajo)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " categoria LIKE '%oportunidad%de%trabajo%'" : cat_str + "categoria LIKE '%portunidad%de%trabajo%'";
			if (App.call_filter.Proyecto)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " categoria LIKE '%proyecto%'" : cat_str + "categoria LIKE '%proyecto%'";

			//Filtro por departamento
			if (App.call_filter.Internacional)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " Ciudad LIKE '%internacional%'" : cat_str + "Ciudad LIKE '%internacional%'";
			if (App.call_filter.Nacional)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " Ciudad LIKE '%nacional%'" : cat_str + "Ciudad LIKE '%nacional%'";
			if (App.call_filter.Beni)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " Ciudad LIKE '%beni%'" : cat_str + "Ciudad LIKE '%beni%'";
			if (App.call_filter.Cochabamba)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " Ciudad LIKE '%cochabamba%'" : cat_str + "Ciudad LIKE '%cochabamba%'";
			if (App.call_filter.La_paz)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " Ciudad LIKE '%la%paz%'" : cat_str + "Ciudad LIKE '%la%paz%'";
			if (App.call_filter.Oruro)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " Ciudad LIKE '%oruro%'" : cat_str + "Ciudad LIKE '%oruro%'";
			if (App.call_filter.Pando)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " Ciudad LIKE '%pando%'" : cat_str + "Ciudad LIKE '%pando%'";
			if (App.call_filter.Potosi)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " Ciudad LIKE '%potosi%'" : cat_str + "Ciudad LIKE '%potosi%'";
			if (App.call_filter.Santa_cruz)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " Ciudad LIKE '%santa%cruz%'" : cat_str + "Ciudad LIKE '%santa%cruz%'";
			if (App.call_filter.Sucre)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " Ciudad LIKE '%sucre%'" : cat_str + "Ciudad LIKE '%sucre%'";
			if (App.call_filter.Tarija)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " Ciudad LIKE '%tarija%'" : cat_str + "Ciudad LIKE '%tarija%'";


			//Filtrar por campos
			if (App.call_filter.Cultura_viva_comunitaria)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " campos LIKE '%cultura%viva%comunitaria%'" : cat_str + "campos LIKE '%cultura%viva%comunitaria%'";
			if (App.call_filter.Cultura_de_red)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " campos LIKE '%cultura%de%red%'" : cat_str + "campos LIKE '%cultura%de%red%'";
			if (App.call_filter.Incidencia)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " campos LIKE '%incidencia%'" : cat_str + "campos LIKE '%incidencia%'";
			if (App.call_filter.Formacion)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " campos LIKE '%formaci%'" : cat_str + "campos LIKE '%formaci%'";
			if (App.call_filter.Sostenibilidad)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " campos LIKE '%sostenibilidad%'" : cat_str + "campos LIKE '%sostenibilidad%'";
			if (App.call_filter.Comunicacion)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " campos LIKE '%comunicaci%'" : cat_str + "campos LIKE '%comunicaci%'";
			if (App.call_filter.Circulacion_cultural)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " campos LIKE '%circulaci%cultural%'" : cat_str + "campos LIKE '%circulaci%cultural%'";


			//Filtrar por areas
			if (App.call_filter.Cultura_libre)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%cultura%libre%'" : cat_str + "areas LIKE '%cultura%libre%'";
			if (App.call_filter.Investigacion)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%investigaci%'" : cat_str + "areas LIKE '%investigaci%'";
			if (App.call_filter.Literarias)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%literarias%'" : cat_str + "areas LIKE '%literarias%'";
			if (App.call_filter.Musicales)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%musicales%'" : cat_str + "areas LIKE '%musicales%'";
			if (App.call_filter.Escenicas_danza)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%escenicas%danza%'" : cat_str + "areas LIKE '%escenicas%danza%'";
			if (App.call_filter.Visuales)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%visuales%'" : cat_str + "areas LIKE '%visuales%'";
			if (App.call_filter.Patrimonio_cultural_inmaterial)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%patrimonio cultural inmaterial%'" : cat_str + "areas LIKE '%patrimonio cultural inmaterial%'";
			if (App.call_filter.Plasticas)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%plasticas%'" : cat_str + "areas LIKE '%plasticas%'";
			if (App.call_filter.Historia)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%historia%'" : cat_str + "areas LIKE '%historia%'";
			if (App.call_filter.Artes_populares)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%artes%populares%'" : cat_str + "areas LIKE '%artes%populares%'";
			if (App.call_filter.Patrimonio_cultural_material)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%patrimonio%cultural%material%'" : cat_str + "areas LIKE '%patrimonio%cultural%material%'";
			if (App.call_filter.Gestion_cultural)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%gesti%cultural%'" : cat_str + "areas LIKE '%gesti%cultural%'";
			if (App.call_filter.Arte_urbano)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%arte%urbano%'" : cat_str + "areas LIKE '%arte%urbano%'";
			if (App.call_filter.Otra)
				cat_str = cat_str != "" ? cat_str + " " + Constants.op + " areas LIKE '%otra%'" : cat_str + "areas LIKE '%otra%'";


			return cat_str;

		}


		//String para la visualización de los filtros activos
		private string get_active_filters()
		{
			string cat_str = "";

			if (App.call_filter.Todas)
				cat_str = "todas";
			else {
				if (App.call_filter.Concurso)
					cat_str = "concurso";
				if (App.call_filter.Movilidad)
					cat_str = cat_str != "" ? cat_str + " + movilidad" : cat_str + "movilidad";
				if (App.call_filter.Oportunidad_de_trabajo)
					cat_str = cat_str != "" ? cat_str + " + oportunidad de trabajo " : cat_str + "portunidad de trabajo";
				if (App.call_filter.Proyecto)
					cat_str = cat_str != "" ? cat_str + " + proyecto" : cat_str + "proyecto";

				//Filtro por departamento
				if (App.call_filter.Internacional)
					cat_str = cat_str != "" ? cat_str + " + internacional" : cat_str + "internacional";
				if (App.call_filter.Nacional)
					cat_str = cat_str != "" ? cat_str + " + nacional" : cat_str + "nacional";
				if (App.call_filter.Beni)
					cat_str = cat_str != "" ? cat_str + " + Beni'" : cat_str + "Beni";
				if (App.call_filter.Cochabamba)
					cat_str = cat_str != "" ? cat_str + " + Cochabamba" : cat_str + "Cochabamba";
				if (App.call_filter.La_paz)
					cat_str = cat_str != "" ? cat_str + " + La Paz" : cat_str + "La Paz";
				if (App.call_filter.Oruro)
					cat_str = cat_str != "" ? cat_str + " + Oruro" : cat_str + "Oruro";
				if (App.call_filter.Pando)
					cat_str = cat_str != "" ? cat_str + " + Pando" : cat_str + "Pando";
				if (App.call_filter.Potosi)
					cat_str = cat_str != "" ? cat_str + " + Potosi" : cat_str + "Potosi";
				if (App.call_filter.Santa_cruz)
					cat_str = cat_str != "" ? cat_str + " + Santa Cruz" : cat_str + "Santa Cruz";
				if (App.call_filter.Sucre)
					cat_str = cat_str != "" ? cat_str + " + Sucre" : cat_str + "Sucre";
				if (App.call_filter.Tarija)
					cat_str = cat_str != "" ? cat_str + " + Tarija" : cat_str + "Tarija";


				//Filtrar por campos
				if (App.call_filter.Cultura_viva_comunitaria)
					cat_str = cat_str != "" ? cat_str + " + cultura viva comunitaria" : cat_str + "cultura viva comunitaria";
				if (App.call_filter.Cultura_de_red)
					cat_str = cat_str != "" ? cat_str + " + cultura de red" : cat_str + "cultura de red";
				if (App.call_filter.Incidencia)
					cat_str = cat_str != "" ? cat_str + " + incidencia" : cat_str + "incidencia";
				if (App.call_filter.Formacion)
					cat_str = cat_str != "" ? cat_str + " + formación" : cat_str + "formación";
				if (App.call_filter.Sostenibilidad)
					cat_str = cat_str != "" ? cat_str + " + sostenibilidad" : cat_str + "sostenibilidad";
				if (App.call_filter.Comunicacion)
					cat_str = cat_str != "" ? cat_str + " + comunicación" : cat_str + "comunicación";
				if (App.call_filter.Circulacion_cultural)
					cat_str = cat_str != "" ? cat_str + " + circulación cultural" : cat_str + "circulación cultural";


				//Filtrar por areas
				if (App.call_filter.Cultura_libre)
					cat_str = cat_str != "" ? cat_str + " + cultura libre" : cat_str + "cultura libre";
				if (App.call_filter.Investigacion)
					cat_str = cat_str != "" ? cat_str + " + investigación" : cat_str + "investigación";
				if (App.call_filter.Literarias)
					cat_str = cat_str != "" ? cat_str + " + literarias" : cat_str + "literarias";
				if (App.call_filter.Musicales)
					cat_str = cat_str != "" ? cat_str + " + musicales" : cat_str + "musicales";
				if (App.call_filter.Escenicas_danza)
					cat_str = cat_str != "" ? cat_str + " + escenicas (danza)" : cat_str + "escenicas (danza)";
				if (App.call_filter.Visuales)
					cat_str = cat_str != "" ? cat_str + " + visuales" : cat_str + "visuales";
				if (App.call_filter.Patrimonio_cultural_inmaterial)
					cat_str = cat_str != "" ? cat_str + " + patrimonio cultural inmaterial" : cat_str + "patrimonio cultural inmaterial";
				if (App.call_filter.Plasticas)
					cat_str = cat_str != "" ? cat_str + " + plásticas" : cat_str + "plásticas";
				if (App.call_filter.Historia)
					cat_str = cat_str != "" ? cat_str + " + historia" : cat_str + "historia";
				if (App.call_filter.Artes_populares)
					cat_str = cat_str != "" ? cat_str + " + artes populares" : cat_str + "artes populares";
				if (App.call_filter.Patrimonio_cultural_material)
					cat_str = cat_str != "" ? cat_str + " + patrimonio cultural material" : cat_str + "patrimonio cultural material";
				if (App.call_filter.Gestion_cultural)
					cat_str = cat_str != "" ? cat_str + " + gestión cultural" : cat_str + "gestión cultural";
				if (App.call_filter.Arte_urbano)
					cat_str = cat_str != "" ? cat_str + " + arte urbano" : cat_str + "arte urbano";
				if (App.call_filter.Otra)
					cat_str = cat_str != "" ? cat_str + " + otra" : cat_str + "otra";
			}

			cat_str = "Filtradas por: " + cat_str;

			return cat_str;

		}

	}
}

