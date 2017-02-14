using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LaudoBuilder.Estilo
{
    public static class EstiloUtils
    {
       
        private static PreferenciaEstilo _preferencia;
        private static PopupEstilo _popup;
       

        public static PreferenciaEstilo Preferencia {
            get {
                return _preferencia;
            }
            set {
                _preferencia = value;
            }
        }

        public static PopupEstilo Popup
        {
            get {
                return _popup;
            }
            set {
                _popup = value;
            }
        }

      

        public static void inicializar() {
            var resources = new ResourceDictionary();

            _preferencia = new PreferenciaEstilo();
            _popup = new PopupEstilo();
            
            _preferencia.inicializar(resources);
            _popup.inicializar(resources);
           

            App.Current.Resources = resources;
        }
    }
}
