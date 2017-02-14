using LaudoBuilder.Estilo;
using Xamarin.Forms;
using LaudoBuilder.Utils;

namespace LaudoBuilder.Pages
{
    public class ModoLaudoPage: BasePreferenciaPage
    {
        Switch _RadarMovelSwitch;
        Switch _PedagioSwitch;
        Switch _PoliciaRodoviariaSwitch;
        Switch _LombadaSwitch;
        Switch _AlertaInteligenteSwitch;
        Switch _BeepAvisoSwitch;
        Switch _VibrarAlertaSwitch;
        Switch _SobreposicaoVisualSwitch;

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
            _RadarMovelSwitch = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.RadarMovel
            };
            _RadarMovelSwitch.Toggled += (sender, e) =>
            {
                PreferenciaUtils.RadarMovel = e.Value;
            };

            _PedagioSwitch = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.Pedagio
            };
            _PedagioSwitch.Toggled += (sender, e) =>
            {
                PreferenciaUtils.Pedagio = e.Value;
            };

            _PoliciaRodoviariaSwitch = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.PoliciaRodoviaria
            };
            _PoliciaRodoviariaSwitch.Toggled += (sender, e) =>
            {
                PreferenciaUtils.PoliciaRodoviaria = e.Value;
            };

            _LombadaSwitch = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.Lombada
            };
            _LombadaSwitch.Toggled += (sender, e) =>
            {
                PreferenciaUtils.Lombada = e.Value;
            };

            _AlertaInteligenteSwitch = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.AlertaInteligente
            };
            _AlertaInteligenteSwitch.Toggled += (sender, e) =>
            {
                PreferenciaUtils.AlertaInteligente = e.Value;
            };

            _BeepAvisoSwitch = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.BeepAviso
            };
            _BeepAvisoSwitch.Toggled += (sender, e) =>
            {
                PreferenciaUtils.BeepAviso = e.Value;
            };

            _VibrarAlertaSwitch = new Switch
            {
                Style = EstiloUtils.Preferencia.Checkbox,
                IsToggled = PreferenciaUtils.VibrarAlerta
            };
            _VibrarAlertaSwitch.Toggled += (sender, e) =>
            {
                PreferenciaUtils.VibrarAlerta = e.Value;
            };

            
        }

        protected override void inicializarTela()
        {
            adicionarSwitch(_RadarMovelSwitch, "Radar Móvel");
            adicionarSwitch(_PedagioSwitch, "Pedágio");
            adicionarSwitch(_PoliciaRodoviariaSwitch, "Polícia Rodoviária");
            adicionarSwitch(_LombadaSwitch, "Lombada");
            adicionarSwitch(_AlertaInteligenteSwitch, "Alerta Inteligente", "Só emitir alerta caso a velocidade atual esteja próxima da velocidade limite");
            adicionarSwitch(_BeepAvisoSwitch, "Beep de Aviso", "Emitir som ao passar por um radar");
            adicionarSwitch(_VibrarAlertaSwitch, "Vibrar ao emitir Alerta");
        }
    }
}
