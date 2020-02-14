using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ATM
{
    class Program
    {

        int tentativi = 0;
        int limite_Tentativi = 3;
        string id_Utente_Corretto = "123";
        string passward_Corretta = "123";
        decimal fondiCorrenti = 0;
        decimal fondiSottratti;
        decimal fondiAddizzionati;
        decimal fondiTot;

        static void Main(string[] args)
        {
            Program program = new Program();

            program.LogIn();
            Console.Read();
        }
        void LogIn()
        {
            Console.WriteLine("inserisci id");
            string id_Utente_Input = Console.ReadLine();
            Console.WriteLine("inserisci passward");
            string password_Input = Console.ReadLine();
            if (id_Utente_Input.Equals(id_Utente_Corretto) && password_Input.Equals(passward_Corretta))
            {
                Atm_Menu();
            }

            else if (tentativi >= limite_Tentativi)
            {
                Esci();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("id o password errati");
                Console.ResetColor();
                ++tentativi;
               
                LogIn();
            }
        }
        void Atm_Menu()
        {
            Console.WriteLine("Benvenuto nel menu");
            Console.WriteLine("inserisci 1 : per aggiungere fondi");
            Console.WriteLine("inserisci 2 : per prelevare fondi");
            Console.WriteLine("inserisci 3 : per visualizza lista movimenti");
            Console.WriteLine("inserisci 4 : per  esci ");
            string input_Utente_Menu = Console.ReadLine();
            switch (input_Utente_Menu)
            {
                case "1":
                    AggiungiFondi();
                    break;

                case "2":
                    RimuoviFondi();
                    break;

                case "3":
                    ListaMovimenti();
                    break;

                case "4":
                    Esci();
                    break;

                default:
                    Atm_Menu();
                    break;
            }
        }
        void Esci()
        {
            Console.WriteLine("Premi invio per uscire");
        }
        void AggiungiFondi()
        {
            Console.WriteLine("inserisci la quantità di fondi da aggiungere");

            try
            {
                string fondiAggiunti = Console.ReadLine();
                if (fondiAggiunti.Contains("+") ||
                   fondiAggiunti.Contains("-") ||
                   fondiAggiunti.Contains("*") ||
                   fondiAggiunti.Contains(" ") ||
                   fondiAggiunti.Contains("%"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("inserisci solo l'importo da aggiungere");
                    Console.ResetColor();
                    AggiungiFondi();
                }
                else
                {
                    fondiAddizzionati = decimal.Parse(fondiAggiunti);
                    fondiTot = fondiCorrenti += fondiAddizzionati;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("al tuo conto sono stati aggiunti " + fondiAddizzionati);
                    Console.ResetColor();
                    Console.WriteLine("fondi disponibili sono " + fondiCorrenti);
                    Console.WriteLine("inserisci 1 : per tornare al menu");
                    Console.WriteLine("inserisci 2 : per uscire");
                    string rispUtente = Console.ReadLine();
                    switch (rispUtente)
                    {
                        case "1":
                            Atm_Menu();
                            break;

                        case "2":
                            Esci();
                            break;

                        default:
                            Atm_Menu();
                            break;
                    }
                }
            }

            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Devi inserire l'importo");
                Console.ResetColor();
                AggiungiFondi();
            }
        }
        void RimuoviFondi()
        {
            Console.WriteLine("inserisci la quantità di fondi da sottrare");
            string fondiRimossi = Console.ReadLine();
            if (fondiRimossi.Contains(" ") ||
                fondiRimossi.Contains("+") ||
                fondiRimossi.Contains("-") ||
                fondiRimossi.Contains("*") ||
                fondiRimossi.Contains("/") ||
                fondiRimossi.Contains("%"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("devi solo inserire l'importo");
                Console.ResetColor();
                RimuoviFondi();

            }
            else
            {
                try
                {
                    fondiSottratti = decimal.Parse(fondiRimossi);
                    if (fondiCorrenti < fondiSottratti)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("fondi non sufficenti");
                        Console.ResetColor();
                          string rispUtente = Console.ReadLine();
                        switch (rispUtente)
                        {
                            case "1":
                                Atm_Menu();
                                break;

                            case "2":
                                Esci();
                                break;

                            default:
                                Atm_Menu();
                                break;
                        }
                    }
                    fondiTot = fondiCorrenti -= fondiSottratti;
                    if (fondiCorrenti >= fondiSottratti)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("dal tuo fondo sono stati sottratti " + fondiSottratti);
                        Console.ResetColor();
                        Console.WriteLine("i tuoi fondi disponibili sono di " + fondiCorrenti);
                        Console.WriteLine("inserisci 1 : per tornare al menu");
                        Console.WriteLine("inserisci 2 : per uscire");
                        string rispUtente = Console.ReadLine();
                        switch (rispUtente)
                        {
                            case "1":
                                Atm_Menu();
                                break;

                            case "2":
                                Esci();
                                break;

                            default:
                                Atm_Menu();
                                break;
                        }
                    }
                }

                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("devi inserire solo lo'importo");
                    Console.ResetColor();
                    RimuoviFondi();
                }
            }
        }
        void ListaMovimenti()
        {
            if (fondiCorrenti >= 0)
            {
                Console.WriteLine("i tuoi fondi disponibili sono di " + fondiCorrenti);
                Console.WriteLine("inserisci 1 : per tornare al menu");
                Console.WriteLine("inserisci 2 : per uscire");
                string rispUtente = Console.ReadLine();
                switch (rispUtente)
                {
                    case "1":
                        Atm_Menu();
                        break;

                    case "2":
                        Esci();
                        break;

                    default:
                        Atm_Menu();
                        break;
                }
            }
            else
            {
                fondiCorrenti = 0;
                Console.WriteLine("i tuoi fondi disponibili sono di " + fondiCorrenti);
                Console.WriteLine("inserisci 1 : per tornare al menu");
                Console.WriteLine("inserisci 2 : per uscire");
                string rispUtente = Console.ReadLine();
                switch (rispUtente)
                {
                    case "1":
                        Atm_Menu();
                        break;

                    case "2":
                        Esci();
                        break;

                    default:
                        Atm_Menu();
                        break;
                }
            }
        }
    }

}    

    


