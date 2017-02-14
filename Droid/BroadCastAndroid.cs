using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace LaudoBuilder.Droid
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Intent.ActionBootCompleted })]
    public class BroadcastAndroid : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
			if (intent.Action == Intent.ActionBootCompleted)
			{
				Intent pushIntent = new Intent(context, typeof(MainActivity));
				//pushIntent.AddFlags(ActivityFlags.NewTask);
				context.StartService(pushIntent);
				//context.StartService(pushIntent);
				InvokeAbortBroadcast();
			}
			else if (intent.Action == Intent.ActionProviderChanged)
			{
				Intent pushIntent = new Intent(context, typeof(MainActivity));
				context.StartService(pushIntent);
				InvokeAbortBroadcast();
			}

           
            
            else if (intent.Action == "Fechar")
            {
                NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);
                notificationManager.Cancel(1);
                System.Environment.Exit(0);
                //Process.KillProcess(Process.MyPid());
            }
        }
    }
}