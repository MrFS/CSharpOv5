using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpOv5;

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

        public override int AntallSolgtePlasser
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override List<string> KjøpBillett(int antVoksne, int antBarn)
        {

        }

        public override string ToString()
        {
            return Tribunenavn + " har en billettpris på " + Pris + ",-";
        }
        
    }
}
