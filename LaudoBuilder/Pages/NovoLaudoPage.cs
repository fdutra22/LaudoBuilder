using System;
using Plugin.Media;
using Xamarin.Forms;
using LaudoBuilder.Model;
using LaudoBuilder.Factory;
using Rg.Plugins.Popup.Pages;
using LaudoBuilder.Utils;
using System.Threading.Tasks;
using LaudoBuilder.BLL;

namespace LaudoBuilder.Pages
{
    public class NovoLaudoPage : PopupPage
    {

        private Entry _TituloEntry;
        private Image _FotoImage;
        Button _Salvar;

        public NovoLaudoPage()
        {
            //Title = "Novo Laudo";

            StackLayout main = new StackLayout()
            {
                Orientation = StackOrientation.Vertical

            };
            _TituloEntry = new Entry
            {
                WidthRequest = 100,
                Placeholder = "Titulo"
            };

            _Salvar = new Button
            {
                Text = "Salvar",
                WidthRequest = 100
            
            };
            _Salvar.Clicked += Salvar;


            main.Children.Add(_TituloEntry);
            main.Children.Add(_Salvar);

            Content = main;
        }

        public void Salvar(Object sender, EventArgs e)
        {
            LaudoBLL laudoBLL = LaudoFactory.create();
            LaudoInfo laudoInfo = new LaudoInfo();
            laudoInfo.Titulo = _TituloEntry.Text;
            laudoBLL.gravar(laudoInfo);

        }
      
       

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // Method for animation child in PopupPage
        // Invoced after custom animation end
        protected virtual Task OnAppearingAnimationEnd()
        {
            return Content.FadeTo(0.5);
        }

        // Method for animation child in PopupPage
        // Invoked before custom animation begin
        protected virtual Task OnDisappearingAnimationBegin()
        {
            return Content.FadeTo(1); ;
        }

        protected override bool OnBackButtonPressed()
        {
            // Prevent hide popup
            //return base.OnBackButtonPressed();
            return true;
        }

        // Invoced when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return default value - CloseWhenBackgroundIsClicked
            return base.OnBackgroundClicked();
        }
    }
}