using System;
using LaudoBuilder.BLL;
using LaudoBuilder.Factory;
using Xamarin.Forms;


namespace LaudoBuilder.Utils
{
    public static class PreferenciaUtils
    {
        private const string URL_ATUALIZACAO = "http://pavmanager.com.br/maparadar.txt";

        private static PreferenciaBLL _regraPreferencia;

        private const string PISOS = "pisos";
        private const string ESQUADRIAS = "esquadrias";
        private const string IMPERMEABILIZACAO = "impermebilizacao";
        private const string INSTALACAOELETRICA = "instalacaoeletrica";
        private const string INSTALACAOHIDRAULICA = "instalacaohidraulica";
        private const string REVESTIMENTO = "revestimento";
        private const string INSTALACAODEGAS = "instalacaodegas";
        private const string TERRAPLANAGEM = "terraplanagem";
        private const string FUNDACAO = "fundacao";
        private const string INFRAESTRUTURA = "infraestrutura";
        private const string SUPERESTRUTURA = "superestrutura";
        

        public static void inicializar() {
            if (_regraPreferencia == null)
                _regraPreferencia = PreferenciaFactory.create();
        }

        public static bool Gratis {
            get {
                return true;
            }
        }

        public static bool Pisos
		{
			get {
                inicializar();
				return _regraPreferencia.pegarBool(PISOS);
			}
            set {
                inicializar();
                _regraPreferencia.gravar(PISOS, value);
            }
		}

        public static bool Esquadrias
        {
            get
            {
                inicializar();
                return _regraPreferencia.pegarBool(ESQUADRIAS);
            }
            set
            {
                inicializar();
                _regraPreferencia.gravar(ESQUADRIAS, value);
            }
        }


        public static bool Impermeabilizacao
        {
            get
            {
                inicializar();
                return _regraPreferencia.pegarBool(IMPERMEABILIZACAO);
            }
            set
            {
                inicializar();
                _regraPreferencia.gravar(IMPERMEABILIZACAO, value);
            }
        }

        public static bool InstalacaoEletrica
        {
            get
            {
                inicializar();
                return _regraPreferencia.pegarBool(INSTALACAOELETRICA);
            }
            set
            {
                inicializar();
                _regraPreferencia.gravar(INSTALACAOELETRICA, value);
            }
        }

        public static bool InstalacaoHidraulica
        {
            get
            {
                inicializar();
                return _regraPreferencia.pegarBool(INSTALACAOHIDRAULICA);
            }
            set
            {
                inicializar();
                _regraPreferencia.gravar(INSTALACAOHIDRAULICA, value);
            }
        }

        public static bool Revestimento
        {
            get
            {
                inicializar();
                return _regraPreferencia.pegarBool(REVESTIMENTO);
            }
            set
            {
                inicializar();
                _regraPreferencia.gravar(REVESTIMENTO, value);
            }
        }

        public static bool Instalacaodegas
        {
            get
            {
                inicializar();
                return _regraPreferencia.pegarBool(INSTALACAODEGAS);
            }
            set
            {
                inicializar();
                _regraPreferencia.gravar(INSTALACAODEGAS, value);
            }
        }

        public static bool Terraplanagem
        {
            get
            {
                inicializar();
                return _regraPreferencia.pegarBool(TERRAPLANAGEM);
            }
            set
            {
                inicializar();
                _regraPreferencia.gravar(TERRAPLANAGEM, value);
            }
        }

        public static bool Fundacao
        {
            get
            {
                inicializar();
                return _regraPreferencia.pegarBool(FUNDACAO);
            }
            set
            {
                inicializar();
                _regraPreferencia.gravar(FUNDACAO, value);
            }
        }
        public static bool Infraestrutura
        {
            get
            {
                inicializar();
                return _regraPreferencia.pegarBool(INFRAESTRUTURA);
            }
            set
            {
                inicializar();
                _regraPreferencia.gravar(INFRAESTRUTURA, value);
            }
        }

        public static bool Superestrutura
        {
            get
            {
                inicializar();
                return _regraPreferencia.pegarBool(SUPERESTRUTURA);
            }
            set
            {
                inicializar();
                _regraPreferencia.gravar(SUPERESTRUTURA, value);
            }
        }


    }
}
