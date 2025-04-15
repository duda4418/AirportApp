using LibrarieModele;
using System;
using System.IO;

namespace AdministrareMemorie
{
    public class AdministrareFlight
    {
        private const int NR_MAX_FLIGHTS = 50;

        private Flight[] flights;
        private int nrFlights;
        private string numeFisier;

        public AdministrareFlight(string numeFisier)
        {
            this.numeFisier = numeFisier;
            flights = new Flight[NR_MAX_FLIGHTS];
            nrFlights = 0;

            LoadFromFile(); // încărcăm la start
        }

        public void AddFlight(Flight flight)
        {
            if (nrFlights < NR_MAX_FLIGHTS)
            {
                flights[nrFlights] = flight;
                nrFlights++;

                SaveToFile(flight); // salvăm în fișier
            }
        }

        public void SaveToFile(Flight flight)
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine(flight.ToStringFisier());
            }
        }

        public void LoadFromFile()
        {
            if (File.Exists(numeFisier))
            {
                using (StreamReader sr = new StreamReader(numeFisier))
                {
                    string linie;
                    while ((linie = sr.ReadLine()) != null)
                    {
                        flights[nrFlights++] = new Flight(linie);
                    }
                }
            }
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

            for (int i = 0; i < flights.Length; i++)
            {
                if (flights[i] != null && flights[i].flightType == type)
                {
                    flightList[cnt++] = flights[i];
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