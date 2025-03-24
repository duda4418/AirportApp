using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrareMemorie
{
    public class AdministrareFlight
    {
        private const int NR_MAX_PASSENGER = 500;
        private const int NR_MAX_FLIGHTS = 50;

        private Flight[] flights;
        private int nrFlights;

        public AdministrareFlight()
        {
            flights = new Flight[NR_MAX_FLIGHTS];
            nrFlights = 0;
        }

        public void AddFlight(Flight flight)
        {
            flights[nrFlights] = flight;
            nrFlights++;
        }

        public Flight[] GetFlights(out int nrFlights)
        {
            nrFlights = this.nrFlights;
            return flights;
        }
        public Flight[] GetFlightType(string type, out int nrFlights)
        {
            Flight[] flightList = new Flight[NR_MAX_FLIGHTS];
            int cnt = 0;
            if (flights == null)
            {
                nrFlights = 0;
                return new Flight[0];
            }

            for (int i = 0; i < flights.Length; i++)
            {
                if (flights[i] != null && flights[i].flightType == type)
                {
                    flightList[cnt] = flights[i];
                    cnt++;
                }
            }
            nrFlights = cnt;
            return flightList;
        }

        public Flight GetFlightDestination(double time)
        {
            for (int i = 0; i < flights.Length; i++)
            {
                if (flights[i] != null && flights[i].time == time)
                    return flights[i];
            }
            return new Flight("", 0, 0, "", "", 0);
        }
    }
}
