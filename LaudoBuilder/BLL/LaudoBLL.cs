using LaudoBuilder.DALFactory;
using LaudoBuilder.IDAL;
using LaudoBuilder.Model;
using System;
using System.Collections.Generic;


namespace LaudoBuilder.BLL
{
	public class LaudoBLL
	{
		private ILaudoDal _laudoDB;

		public LaudoBLL()
		{
            _laudoDB = LaudoFacotry.create();
		}

		public IList<LaudoInfo> listar()
		{
			IList<LaudoInfo> laudos = _laudoDB.listar();

			return laudos;
		}
        /*
    [Obsolete("Usar pegarBool agora.")]
    public bool pegarBooleano(string preferencia)
    {
        return pegarBool(preferencia);
    }


    public string pegar(string preferencia, string padrao = "")
    {
        PreferenciaInfo _preferencia = _preferenciaDB.pegar(preferencia);
        return (_preferencia != null) ? _preferencia.Valor : padrao;
    }

    public bool pegarBool(string chave, bool padrao = false) {
        PreferenciaInfo preferencia = _preferenciaDB.pegar(chave);
        if (preferencia != null) {
            bool retorno = padrao;
            if (bool.TryParse(preferencia.Valor, out retorno)) {
                return retorno;
            }
        }
        return padrao;
    }

    public int pegarInt(string chave, int padrao = 0) {
        PreferenciaInfo preferencia = _preferenciaDB.pegar(chave);
        if (preferencia != null) {
            int retorno = padrao;
            if (int.TryParse(preferencia.Valor, out retorno))
                return retorno;
        }
        return padrao;
    }

    public long pegarLong(string chave, long padrao = 0)
    {
        PreferenciaInfo preferencia = _preferenciaDB.pegar(chave);
        if (preferencia != null)
        {
            long retorno = padrao;
            if (long.TryParse(preferencia.Valor, out retorno))
                return retorno;
        }
        return padrao;
    }
  
        public void gravar(string preferencia, int valor)
		{
			PreferenciaInfo pref = new PreferenciaInfo() { 
				Preferencia = preferencia,
				Valor = valor.ToString()
			};
			_preferenciaDB.gravar(pref);
		}

        public void gravar(string preferencia, bool valor)
        {
            PreferenciaInfo pref = new PreferenciaInfo()
            {
                Preferencia = preferencia,
                Valor = valor.ToString()
            };
            _preferenciaDB.gravar(pref);
        }
          */
        public void gravar(LaudoInfo laudo)
        {

            _laudoDB.gravar(laudo);
        }

        public void excluir(string titulo)
		{
            _laudoDB.excluir(titulo);
		}

        
    }
}
