using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;

namespace BusinessLayer.Classes
{
    class Reservation : IReservation
    {
        private int _id;
        private IMatch _match;
        private int _place;
        private ISpectateur _spectateur;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public IMatch Match
        {
            get { return _match; }
            set { _match = value; }
        }

        public int Place
        {
            get { return _place; }
            set { _place = value; }
        }

        public ISpectateur Spectateur
        {
            get { return _spectateur; }
            set { _spectateur = value; }
        }

        public Reservation() : this(0, new Match(), -1, new Spectateur()) { }

        public Reservation(int id, IMatch match, int place, ISpectateur spectateur)
        {
            Id = id;
            Match = match;
            Place = place;
            Spectateur = spectateur;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj as Reservation == null) return false;
            Reservation reservation = (Reservation)obj;
            return Id.Equals(reservation.Id);
        }
    }
}
