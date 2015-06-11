using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IStade
    {
        int Id { get; set; }
        string Nom { get; set; }
        string Adresse { get; set; }
        string Ville { get; set; }
        int NombrePlaces { get; set; }
        int GetHashCode();
        bool Equals(Object obj);
        string ToString();
    }
}
