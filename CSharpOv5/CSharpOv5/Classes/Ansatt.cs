using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOv5.Classes
{
    public abstract class Ansatt : Kjønn, Rekkefølge
    {
        public int Ansattnummer
        {
            get;
        }
        #region Rekkefølge Members
        public bool foran(Rekkefølge denAndre)
        {
            if (denAndre is Ansatt)
                return Ansattnummer < ((Ansatt)denAndre).Ansattnummer;
            else return true;
        }
        #endregion
        #region Kjønn Members
        public abstract bool Kvinne
        {
            get;
        }
        #endregion
    }

    public class KvinneligAnsatt : Ansatt
    {
        #region Kjønn Members
        public override bool Kvinne
        {
            get
            {
                return true;
            }
        }
        #endregion
    }
}
