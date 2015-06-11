using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IPersonne
    {
        int Id { get; set; }
        string Nom { get; set; }
        string Prenom { get; set; }
        DateTime DateNaissance { get; set; }
    }
}
