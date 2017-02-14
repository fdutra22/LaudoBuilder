using System;

using Xamarin.Forms;

namespace LaudoBuilder
{
	public class SairPage : ContentPage
	{
		public SairPage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

