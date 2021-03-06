﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatkiWseiLibrary.Modele;

namespace StatkiWseiLibrary
{
    public static class LogikaGry
    {
        // Stworzenie siatki o wymierach 5 x 5
        public static void TworzeniePola(ModelGracza model)
        {
            List<string> litery = new List<string> { "A", "B", "C", "D", "E" };
            List<int> numery = new List<int> { 1, 2, 3, 4, 5 };
            foreach (string litera in litery)
            {
                foreach (int numer in numery)
                {
                    DodajPole(model, litera, numer);
                }
            }
        }
        
        //Stworzenie siatki dla gracza
        private static void DodajPole(ModelGracza model, string litera, int numer)
        {
            ModelSiatki pole = new ModelSiatki

            {
                LiteraPola = litera,
                NumerPola = numer,
                Status = StatusPola.Pusty
            };

            model.poleStrzalu.Add(pole);
        }

        // Okreslenie aktywnego gracza

        public static bool AktywnyGracz(ModelGracza gracz)
        {
            bool czyAktywny = false;

            foreach (var statek in gracz.miejsceStatku)
            {
                if (statek.Status != StatusPola.Zatopiony)
                {
                    czyAktywny = true;
                }
            }

            return czyAktywny;
        }

        // Umieszczanie statkow na planszy wraz  z walidacja 
        public static bool UmiescStatek(ModelGracza model, string lokalizacja)
        {
            bool wynik = false;
            (string wiersz, int kolumna) = PodzialNaKolumnyIWiersze(lokalizacja);

            bool czyWlasciwaLokalizacjaPola = WalidacjaPola(model, wiersz, kolumna);
            bool czyWolnePole = WalidacjaPolozeniaStatku(model, wiersz, kolumna);

            if (czyWlasciwaLokalizacjaPola && czyWolnePole)
            {
                model.miejsceStatku.Add(new ModelSiatki
                {
                    LiteraPola = wiersz.ToUpper(),
                    NumerPola = kolumna,
                    Status = StatusPola.Statek
                });

                wynik = true;
            }

            return wynik;
        }

        private static bool WalidacjaPolozeniaStatku(ModelGracza model, string wiersz, int kolumna)
        {
            bool czyWlasciwaLokalizacja = true;

            foreach (var ship in model.miejsceStatku)
            {
                if (ship.LiteraPola == wiersz.ToUpper() && ship.NumerPola == kolumna)
                {
                    czyWlasciwaLokalizacja = false;
                }
            }

            return czyWlasciwaLokalizacja;
        }

        private static bool WalidacjaPola(ModelGracza model, string wiersz, int kolumna)
        {
            bool czyWlasciwaLokalizacja = false;

            foreach (var ship in model.poleStrzalu)
            {
                if (ship.LiteraPola == wiersz.ToUpper() && ship.NumerPola == kolumna)
                {
                    czyWlasciwaLokalizacja = true;
                }
            }

            return czyWlasciwaLokalizacja;
        }



        public static (string wiersz, int kolumna) PodzialNaKolumnyIWiersze(string strzal)
        {
            string wiersz = "";
            int kolumna = 0;

            if (strzal.Length != 2)
            {
                throw new ArgumentException("  Wprowadz poprawne koordynaty.");
            }

            char[] strzaly = strzal.ToArray();

            wiersz = strzaly[0].ToString();
            kolumna = int.Parse(strzaly[1].ToString());

            return (wiersz, kolumna);
        }

        public static int LicznikStrzalow(ModelGracza gracz)
        {
            int licznikStrzalow = 0;

            foreach (var strzal in gracz.poleStrzalu)
            {
                if (strzal.Status != StatusPola.Pusty)
                {
                    licznikStrzalow += 1;
                }
            }

            return licznikStrzalow;
        }
        public static bool WalidacjaStrzalu(ModelGracza gracz, string wiersz, int kolumna)
        {
            bool czyPoprawny = false;

            foreach (var poleSiatki in gracz.poleStrzalu)
            {
                if (poleSiatki.LiteraPola == wiersz.ToUpper() && poleSiatki.NumerPola == kolumna)
                {
                    if (poleSiatki.Status == StatusPola.Pusty)
                    {
                        czyPoprawny = true;
                    }
                }
            }

            return czyPoprawny;
        }
        public static bool RezultatStrzaluAktywnegoGracza(ModelGracza przeciwnik , string wiersz, int kolumna)
        {
            bool czyTrafiony = false;

            foreach (var statek in przeciwnik.miejsceStatku)
            {
                if (statek.LiteraPola == wiersz.ToUpper() && statek.NumerPola == kolumna)
                {
                    czyTrafiony = true;
                    statek.Status = StatusPola.Zatopiony;
                }
            }

            return czyTrafiony;
        }
        public static void RezultatStrzaluPrzeciwnik(ModelGracza gracz, string wiersz, int kolumna, bool czyTrafiony )
        {

            foreach (var poleSiatki in gracz.poleStrzalu)
            {
                if (poleSiatki.LiteraPola == wiersz.ToUpper() && poleSiatki.NumerPola == kolumna)
                {
                    if (czyTrafiony)
                    {
                        poleSiatki.Status = StatusPola.Trafiony;
                    }
                    else
                    {
                        poleSiatki.Status = StatusPola.Pudło;
                    }
                }
            }

        }
    }
}
