using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOv4.Classes.Oving
{
    public class Billett
    {
        public Billett(string tribunenavn, double pris)
        {
            Tribunenavn = tribunenavn;
            Pris = pris;
        }

        string Tribunenavn
        {
            get;
            set;
        }

        double Pris
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Tribunenavn + " har en billettpris på " + Pris + ",-";
        }

    }
}
