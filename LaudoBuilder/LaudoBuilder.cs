using System;
using LaudoBuilder.Pages;
using Xamarin.Forms;

namespace LaudoBuilder
{
	public class App : Application
	{
		public App()
		{
			// The root page of your application


			MainPage = new NavigationPage(new Principal());
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
