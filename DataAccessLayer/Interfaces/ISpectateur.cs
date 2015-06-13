using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ISpectateur : IPersonne
    {
        string Adresse { get; set; }
        string Ville { get; set; }
        string Email { get; set; }
        int GetHashCode();
        bool Equals(Object obj);
        string ToString();
    }
}
