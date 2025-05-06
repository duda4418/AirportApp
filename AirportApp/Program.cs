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
                Console.WriteLine("\n====== AIRPORT MANAGEMENT SYSTEM ======");
                Console.WriteLine("C. Citire informatii zboruri de la tastatura");
                Console.WriteLine("I. Afisare ultimul zbor");
                Console.WriteLine("A. Afisare zboruri");
                Console.WriteLine("S. Salvare zbor in vector de obiecte");
                Console.WriteLine("P. Gasire zboruri dupa tip");
                Console.WriteLine("F. Gasire zboruri dupa status");
                Console.WriteLine("D. Gasire zboruri dupa ora");
                Console.WriteLine("R. Citire informatii pasageri de la tastatura");
                Console.WriteLine("T. Salvare pasager in fisier");
                Console.WriteLine("X. Inchidere program");
                Console.WriteLine("======================================");

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
                        Console.WriteLine("Introduceti tipul zborului:");
                        Console.WriteLine("1. Departure");
                        Console.WriteLine("2. Arrival");
                        string typeInput = Console.ReadLine();

                        FlightType selectedType;
                        switch (typeInput)
                        {
                            case "1":
                                selectedType = FlightType.Departure;
                                break;
                            case "2":
                                selectedType = FlightType.Arrival;
                                break;
                            default:
                                if (Enum.TryParse(typeInput, out selectedType))
                                    break;
                                else
                                {
                                    Console.WriteLine("Tip de zbor invalid. Folositi Departure sau Arrival.");
                                    continue;
                                }
                        }

                        Flight[] flightList = adminFlights.GetFlightType(selectedType, out nrFlights);
                        AfisareZboruri(flightList, nrFlights);
                        break;

                    case "F":
                        Console.WriteLine("Selectati statusul zborului:");
                        Console.WriteLine("1. On Time");
                        Console.WriteLine("2. Delayed");
                        Console.WriteLine("3. Boarding");
                        Console.WriteLine("4. Cancelled");
                        Console.WriteLine("5. Landed");
                        Console.WriteLine("6. In Air");
                        Console.WriteLine("7. Check In");

                        string statusInput = Console.ReadLine();
                        FlightStatus selectedStatus = FlightStatus.None;

                        switch (statusInput)
                        {
                            case "1":
                                selectedStatus = FlightStatus.OnTime;
                                break;
                            case "2":
                                selectedStatus = FlightStatus.Delayed;
                                break;
                            case "3":
                                selectedStatus = FlightStatus.Boarding;
                                break;
                            case "4":
                                selectedStatus = FlightStatus.Cancelled;
                                break;
                            case "5":
                                selectedStatus = FlightStatus.Landed;
                                break;
                            case "6":
                                selectedStatus = FlightStatus.InAir;
                                break;
                            case "7":
                                selectedStatus = FlightStatus.CheckIn;
                                break;
                            default:
                                Console.WriteLine("Status invalid. Se vor afisa toate zborurile.");
                                Flight[] allFlights = adminFlights.GetFlights(out nrFlights);
                                AfisareZboruri(allFlights, nrFlights);
                                continue;
                        }

                        Flight[] statusFlights = adminFlights.GetFlightsByStatus(selectedStatus, out nrFlights);
                        AfisareZboruri(statusFlights, nrFlights);
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
            Console.WriteLine("Introduceti tipul zborului:");
            Console.WriteLine("1. Departure");
            Console.WriteLine("2. Arrival");
            string typeInput = Console.ReadLine();

            FlightType flightType;
            switch (typeInput)
            {
                case "1":
                    flightType = FlightType.Departure;
                    break;
                case "2":
                    flightType = FlightType.Arrival;
                    break;
                default:
                    if (Enum.TryParse(typeInput, out flightType))
                        break;
                    else
                    {
                        Console.WriteLine("Tip de zbor invalid. Se va folosi Unknown.");
                        flightType = FlightType.Unknown;
                    }
                    break;
            }

            Console.WriteLine("Introduceti orasul");
            string city = Console.ReadLine();

            Console.WriteLine("Introduceti ora");
            double time = double.Parse(Console.ReadLine());

            Console.WriteLine("Introduceti gate-ul");
            int gate = int.Parse(Console.ReadLine());

            Console.WriteLine("Selectati statusul zborului:");
            Console.WriteLine("1. On Time");
            Console.WriteLine("2. Delayed");
            Console.WriteLine("3. Boarding");
            Console.WriteLine("4. Cancelled");
            Console.WriteLine("5. Landed");
            Console.WriteLine("6. In Air");
            Console.WriteLine("7. Check In");
            Console.WriteLine("8. Multiple (separate by comma, e.g.: 2,3 for Delayed and Boarding)");

            string statusInput = Console.ReadLine();
            FlightStatus status = FlightStatus.None;

            if (statusInput == "8")
            {
                Console.WriteLine("Introduceti statusurile separate prin virgula (e.g.: 2,3):");
                string multipleStatuses = Console.ReadLine();
                string[] statusChoices = multipleStatuses.Split(',');

                foreach (string choice in statusChoices)
                {
                    if (int.TryParse(choice.Trim(), out int statusChoice))
                    {
                        switch (statusChoice)
                        {
                            case 1: status |= FlightStatus.OnTime; break;
                            case 2: status |= FlightStatus.Delayed; break;
                            case 3: status |= FlightStatus.Boarding; break;
                            case 4: status |= FlightStatus.Cancelled; break;
                            case 5: status |= FlightStatus.Landed; break;
                            case 6: status |= FlightStatus.InAir; break;
                            case 7: status |= FlightStatus.CheckIn; break;
                        }
                    }
                }
            }
            else
            {
                switch (statusInput)
                {
                    case "1": status = FlightStatus.OnTime; break;
                    case "2": status = FlightStatus.Delayed; break;
                    case "3": status = FlightStatus.Boarding; break;
                    case "4": status = FlightStatus.Cancelled; break;
                    case "5": status = FlightStatus.Landed; break;
                    case "6": status = FlightStatus.InAir; break;
                    case "7": status = FlightStatus.CheckIn; break;
                    default:
                        Console.WriteLine("Status invalid. Se va folosi None.");
                        status = FlightStatus.None;
                        break;
                }
            }

            Flight flight = new Flight(city, time, gate, status, flightType, nrFlights);

            return flight;
        }

        public static void AfisareZbor(Flight flight)
        {
            string flightInfo = string.Format("Datele zborului {0}: {1} {2} {3} {4} {5}",
                    flight.flightId,
                    flight.flightType,
                    flight.city ?? " NECUNOSCUT ",
                    flight.time,
                    flight.gate,
                    flight.status);

            Console.WriteLine(flightInfo);
        }

        public static void AfisareZboruri(Flight[] flights, int nrFlights)
        {
            Console.WriteLine("\nZboruri:");
            if (nrFlights == 0)
            {
                Console.WriteLine("Nu exista zboruri care sa corespunda criteriilor.");
                return;
            }

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