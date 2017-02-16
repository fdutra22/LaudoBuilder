using System;
using Xamarin.Forms;

namespace LaudoBuilder.Pages
{
	public class SobrePage : ContentPage, IDisposable
	{
		Image _NavIconImage;
		Image _LogoClubImage;

		public SobrePage()
		{
			Title = "Sobre";

			inicializarComponente();

			Content = new ScrollView
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				Content = new StackLayout
				{
					BackgroundColor = Color.White,
					Orientation = StackOrientation.Vertical,
                    Margin = new Thickness(30,30,30,30),
					Children = {
						new StackLayout {
							Orientation = StackOrientation.Vertical,
							HorizontalOptions = LayoutOptions.FillAndExpand,
							HeightRequest = AbsoluteLayout.AutoSize,
							BackgroundColor = Color.White,
							Children = {
								_NavIconImage,
								new Label {
									Text = "LaudoBuilder",
									FontSize = 40,
									FontFamily = "Roboto-Condensed",
									HorizontalOptions = LayoutOptions.Center
								},
								new Label {
									Text = "Versão: 1.0.0",
									FontSize = 25,
									FontFamily = "Roboto-Condensed",
									HorizontalOptions = LayoutOptions.Center
								}
							}
						},
						new StackLayout {
							Orientation = StackOrientation.Vertical,
							HorizontalOptions = LayoutOptions.Fill,
							VerticalOptions = LayoutOptions.Center,
							Children = {
								new Label {
									Text = "Desenvolvido Por Fábio Lopes - 993978230",
									HorizontalOptions = LayoutOptions.Center,
                                    HorizontalTextAlignment = TextAlignment.Center
								},
								_LogoClubImage
							}
						}
					}
				}
			};
		}

		private void inicializarComponente()
		{
			_NavIconImage = new Image
			{
				Source = ImageSource.FromFile("icon.png"),
				WidthRequest = 220,
				HorizontalOptions = LayoutOptions.Center
			};
			_LogoClubImage = new Image
			{
				Source = ImageSource.FromFile("icon.png"),
				WidthRequest = 170
			};
		}

		public void Dispose()
		{
			_NavIconImage.Source = null;
			_LogoClubImage.Source = null;
		}
	}
}
