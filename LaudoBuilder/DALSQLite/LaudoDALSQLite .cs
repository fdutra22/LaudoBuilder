using LaudoBuilder.IDAL;
using LaudoBuilder.Model;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace LaudoBuilder.DALSQLite
{
	public class LaudoDALSQLite : ILaudoDal
	{
		SQLiteConnection database;
		static object locker = new object();

		public LaudoDALSQLite()
		{
						database = DependencyService.Get<ISQLite>().GetConnection();
			database.CreateTable<LaudoInfo>();
		}

		public IList<LaudoInfo> listar()
		{
			lock (locker)
			{
				return (from i in database.Table<LaudoInfo>() select i).ToList();
			}
		}

		public LaudoInfo pegar(string titulo)
		{
			lock (locker)
			{
				return database.Table<LaudoInfo>().FirstOrDefault(x => x.Titulo == titulo);
			}
		}

		public int gravar(LaudoInfo titulo)
		{
			lock (locker)
			{
				
				return database.InsertOrReplace(titulo);

			}
		}

		public void excluir(string titulo)
		{
			database.Delete<LaudoInfo>(titulo);
		}

        
    }
}
