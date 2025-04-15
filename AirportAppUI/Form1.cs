using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibrarieModele;
using AdministrareMemorie;
using Microsoft.VisualBasic;


namespace AirportAppUI
{
    public partial class Form1 : Form
    {
        private AdministrarePassenger adminPassenger;
        private AdministrareFlight adminFlight;
        private const int MAX_NAME_LENGTH = 10;
        private const int MAX_SURNAME_LENGTH = 10;
        private Label lblName;
        private Label lblSurname;


        public Form1()
        {
            InitializeComponent();
            string filePath = "A:/AirportApp/passengers.txt";
            adminPassenger = new AdministrarePassenger(filePath);
            LoadPassengers();

            string flightPath = "A:/AirportApp/flights.txt";
            adminFlight = new AdministrareFlight(flightPath);
            LoadFlights();

        }
        private void LoadFlights()
        {
            int nrFlights;
            Flight[] flights = adminFlight.GetFlights(out nrFlights);
            dgvFlights.DataSource = new List<Flight>(flights);
        }

        private void btnAddPassenger_Click(object sender, EventArgs e)
        {
            // Reset label colors
            lblName.ForeColor = Color.Black;
            lblSurname.ForeColor = Color.Black;

            string name = Prompt("Enter name:");
            string surname = Prompt("Enter surname:");

            bool isValid = true;
            StringBuilder errors = new StringBuilder();

            if (name.Length > MAX_NAME_LENGTH)
            {
                lblName.ForeColor = Color.Red;
                errors.AppendLine($"Name must be max {MAX_NAME_LENGTH} characters.");
                isValid = false;
            }

            if (surname.Length > MAX_SURNAME_LENGTH)
            {
                lblSurname.ForeColor = Color.Red;
                errors.AppendLine($"Surname must be max {MAX_SURNAME_LENGTH} characters.");
                isValid = false;
            }

            if (!isValid)
            {
                MessageBox.Show(errors.ToString(), "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string seat = Prompt("Enter seat number:");
            int flightId = int.Parse(Prompt("Enter flight ID:"));
            int nrPassengers;
            adminPassenger.GetPassengers(out nrPassengers);
            Passenger passenger = new Passenger(nrPassengers + 1, name, surname, flightId, seat);
            adminPassenger.AddPassenger(passenger);
            LoadPassengers();
        }


        private void btnAddFlight_Click(object sender, EventArgs e)
        {
            string type = Prompt("Enter flight type (Arrival/Departure):");
            string city = Prompt("Enter city:");
            double time = double.Parse(Prompt("Enter time (ex: 13.30):"));
            int gate = int.Parse(Prompt("Enter gate:"));
            string status = Prompt("Enter status:");

            int nrFlights;
            adminFlight.GetFlights(out nrFlights);
            Flight flight = new Flight(city, time, gate, status, type, nrFlights + 1);
            adminFlight.AddFlight(flight);
            LoadFlights();
        }

        // Utility method for prompting
        private string Prompt(string message)
        {
            return Microsoft.VisualBasic.Interaction.InputBox(message, "Input Required", "");
        }


        private void LoadPassengers()
        {
            int nrPassengers;
            Passenger[] passengers = adminPassenger.GetPassengers(out nrPassengers);

            // Binding data to DataGridView
            dataGridView1.DataSource = new List<Passenger>(passengers);
        }
        private void btnSearchPassenger_Click(object sender, EventArgs e)
        {
            TextBox txtSearch = this.Controls.Find("txtSearchPassenger", true).FirstOrDefault() as TextBox;
            if (txtSearch != null)
            {
                string search = txtSearch.Text.Trim().ToLower();
                int nrPassengers;
                Passenger[] passengers = adminPassenger.GetPassengers(out nrPassengers);
                var filtered = passengers.Where(p =>
                    p.Name.ToLower().Contains(search) ||
                    p.Surname.ToLower().Contains(search)).ToList();
                dataGridView1.DataSource = filtered;
            }
        }

        private void btnSearchFlight_Click(object sender, EventArgs e)
        {
            TextBox txtSearch = this.Controls.Find("txtSearchFlight", true).FirstOrDefault() as TextBox;
            if (txtSearch != null)
            {
                string search = txtSearch.Text.Trim().ToLower();
                int nrFlights;
                Flight[] flights = adminFlight.GetFlights(out nrFlights);

                var filtered = flights
                    .Where(f => f != null &&
                                (f.city != null && f.city.ToLower().Contains(search) ||
                                 f.flightType != null && f.flightType.ToLower().Contains(search)))
                    .ToList();

                dgvFlights.DataSource = filtered;
            }
        }


    }

}