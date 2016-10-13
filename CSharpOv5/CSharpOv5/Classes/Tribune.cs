using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOv5
{
    public abstract class Tribune : ICloneable
    {
        public Tribune(string navn, double pris, int kap)
        {
            Navn = navn;
            Pris = pris;
            Kapasitet = kap;
        }

        public string Navn
        {
            get;
            private set;
        }

        public double Pris
        {
            get;
            private set;
        }

        public int Kapasitet
        {
            get;
            private set;
        }

        public int Barn
        {
            get;
            set;
        }

        public abstract object Clone();
        public double SolgtFor()
        {
            double barn = Barn * BarnePris();
            double voksne = (AntallSolgtePlasser - Barn) * Pris;

            return barn + voksne;
        }
        public abstract int AntallSolgtePlasser
        {
            get;
        }

        public abstract List<string> KjøpBillett(int antVoksne, int antBarn);

        public virtual double BarnePris()
        {
            return Pris / 2;
        }

        public virtual Tuple<bool, int, int> SelgPlasser(int antall)
        {
            return Tuple.Create(false, 0, 0);
        }

        public override string ToString()
        {
            return Navn + " har kapasitet " + Kapasitet + " og pris " + Pris + " kroner.";
        }
    }

    public class Ståtribune : Tribune
    {
        private int antallSolgtePlasser;
        public Ståtribune(string navn, double pris, int kap)
            : base(navn, pris, kap)
        {
            antallSolgtePlasser = 0;
        }
        public override int AntallSolgtePlasser
        {
            get
            {
                return antallSolgtePlasser;
            }
        }

        public override Tuple<bool, int, int> SelgPlasser(int antall)
        {
            if (AntallSolgtePlasser + antall <= Kapasitet)
            {
                antallSolgtePlasser += antall;
                return Tuple.Create(true, 0, 0);
            }
            else return Tuple.Create(false, 0, 0);
        }

        public override object Clone()
        {
            Ståtribune t = new Ståtribune(Navn, Kapasitet, (int)Pris);
            t.antallSolgtePlasser = antallSolgtePlasser;
            return t;
        }

        public override List<string> KjøpBillett(int antVoksne, int antBarn)
        {
            List<string> res = new List<string>();

            res.Add("Voksenbilletter\nRad\tPlass\tPris");

            for (int i = 0; i < antVoksne; i++)
            {
                Tuple<bool, int, int> getTup = SelgPlasser(1);

                if (getTup.Item1)
                {
                    res.Add(getTup.Item2 + "\t" + getTup.Item3 + "\t" + Pris);
                }
                else
                {
                    res.Add("Ingen voksenbilletter tilgjengelig");
                    break;
                }
            }

            res.Add("\nBarnebilletter\nRad\tPlass\tPris");

            for (int i = 0; i < antBarn; i++)
            {
                Tuple<bool, int, int> getTup = SelgPlasser(1);

                if (getTup.Item1)
                {
                    
                    res.Add(getTup.Item2 + "\t" + getTup.Item3 + "\t" + BarnePris());
                }
                else
                {
                    res.Add("Ingen barnebilletter tilgjengelig");
                    break;
                }
            }

            return res;
        }
    }

    public class Sittetribune : Tribune
    {
        private int[] antallSolgtPrRad;
        private int rad, plass;

        public Sittetribune(string navn, double pris, int kap, int antRader)
            : base(navn, pris, kap)
        {
            AntallRader = antRader;
            antallSolgtPrRad = new int[AntallRader];
            for (int i = 0; i < AntallRader; i++) antallSolgtPrRad[i] = 0;

            rad = 1;
            plass = 1;
        }

        public int AntallRader
        {
            get;
            private set;
        }

        public int Plass
        {
            get
            {
                return plass;
            }
            set
            {
                if (plass > Kapasitet / AntallRader)
                {
                    plass = 0;
                    rad++;
                }
                else
                {
                    plass++;
                }
            }
        }

        public int Rad
        {
            get;set;
        }

        public override int AntallSolgtePlasser
        {
            get
            {
                int total = 0;
                for (int i = 0; i < AntallRader; i++) total += antallSolgtPrRad[i];
                return total;
            }
        }


        public override Object Clone()
        {
            Sittetribune t = new Sittetribune(Navn, Kapasitet, (int)Pris, AntallRader);
            for (int i = 0; i < AntallRader; i++)
            {
                t.antallSolgtPrRad[i] = antallSolgtPrRad[i];
            }
            return t;
        }


        public override Tuple<bool, int, int> SelgPlasser(int antall)
        {
            int kapPrRad = Kapasitet / AntallRader;
            int i = 0;
            while (i < AntallRader && antallSolgtPrRad[i] + antall > kapPrRad) i++;
            if (i < AntallRader)
            {
                antallSolgtPrRad[i] += antall;

                Tuple<bool, int, int> tup = new Tuple<bool, int, int>(true, Rad, Plass);

                return tup;
            }
            else { Tuple<bool, int, int> tup = new Tuple<bool, int, int>(false, 0, 0); return tup; };
        }

        public override List<string> KjøpBillett(int antVoksne, int antBarn)
        {

            List<string> res = new List<string>();

            res.Add("Voksenbilletter\nRad\tPlass\tPris");

            for (int i = 0; i < antVoksne; i++)
            {
                Tuple<bool, int, int> getTup = SelgPlasser(1);

                if (getTup.Item1)
                {
                    Plass++;
                    res.Add(getTup.Item2 + "\t" + getTup.Item3 + "\t" + Pris);
                }
                else
                {
                    res.Add("Ingen voksenbilletter tilgjengelig");
                    break;
                }
            }

            res.Add("\nBarnebilletter\nRad\tPlass\tPris");

            for (int i = 0; i < antBarn; i++)
            {
                Tuple<bool, int, int> getTup = SelgPlasser(1);

                if (getTup.Item1)
                {
                    Plass++;
                    res.Add(getTup.Item2 + "\t" + getTup.Item3 + "\t" + BarnePris());
                }
                else
                {
                    res.Add("Ingen barnebilletter tilgjengelig");
                    break;
                }
            }



            return res;

        }

        public override string ToString()
        {
            return base.ToString() + " Antall rader er " + AntallRader + ".";
        }
    }

    public class VIPtribune : Sittetribune
    {
        private string[,] tilskuer;

        public VIPtribune(string navn, double pris, int kap, int antRader)
            : base(navn, pris, kap, antRader)
        {
            int antPrRad = Kapasitet / AntallRader;
            tilskuer = new string[AntallRader, antPrRad];
        }
    }
}
