using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IArbitre : IPersonne
    {
        string NumeroPoliceAssuranceVie { get; set; }
        int GetHashCode();
        bool Equals(Object obj);
        string ToString();
    }
}
