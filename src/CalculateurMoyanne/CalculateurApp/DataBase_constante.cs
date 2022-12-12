using System;
namespace CalculateurApp
{
	public  static class DataBase_constante
	{
		public const string DatabaseName = "calculDb.db3";
		public const SQLite.SQLiteOpenFlags flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache;
		public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DatabaseName);
	}
}

