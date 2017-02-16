using LaudoBuilder.Model;
using System.Collections.Generic;

namespace LaudoBuilder.IDAL
{
	public interface ILaudoDal
	{
		IList<LaudoInfo> listar();
		LaudoInfo pegar(string titulo);
		int gravar(LaudoInfo laudo);
       
        void excluir(string titulo);
	}
}
