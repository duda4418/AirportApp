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

        // Updated to use FlightType enum
        public Flight[] GetFlightType(FlightType type, out int nrFlights)
        {
            Flight[] flightList = new Flight[NR_MAX_FLIGHTS];
            int cnt = 0;

            for (int i = 0; i < this.nrFlights; i++)
            {
                if (flights[i] != null && flights[i].flightType == type)
                {
                    flightList[cnt++] = flights[i];
                }
            }

            nrFlights = cnt;
            return flightList;
        }

        // Overload to maintain backward compatibility with string input
        public Flight[] GetFlightType(string typeString, out int nrFlights)
        {
            if (Enum.TryParse(typeString, out FlightType type))
            {
                return GetFlightType(type, out nrFlights);
            }

            // If parsing failed, return empty array
            nrFlights = 0;
            return new Flight[0];
        }

        // Get flights by status
        public Flight[] GetFlightsByStatus(FlightStatus status, out int nrFlights)
        {
            Flight[] flightList = new Flight[NR_MAX_FLIGHTS];
            int cnt = 0;

            for (int i = 0; i < this.nrFlights; i++)
            {
                // Check if flight has ANY of the specified status flags
                if (flights[i] != null && (flights[i].status & status) != 0)
                {
                    flightList[cnt++] = flights[i];
                }
            }

            nrFlights = cnt;
            return flightList;
        }

        public Flight GetFlightDestination(double time)
        {
            for (int i = 0; i < this.nrFlights; i++)
            {
                if (flights[i] != null && flights[i].time == time)
                    return flights[i];
            }

            return new Flight("", 0, 0, FlightStatus.None, FlightType.Unknown, 0);
        }
    }
}