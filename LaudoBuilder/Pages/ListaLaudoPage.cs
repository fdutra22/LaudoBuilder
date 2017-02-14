using System.Collections.ObjectModel;
using LaudoBuilder.Model;
using Xamarin.Forms;

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
			laudos.Add(new LaudoInfo() { Titulo = "Laudo 1", Imagem = "icon.png" });
			laudos.Add(new LaudoInfo() { Titulo = "Laudo 2", Imagem = "icon.png" });
			laudos.Add(new LaudoInfo() { Titulo = "Laudo 3", Imagem = "icon.png" });

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
			Image AdicionarRadarButton = new Image
			{
				Aspect = Aspect.AspectFit,
				Source = ImageSource.FromFile("ic_add_box_black_24dp.png"),
				WidthRequest = 80,
				HeightRequest = 80,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.End,
				Margin = new Thickness(0, 0, 10, 10)
			};
			AdicionarRadarButton.GestureRecognizers.Add(
					new TapGestureRecognizer()
					{
						Command = new Command(() =>
						{
							adcionarGrupo();
						}
					)
					});

			listaView.Children.Add(listaLaudos);
			listaView.Children.Add(AdicionarRadarButton);
			Content = listaView;
		}

		public void adcionarGrupo()
		{
			//NavigationX.create(this).PushModalAsync(new AdcionarGrupoPopUp());

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

				var excluirGrupo = new MenuItem
				{
					Text = "Excluir"
				};

				excluirGrupo.SetBinding(MenuItem.CommandParameterProperty, new Binding("."));
				excluirGrupo.Clicked += (sender, e) =>
				{
					//MensagemInfo mensagem = (MensagemInfo)((MenuItem)sender).BindingContext;
					//MensagemBLL mensagemBLL = MensagemFactory.create();
					//mensagemBLL.excluir(mensagem.Id);

					//ListView listaGrupos = this.Parent as ListView;

					//listaGrupos.SetBinding(ListView.ItemsSourceProperty, new Binding("."));
					//listaGrupos.RowHeight = 120;
					//var grupos = mensagemBLL.pegarMensagem();
					//listaGrupos.BindingContext = grupos;
					//listaGrupos.ItemTemplate = new DataTemplate(typeof(GruposCelula));
				};
				//ContextActions.Add(excluirGrupo);

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
				foto.SetBinding(Image.SourceProperty, new Binding("Imagem"));

				Label nome = new Label
				{
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
				};
				nome.SetBinding(Label.TextProperty, new Binding("Titulo"));


				Label descricao = new Label
				{
					TextColor = Color.FromHex(TemaInfo.PrimaryText),
					FontFamily = "Roboto-Condensed",
					FontSize = 20,
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
				};
				//descricao.SetBinding(Label.TextProperty, new Binding("DescricaoStr"));


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
				stackRight.Children.Add(descricao);

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
