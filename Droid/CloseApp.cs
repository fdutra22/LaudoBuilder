using Android.App;
using Xamarin.Forms;
using LaudoBuilder.Droid;
using LaudoBuilder.IDAL;
using Android.OS;

[assembly: Dependency(typeof(CloseApp))]

namespace LaudoBuilder.Droid
{
    public class CloseApp : ICloseApp
    {
        public void closeApplication()
        {
            Process.KillProcess(Process.MyPid());
        }
    }
}