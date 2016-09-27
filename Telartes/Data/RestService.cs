using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;
using System.Net;


namespace  Telartes
{
	public class RestService : IRestService
	{
		HttpClient client;

		//public List<TodoItem> Items { get; private set; }
		public List<CallItem> Items { get; private set; }

		public RestService()
		{
			var authData = string.Format("{0}:{1}", Constants.USERNAME, Constants.PASSWORD);
			var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
		}

		/*
		//Se descargan los datos del Web Server para las convocatorias
		public async Task<List<CallItem>> RefreshDataAsync(string RestUrl, CallItem item)
		{
			Items = new List<CallItem>();

			var uri = new Uri(string.Format(RestUrl, string.Empty));

			try
			{
				client.Timeout = Constants.http_timeout;
				var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					//Items = JsonConvert.DeserializeObject <List<TodoItem>> (content);
					Items = JsonConvert.DeserializeObject<List<CallItem>>(content);
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}

			return Items;
		}*/


	//Se descargan los datos del Web Server para las convocatorias
	public async Task<List<CallItem>> RefreshDataAsync(string RestUrl, CallItem item)
	{
			Items = new List<CallItem>();
			var uri = new Uri(string.Format(RestUrl, string.Empty));

			//try
			//{
				//client.Timeout = Constants.HTTP_TIMEOUT;
				var response = await Task.Run(() =>
				{
					var cancelSource = new CancellationTokenSource();
					var reqTask = client.GetAsync(uri, cancelSource.Token);

					//Se cancela la conexión si tarda mas del timeout
					if (Task.WaitAny(new Task[] { reqTask }, Constants.HTTP_TIMEOUT) < 0)
					{
						cancelSource.Cancel(); // attempt to cancel the HTTP request
					throw new WebException(Resx.AppResources.Connection_Msg_No_Server_Connection,WebExceptionStatus.ConnectFailure);
					}
					return reqTask.GetAwaiter().GetResult();
				}).ConfigureAwait(false);

				//var response = await client.GetAsync(uri);
				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					Items = JsonConvert.DeserializeObject<List<CallItem>>(content);
				}
			//}
			//catch (Exception ex)
			//{
			//	Debug.WriteLine(@"				ERROR RefreshDataAsync: {0}", ex.Message);
			//}

			return Items;
		}


		/*
		//Se descargan los datos del Web Server para las convocatorias
		public async Task<List<CallItem>> RefreshDataAsync(string RestUrl, CallItem item)
		{
			Items = new List<CallItem>();

			var uri = new Uri(string.Format(RestUrl, string.Empty));

			using (var http_client = new HttpClient())
			{
				var authData = string.Format("{0}:{1}", Constants.USERNAME, Constants.PASSWORD);
				var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

				http_client.MaxResponseContentBufferSize = 256000;
				http_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);

				http_client.Timeout = Constants.HTTP_TIMEOUT;




				try
				{
					HttpRequestMessage msg = new HttpRequestMessage();
					msg.Content = HttpContent( uri);
					var response = await http_client.SendAsync(uri);
					if (response.IsSuccessStatusCode)
					{
						var content = await response.Content.ReadAsStringAsync();
						//Items = JsonConvert.DeserializeObject <List<TodoItem>> (content);
						Items = JsonConvert.DeserializeObject<List<CallItem>>(content);
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine(@"				ERROR {0}", ex.Message);
				}
			}
			return Items;
		}
		*/



		public async Task SaveItemAsync(CallItem item, bool isNewItem = false)
		{
			var uri = new Uri(string.Format(Constants.REST_CALL_URL, item.node_title));

			try
			{
				var json = JsonConvert.SerializeObject(item);
				var content = new StringContent(json, Encoding.UTF8, "application/json");

				HttpResponseMessage response = null;
				if (isNewItem)
				{
					response = await client.PostAsync(uri, content);
				}
				else {
					response = await client.PutAsync(uri, content);
				}

				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"				TodoItem successfully saved.");
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
		}



		public async Task DeleteItemAsync(string id)
		{
			// RestUrl = http://developer.xamarin.com:8081/api/todoitems{0}
			var uri = new Uri(string.Format(Constants.REST_CALL_URL, id));

			try
			{
				var response = await client.DeleteAsync(uri);

				if (response.IsSuccessStatusCode)
				{
					Debug.WriteLine(@"				TodoItem successfully deleted.");
				}

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"				ERROR {0}", ex.Message);
			}
		}

	}
}

