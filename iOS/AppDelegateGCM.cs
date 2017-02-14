using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Google.GoogleCloudMessaging;
using Google.InstanceID;
using UIKit;

namespace LaudoBuilder.iOS
{
	[Register("AppDelegateGCM")]
	public partial class AppDelegateGCM : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate,
	IInstanceIdDelegate, IReceiverDelegate
	{
		public Google.Core.Configuration Configuration { get; set; }
		NSData DeviceToken { get; set; }

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			NSError err;
			Google.Core.Context.SharedInstance.Configure(out err);
			if (err != null)
				Console.WriteLine("Failed to configure Google: {0}", err.LocalizedDescription);
			Configuration = Google.Core.Context.SharedInstance.Configuration;


			// Configure and Start GCM
			var gcmConfig = Google.GoogleCloudMessaging.Config.DefaultConfig;
			gcmConfig.ReceiverDelegate = this;
			Service.SharedInstance.Start(gcmConfig);

			// Register for remote notifications
			var notTypes = UIUserNotificationType.Sound | UIUserNotificationType.Alert | UIUserNotificationType.Badge;
			var settings = UIUserNotificationSettings.GetSettingsForTypes(notTypes, null);
			UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
			UIApplication.SharedApplication.RegisterForRemoteNotifications();

			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
		public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken)
		{

			// Save our token in memory for future calls to GCM
			DeviceToken = deviceToken;

			// Configure and start Instance ID
			var config = Google.InstanceID.Config.DefaultConfig;
			InstanceId.SharedInstance.Start(config);

			// Get a GCM token
			GetToken();
		}

		void GetToken()
		{
			// Register APNS Token to GCM
			var options = new NSDictionary();
			options.SetValueForKey(DeviceToken, Constants.RegisterAPNSOption);
			options.SetValueForKey(new NSNumber(true), Constants.APNSServerTypeSandboxOption);

			// Get our token
			InstanceId.SharedInstance.Token(
				"532603111238",//My sender id here,
				Constants.ScopeGCM,
				options,
				(token, error) => Console.WriteLine("GCM Registration ID: " + token));
		}

		public override void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
		{
			// Your own notification handling logic here

			// Notify GCM we received the message
			Service.SharedInstance.AppDidReceiveMessage(userInfo);
		}

		public override void OnActivated(UIApplication application)
		{
			Service.SharedInstance.Connect(error =>
			{
				if (error != null)
					Console.WriteLine("Could not connect to GCM: {0}", error.LocalizedDescription);
				else
					Console.WriteLine("Connected to GCM");
			});
		}

		public override void DidEnterBackground(UIApplication application)
		{
			Service.SharedInstance.Disconnect();
		}

		public void DeleteToken()
		{
			InstanceId.SharedInstance.DeleteToken(
				"532603111238",//My sender id here
				Constants.ScopeGCM,
				error =>
				{
				// Callback, non-null error if there was a problem
				if (error != null)
						Console.WriteLine("Deleted Token");
					else
						Console.WriteLine("Error deleting token");
				});
		}

		int messageId = 1;

		// We can send upstream messages back to GCM
		public void SendUpstreamMessage()
		{
			var msg = new NSDictionary();
			msg.SetValueForKey(new NSString("1234"), new NSString("userId"));
			msg.SetValueForKey(new NSString("hello world"), new NSString("msg"));

			var to = "532603111238" + "@gcm.googleapis.com";

			Service.SharedInstance.SendMessage(msg, to, (messageId++).ToString());
		}

		[Export("didDeleteMessagesOnServer")]
		public void DidDeleteMessagesOnServer()
		{
			// ...
		}

		[Export("didSendDataMessageWithID:")]
		public void DidSendDataMessage(string messageID)
		{
			// ...
		}

		[Export("willSendDataMessageWithID:error:")]
		public void WillSendDataMessage(string messageID, NSError error)
		{
			// ...
		}
	}
}
