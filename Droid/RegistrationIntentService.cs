using System;
using Android.App;
using Android.Content;
using Android.Gms.Gcm;
using Android.Gms.Gcm.Iid;
using Android.Util;


namespace LaudoBuilder.Droid
{
	[Service(Exported = false)]
	class RegistrationIntentService : IntentService
	{
		static readonly string[] Topics = {
		"global"
	};
		public RegistrationIntentService() : base("RegistrationIntentService")
		{ }

		protected override void OnHandleIntent(Intent intent)
		{
			try
			{
				Log.Info("RegistrationIntentService", "Calling InstanceID.GetToken");
				lock (this)
				{
					var instanceID = InstanceID.GetInstance(this);
					var token = instanceID.GetToken(
						"896558414893", GoogleCloudMessaging.InstanceIdScope, null);
					Log.Info("RegistrationIntentService", "GCM Registration Token: " + token);
					SendRegistrationToAppServer(token);
					SubscribeToTopics(token, Topics);
				}
			}
			catch (Exception e)
			{
				Log.Debug("RegistrationIntentService", "Failed to get a registration token");
				return;
			}
		}
		void SendRegistrationToAppServer(string token)
		{
			// Add custom implementation here as needed.  
		}
		void SubscribeToTopics(string token, string[] topics)
		{
			foreach (var topic in topics)
			{
				var pubSub = GcmPubSub.GetInstance(this);
				pubSub.Subscribe(token, "/topics/" + topic, null);
			}
		}
	}
}

