using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace LaudoBuilder
{
	public class DadosPage : ContentPage
	{
		Entry message;
		public DadosPage()
		{

			StackLayout main = new StackLayout();
			message = new Entry
			{
				WidthRequest = 200
			};
			Button enviar = new Button
			{
				Text = "Enviar",
				WidthRequest = 200
			};
			enviar.Clicked += OnButtonClicked;
			main.Children.Add(message);
			main.Children.Add(enviar);

			Content = main;

		}
		public async void OnButtonClicked(object sender, EventArgs args)
		{
			MessageSender enviaMenssagem = new MessageSender();
			enviaMenssagem.EnviaMensagem(message.Text);
		}
	}
}

