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
