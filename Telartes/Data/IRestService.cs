using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace  Telartes
{
	public interface IRestService
	{
		Task<List<CallItem>> RefreshDataAsync(string RestUrl, CallItem item);

		Task SaveItemAsync(CallItem item, bool isNewItem);

		Task DeleteItemAsync(string id);
	}
}

