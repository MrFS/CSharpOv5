using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOv4.Classes.Oving
{
    public class Sittebillett : Billett
    {
        public Sittebillett(string tribunenavn, double pris, int rad, int plassnr) : base(tribunenavn, pris)
        {
            Tribunenavn = tribunenavn;
            Pris = pris;
            Rad = rad;
            PlassNr = plassnr;
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

        int Rad
        {
            get;
            set;
        }

        int PlassNr
        {
            get;
            set;
        }
    }
}
