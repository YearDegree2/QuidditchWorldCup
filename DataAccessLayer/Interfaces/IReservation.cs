using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IReservation
    {
        int Id { get; set; }
        IMatch Match { get; set; }
        int Place { get; set; }
        ISpectateur Spectateur { get; set; }
        int GetHashCode();
        bool Equals(Object obj);
    }
}
