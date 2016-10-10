using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOv4.Classes.Oving
{
    public class Ståbillett : Billett
    {
        public Ståbillett(string tribunenavn, double pris, int plassnr) : base(tribunenavn, pris)
        {

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

        int PlassNr
        {
            get;
            set;
        }
    }
}
