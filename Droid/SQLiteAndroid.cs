using Android.Content;
using Xamarin.Forms;
using LaudoBuilder.Droid;
using System.IO;
using SQLite;

[assembly: Dependency(typeof(SQLiteAndroid))]

namespace LaudoBuilder.Droid
{
    public class SQLiteAndroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string sqliteFilename = "laudobuilder.sqlite";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentsPath, sqliteFilename);
            if (!File.Exists(path))
            {

                Context context = Android.App.Application.Context;
                Stream origem = context.Assets.Open(sqliteFilename);
                FileStream destino = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                origem.CopyTo(destino);
                origem.Close();
                destino.Close();
            }
            SQLiteConnection cnn = new SQLiteConnection(path);
            return cnn;
        }
    }
}