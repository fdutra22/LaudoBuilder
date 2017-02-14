using LaudoBuilder.DALSQLite;
using LaudoBuilder.IDAL;
using System;


namespace LaudoBuilder.DALFactory
{
	public class PreferenciaDALFactory
	{
		private static IPreferenciaDAL _Preferencia;

		public static IPreferenciaDAL create()
		{
			if (_Preferencia == null)
				_Preferencia = new PreferenciaDALSQLite();
			return _Preferencia;
		}
	}
}
