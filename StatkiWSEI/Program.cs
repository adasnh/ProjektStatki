using System;
using StatkiWseiLibrary.Modele;
using StatkiWseiLibrary.Style;
using System.Globalization;
using StatkiWseiLibrary;

namespace StatkiWSEI
{
    class Program
    {
        static void Main(string[] args)
        {
            StyleGry.StatkiTytułStart();
            EkranKonsoli.WiadomoscPowitalna();

            ModelGracza aktywnyGracz = EkranKonsoli.TworzenieGracza("Gracz 1");
            ModelGracza przeciwnik = EkranKonsoli.TworzenieGracza("Gracz 2");
            ModelGracza zwyciezca = null;

            do
            {
                WyswietelMiejsceStrzalu(aktywnyGracz);

                ZapiszStrzal(aktywnyGracz, przeciwnik);

                bool czyGraDalejTrwa = LogikaGry.AktywnyGracz(przeciwnik);

                if (czyGraDalejTrwa == true)
                {


                    // Zamiana aktywnego gracza
                    (aktywnyGracz, przeciwnik) = (przeciwnik, aktywnyGracz);


                }
                else
                {
                    zwyciezca = aktywnyGracz;
                }

            } while (zwyciezca == null);

            ZidentyfikujWygranego(zwyciezca);

            Console.ForegroundColor = ConsoleColor.Blue;

            WyswietelMiejsceStrzalu(zwyciezca);

            StyleGry.StatkiTytułKoniec();

            Console.ReadLine();
        }

        // prywatne metody

        private static void ZidentyfikujWygranego(ModelGracza zwyciezca)
        {
            Console.WriteLine($"  Gratulacje dla {zwyciezca.Nick} za wygraną!");
            Console.WriteLine($"  {zwyciezca.Nick} potrzebował {LogikaGry.LicznikStrzalow(zwyciezca)} strzałów.");
            Console.WriteLine();
        }

        private static void ZapiszStrzal(ModelGracza aktywnyGracz, ModelGracza przeciwnik)
        {
            bool czyPoprawnyStrzal = false;
            string wiersz = "";
            int kolumna = 0;

            do
            {
                string strzal = ZapytajOKoordynatyDoStrzalu(aktywnyGracz);
                try
                {
                    (wiersz, kolumna) = LogikaGry.PodzialNaKolumnyIWiersze(strzal) ;
                    czyPoprawnyStrzal = LogikaGry.WalidacjaStrzalu(aktywnyGracz, wiersz, kolumna);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Błąd: " + ex.Message);
                    czyPoprawnyStrzal = false;
                }

                if (czyPoprawnyStrzal == false)
                {
                    Console.WriteLine("Błędne miejsce strzały. Spróbuj ponownie");
                }

            } while (czyPoprawnyStrzal == false);

            bool czyTrafiony = LogikaGry.RezultatStrzaluAktywnegoGracza(przeciwnik, wiersz, kolumna);

            LogikaGry.RezultatStrzaluPrzeciwnik(aktywnyGracz, wiersz, kolumna, czyTrafiony);

            WyswietlRezultatStrzalu(wiersz, kolumna, czyTrafiony);
        }
        private static string ZapytajOKoordynatyDoStrzalu(ModelGracza gracz)
        {
            Console.Write($"  {gracz.Nick}, podaj miejsce strzału: ");
            string wynik = Console.ReadLine().Trim();

            return wynik;
        }

        private static void WyswietlRezultatStrzalu(string wiersz, int kolumna, bool czyTrafiony)
        {
            if (czyTrafiony)
            {
                Console.WriteLine($"  {wiersz}{kolumna} trafiony!");
            }
            else
            {
                Console.WriteLine($"  {wiersz}{kolumna} pudło.");

            }

            Console.WriteLine();
        }

        

        private static void WyswietelMiejsceStrzalu(ModelGracza aktywnyGracz)
        {
            string obecnyWiersz = aktywnyGracz.miejsceStatku[0].LiteraPola;

            foreach (var poleSiatki in aktywnyGracz.poleStrzalu)
            {
                if (poleSiatki.LiteraPola != obecnyWiersz)
                {
                    Console.WriteLine();
                    obecnyWiersz = poleSiatki.LiteraPola;
                }

                if (poleSiatki.Status == StatusPola.Pusty)
                {
                    Console.Write($" {poleSiatki.LiteraPola}{poleSiatki.NumerPola} ");

                }
                else if (poleSiatki.Status == StatusPola.Trafiony)
                {
                    Console.Write(" X  ");
                }
                else if (poleSiatki.Status == StatusPola.Pudło)
                {
                    Console.Write(" O  ");
                }
                else
                {
                    Console.Write(" ?  ");
                }
            }

            Console.WriteLine();
            Console.WriteLine();

        }
    }
}
