using LaudoBuilder.Estilo;
using Xamarin.Forms;
using LaudoBuilder.Utils;
using System.Net.Http;
using Newtonsoft.Json;
using LaudoBuilder.Model;
using System.Collections.ObjectModel;
using System.Text;

namespace LaudoBuilder.Pages
{
    public class ModoLaudoPage: BasePreferenciaPage
    {
        Switch _Pisos;
        Switch _Esquadrias;
        Switch _Impermeabilizacao;
        Switch _InstalacaoEletrica;
        Switch _InstalacaoHidraulica;
        Switch _Revestimento;
        Switch _Instalacaodegas;
        Switch _Terraplanagem;
        Switch _Fundacao;
        Switch _Infraestrutura;
        Switch _Superestrutura;
        Button _sincronizar;

        ObservableCollection<PreferenciaInfo> laudos = new ObservableCollection<PreferenciaInfo>();
        
        protected override string Titulo
        {
            get
            {
                return "Laudo 1";
            }
        }

        protected override void inicializarComponente()
        {
			EstiloUtils.inicializar();

            laudos.Add(new PreferenciaInfo() { Titulo = "titulo", Valor = "Laudo 1"});
            _Pisos = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.Pisos
            };
            _Pisos.Toggled += (sender, e) => {
                PreferenciaUtils.Pisos = e.Value;
                laudos.Add(new PreferenciaInfo() { Preferencia = "pisos", ValorBool = e.Value });
            };

            _Esquadrias = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.Esquadrias
            };
            _Esquadrias.Toggled += (sender, e) => {
                PreferenciaUtils.Esquadrias = e.Value;
                laudos.Add(new PreferenciaInfo() { Preferencia = "esquadrias", ValorBool = e.Value });
            };

            _Impermeabilizacao = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.Impermeabilizacao
            };
            _Impermeabilizacao.Toggled += (sender, e) => {
                PreferenciaUtils.Impermeabilizacao = e.Value;
                laudos.Add(new PreferenciaInfo() { Preferencia = "impermeabilizacao", ValorBool = e.Value });
            };

            _InstalacaoEletrica = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.InstalacaoEletrica
            };
            _InstalacaoEletrica.Toggled += (sender, e) => {
                PreferenciaUtils.InstalacaoEletrica = e.Value;
                laudos.Add(new PreferenciaInfo() { Preferencia = "instalacaoeletrica", ValorBool = e.Value });
            };

            _InstalacaoHidraulica = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.InstalacaoHidraulica
            };
            _InstalacaoHidraulica.Toggled += (sender, e) => {
                PreferenciaUtils.InstalacaoHidraulica = e.Value;
                laudos.Add(new PreferenciaInfo() { Preferencia = "instalacaohidraulica", ValorBool = e.Value });
            };

            _Revestimento = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.Revestimento
            };
            _Revestimento.Toggled += (sender, e) => {
                PreferenciaUtils.Revestimento = e.Value;
                laudos.Add(new PreferenciaInfo() { Preferencia = "revestimento", ValorBool = e.Value });
            };

            _Instalacaodegas = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.Instalacaodegas
            };

            _Instalacaodegas.Toggled += (sender, e) => {
                PreferenciaUtils.Instalacaodegas = e.Value;
                laudos.Add(new PreferenciaInfo() { Preferencia = "instalacadegas", ValorBool = e.Value });
            };

            _Terraplanagem = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.Terraplanagem
            };
            _Terraplanagem.Toggled += (sender, e) => {
                PreferenciaUtils.Terraplanagem = e.Value;
                laudos.Add(new PreferenciaInfo() { Preferencia = "terraplanagem", ValorBool = e.Value });
            };

            _Fundacao = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.Fundacao
            };
            _Fundacao.Toggled += (sender, e) => {
                PreferenciaUtils.Fundacao = e.Value;
                laudos.Add(new PreferenciaInfo() { Preferencia = "fundacao", ValorBool = e.Value });
            };

            _Infraestrutura = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.Infraestrutura
            };
            _Infraestrutura.Toggled += (sender, e) => {
                PreferenciaUtils.Infraestrutura = e.Value;
                laudos.Add(new PreferenciaInfo() { Preferencia = "infraestrutura", ValorBool = e.Value });
            };

            _Superestrutura = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.Superestrutura
            };
            _Superestrutura.Toggled += (sender, e) => {
                PreferenciaUtils.Superestrutura = e.Value;
                laudos.Add(new PreferenciaInfo() { Preferencia = "superestrutura", ValorBool = e.Value });
            };

            _sincronizar = new Button
            {
                Text = "Sincronizar"
            };
            _sincronizar.Clicked += (sender, e) =>
            {
                HttpClient client = new HttpClient();
                string url = "http://laudobuilder.esy.es/api/laudo";
                string contentType = "application/json";

                var content = new StringContent(
                    JsonConvert.SerializeObject( laudos, Formatting.Indented), Encoding.UTF8, contentType);

                var result = client.PostAsync(url, content).ConfigureAwait(false);
            };
        }

        protected override void inicializarTela()
        {
            adicionarSwitch(_Pisos, "Pisos");
            adicionarSwitch(_Esquadrias, "Esquadrias de aluminio");
            adicionarSwitch(_Impermeabilizacao, "Impermeabilizações");
            adicionarSwitch(_InstalacaoEletrica, "Instalações eletricas");
            adicionarSwitch(_InstalacaoHidraulica, "Instalações hidraulicas");
            adicionarSwitch(_Revestimento, "Revestimento interno");
            adicionarSwitch(_Instalacaodegas, "Instalação de gás");
            adicionarSwitch(_Terraplanagem, "Terraplanagem");
            adicionarSwitch(_Fundacao, "Fundação");
            adicionarSwitch(_Infraestrutura, "Infraestrutura");
            adicionarSwitch(_Superestrutura, "Superestrutura - alvenaria");
        }
    }
}
