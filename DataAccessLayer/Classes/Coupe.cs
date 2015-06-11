using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer.Classes
{
    class Coupe : ICoupe
    {
        private int _id;
        private string _year;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public Coupe() : this(0, "inconnu") { }

        public Coupe(int id, string year)
        {
            Id = id;
            Year = year;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj as Coupe == null) return false;
            Coupe coupe = (Coupe)obj;
            return Id.Equals(coupe.Id);
        }

        public override string ToString()
        {
            return String.Format("Coupe du monde {0}", Year);
        }
    }
}
