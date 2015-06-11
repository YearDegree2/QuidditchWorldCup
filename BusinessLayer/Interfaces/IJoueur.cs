using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Classes;

namespace BusinessLayer.Interfaces
{
    public interface IJoueur : IPersonne
    {
        string Numero { get; set; }
        PosteJoueur Poste { get; set; }
        bool Capitaine { get; set; }
        int GetHashCode();
        bool Equals(Object obj);
        string ToString();
    }
}
