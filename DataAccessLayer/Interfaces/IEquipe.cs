using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IEquipe
    {
        int Id { get; set; }
        string Nom { get; set; }
        string Pays { get; set; }
        ICollection<IJoueur> Joueurs { get; set; }
        int GetHashCode();
        bool Equals(Object obj);
        string ToString();
    }
}
