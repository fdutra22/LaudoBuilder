using System;

using Xamarin.Forms;

namespace LaudoBuilder.Pages
{
	public class InstrucaoPage : ContentPage
	{
		public InstrucaoPage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Em Contrução;" }
				}
			};
		}
	}
}

