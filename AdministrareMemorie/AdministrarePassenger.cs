using LibrarieModele;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrareMemorie
{
    public class AdministrarePassenger
    {
        private const int NR_MAX_PASSENGERS = 50;
        private string numeFisier;
        private Passenger[] passengers;
        private int nrPassengers;

        public AdministrarePassenger(string numeFisier)
        {
            this.numeFisier = numeFisier;
            passengers = new Passenger[NR_MAX_PASSENGERS];
            nrPassengers = 0;
            LoadFromFile();
            //Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            //streamFisierText.Close();
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
                        passengers[nrPassengers++] = new Passenger(linie);
                    }
                }
            }
        }

        public void AddPassenger(Passenger passenger)
        {
            using (StreamWriter streamWriterFisierText = new StreamWriter(numeFisier, true))
            {
                streamWriterFisierText.WriteLine(passenger.ConversieLaSir_PentruFisier());
            }
        }

        public Passenger[] GetPassengers(out int nrPassengers)
        {
            Passenger[] passengers = new Passenger[NR_MAX_PASSENGERS];
            nrPassengers = 0;

            try
            {
                using (StreamReader reader = new StreamReader(numeFisier))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null && nrPassengers < NR_MAX_PASSENGERS)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            passengers[nrPassengers] = new Passenger(line);
                            nrPassengers++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show($"Error loading passengers: {ex.Message}");
            }

            Array.Resize(ref passengers, nrPassengers);
            return passengers;
        }

        
        public void UpdatePassenger(Passenger updatedPassenger)
        {
            for (int i = 0; i < nrPassengers; i++)
            {
                if (passengers[i].Id == updatedPassenger.Id)
                {
                    passengers[i] = updatedPassenger;
                    SaveAllPassengers();
                    break;
                }
            }
        }

        private void SaveAllPassengers()
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, false))
            {
                for (int i = 0; i < nrPassengers; i++)
                {
                    sw.WriteLine(passengers[i].ConversieLaSir_PentruFisier());
                }
            }
        }

    }
}