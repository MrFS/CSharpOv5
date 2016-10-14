using CSharpOv5.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpOv5
{
    class Program
    {
        static void Main(string[] args)
        {
            Sittetribune st = new Sittetribune("Felt A", 250, 200, 10);
            Ståtribune stt = new Ståtribune("Felt B", 100, 1000);
            VIPtribune vp = new VIPtribune("Felt C", 500, 100, 5);

            Tribune[] tribuner = new Tribune[3] { st, stt, vp };

            Console.WriteLine("Velkommen til et tilbakestående billettsystem\nVelg hvilken billettype du vil ha:");

            do
            {
                
                Console.WriteLine("Trykk A for sittebilletter; B for ståbilletter; C for VIPbilletter");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.A:

                        int x, y;
                        Console.WriteLine("\nSittebilletter bestilling\nHvor mange voksne: "); x = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Hvor mange barn: "); y = Convert.ToInt32(Console.ReadLine());

                        string[] antVoksne = new string[x];
                        string[] antBarn = new string[y];

                        Console.WriteLine("Sittebilletter\n");

                        List<string> ress = st.KjopBillett(antVoksne, antBarn);

                        foreach (var item in ress)
                        {
                            Console.WriteLine(item);
                        }

                        Console.Write(st.SolgtFor() + "\n" + st.AntallSolgtePlasser + "\n\n");

                        ress.Clear();

                        break;
                    case ConsoleKey.B:

                        Console.WriteLine("\nStåbilletter bestilling\nHvor mange voksne: "); x = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Hvor mange barn: "); y = Convert.ToInt32(Console.ReadLine());

                        string[] antVoksneStabillett = new string[x];
                        string[] antBarnStabillett = new string[y];

                        Console.WriteLine("Sittebilletter\n");

                        ress = stt.KjopBillett(antVoksneStabillett, antBarnStabillett);

                        foreach (var item in ress)
                        {
                            Console.WriteLine(item);
                        }

                        Console.Write("Hittil er det solgt for " + stt.SolgtFor() + ",-\nAntall solgte plasser: " + stt.AntallSolgtePlasser + "\n\n");

                        ress.Clear();

                        break;
                    case ConsoleKey.C:

                        int ant = 0;
                        
                        Console.WriteLine("\nVIPbilletter bestilling\nSkriv hvor mange voksne: "); ant = Convert.ToInt32(Console.ReadLine());

                        string[] voksne = new string[ant];

                        Console.WriteLine("Skriv navn på de voksne: ");

                        for (int i = 0; i < voksne.Length; i++)
                        {
                            voksne[i] = Console.ReadLine();
                        }
                        
                        Console.WriteLine("Skriv hvor mange barn: "); ant = Convert.ToInt32(Console.ReadLine());

                        string[] barn = new string[ant];

                        Console.WriteLine("Skriv navn på barn: ");

                        for (int i = 0; i < barn.Length; i++)
                        {
                            barn[i] = Console.ReadLine();
                        }

                        ress = vp.KjopBillett(voksne, barn);

                        foreach (var item in ress)
                        {
                            Console.WriteLine(item);
                        }

                        Console.Write(vp.SolgtFor() + "\n" + vp.AntallSolgtePlasser + "\n\n");

                        break;
                    default:
                        break;
                }

                Console.WriteLine("\nSortering av tribuner etter navn\n");

                Tribune[] s = new Tribune[3] { vp, stt, st };

                Sortering.SorterNavn(s);

                foreach (var item in s)
                {
                    Console.Write(item.Navn + "\n");
                }

                Console.WriteLine("\nSortering etter hvor mye solgt for");

                Sortering.SorterSolgtFor(s);

                foreach (var item in s)
                {
                    Console.WriteLine(item.Navn + " har solgt for: " + item.SolgtFor());
                }

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            
            Console.Read();
            
        }
        
    }
    
}
