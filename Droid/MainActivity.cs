using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;

namespace LaudoBuilder.Droid
{
	[Activity(Label = "LaudoBuilder.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			if (IsPlayServicesAvailable())
			{
				var intent = new Intent(this, typeof(RegistrationIntentService));
				StartService(intent);
			}
			var listener = new BroadcastAndroid();
			RegisterReceiver(listener, new IntentFilter(Intent.ActionBootCompleted));
			LoadApplication(new App());
		}

		public bool IsPlayServicesAvailable()
		{
			int resultCode = GooglePlayServicesUtil.IsGooglePlayServicesAvailable(this);
			if (resultCode == 0)
			{
				Toast.MakeText(this, "Google Play Services is available.", ToastLength.Short)
					.Show();
				return true;
			}
			return false;
		}
	}
}
