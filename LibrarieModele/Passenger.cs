using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Passenger
    {
        private const char SEPARATOR_PRINCIPAL_FISIER = ';';
        private const char SEPARATOR_SECUNDAR_FISIER = ' ';
        private const int NUME = 1;
        private const int PRENUME = 2;
        public string name { get; set; }
        public string surname { get; set; }

        //public string passportNumber { get; set; }
        //public string flightNumber { get; set; }
        //public string seatNumber { get; set; }

        public Passenger()
        {
            name = surname = string.Empty;

        }

        public Passenger(string _name, string _surname /*string _passportNumber, string _flightNumber, string _seatNumber*/)
        {
            name = _name;
            surname = _surname;
            //passportNumber = _passportNumber;
            //flightNumber = _flightNumber;
            //seatNumber = _seatNumber;
        }
        public Passenger(string linieFisier)
        {
            string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

            //ordinea de preluare a campurilor este data de ordinea in care au fost scrise in fisier prin apelul implicit al metodei ConversieLaSir_PentruFisier()
            this.name = dateFisier[NUME];
            this.surname = dateFisier[PRENUME];
        }

        public string ConversieLaSir_PentruFisier()
        {

            string obiectPassengerPentruFisier = string.Format("{1}{0}{2}",
                SEPARATOR_PRINCIPAL_FISIER,
                (name ?? " NECUNOSCUT "),
                (surname ?? " NECUNOSCUT "));

            return obiectPassengerPentruFisier;
        }

        public string DisplayPassenger()
        {
            return $" Name: {name}, Surname: {surname}";
        }
    }
}
