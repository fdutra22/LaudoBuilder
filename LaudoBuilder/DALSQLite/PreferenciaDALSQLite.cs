﻿using LaudoBuilder.IDAL;
using LaudoBuilder.Model;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace LaudoBuilder.DALSQLite
{
	public class PreferenciaDALSQLite : IPreferenciaDAL
	{
		SQLiteConnection database;
		static object locker = new object();

		public PreferenciaDALSQLite()
		{
						database = DependencyService.Get<ISQLite>().GetConnection();
			database.CreateTable<PreferenciaInfo>();
		}

		public IList<PreferenciaInfo> listar()
		{
			lock (locker)
			{
				return (from i in database.Table<PreferenciaInfo>() select i).ToList();
			}
		}

		public PreferenciaInfo pegar(string preferencia)
		{
			lock (locker)
			{
				return database.Table<PreferenciaInfo>().FirstOrDefault(x => x.Preferencia == preferencia);
			}
		}

		public int gravar(PreferenciaInfo preferencia)
		{
			lock (locker)
			{
				
				return database.InsertOrReplace(preferencia);

			}
		}

		public void excluir(string preferencia)
		{
			database.Delete<PreferenciaInfo>(preferencia);
		}

        
    }
}
