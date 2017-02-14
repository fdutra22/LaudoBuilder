using System;
using Android.App;
using Android.Content;
using Android.Gms.Gcm;
using Android.OS;
using Android.Util;
using Xamarin.Forms;

namespace LaudoBuilder.Droid
{
	[Service(Exported = false), IntentFilter(new[] {"com.google.android.c2dm.intent.RECEIVE"})]

	public class MyGcmListenerService : GcmListenerService
	{
		public override void OnMessageReceived(string from, Bundle data)
		{
			// Extract the message received from GCM:  
			var message = data.GetString("message");
			Log.Debug("MyGcmListenerService", "From: " + from);
			Log.Debug("MyGcmListenerService", "Message: " + message);
			// Forward the received message in a local notification:  
			SendNotification(message);
		}
		// Use Notification Builder to create and launch the notification:  
		void SendNotification(string message)
		{
			vibrar(1500);
			var intent = new Intent(this, typeof(MainActivity));
			intent.AddFlags(ActivityFlags.ClearTop);
			var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);
			var notificationBuilder = new Notification.Builder(this)
			                                          .SetSmallIcon(Resource.Drawable.ic_play_light) //Icon  
			.SetContentTitle("LaudoBuilder - Notificação") //Title  
			.SetContentText(message) //Message  
			.SetAutoCancel(true)
			.SetContentIntent(pendingIntent);
			var notificationManager = (NotificationManager)GetSystemService(Context.NotificationService);
			notificationManager.Notify(0, notificationBuilder.Build());
		}

		public void vibrar(int milisegundo)
		{
			Context context = Android.App.Application.Context;
			Vibrator vibrator = (Vibrator)context.GetSystemService(Context.VibratorService);
			vibrator.Vibrate(milisegundo);
		}
	}
}

