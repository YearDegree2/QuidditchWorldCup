using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICoupe
    {
        int Id { get; set; }
        string Year { get; set; }
        int GetHashCode();
        bool Equals(Object obj);
        string ToString();
    }
}
