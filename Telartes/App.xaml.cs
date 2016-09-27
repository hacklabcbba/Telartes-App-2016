using Xamarin.Forms;
using Plugin.Connectivity;

namespace Telartes
{
	public partial class App : Application
	{
		//Gestiona los filtros de las convocatorias
		public static CallFilter call_filter;

		//Gestion el update de los datos
		public static bool refresh_calllist = false;

		//Gestiona la conexión del webservice
		public static ItemManager Manager { get; private set; }

		//Conexión al SQLite
		static ItemDatabase database;


		public App()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new StartupScreen());

			Manager = new ItemManager(new RestService());

			call_filter = new CallFilter();
			call_filter.RestoreState(Current.Properties);  //recupera los datos guardados del call_filter

		}

		public static ItemDatabase Database
		{
			get
			{
				if (database == null)
				{
					database = new ItemDatabase();
				}
				return database;
			}
		}

		//Verifica el estado de la conección
		public static EConnection Connection_state()
		{
			try
			{
				if (CrossConnectivity.Current.IsConnected)
				{
					foreach (var band in CrossConnectivity.Current.ConnectionTypes)
					{
						string s = band.ToString();
						if (s.ToUpper().Contains("WIFI"))
							return EConnection.WIFI;
					}
					return EConnection.OTHERS;
				}
				else
					return EConnection.no_connection;
			}
			catch (System.NotImplementedException e)
			{
				return EConnection.not_defined;
			}

		}


		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
			call_filter.SaveState(Current.Properties); //guarda el estado de call_filter

		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

