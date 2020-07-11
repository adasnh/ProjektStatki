
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

        // Tworzenie środowiska dla gracza
        public static ModelGracza TworzenieGracza(string nazwaGracza)
        {
            ModelGracza output = new ModelGracza();

            Console.WriteLine($"  Informacje o graczu {nazwaGracza}");

            // Pytanie o nick
            output.Nick = ZapytajONick();

            // Wczytanie siatki
            LogikaGry.TworzeniePola(output);

            // Pytanie o koordynaty dla statkow

            RozstawianieStatkow(output);


            Console.Clear();

            return output;
        }

        // Rozstawianie statków na planszy
        private static void RozstawianieStatkow(ModelGracza model)
        {
            do
            {
                Console.Write($"  Gdzie chcesz umiescic statek nr {model.miejsceStatku.Count + 1}: ");
                string miejsce = Console.ReadLine().Trim();

                bool czyDobreMiejsce = false;

                try
                {
                    czyDobreMiejsce = LogikaGry.UmiescStatek(model, miejsce);
                }
                catch (Exception x)
                {

                    Console.WriteLine("  Bład: " + x.Message);
                }

                if (czyDobreMiejsce == false)
                {
                    Console.WriteLine("  To nie jest poprawna lokalizacja.  Sprubój ponownie.");
                }
            } while (model.miejsceStatku.Count < 5);
        }

    }
}
