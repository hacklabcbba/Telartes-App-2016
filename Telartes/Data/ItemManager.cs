using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace  Telartes
{
	public class ItemManager
	{
		IRestService restService;

		public ItemManager(IRestService service)
		{
			restService = service;
		}

		//Descarga todos los datos del Web Server
		public Task<List<CallItem>> GetTasksAsync(string RestUrl, CallItem item)
		{
			return restService.RefreshDataAsync(RestUrl, item);
		}


		public Task SaveTaskAsync(CallItem item, bool isNewItem = false)
		{
			return restService.SaveItemAsync(item, isNewItem);
		}

		public Task DeleteTaskAsync(CallItem item)
		{
			return restService.DeleteItemAsync(item.node_title);
		}
	
	}
}


