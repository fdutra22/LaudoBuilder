using LaudoBuilder.Model;
using Xamarin.Forms;

namespace LaudoBuilder.Pages
{
	public class Principal : MasterDetailPage
	{
		MenuPage masterPage;

		public Principal()
		{
			Title = "LaudoBuidler";
			masterPage = new MenuPage();
			Master = new MenuPage();
			if (Device.OS == TargetPlatform.iOS)
			{
				Detail = new NavigationPage(new ListaLaudoPage());
			}
			else {
				Detail = new ListaLaudoPage();
			}
			masterPage.ListView.ItemSelected += OnItemSelected;
			IsPresented = false;
			if (Device.OS == TargetPlatform.Windows)
			{
				Master.Icon = "swap.png";
			}
		}

		protected void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MenuItemInfo;
			if (item != null)
			{
				if (item.click != null)
				{
					item.click(sender, new MenuEventArgs(this));
				}
				masterPage.ListView.SelectedItem = null;
				IsPresented = false;
				/*
                else {
                    if (!carregandoPagina)
                    {
                        if (_paginaAtual.GetType() != item.TargetType)
                        {
                            carregandoPagina = true;
                            _paginaAtual = (Page)Activator.CreateInstance(item.TargetType);
                            _paginaAtual.Appearing += (sender2, e2) => {
                                carregandoPagina = false;
                            };
                            Detail = new NavigationPage(_paginaAtual);
                        }
                        masterPage.ListView.SelectedItem = null;
                        IsPresented = false;
                    }
                }
                */
			}
		}

	}
}
