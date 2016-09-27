using SQLite;
using System.Text.RegularExpressions;

namespace  Telartes
{
	public class CallItem
	{
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }

		public string node_title { get; set; }
		public string archivo_pdf { get; set; }
		public string areas { get; set; }

		public string areas_delta { get; set; }
		public string campos { get; set; }
		public string campos_delta { get; set; }

		public string categoria { get; set; }
		public string ciudad { get; set; }
		public string convocante { get; set; }

		public string direccion_web { get; set; }
		public string correo_electronico { get; set; }
		public string plazo { get; set; }

		public string imagen { get; set; }
		public string fecha_de_mensaje { get; set; }
		public string fecha_de_modificacion { get; set; }

		public string nid { get; set; }
		public string descripcion { get; set; }
		public string enviado_por { get; set; }

		public string Node_Title
		{
			get
			{
				if (node_title != null)
				{
					int bgn = node_title.IndexOf('>');
					int end = node_title.IndexOf('<', 1);

					string dsc;
					if (bgn != -1 || end != -1)
					{
						dsc = node_title.Substring(bgn + 1, end - bgn - 1);
					}
					else
						dsc = "";

					return dsc;
				}
				else
					return "";
			}
		}

		public string Descripcion
		{
			get
			{
				if (descripcion != null)
				{
					string dsc;

					dsc = HtmlToText.ConvertHtml(descripcion);

					return dsc;
				}
				else
					return "";
			}		
		}


		public string Descripcion_html
		{
			get
			{
				if (descripcion != null)
				{
					string s = @"<html><body>";
					s += descripcion;
					s += @"<h1> Xamarin.Forms </h1>
<p> Welcome to WebView.</p>
   </body>
   </html>";
					return s;
				}
				else
					return "";
			}
		}

		public string Plazo
		{
			get
			{
				if (plazo != null)
				{
					int bgn = plazo.IndexOf('>');
					int end = plazo.IndexOf('<', 1);

					string dsc;
					if (bgn != -1 || end != -1)
					{
						dsc = plazo.Substring(bgn + 1, end - bgn - 1);
					}
					else
						dsc = "";

					return dsc;
				}
				else
					return "";
			}
		}

		public string Ciudad
		{
			get
			{
				if (ciudad != null)
				{
					int bgn = ciudad.IndexOf('>');
					int end = ciudad.IndexOf('<', 1);

					string dsc;
					if (bgn != -1 || end != -1)
					{
						dsc = ciudad.Substring(bgn + 1, end - bgn - 1);
					}
					else
						dsc = "";
					
					return dsc;
				}
				else
					return "";
			}
		}

		public string Imagen
		{
			get 
			{
				if (imagen != null)
				{
					string pattern = @"\s";
					string[] elements = Regex.Split(imagen, pattern);
					foreach (string s in elements)
					{
						if (s.Contains("http"))
						{
							int bgn = s.IndexOf('"');
							int end = s.IndexOf('"',bgn+1);

							string dsc = "";
							if (bgn != -1 || end != -1)
							{
								dsc = s.Substring(bgn + 1, end - bgn - 1);
							}
							return dsc;
						}
					}
					return "";
				}
				else
					return "logoredondo.png";
			}
		}

		public string Direccion_web
		{
			get
			{
				if (direccion_web != null)
				{
					int bgn = direccion_web.IndexOf('>');
					int end = direccion_web.IndexOf('<', 1);

					string dsc;
					if (bgn != -1 || end != -1)
					{
						dsc = direccion_web.Substring(bgn + 1, end - bgn - 1);
					}
					else
						dsc = "";

					return dsc;
				}
				else
					return "";
			}
		}

		//Sirve a habilitar/deshabilitar el boton de web
		public bool Web_enable
		{
			get
			{
				if (Direccion_web != null && Direccion_web != "")
				{
					return true;
				}
				else return false;
			}
		}


		//Sirve a habilitar/deshabilitar el boton de envio mail
		public bool Mail_enable
		{
			get
			{
				if (correo_electronico != null && correo_electronico != "")
				{
					return true;
				}
				else return false;
			}
		}
	}
}
