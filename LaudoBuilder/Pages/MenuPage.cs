using LaudoBuilder.Model;
using System.Collections.Generic;
using Xamarin.Forms;


namespace LaudoBuilder.Pages
{
	public class MenuPage : ContentPage
	{
		ListView _listView;

		public ListView ListView
		{
			get
			{
				return _listView;
			}
		}

		public MenuPage()
		{
			Title = "LaudoBuilder";

			inicializarComponente();

			BackgroundColor = Color.FromHex("#ffffff");
			//BackgroundColor = Color.Transparent;
			//var layout = new StackLayout
			//var layout = new AbsoluteLayout
			Content = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(5, 25, 5, 5),
				BackgroundColor = Color.Transparent, //Color.FromHex("#ffffff"), //,
				Children = {
					new Image {
						Source = "navicon.png",
						HorizontalOptions = LayoutOptions.Start,
						VerticalOptions = LayoutOptions.Center,
						WidthRequest = 80,
						HeightRequest = 80
					},
					_listView
				}
			};

		}

		private void inicializarComponente()
		{
			var paginas = new List<MenuItemGrupo>();
			paginas.Add(criarGrupoModo());
			paginas.Add(criarGrupoAcao());
			paginas.Add(criarGrupoAplicativo());

			_listView = new ListView
			{
				GroupDisplayBinding = new Binding("Nome"),
				HasUnevenRows = false,
				SeparatorVisibility = SeparatorVisibility.Default,
				IsGroupingEnabled = true,
				BackgroundColor = Color.Transparent,
				SeparatorColor = Color.FromHex("#bdbdbd"),
				GroupHeaderTemplate = new DataTemplate(typeof(MenuGrupoCell)),
				ItemTemplate = new DataTemplate(typeof(MenuItemCell))
			};
			_listView.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			_listView.ItemsSource = paginas;
			_listView.ItemTapped += (sender, e) =>
			{
				MenuItemInfo item = (MenuItemInfo)e.Item;
				if (item.click != null)
				{
					if (this.Navigation.NavigationStack.Count == 1)
					{
						item.click(sender, new MenuEventArgs(this));
					}
				}
			};

			_listView.Footer = new Label()
			{
				Text = ""
			};
		}

		private MenuItemGrupo criarGrupoModo()
		{
			var grupo = new MenuItemGrupo("APLICATIVO", "APLICATIVO");
			grupo.Add(new MenuItemInfo
			{
				Titulo = "Laudos",
				Icone = "ic_content_paste_black_24dp.png",
				click = (sender, e) =>
				{
					App.Current.MainPage.Navigation.PushAsync(new ListaLaudoPage());
				}
			});

			return grupo;
		}

		private MenuItemGrupo criarGrupoAcao()
		{
			var grupo = new MenuItemGrupo("INFORMAÇÕES", "INFORMAÇÕES");
			grupo.Add(new MenuItemInfo
			{
				Titulo = "Instruções",
				Icone = "instrucoes.png",
				click = (sender, e) =>
				{
					App.Current.MainPage.Navigation.PushAsync(new InstrucaoPage());
				}
			});
			grupo.Add(new MenuItemInfo
			{
				Titulo = "Sobre",
				Icone = "sobre.png",
				click = (sender, e) =>
				{
					App.Current.MainPage.Navigation.PushAsync(new SobrePage());
				}
			});


			return grupo;
		}

		private MenuItemGrupo criarGrupoAplicativo()
		{

			var grupo = new MenuItemGrupo("FINALIZAR", "FINALIZAR");
			grupo.Add(new MenuItemInfo
			{
				Titulo = "Sair",
				Icone = "sair.png",
				click =  (sender, e) =>
				{
					App.Current.MainPage.Navigation.PushAsync(new SairPage(), true);
					//await Navigation.PushPopupAsync(new InstrucaoPage());
				}
			});


			return grupo;
		}

		public class MenuGrupoCell : ViewCell
		{

			public MenuGrupoCell()
			{
				var tituloLabel = new Label
				{
					FontSize = 22,
					FontFamily = "Roboto-Condensed",
					TextColor = Color.FromHex("#009688"),
					BackgroundColor = Color.Transparent
				};
				tituloLabel.SetBinding(Label.TextProperty, new Binding("Nome"));
				View = new StackLayout
				{
					Orientation = StackOrientation.Vertical,
					BackgroundColor = Color.Transparent,
					Margin = new Thickness(0, 10, 0, 10),
					Children = {
						tituloLabel,
						new BoxView {
							HeightRequest = 5,
							BackgroundColor = Color.FromHex("#009688")
						}
					}
				};
			}
		}

		public class MenuItemCell : ViewCell
		{

			public MenuItemCell()
			{

				var imagemLabel = new Image
				{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.CenterAndExpand,
					WidthRequest = 40,
					HeightRequest = 40,
					//Margin = new Thickness(0,0,0,0)
				};
				imagemLabel.SetBinding(Image.SourceProperty, new Binding("Icone"));
				var tituloLabel = new Label
				{
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					FontSize = 18,
					FontFamily = "Roboto-Condensed",
					//Margin = new Thickness(0,0,0,0)
				};
				tituloLabel.SetBinding(Label.TextProperty, new Binding("Titulo"));
				View = new StackLayout
				{
					Orientation = StackOrientation.Horizontal,
					BackgroundColor = Color.Transparent,
					VerticalOptions = LayoutOptions.Fill,
					//Margin = new Thickness(10, 10, 10, 10),
					Children = {
								imagemLabel,
								tituloLabel
							}
				};

			}

		}
	}
}
