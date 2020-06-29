using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatkiWseiLibrary.Style
{
    class StyleGry
    {
        public static void StatkiTytułStart()
        {

            Console.ForegroundColor = ConsoleColor.DarkBlue;

            Console.Title = "Statki WSEI 2020";
            Console.WriteLine(); 
            string statkiStartowaGrafika =
                 @" 
                         ######  ########    ###    ######## ##    ##  #### 
                        ##    ##    ##      ## ##      ##    ##   ##    ##  
                        ##          ##     ##   ##     ##    ##  ##     ##  
                         ######     ##    ##     ##    ##    #####      ##  
                              ##    ##    #########    ##    ##  ##     ##  
                        ##    ##    ##    ##     ##    ##    ##   ##    ##  
                         ######     ##    ##     ##    ##    ##    ##  ####   
                ";

            Console.WriteLine(statkiStartowaGrafika);
            Console.WriteLine(); 
            Console.ForegroundColor = ConsoleColor.Yellow;
            SrodkowanieTeksu.SrodkowanieTekstu("Nacisnij enter aby kontynuowac...");
            Console.ReadKey();
            Console.Clear();

        }

        public static void StatkiTytułKoniec()
        {

            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.Title = "Statki";
            Console.WriteLine(); 
            string statkiKoncowaGrafika =
                 @"
                       
                        ##    ##  #######  ##    ## #### ########  ######      ######   ########  ##    ## 
                        ##   ##  ##     ## ###   ##  ##  ##       ##    ##    ##    ##  ##     ##  ##  ##  
                        ##  ##   ##     ## ####  ##  ##  ##       ##          ##        ##     ##   ####   
                        #####    ##     ## ## ## ##  ##  ######   ##          ##   #### ########     ##    
                        ##  ##   ##     ## ##  ####  ##  ##       ##          ##    ##  ##   ##      ##    
                        ##   ##  ##     ## ##   ###  ##  ##       ##    ##    ##    ##  ##    ##     ##    
                        ##    ##  #######  ##    ## #### ########  ######      ######   ##     ##    ##  
                        
                                                                                          
   
                ";

            maszynaDoPisania(statkiKoncowaGrafika);
            Console.WriteLine(); 
            Console.ForegroundColor = ConsoleColor.Yellow;
            SrodkowanieTeksu.SrodkowanieTekstu("Nacisnij enter aby kontynuowac...");
            Console.ReadKey();
            Console.Clear();

        }

        public static void maszynaDoPisania(string wiadomosc)
        {
            for (int i = 0; i < wiadomosc.Length; i++)
            {
                Console.Write(wiadomosc[i]);
                System.Threading.Thread.Sleep(1);

            }

        }


    }
}
