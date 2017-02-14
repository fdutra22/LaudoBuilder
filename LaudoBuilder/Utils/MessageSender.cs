using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LaudoBuilder
{
	class MessageSender
	{
		public const string API_KEY = "AAAA0L8LvC0:APA91bEZoHw3rfkVhc4k1AGl7VbxeV0zqJZzWQJNzUm-03xYVvSJjxc7fw6tUgz3FRwvJiIYVnIDje57yLuI2oD6LdWNFKAaSF968CCJ1Q04J1K8RL7q5m7KNxG1ErV7ZmfoyVyKN3aK";
		public const string MESSAGE = "Hello, Xamarin!";

		public void EnviaMensagem(string message)
		{
			var jGcmData = new JObject();
			var jData = new JObject();

			jData.Add("message", message);
			jGcmData.Add("to", "/topics/global");
			jGcmData.Add("data", jData);

			var url = new Uri("https://gcm-http.googleapis.com/gcm/send");
			try
			{
				using (var client = new HttpClient())
				{
					client.DefaultRequestHeaders.Accept.Add(
						new MediaTypeWithQualityHeaderValue("application/json"));

					client.DefaultRequestHeaders.TryAddWithoutValidation(
						"Authorization", "key=" + API_KEY);

					Task.WaitAll(client.PostAsync(url,
					        new StringContent(jGcmData.ToString(), Encoding.UTF8, "application/json"))
							.ContinueWith(response =>
							{
								Debug.WriteLine(response);
								Debug.WriteLine("Message sent: check the client device notification tray.");
							}));
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine("Unable to send GCM message:");
				Debug.WriteLine(e.StackTrace);
			}
		}
	}
}