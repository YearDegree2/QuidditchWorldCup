using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IMatch
    {
        int Id { get; set; }
        DateTime Date { get; set; }
        ICoupe Coupe { get; set; }
        IEquipe EquipeDomicile { get; set; }
        IEquipe EquipeVisiteur { get; set; }
        double Prix { get; set; }
        IStade Stade { get; set; }
        IArbitre Arbitre { get; set; }
        int ScoreEquipeDomicile { get; set; }
        int ScoreEquipeVisiteur { get; set; }
        int GetHashCode();
        bool Equals(Object obj);
        string ToString();
    }
}
