using System;
using Xamarin.Forms;

namespace  Telartes
{
	public static class Constants
	{
		// ---------------- StartUpScreen  ---------------
		// Tiempo de espera de la SPLASH PAGE en mseg
		public const int WAIT_TIME = 3000;

		// URL of REST service
		public const string REST_CALL_URL = "http://telartes.org.bo/rest/views/convocatoriasrest";

		//HTTP Client tiemout
		public static TimeSpan HTTP_TIMEOUT = new TimeSpan(0,0,5);

		// Credentials that are hard coded into the REST service
		public const string USERNAME = "Xamarin";
		public const string PASSWORD = "Pa$$w0rd";

		public const string INFORMACION = "Información";
		public const string NOTICIAS = "Noticias";
		public const string AGENDA_CULTURAL = "Agenda Cultural";
		public const string CONVOCATORIAS = "Convocatorias";
		public const string AJUSTES = "Ajustes";
		public const string NOTIFICACIONES = "Notificaciones";

		// SQLite
		public const string op = "OR";

	}

}

