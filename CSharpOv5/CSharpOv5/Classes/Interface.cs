using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOv5.Classes
{
    interface Interface
    {
    }

    public interface Kjønn
    {
        bool Kvinne { get; }
    }
    public interface Rekkefølge
    {
        bool foran(Rekkefølge denAndre);
    }
}
