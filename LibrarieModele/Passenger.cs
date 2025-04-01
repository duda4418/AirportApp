public class Passenger
{
    private const char SEPARATOR_PRINCIPAL_FISIER = ';';
    private const char SEPARATOR_SECUNDAR_FISIER = ' ';
    private const int ID = 0; // Adjusted indices to include ID
    private const int NUME = 1;
    private const int PRENUME = 2;

    public int Id { get; set; } // New property
    public string Name { get; set; }
    public string Surname { get; set; }

    public Passenger()
    {
        Id = 0;
        Name = Surname = string.Empty;
    }

    public Passenger(int id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }

    public Passenger(string linieFisier)
    {
        string[] dateFisier = linieFisier.Split(SEPARATOR_PRINCIPAL_FISIER);

        Id = int.Parse(dateFisier[ID]);
        Name = dateFisier[NUME];
        Surname = dateFisier[PRENUME];
    }

    public string ConversieLaSir_PentruFisier()
    {
        return string.Format("{1}{0}{2}{0}{3}",
            SEPARATOR_PRINCIPAL_FISIER,
            Id,
            (Name ?? "NECUNOSCUT"),
            (Surname ?? "NECUNOSCUT"));
    }

    public string DisplayPassenger()
    {
        return $"ID: {Id}, Name: {Name}, Surname: {Surname}";
    }

}