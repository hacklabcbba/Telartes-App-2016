using System;
using SQLite;


namespace  Telartes
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}