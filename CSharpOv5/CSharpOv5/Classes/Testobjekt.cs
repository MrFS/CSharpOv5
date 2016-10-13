using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOv5.Classes
{
    class Testobjekt : IComparable
    {
        public int Verdi
        {
            get;
            set;
        }
        public Testobjekt(int v)
        {
            Verdi = v;
        }
        public int CompareTo(Object detAndre)
        {
            if (!(detAndre is Testobjekt)) return -1;
            Testobjekt t = (Testobjekt)detAndre;
            if (Verdi < t.Verdi) return -1;
            else if (Verdi > t.Verdi) return 1;
            else return 0;
        }
    }
}
