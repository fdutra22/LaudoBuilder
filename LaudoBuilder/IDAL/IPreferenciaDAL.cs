using LaudoBuilder.Model;
using System.Collections.Generic;

namespace LaudoBuilder.IDAL
{
	public interface IPreferenciaDAL
	{
		IList<PreferenciaInfo> listar();
		PreferenciaInfo pegar(string Preferencia);
		int gravar(PreferenciaInfo preferencia);
       
        void excluir(string preferencia);
	}
}
