using Xamarin.Forms;
using LaudoBuilder.Droid;
using LaudoBuilder.IDAL;

[assembly: Dependency(typeof(TelaAndroid))]

namespace LaudoBuilder.Droid
{
    public class TelaAndroid : ITela
    {
        public static float Largura { get; set; }
        public static float LarguraSemPixel { get; set; }
        public static float AlturaSemPixel { get; set; }
        public static float LarguraDPI { get; set; }
        public static float AlturaDPI { get; set; }
        public static float Altura { get; set; }
        public static string Orientacao { get; set; }
        public static string Dispositivo { get; set; }

        public float pegarAltura()
        {
            return (float)Altura;
        }

        public float pegarLargura()
        {
            return (float)Largura;
        }

        public float pegarLarguraSemPixel()
        {
            return (float)LarguraSemPixel;
        }

        public float pegarAlturaSemPixel()
        {
            return (float)AlturaSemPixel;
        }

        public float pegarAlturaDPI()
        {
            return (float)AlturaDPI;
        }

        public float pegarLarguraDPI()
        {
            return (float)LarguraDPI;
        }

        public string pegarOrientacao()
        {
            return Orientacao;
        }

        public string pegarDispositivo()
        {
            return Dispositivo;
        }

    }
}