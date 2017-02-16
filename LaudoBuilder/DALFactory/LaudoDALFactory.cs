using LaudoBuilder.DALSQLite;
using LaudoBuilder.IDAL;
using System;


namespace LaudoBuilder.DALFactory
{
	public class LaudoFacotry
	{
		private static ILaudoDal _Laudo;

		public static ILaudoDal create()
		{
			if (_Laudo == null)
                _Laudo = new LaudoDALSQLite();
			return _Laudo;
		}
	}
}
