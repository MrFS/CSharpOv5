using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOv5.Classes
{
    public class Sortering
    {
        public delegate bool Sammenligner(object o1, object o2);
        public static void sorter(object[] tab, Sammenligner Sml)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                for (int j = 0; j < tab.Length - 1; j++)
                {
                    if (Sml(tab[j], tab[j + 1])) bytt(tab, j, j + 1);
                }
            }
        }
        private static void bytt(object[] tab, int i, int j)
        {
            object temp = tab[i];
            tab[i] = tab[j];
            tab[j] = temp;
        }

        public static Tribune[] SorterNavn(Tribune[] o1)
        {
            Array.Sort(o1, 
                       delegate(Tribune x, Tribune y) { return string.Compare(x.Navn, y.Navn); });

            return o1;
        }

        public static Tribune[] SorterSolgtFor(Tribune[] o1)
        {
            Array.Sort(o1,
                       delegate (Tribune x, Tribune y) { return x.SolgtFor().CompareTo(y.SolgtFor()); });

            //var sort = o1.OrderBy(Tribune => Tribune.AntallSolgtePlasser).ToArray();

            //o1.OrderByDescending(Tribune => Tribune.SolgtFor());


            Array.Reverse(o1);

            return o1;
        }
    }

}
