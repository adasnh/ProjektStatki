using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiWseiLibrary.Style
{
    class SrodkowanieTeksu
    {
        public static void SrodkowanieTekstu(string wiadomosc)
        {
            int ekranSzerokosc = Console.WindowWidth;
            int stringSzerokosc = wiadomosc.Length;
            int miejsca = (ekranSzerokosc / 2) + (stringSzerokosc / 2);

            Console.WriteLine("\n");


            Console.WriteLine(wiadomosc.PadLeft(miejsca));
        }
    }
}
