using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using Plugin.Permissions;


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

            TelaAndroid.Largura = (int)Resources.DisplayMetrics.WidthPixels; // real pixels
            TelaAndroid.Altura = (int)Resources.DisplayMetrics.HeightPixels;
            TelaAndroid.LarguraSemPixel = (int)Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density; // real pixels
            TelaAndroid.AlturaSemPixel = (int)Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density; // real pixels

            TelaAndroid.LarguraDPI = (int)Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Xdpi; // real pixels
            TelaAndroid.AlturaDPI = (int)Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Ydpi; // real pixels

            TelaAndroid.Orientacao = Resources.Configuration.Orientation.ToString();

            if (IsPlayServicesAvailable())
			{
				var intent = new Intent(this, typeof(RegistrationIntentService));
				StartService(intent);
			}
			//var listener = new BroadcastAndroid();
			//RegisterReceiver(listener, new IntentFilter(Intent.ActionBootCompleted));
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

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}
