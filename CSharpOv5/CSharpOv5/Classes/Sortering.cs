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
    }
}
