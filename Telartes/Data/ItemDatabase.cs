using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;


namespace  Telartes
{
	public class ItemDatabase
	{
		static object locker = new object();

		SQLiteConnection database;

		/// <summary>
		/// Initializes a new instance of the <see cref="Tasky.DL.TaskDatabase"/> TaskDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		/// 
		/// 
		public ItemDatabase()
		{
			database = DependencyService.Get<ISQLite>().GetConnection();
			// crea la tabla o se conecta a esta si ya existe
			database.CreateTable<CallItem>();
		}


		//Descarga todos los datos de la tabla especificada
		public IEnumerable<CallItem> GetItems()
		{
			lock (locker)
			{
				return (from i in database.Table<CallItem>() select i).ToList();
			}
		}

		//Descarga los datos segun la query string
		public IEnumerable<CallItem> GetItems(string query_string)
		{
			lock (locker)
			{
				return database.Query<CallItem>(query_string);
			}
		}

		public IEnumerable<CallItem> GetItemsNotDone()
		{
			lock (locker)
			{
				return database.Query<CallItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
			}
		}

		public CallItem GetItem(int id)
		{
			lock (locker)
			{
				return database.Table<CallItem>().FirstOrDefault(x => x.ID == id);
			}
		}

		public int SaveItem(CallItem item)
		{
			lock (locker)
			{
				if (item.ID != 0)
				{
					database.Update(item);
					return item.ID;
				}
				else {
					return database.Insert(item);
				}
			}
		}

		public int DeleteItem(int id)
		{
			lock (locker)
			{
				return database.Delete<CallItem>(id);
			}
		}
	
		//Borra todos los datos de la tabla CallItem
		public int DeleteAllItems(CallItem c)
		{
			lock (locker)
			{
				return database.DeleteAll<CallItem>();
			}
		}
	}
}


