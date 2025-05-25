using System;

public class Passenger
{
    private const char SEPARATOR_PRINCIPAL_FISIER = ';';
    private const int ID = 0;
    private const int NUME = 1;
    private const int PRENUME = 2;
    private const int FLIGHT_ID = 3;
    private const int SEAT_NUMBER = 4;

    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int FlightId { get; set; }
    public string SeatNumber { get; set; }

    public Passenger()
    {
        Id = FlightId = 0;
        Name = Surname = SeatNumber = string.Empty;
    }

    public Passenger(int id, string name, string surname, int flightId, string seatNumber)
    {
        Id = id;
        Name = name;
        Surname = surname;
        FlightId = flightId;
        SeatNumber = seatNumber;
    }

    public Passenger(string linieFisier)
    {
        string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

        if (dateFisier.Length >= 5)
        {
            Id = int.Parse(dateFisier[ID]);
            Name = dateFisier[NUME];
            Surname = dateFisier[PRENUME];
            FlightId = int.Parse(dateFisier[FLIGHT_ID]);
            SeatNumber = dateFisier[SEAT_NUMBER];
        }
        else if (dateFisier.Length == 3)
        {
            Id = int.Parse(dateFisier[ID]);
            Name = dateFisier[NUME];
            Surname = dateFisier[PRENUME];
            FlightId = 0;
            SeatNumber = "NECUNOSCUT";
        }
        else
        {
            throw new FormatException("Linie pasager invalidă: " + linieFisier);
        }
    }

    public string ConversieLaSir_PentruFisier()
    {
        return string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}",
            SEPARATOR_PRINCIPAL_FISIER,
            Id,
            Name ?? "NECUNOSCUT",
            Surname ?? "NECUNOSCUT",
            FlightId,
            SeatNumber ?? "NECUNOSCUT");
    }

    public string DisplayPassenger()
    {
        return $"ID: {Id}, Name: {Name}, Surname: {Surname}, Flight ID: {FlightId}, Seat: {SeatNumber}";
    }

}
