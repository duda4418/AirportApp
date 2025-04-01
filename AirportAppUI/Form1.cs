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


namespace AirportAppUI
{
    public partial class Form1 : Form
    {
        private AdministrarePassenger adminPassenger;

        public Form1()
        {
            InitializeComponent();
            string filePath = "A:/AirportApp/passengers.txt";
            adminPassenger = new AdministrarePassenger(filePath);
            LoadPassengers();
        }

        private void LoadPassengers()
        {
            int nrPassengers;
            Passenger[] passengers = adminPassenger.GetPassengers(out nrPassengers);

            // Binding data to DataGridView
            dataGridView1.DataSource = new List<Passenger>(passengers);
        }
    }

}
