using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

namespace LaudoBuilder.Model
{
	[Table("Laudo")]
	public class LaudoInfo
	{
        public int Id { get; set; }
		public string Titulo { get; set; }
		public string ImagemUrl { get; set; }
        public string FotoBase64 { get; set; }


       
        private ImageSource _Image;
        public ImageSource Image
        {
            get
           {
                if (_Image == null)
                {
                    _Image = Xamarin.Forms.ImageSource.FromStream(
                        () => new MemoryStream(Convert.FromBase64String(FotoBase64)));
                }
               return _Image;
            }
        }
    }
}
