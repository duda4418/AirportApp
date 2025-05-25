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
        //private ErrorProvider errorProvider;
        private const string FISIER_PASSENGERS = "passengers.txt";
        private const string FISIER_FLIGHTS = "flights.txt";

        public Form1()
        {
            InitializeComponent();
            SetupListViews();
            txtPassengerId.Enabled = false;
            txtFlightId.Enabled = false;




            // Initialize error provider
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Initialize file paths - using relative paths to make it more portable
            string passengerPath = FISIER_PASSENGERS;
            string flightPath = FISIER_FLIGHTS;

            // Initialize data managers
            adminPassenger = new AdministrarePassenger(passengerPath);
            adminFlight = new AdministrareFlight(flightPath);

            // Setup controls
            SetupFlightControls();

            // Load initial data
            LoadFlights();
            LoadPassengers();
        }
        // In Form1 constructor after InitializeComponent();
        private void SetupListViews()
        {
            // Flights ListView
            lstFlights.View = View.Details;
            lstFlights.FullRowSelect = true; // Allow full-row selection
            lstFlights.MultiSelect = false;  // Disable multi-selection
            lstFlights.HideSelection = false; // Keep selection visible
            lstFlights.Columns.Add("Flight ID", 80);
            lstFlights.Columns.Add("City", 150);
            lstFlights.Columns.Add("Time", 80);
            lstFlights.Columns.Add("Gate", 80);
            lstFlights.Columns.Add("Status", 150);
            lstFlights.Columns.Add("Type", 100);

            // Passengers ListView
            lstPassengers.View = View.Details;
            lstPassengers.FullRowSelect = true;
            lstPassengers.MultiSelect = false;
            lstPassengers.HideSelection = false;
            lstPassengers.Columns.Add("ID", 50);
            lstPassengers.Columns.Add("Name", 150);
            lstPassengers.Columns.Add("Surname", 150);
            lstPassengers.Columns.Add("Flight ID", 80);
            lstPassengers.Columns.Add("Seat", 80);
        }

        #region Setup Controls
        private void SetupFlightControls()
        {
            // Flight Status ComboBox setup
            cmbFlightStatus.Items.Clear();
            foreach (FlightStatus status in Enum.GetValues(typeof(FlightStatus)))
            {
                // Skip "None" value
                if (status != FlightStatus.None)
                    cmbFlightStatus.Items.Add(status);
            }

            if (cmbFlightStatus.Items.Count > 0)
                cmbFlightStatus.SelectedIndex = 0;

            // Flight Status flags CheckListBox setup
            checkListBoxFlightStatusFlags.Items.Clear();
            foreach (FlightStatus status in Enum.GetValues(typeof(FlightStatus)))
            {
                // Skip "None" value
                if (status != FlightStatus.None)
                    checkListBoxFlightStatusFlags.Items.Add(status);
            }

            // Set Departure as default flight type
            rbDeparture.Checked = true;
        }
        #endregion

        #region Load Data
        private void LoadFlights()
        {
            int nrFlights;
            Flight[] flights = adminFlight.GetFlights(out nrFlights);

            lstFlights.Items.Clear();
            for (int i = 0; i < nrFlights; i++)
            {
                if (flights[i] != null)
                {
                    ListViewItem item = new ListViewItem(flights[i].flightId.ToString());
                    item.SubItems.Add(flights[i].city);
                    item.SubItems.Add(flights[i].time.ToString("yyyy-MM-dd HH:mm"));
                    item.SubItems.Add(flights[i].gate.ToString());
                    item.SubItems.Add(flights[i].GetStatusString());
                    item.SubItems.Add(flights[i].flightType.ToString());
                    item.Tag = flights[i];  // Store the Flight object for later reference
                    lstFlights.Items.Add(item);
                }
            }
        }

        private void LoadPassengers()
        {
            int nrPassengers;
            Passenger[] passengers = adminPassenger.GetPassengers(out nrPassengers);

            lstPassengers.Items.Clear();
            for (int i = 0; i < nrPassengers; i++)
            {
                if (passengers[i] != null)
                {
                    ListViewItem item = new ListViewItem(passengers[i].Id.ToString());
                    item.SubItems.Add(passengers[i].Name);
                    item.SubItems.Add(passengers[i].Surname);
                    item.SubItems.Add(passengers[i].FlightId.ToString());
                    item.SubItems.Add(passengers[i].SeatNumber);
                    item.Tag = passengers[i];  // Store the Passenger object for later reference
                    lstPassengers.Items.Add(item);
                }
            }
        }
        #endregion

        #region Flight Operations
        private void btnAddFlight_Click(object sender, EventArgs e)
        {
            // Clear any previous errors
            errorProvider.Clear();

            // Generate Flight ID
            int nrFlights;
            Flight[] flights = adminFlight.GetFlights(out nrFlights);

            // Handle null/empty case
            int maxFlightId = 0;
            if (flights != null && nrFlights > 0)
            {
                maxFlightId = flights.Take(nrFlights)  // Only consider populated entries
                                  .Where(f => f != null)  // Filter out nulls
                                  .Max(f => f.flightId);
            }

            int flightId = maxFlightId + 1;

            // Validate Flight ID
            //if (!ValidateFlightId(txtFlightId.Text))
            //{
            //    errorProvider.SetError(txtFlightId, "Flight ID must be a positive integer");
            //    return;
            //}

            // Validate City
            if (!ValidateCity(txtFlightCity.Text))
            {
                errorProvider.SetError(txtFlightCity, "City name is required");
                return;
            }

            DateTime selectedTime = dtpFlightTime.Value;
            // Validate Time
            if (!ValidateTime(selectedTime))
            {
                errorProvider.SetError(dtpFlightTime, "Flight time must be in the future");
                return;
            }

            // Validate Gate
            if (!ValidateGate(txtFlightGate.Text))
            {
                errorProvider.SetError(txtFlightGate, "Gate must be a positive integer");
                return;
            }

            // All validations passed, create and add the flight
            //int flightId = int.Parse(txtFlightId.Text);
            string city = txtFlightCity.Text;
            DateTime time = DateTime.Parse(dtpFlightTime.Text);
            int gate = int.Parse(txtFlightGate.Text);

            // Get Flight Status (primary status)
            FlightStatus status = (FlightStatus)cmbFlightStatus.SelectedItem;

            // Add any selected status flags
            for (int i = 0; i < checkListBoxFlightStatusFlags.CheckedItems.Count; i++)
            {
                FlightStatus flagStatus = (FlightStatus)checkListBoxFlightStatusFlags.CheckedItems[i];
                status |= flagStatus;
            }

            // Get Flight Type
            FlightType flightType = rbDeparture.Checked ? FlightType.Departure : FlightType.Arrival;

            // Create and add flight
            Flight newFlight = new Flight(city, time, gate, status, flightType, flightId);
            adminFlight.AddFlight(newFlight);

            // Refresh the list
            LoadFlights();

            // Clear the inputs
            ClearFlightInputs();

            MessageBox.Show("Flight added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearchFlight_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchFlights.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchValue))
            {
                // If search box is empty, reload all flights
                LoadFlights();
                return;
            }

            // Get all flights
            int nrFlights;
            Flight[] flights = adminFlight.GetFlights(out nrFlights);

            // Clear the current list
            lstFlights.Items.Clear();

            // Filter and add flights
            for (int i = 0; i < nrFlights; i++)
            {
                if (flights[i] != null)
                {
                    bool match = false;

                    // Check if search value is in any of the flight properties
                    match = match || flights[i].flightId.ToString().Contains(searchValue);
                    match = match || flights[i].city.ToLower().Contains(searchValue);
                    match = match || flights[i].time.ToString("yyyy-MM-dd HH:mm").Contains(searchValue);
                    match = match || flights[i].gate.ToString().Contains(searchValue);
                    match = match || flights[i].status.ToString().ToLower().Contains(searchValue);
                    match = match || flights[i].flightType.ToString().ToLower().Contains(searchValue);

                    if (match)
                    {
                        ListViewItem item = new ListViewItem(flights[i].flightId.ToString());
                        item.SubItems.Add(flights[i].city);
                        item.SubItems.Add(flights[i].time.ToString());
                        item.SubItems.Add(flights[i].gate.ToString());
                        item.SubItems.Add(flights[i].GetStatusString());
                        item.SubItems.Add(flights[i].flightType.ToString());
                        item.Tag = flights[i];
                        lstFlights.Items.Add(item);
                    }
                }
            }
        }

        private void listViewFlights_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected && e.Item.Tag != null)
            {
                Flight selectedFlight = (Flight)e.Item.Tag;

                //make the Flight ID textbox read-only
                txtFlightId.Enabled = false;

                // Populate the flight details
                txtFlightId.Text = selectedFlight.flightId.ToString();
                txtFlightCity.Text = selectedFlight.city;
                dtpFlightTime.Text = selectedFlight.time.ToString();
                txtFlightGate.Text = selectedFlight.gate.ToString();

                // Set the flight status
                for (int i = 0; i < cmbFlightStatus.Items.Count; i++)
                {
                    FlightStatus status = (FlightStatus)cmbFlightStatus.Items[i];
                    if (status == selectedFlight.status)
                    {
                        cmbFlightStatus.SelectedIndex = i;
                        break;
                    }
                }

                // Check flight status flags
                for (int i = 0; i < checkListBoxFlightStatusFlags.Items.Count; i++)
                {
                    FlightStatus flag = (FlightStatus)checkListBoxFlightStatusFlags.Items[i];
                    checkListBoxFlightStatusFlags.SetItemChecked(i, (selectedFlight.status & flag) == flag);
                }

                // Set the flight type
                rbDeparture.Checked = selectedFlight.flightType == FlightType.Departure;
                rbArrival.Checked = selectedFlight.flightType == FlightType.Arrival;
            }
        }
        private void ClearFlightInputs()
        {
            txtFlightId.Text = string.Empty;
            txtFlightCity.Text = string.Empty;
            dtpFlightTime.Text = string.Empty;
            txtFlightGate.Text = string.Empty;

            // Reset status and type
            if (cmbFlightStatus.Items.Count > 0)
                cmbFlightStatus.SelectedIndex = 0;

            for (int i = 0; i < checkListBoxFlightStatusFlags.Items.Count; i++)
                checkListBoxFlightStatusFlags.SetItemChecked(i, false);

            rbDeparture.Checked = true;
        }
        #endregion

        #region Passenger Operations
        private void btnAddPassenger_Click(object sender, EventArgs e)
        {
            // Clear any previous errors
            errorProvider.Clear();

            // Generate Passenger ID
            int nrPassengers;
            Passenger[] passengers = adminPassenger.GetPassengers(out nrPassengers);

            int maxPassengerId = 0;
            if (passengers != null && nrPassengers > 0)
            {
                maxPassengerId = passengers.Take(nrPassengers)
                                        .Where(p => p != null)
                                        .Max(p => p.Id);
            }
            int passengerId = maxPassengerId + 1;

            // Validate Passenger ID
            //if (!ValidatePassengerId(txtPassengerId.Text))
            //{
            //    errorProvider.SetError(txtPassengerId, "Passenger ID must be a positive integer");
            //    return;
            //}

            // Validate Name
            if (!ValidateName(txtPassengerName.Text))
            {
                errorProvider.SetError(txtPassengerName, "Name is required");
                return;
            }

            // Validate Surname
            if (!ValidateName(txtPassengerSurname.Text))
            {
                errorProvider.SetError(txtPassengerSurname, "Surname is required");
                return;
            }

            // Validate Flight ID
            if (!ValidateFlightId(txtPassengerFlightId.Text))
            {
                errorProvider.SetError(txtPassengerFlightId, "Flight ID must be a real flight");
                return;
            }

            // Validate Seat Number
            if (!ValidateSeatNumber(txtPassengerSeatNumber.Text))
            {
                errorProvider.SetError(txtPassengerSeatNumber, "Seat number is required");
                return;
            }

            // All validations passed, create and add the passenger
            //int passengerId = int.Parse(txtPassengerId.Text);
            string name = txtPassengerName.Text;
            string surname = txtPassengerSurname.Text;
            int flightId = int.Parse(txtPassengerFlightId.Text);
            string seatNumber = txtPassengerSeatNumber.Text;

            // Create and add passenger
            Passenger newPassenger = new Passenger(passengerId, name, surname, flightId, seatNumber);
            adminPassenger.AddPassenger(newPassenger);

            // Refresh the list
            LoadPassengers();

            // Clear the inputs
            ClearPassengerInputs();

            MessageBox.Show("Passenger added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearchPassenger_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchPassengers.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchValue))
            {
                // If search box is empty, reload all passengers
                LoadPassengers();
                return;
            }

            // Get all passengers
            int nrPassengers;
            Passenger[] passengers = adminPassenger.GetPassengers(out nrPassengers);

            // Clear the current list
            lstPassengers.Items.Clear();

            // Filter and add passengers
            for (int i = 0; i < nrPassengers; i++)
            {
                if (passengers[i] != null)
                {
                    bool match = false;

                    // Check if search value is in any of the passenger properties
                    match = match || passengers[i].Id.ToString().Contains(searchValue);
                    match = match || passengers[i].Name.ToLower().Contains(searchValue);
                    match = match || passengers[i].Surname.ToLower().Contains(searchValue);
                    match = match || passengers[i].FlightId.ToString().Contains(searchValue);
                    match = match || passengers[i].SeatNumber.ToLower().Contains(searchValue);

                    if (match)
                    {
                        ListViewItem item = new ListViewItem(passengers[i].Id.ToString());
                        item.SubItems.Add(passengers[i].Name);
                        item.SubItems.Add(passengers[i].Surname);
                        item.SubItems.Add(passengers[i].FlightId.ToString());
                        item.SubItems.Add(passengers[i].SeatNumber);
                        item.Tag = passengers[i];
                        lstPassengers.Items.Add(item);
                    }
                }
            }
        }
            
        private void listViewPassengers_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected && e.Item.Tag != null)
            {
                Passenger selectedPassenger = (Passenger)e.Item.Tag;
                txtPassengerId.Enabled = false;

                // Populate the passenger details
                txtPassengerId.Text = selectedPassenger.Id.ToString();
                txtPassengerName.Text = selectedPassenger.Name;
                txtPassengerSurname.Text = selectedPassenger.Surname;
                txtPassengerFlightId.Text = selectedPassenger.FlightId.ToString();
                txtPassengerSeatNumber.Text = selectedPassenger.SeatNumber;

                checkBoxFrequentFlyer.Checked = selectedPassenger.Id % 2 == 0;
            }
        }

        private void ClearPassengerInputs()
        {
            txtPassengerId.Text = string.Empty;
            txtPassengerName.Text = string.Empty;
            txtPassengerSurname.Text = string.Empty;
            txtPassengerFlightId.Text = string.Empty;
            txtPassengerSeatNumber.Text = string.Empty;
            checkBoxFrequentFlyer.Checked = false;

        }
        #endregion

        #region Validation Methods
        private bool ValidateFlightId(string flightIdText)
        {
            // Basic validation
            if (string.IsNullOrWhiteSpace(flightIdText))
                return false;

            if (!int.TryParse(flightIdText, out int flightId) || flightId <= 0)
                return false;

            // Check existence in flights.txt
            int nrFlights;
            Flight[] flights = adminFlight.GetFlights(out nrFlights);

            // Ensure there are flights and the array is valid
            if (flights == null || nrFlights == 0)
                return false;

            // Check if any flight has this ID
            for (int i = 0; i < nrFlights; i++)
            {
                if (flights[i] != null && flights[i].flightId == flightId)
                    return true;
            }

            return false;
        }

        private bool ValidateCity(string city)
        {
            return !string.IsNullOrWhiteSpace(city);
        }

        private bool ValidateTime(DateTime selectedTime)
        {
            return selectedTime > DateTime.Now;
        }

        private bool ValidateGate(string gateText)
        {
            if (string.IsNullOrWhiteSpace(gateText))
                return false;

            if (!int.TryParse(gateText, out int gate))
                return false;

            return gate > 0;
        }

        private bool ValidatePassengerId(string passengerIdText)
        {
            if (string.IsNullOrWhiteSpace(passengerIdText))
                return false;

            if (!int.TryParse(passengerIdText, out int passengerId))
                return false;

            return passengerId > 0;
        }

        private bool ValidateName(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        private bool ValidateSeatNumber(string seatNumber)
        {
            return !string.IsNullOrWhiteSpace(seatNumber);
        }

        private void btnUpdateFlight_Click(object sender, EventArgs e)
        {
            if (lstFlights.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a flight to update.");
                return;
            }

            Flight selectedFlight = (Flight)lstFlights.SelectedItems[0].Tag;

            // Clear any previous errors
            errorProvider.Clear();

            // Validate Flight ID
            if (!ValidateFlightId(txtFlightId.Text))
            {
                errorProvider.SetError(txtFlightId, "Flight ID must be a positive integer");
                return;
            }

            // Validate City
            if (!ValidateCity(txtFlightCity.Text))
            {
                errorProvider.SetError(txtFlightCity, "City name is required");
                return;
            }
            DateTime selectedTime = dtpFlightTime.Value;
            // Validate Time
            if (!ValidateTime(selectedTime))
            {
                errorProvider.SetError(dtpFlightTime, "Flight time must be in the future");
                return;
            }

            // Validate Gate
            if (!ValidateGate(txtFlightGate.Text))
            {
                errorProvider.SetError(txtFlightGate, "Gate must be a positive integer");
                return;
            }

            selectedFlight.city = txtFlightCity.Text;
            selectedFlight.time = DateTime.Parse(dtpFlightTime.Text);
            selectedFlight.gate = int.Parse(txtFlightGate.Text);
            selectedFlight.status = CombineFlightStatus();
            selectedFlight.flightType = rbDeparture.Checked ? FlightType.Departure : FlightType.Arrival;

            adminFlight.UpdateFlight(selectedFlight);
           
            LoadFlights();
            ClearFlightInputs();
            MessageBox.Show("Flight updated successfully!");
        }

        private FlightStatus CombineFlightStatus()
        {
            FlightStatus status = (FlightStatus)cmbFlightStatus.SelectedItem;
            foreach (var checkedItem in checkListBoxFlightStatusFlags.CheckedItems)
            {
                status |= (FlightStatus)checkedItem;
            }
            return status;
        }
        private void btnUpdatePassenger_Click(object sender, EventArgs e)
        {
            if (lstPassengers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a passenger to update.");
                return;
            }

            Passenger selectedPassenger = (Passenger)lstPassengers.SelectedItems[0].Tag;


            // Clear any previous errors
            errorProvider.Clear();

            // Validate Passenger ID
            if (!ValidatePassengerId(txtPassengerId.Text))
            {
                errorProvider.SetError(txtPassengerId, "Passenger ID must be a positive integer");
                return;
            }

            // Validate Name
            if (!ValidateName(txtPassengerName.Text))
            {
                errorProvider.SetError(txtPassengerName, "Name is required");
                return;
            }

            // Validate Surname
            if (!ValidateName(txtPassengerSurname.Text))
            {
                errorProvider.SetError(txtPassengerSurname, "Surname is required");
                return;
            }

            // Validate Flight ID
            if (!ValidateFlightId(txtPassengerFlightId.Text))
            {
                errorProvider.SetError(txtPassengerFlightId, "Flight ID must be a real flight");
                return;
            }

            // Validate Seat Number
            if (!ValidateSeatNumber(txtPassengerSeatNumber.Text))
            {
                errorProvider.SetError(txtPassengerSeatNumber, "Seat number is required");
                return;
            }

            

            selectedPassenger.Name = txtPassengerName.Text;
            selectedPassenger.Surname = txtPassengerSurname.Text;
            selectedPassenger.FlightId = int.Parse(txtPassengerFlightId.Text);
            selectedPassenger.SeatNumber = txtPassengerSeatNumber.Text;

            adminPassenger.UpdatePassenger(selectedPassenger);
            LoadPassengers();
            ClearPassengerInputs();
            MessageBox.Show("Passenger updated successfully!");
        }
        #endregion
    }
}