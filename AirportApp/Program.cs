using System;
using System.Collections.Generic;
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

            AdministrareFlight adminFlights = new AdministrareFlight();
            Flight newFlight = new Flight();

            // setare locatie fisier in directorul corespunzator solutiei
            // astfel incat datele din fisier sa poata fi utilizate si de alte proiecte
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            string caleCompleta = "C:/Users/dudad/source/repos/Airport-App/AirPort-App/AirPort-App/Passengers.txt";
            AdministrarePassenger adminPassenger = new AdministrarePassenger(caleCompleta);
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
                Console.WriteLine("F. Vector scara fisier");
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

                    case "F":
                        Console.WriteLine("Vector scara: ");
                        ProcessWords("date.txt");
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

        public static void ProcessWords(string filePath)
        {

            string[] words = File.ReadAllLines("C:/Users/dudad/source/repos/Airport-App/AirPort-App/AirPort-App/data.txt");
            string[][] sortedWords = new string[26][];

            for (int i = 0; i < 26; i++)
            {
                sortedWords[i] = new string[0];
            }

            foreach (string word in words)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;

                char firstLetter = char.ToLower(word[0]);
                if (firstLetter >= 'a' && firstLetter <= 'z')
                {
                    int index = firstLetter - 'a';
                    Array.Resize(ref sortedWords[index], sortedWords[index].Length + 1);
                    sortedWords[index][sortedWords[index].Length - 1] = word;
                }
            }

            for (int i = 0; i < 26; i++)
            {
                if (sortedWords[i].Length > 0)
                {
                    Console.WriteLine($"Litera {(char)('A' + i)}:");
                    Console.WriteLine(string.Join(", ", sortedWords[i]));
                }
            }
        }
        public static Passenger CitirePasager()
        {

            Console.WriteLine("Introduceti numele");
            string surname = Console.ReadLine();

            Console.WriteLine("Introduceti prenumele");
            string name = Console.ReadLine();

            Passenger pasager = new Passenger(name, surname);

            return pasager;
        }
    }
}
