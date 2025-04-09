using AdministrareMemorie;
using LibrarieModele;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirportApp
{
    public class Program
    {
        static int nrFlights = 0;

        static void Main(string[] args)
        {

            

            string numeFisier = ConfigurationManager.AppSettings["passengers.txt"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleFisierPassenger = locatieFisierSolutie + "\\" + numeFisier;
            Console.WriteLine($"Calea completă a fișierului: {caleFisierPassenger}");

            numeFisier = ConfigurationManager.AppSettings["flights.txt"];
            locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleFisierFlight = locatieFisierSolutie + "\\" + numeFisier;
            Console.WriteLine($"Calea completă a fișierului: {caleFisierFlight}");

            AdministrareFlight adminFlights = new AdministrareFlight(caleFisierFlight);
            Flight newFlight = new Flight();

            AdministrarePassenger adminPassenger = new AdministrarePassenger(caleFisierPassenger);
            int nrPassengers;
            Passenger[] existingPassengers = adminPassenger.GetPassengers(out nrPassengers);
            int nextId = nrPassengers + 1; // Determine next ID

            Passenger newPassenger = new Passenger();


            string optiune;
            do
            {
                Console.WriteLine("C. Citire informatii zboruri de la tastatura");
                Console.WriteLine("I. Afisare ultimul zbor");
                Console.WriteLine("A. Afisare zboruri");
                Console.WriteLine("S. Salvare zbor in vector de obiecte");
                Console.WriteLine("P. Gasire zboruri dupa tip");
                Console.WriteLine("D. Gasire zboruri dupa ora");
                Console.WriteLine("R. Citire informatii pasageri de la tastatura");
                Console.WriteLine("T. Salvare pasager in fisier");
                Console.WriteLine("X. Inchidere program");

                Console.WriteLine("Alegeti o optiune");
                optiune = Console.ReadLine();

                switch (optiune.ToUpper())
                {
                    case "C":
                        newFlight = CitireZbor();

                        break;
                    case "I":
                        AfisareZbor(newFlight);

                        break;

                    case "A":
                        Flight[] flights = adminFlights.GetFlights(out nrFlights);
                        AfisareZboruri(flights, nrFlights);

                        break;
                    case "S":
                        int flightId = nrFlights + 1;
                        newFlight.flightId = flightId;
                        adminFlights.AddFlight(newFlight); 
                        break;
                    case "X":
                        return;

                    case "P":
                        Console.WriteLine("Introduceti tipul zborului: (Departure / Arrival)");
                        string type = Console.ReadLine();

                        Flight[] flightList = adminFlights.GetFlightType(type, out nrFlights);
                        AfisareZboruri(flightList, nrFlights);
                        break;


                    case "D":
                        Console.WriteLine("Introduceti ora");
                        double time = double.Parse(Console.ReadLine());

                        newFlight = adminFlights.GetFlightDestination(time);
                        AfisareZbor(newFlight);
                        break;


                    case "R":
                        newPassenger = CitirePasager();
                        break;

                    case "T":
                        adminPassenger.AddPassenger(newPassenger);
                        break;

                    default:
                        Console.WriteLine("Optiune inexistenta");
                        break;
                }
            } while (optiune.ToUpper() != "X");

            Console.ReadKey();
        }

        public static Flight CitireZbor()
        {
            Console.WriteLine("Introduceti tipul zborului");
            string type = Console.ReadLine();

            Console.WriteLine("Introduceti orasul");
            string city = Console.ReadLine();

            Console.WriteLine("Introduceti ora");
            double time = double.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti gate-ul");
            int gate = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti statusul");
            string status = Console.ReadLine();

            Flight flight = new Flight(city, time, gate, status, type, nrFlights);

            return flight;
        }

        public static void AfisareZbor(Flight flight)
        {
            string flightInfo = string.Format("Datele zborului {0}: {1} {2} {3} {4} {5}",
                    flight.flightId,
                    flight.flightType ?? " NECUNOSCUT ",
                    flight.city ?? " NECUNOSCUT ",
                    flight.time,
                    flight.gate,
                    flight.status ?? "NECUNOSCUT");

            Console.WriteLine(flightInfo);
        }

        public static void AfisareZboruri(Flight[] flights, int nrFlights)
        {
            Console.WriteLine("Zboruri:");
            for (int contor = 0; contor < nrFlights; contor++)
            {
                string flightInfo = flights[contor].DisplayFlight();
                Console.WriteLine(flightInfo);
            }
        }
        public static Passenger CitirePasager()
        {
            Console.WriteLine("Introduceti numele:");
            string surname = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele:");
            string name = Console.ReadLine();

            Console.WriteLine("Introduceti ID-ul zborului:");
            int flightId = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti numarul locului (ex: 12A):");
            string seatNumber = Console.ReadLine();

            string numeFisier = ConfigurationManager.AppSettings["passengers.txt"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleFisierPassenger = locatieFisierSolutie + "\\" + numeFisier;
            AdministrarePassenger adminPassenger = new AdministrarePassenger(caleFisierPassenger);
            int nrPassengers;
            Passenger[] existingPassengers = adminPassenger.GetPassengers(out nrPassengers);
            int nextId = nrPassengers + 1;

            Passenger pasager = new Passenger(nextId, name, surname, flightId, seatNumber);

            return pasager;
        }

    }
}
