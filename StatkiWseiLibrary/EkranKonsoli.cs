
using System;
using System.Globalization;
using StatkiWseiLibrary.Modele;
using StatkiWseiLibrary.Style;


namespace StatkiWseiLibrary
{
    public static class EkranKonsoli
    {
        public static void WiadomoscPowitalna()
        {
            SrodkowanieTeksu.SrodkowanieTekstu("Witaj w grze STATKI");
            Console.WriteLine("");
        }

        public static string ZapytajONick()
        {
            Console.Write("  Podaj swoje imie: ");
            string wyjscieprzed = Console.ReadLine().Trim();
            string wyjscie = new CultureInfo("pl-PL").TextInfo.ToTitleCase(wyjscieprzed);

            return wyjscie;
        }

        public static ModelGracza TworzenieGracza(string nazwaGracza)
        {
            ModelGracza output = new ModelGracza();

            Console.WriteLine($"  Informacje o graczu {nazwaGracza}");

            // Pytanie o nick
            output.Nick = ZapytajONick();

            //tworzenie pola dla gracza
            LogikaGry.TworzeniePola(output);

            

            

            
            Console.Clear();

            return output;
        }


    }
}
