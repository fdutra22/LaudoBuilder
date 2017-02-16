using LaudoBuilder.Model;
using Xamarin.Forms;
using LaudoBuilder.Utils;
using LaudoBuilder.BLL;
using LaudoBuilder.Factory;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using System.Collections.ObjectModel;

namespace LaudoBuilder.Pages
{
	public class ListaLaudoPage : ContentPage
	{

		public ListaLaudoPage()
		{
			Title = "Laudos";

			StackLayout listaView = new StackLayout();
			listaView.VerticalOptions = LayoutOptions.Fill;
			listaView.HorizontalOptions = LayoutOptions.Fill;
            
			ObservableCollection<LaudoInfo> laudos = new ObservableCollection<LaudoInfo>();
			laudos.Add(new LaudoInfo() { Titulo = "Laudo 1", ImagemUrl = "icon.png" });

            
            LaudoBLL regraLaudo = LaudoFactory.create();
            //IList<LaudoInfo> laudos =  regraLaudo.listar();

			ListView listaLaudos = new ListView();
			listaLaudos.RowHeight = 120;
			listaLaudos.ItemTemplate = new DataTemplate(typeof(GruposCelula));
			listaLaudos.ItemTapped += OnTap;
			listaLaudos.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
			listaLaudos.HasUnevenRows = true;
			listaLaudos.SeparatorColor = Color.Transparent;
			listaLaudos.VerticalOptions = LayoutOptions.Start;
			listaLaudos.HorizontalOptions = LayoutOptions.Center;

			listaLaudos.BindingContext = laudos;
			Image AdicionarLaudoButton = new Image
			{
				Aspect = Aspect.AspectFit,
				Source = ImageSource.FromFile("ic_add_box_black_24dp.png"),
				WidthRequest = TelaUtils.Largura * 0.1,
                HeightRequest = TelaUtils.Largura * 0.1,				
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.End,
				Margin = new Thickness(0, 0, 10, 10)
			};
            AdicionarLaudoButton.GestureRecognizers.Add(
					new TapGestureRecognizer()
					{
						Command = new Command(() =>
						{
                            adcionarLaudo();
						}
					)
					});

			listaView.Children.Add(listaLaudos);
			listaView.Children.Add(AdicionarLaudoButton);
			Content = listaView;
		}

        

        public  void adcionarLaudo()
        {
            var page = new NovoLaudoPage();
            App.Current.MainPage.Navigation.PushPopupAsync(page);
            //Navigation.PushPopupAsync(page);
        }

        public void OnTap(object sender, ItemTappedEventArgs e)
		{

			//GrupoInfo item = (GrupoInfo)e.Item;

			App.Current.MainPage.Navigation.PushAsync(new ModoLaudoPage());

		}

		public class GruposCelula : ViewCell
		{

			public GruposCelula()
			{

				var excluirLaudo = new MenuItem
				{
					Text = "Excluir"
				};

                excluirLaudo.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
                excluirLaudo.Clicked += (sender, e) =>
				{
					 LaudoInfo laudo = (LaudoInfo)((MenuItem)sender).BindingContext;
					 LaudoBLL laudoBLL = LaudoFactory.create();
                     laudoBLL.excluir(laudo.Titulo);

					 ListView listaGrupos = this.Parent as ListView;

					listaGrupos.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
					listaGrupos.RowHeight = 120;
					var grupos = laudoBLL.listar();
					listaGrupos.BindingContext = grupos;
					listaGrupos.ItemTemplate = new DataTemplate(typeof(GruposCelula));
				};
				ContextActions.Add(excluirLaudo);

				StackLayout main = new StackLayout();
				main.BackgroundColor = Color.Transparent;
				main.Orientation = StackOrientation.Horizontal;
				main.VerticalOptions = LayoutOptions.StartAndExpand;
				main.HorizontalOptions = LayoutOptions.CenterAndExpand;

				StackLayout stackRight = new StackLayout();
				stackRight.Orientation = StackOrientation.Vertical;
				stackRight.VerticalOptions = LayoutOptions.CenterAndExpand;
				stackRight.HorizontalOptions = LayoutOptions.StartAndExpand;

				StackLayout stackLeft = new StackLayout();
				stackLeft.Orientation = StackOrientation.Vertical;
				stackLeft.VerticalOptions = LayoutOptions.StartAndExpand;
				stackLeft.HorizontalOptions = LayoutOptions.StartAndExpand;


				Image foto = new Image()
				{
					WidthRequest = 50,
					HeightRequest = 50,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					Source = "ic_add_a_photo_48pt.png"
				};
				foto.SetBinding(Image.SourceProperty, new Binding("Image"));

				Label nome = new Label
				{
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
				};
				nome.SetBinding(Label.TextProperty, new Binding("Titulo"));


				

				var frameOuter = new Frame();
				frameOuter.BackgroundColor = Color.FromHex(TemaInfo.BlueAccua);
				frameOuter.HeightRequest = AbsoluteLayout.AutoSize;
				if (Device.OS == TargetPlatform.iOS)
				{
					foto.WidthRequest = 60;

					//frameOuter.Padding = new Thickness(5, 10, 5, 10);
					//frameOuter.WidthRequest =  0.9;
					frameOuter.Margin = new Thickness(5, 10, 5, 0);

				}
				else {
					frameOuter.Margin = new Thickness(5, 10, 5, 10);
				}

				stackLeft.Children.Add(foto);
				stackRight.Children.Add(nome);
				

				main.Children.Add(stackLeft);
				main.Children.Add(stackRight);

				frameOuter.Content = main;

				View = frameOuter;

			}


		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{

			base.OnDisappearing();
		}
	}
}
