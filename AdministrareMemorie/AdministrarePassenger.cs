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

        public AdministrarePassenger(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream streamFisierText = File.Open(numeFisier, FileMode.OpenOrCreate);
            streamFisierText.Close();
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
            Passenger[] passengers = new Passenger[50]; 
            using (StreamReader reader = new StreamReader(numeFisier))
            {
                string line;
                nrPassengers = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    passengers[nrPassengers++] = new Passenger(line);
                }
            }

            Array.Resize(ref passengers, nrPassengers);
            return passengers;
        }



        public Passenger[] GetStudenti(out int nrPassengers)
        {
            Passenger[] studenti = new Passenger[NR_MAX_PASSENGERS];

            // instructiunea 'using' va apela streamReader.Close()
            using (StreamReader streamReader = new StreamReader(numeFisier))
            {
                string linieFisier;
                nrPassengers = 0;

                while ((linieFisier = streamReader.ReadLine()) != null)
                {
                    studenti[nrPassengers++] = new Passenger(linieFisier);
                }
            }

            Array.Resize(ref studenti, nrPassengers);

            return studenti;
        }
    }
}
