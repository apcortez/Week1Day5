using System;
using System.IO;

namespace Week1Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("************************");
            Console.WriteLine("* Benvenuto a Tombola! *");
            Console.WriteLine("************************");
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                int vinti;
                int numeri;
                Console.WriteLine("Scegli se giocare con 5 o 15 numeri: ");
                while (!int.TryParse(Console.ReadLine(), out numeri) || (numeri != 5 && numeri != 15))
                {
                    Console.WriteLine("Scelta non consentita. Riprova: Inserisci 5 o 15! ");
                }

                int[] numeriScelti = new int[numeri];
                numeriScelti = Scelta(numeriScelti);

                Console.WriteLine("I numeri scelti sono: ");
                StampaNumeri(numeriScelti);
                
                int diff = DifficoltaGioco();
                
                int[] numeriVincenti = new int[diff];
                numeriVincenti = Estrazione(numeriVincenti);

                GeneraFileNumeriVincenti(numeriVincenti);
                int[] numeriVincentiUtente = Controllo(numeriVincenti, numeriScelti);
                StampaControlloVittoria(numeriVincentiUtente, numeri, out vinti);
                if (vinti > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("I tuoi numeri vincenti sono: ");
                    StampaNumeri(numeriVincentiUtente);
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Vuoi continuare? Scrivi 'si' per proseguire.");
            } while (Console.ReadLine().ToLower() == "si");
        }
         
        private static void GeneraFileNumeriVincenti(int[] numeriVincenti)
        {
            string path = @"C:\Users\angelica.cortez\source\repos\Week1Day5\NumeriVincenti.txt";

            
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine("\n**Numeri Estratti**\n");
                for (int x = 0; x < numeriVincenti.Length; x++)
                {
                    sw.Write(numeriVincenti[x] + "\t");
                }

            }
        }

        private static void StampaControlloVittoria(int[] numeriVincentiUtente, int numeriScelti, out int n)
        {
            n=0;
            
            for(int x=0; x<numeriVincentiUtente.Length; x++)
            {
                if (numeriVincentiUtente[x] != 0)
                {
                    n++;
                }
            }
            
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            switch (n)
            {   
                case 2:
                    Console.WriteLine("*******************");
                    Console.WriteLine("* Hai fatto AMBO! *");
                    Console.WriteLine("*******************");
                    break;
                case 3:
                case 4:
                    Console.WriteLine("********************");
                    Console.WriteLine("* Hai fatto TERNO! *");
                    Console.WriteLine("********************");
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                    Console.WriteLine("******************************");
                    Console.WriteLine("* Bravo! Hai fatto CINQUINA! *");
                    Console.WriteLine("******************************");
                    break;
                case 15:
                    Console.WriteLine("*************************************");
                    Console.WriteLine("* Complimenti!!! Hai fatto TOMBOLA! *");
                    Console.WriteLine("*************************************");
                    break;
                default:
                    Console.WriteLine("**************************");
                    Console.WriteLine("* Mi dispice. Hai PERSO! *");
                    Console.WriteLine("**************************");
                    break;
            
        }
       
        }

        private static int[] Controllo(int[] numeriVincenti, int[] numeriScelti)
        {
            int[] numeri_vinti = new int[numeriScelti.Length];
            for(int x=0; x<numeri_vinti.Length; x++)
            {
                int trovato = Array.IndexOf(numeriVincenti, numeriScelti[x]);
                if (trovato > -1)
                {
                    numeri_vinti[x] = numeriScelti[x];
                }
            }

            return numeri_vinti;
        }

        private static int[] Estrazione(int[] numeriVincenti)
        {
            Random random = new Random();
            int nRandom;
            for(int x=0; x<numeriVincenti.Length; x++)
            {
                nRandom = random.Next(1, 91);
                int trovato = Array.IndexOf(numeriVincenti, nRandom);
                if (trovato > -1) 
                {
                    x--;
                }
                else
                {
                    numeriVincenti[x] = nRandom;
                }
            }
            return numeriVincenti;
        }

        private static int DifficoltaGioco()
        {   int difficolta;
            int n=0;
            Console.WriteLine("******************************************");
            Console.WriteLine("Scegli nel menu la difficoltà del gioco: \n1 - Facile \n2 - Medio \n3 - Difficile");
            Console.WriteLine("******************************************");
            while (!int.TryParse(Console.ReadLine(), out difficolta) || difficolta>3 || difficolta<1)
            {
                Console.WriteLine("Scelta non consentita. Riprova: Inserisci 5 o 15! ");
            }
            switch (difficolta)
            {
                case 1: 
                    n= 70;
                    break;
                case 2:
                    n = 40;
                    break;
                case 3:
                    n = 20;
                    break;
            }

            return n;

        }

        private static void StampaNumeri(int[] num)
        {
            
           foreach(var n in num)
            {
                if (n != 0)
                {
                    Console.Write(n + "\t");
                }
            }
            Console.WriteLine("\n");
        }

        private static int[] Scelta(int[] numeriScelti)
        {
            Console.WriteLine($"Inserisci {numeriScelti.Length} numeri a scelta da 1 a 90. ");
            for (int x = 0; x < numeriScelti.Length; x++)
            {
                int n = 0;
                Console.WriteLine($"Inserisci il {x + 1}^ numero: ");
               
                while (!int.TryParse(Console.ReadLine(), out n) || n > 90 || n < 0 ) 
                {
                    Console.WriteLine("Scelta non consentita. Riprova: ");
                }
                
                numeriScelti[x] = n;
            }
            return numeriScelti;
        }

        
    }
}
