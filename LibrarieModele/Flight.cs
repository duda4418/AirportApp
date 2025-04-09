using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarieModele
{
    public class Flight
    {
        public string city { get; set; }
        public double time { get; set; }
        public int gate
        {
            get; set;
        }
        public string status { get; set; }
        public string flightType { get; set; }
        public int flightId { get; set; }
        public const char SEPARATOR_PRINCIPAL = ';';

        public Flight(string linieFisier)
        {
            var parts = linieFisier.Split(SEPARATOR_PRINCIPAL);
            if (parts.Length >= 6)
            {
                flightId = int.Parse(parts[0]);
                city = parts[1];
                time = double.Parse(parts[2]);
                gate = int.Parse(parts[3]);
                status = parts[4];
                flightType = parts[5];
            }
        }


        public string ToStringFisier()
        {
            return $"{flightId}{SEPARATOR_PRINCIPAL}{city}{SEPARATOR_PRINCIPAL}{time}{SEPARATOR_PRINCIPAL}{gate}{SEPARATOR_PRINCIPAL}{status}{SEPARATOR_PRINCIPAL}{flightType}";
        }


        public Flight()
        {
            city = status = string.Empty;

        }
        public Flight(string _city, double _time, int _gate, string _status, string _flightType, int _flightId)
        {
            city = _city;
            time = _time;
            gate = _gate;
            status = _status;
            flightType = _flightType;
            flightId = _flightId;
        }

        public string DisplayFlight()
        {
            return $"{flightType}: {city}, Time: {time}, Gate: {gate}, Status: {status}";
        }
    }
}
