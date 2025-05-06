using System.Drawing;
using System.Windows.Forms;
using System;
using LibrarieModele;

namespace AirportAppUI
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private TabControl tabControl;
        private TabPage tabFlights;
        private TabPage tabPassengers;

        // Flight tab controls
        private ListView lstFlights;
        private Panel pnlAddFlight;
        private Label lblFlightCity;
        private TextBox txtFlightCity;
        private Label lblFlightTime;
        private TextBox txtFlightTime;
        private Label lblFlightGate;
        private TextBox txtFlightGate;
        private Label lblFlightStatus;
        private ComboBox cmbFlightStatus;
        private Label lblFlightType;
        private RadioButton rbDeparture;
        private RadioButton rbArrival;
        private Panel pnlFlightType;
        private Label lblFlightId;
        private TextBox txtFlightId;
        private Button btnAddFlight;
        private Panel pnlFlightSearch;
        private Label lblSearchFlights;
        private TextBox txtSearchFlights;
        private ComboBox cmbFlightSearchType;
        private Button btnSearchFlights;
        private CheckBox chkShowOnlyOnTime;
        private Button btnClearFlightSearch;
        private ErrorProvider errorProvider;

        // Passenger tab controls
        private ListView lstPassengers;
        private Panel pnlAddPassenger;
        private Label lblPassengerId;
        private TextBox txtPassengerId;
        private Label lblPassengerName;
        private TextBox txtPassengerName;
        private Label lblPassengerSurname;
        private TextBox txtPassengerSurname;
        private Label lblPassengerFlightId;
        private TextBox txtPassengerFlightId;
        private Label lblPassengerSeatNumber;
        private TextBox txtPassengerSeatNumber;
        private Button btnAddPassenger;
        private Panel pnlPassengerSearch;
        private Label lblSearchPassengers;
        private TextBox txtSearchPassengers;
        private Button btnSearchPassengers;
        private Button btnClearPassengerSearch;
        private CheckBox chkShowAllPassengers;
        private ComboBox cmbPassengerSearchType;

        private CheckedListBox checkListBoxFlightStatusFlags;
        private CheckBox checkBoxFrequentFlyer;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabFlights = new System.Windows.Forms.TabPage();
            this.tabPassengers = new System.Windows.Forms.TabPage();

            // Flight tab controls initialization
            this.lstFlights = new System.Windows.Forms.ListView();
            this.pnlAddFlight = new System.Windows.Forms.Panel();
            this.lblFlightCity = new System.Windows.Forms.Label();
            this.txtFlightCity = new System.Windows.Forms.TextBox();
            this.lblFlightTime = new System.Windows.Forms.Label();
            this.txtFlightTime = new System.Windows.Forms.TextBox();
            this.lblFlightGate = new System.Windows.Forms.Label();
            this.txtFlightGate = new System.Windows.Forms.TextBox();
            this.lblFlightStatus = new System.Windows.Forms.Label();
            this.cmbFlightStatus = new System.Windows.Forms.ComboBox();
            this.lblFlightType = new System.Windows.Forms.Label();
            this.pnlFlightType = new System.Windows.Forms.Panel();
            this.rbDeparture = new System.Windows.Forms.RadioButton();
            this.rbArrival = new System.Windows.Forms.RadioButton();
            this.lblFlightId = new System.Windows.Forms.Label();
            this.txtFlightId = new System.Windows.Forms.TextBox();
            this.btnAddFlight = new System.Windows.Forms.Button();
            this.pnlFlightSearch = new System.Windows.Forms.Panel();
            this.lblSearchFlights = new System.Windows.Forms.Label();
            this.txtSearchFlights = new System.Windows.Forms.TextBox();
            this.cmbFlightSearchType = new System.Windows.Forms.ComboBox();
            this.btnSearchFlights = new System.Windows.Forms.Button();
            this.chkShowOnlyOnTime = new System.Windows.Forms.CheckBox();
            this.btnClearFlightSearch = new System.Windows.Forms.Button();

            // Passenger tab controls initialization
            this.lstPassengers = new System.Windows.Forms.ListView();
            this.pnlAddPassenger = new System.Windows.Forms.Panel();
            this.lblPassengerId = new System.Windows.Forms.Label();
            this.txtPassengerId = new System.Windows.Forms.TextBox();
            this.lblPassengerName = new System.Windows.Forms.Label();
            this.txtPassengerName = new System.Windows.Forms.TextBox();
            this.lblPassengerSurname = new System.Windows.Forms.Label();
            this.txtPassengerSurname = new System.Windows.Forms.TextBox();
            this.lblPassengerFlightId = new System.Windows.Forms.Label();
            this.txtPassengerFlightId = new System.Windows.Forms.TextBox();
            this.lblPassengerSeatNumber = new System.Windows.Forms.Label();
            this.txtPassengerSeatNumber = new System.Windows.Forms.TextBox();
            this.btnAddPassenger = new System.Windows.Forms.Button();
            this.pnlPassengerSearch = new System.Windows.Forms.Panel();
            this.lblSearchPassengers = new System.Windows.Forms.Label();
            this.txtSearchPassengers = new System.Windows.Forms.TextBox();
            this.btnSearchPassengers = new System.Windows.Forms.Button();
            this.btnClearPassengerSearch = new System.Windows.Forms.Button();
            this.chkShowAllPassengers = new System.Windows.Forms.CheckBox();

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabFlights.SuspendLayout();
            this.tabPassengers.SuspendLayout();
            this.pnlAddFlight.SuspendLayout();
            this.pnlFlightType.SuspendLayout();
            this.pnlFlightSearch.SuspendLayout();
            this.pnlAddPassenger.SuspendLayout();
            this.pnlPassengerSearch.SuspendLayout();
            this.SuspendLayout();

            // Form properties
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Name = "Form1";
            this.Text = "Airport Management System";
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tab Control
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 700);
            this.tabControl.TabIndex = 0;
            this.Controls.Add(this.tabControl);

            // Flights Tab
            this.tabFlights.Location = new System.Drawing.Point(4, 22);
            this.tabFlights.Name = "tabFlights";
            this.tabFlights.Padding = new System.Windows.Forms.Padding(3);
            this.tabFlights.Size = new System.Drawing.Size(992, 674);
            this.tabFlights.TabIndex = 0;
            this.tabFlights.Text = "Flights";
            this.tabFlights.UseVisualStyleBackColor = true;
            this.tabControl.Controls.Add(this.tabFlights);

            // Flights ListBox
            this.lstFlights.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            //this.lstFlights.FormattingEnabled = true;
            this.lstFlights.Location = new System.Drawing.Point(6, 150);
            this.lstFlights.Name = "lstFlights";
            this.lstFlights.Size = new System.Drawing.Size(980, 511);
            this.lstFlights.TabIndex = 0;
            this.tabFlights.Controls.Add(this.lstFlights);

            // Add Flight Panel
            this.pnlAddFlight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAddFlight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddFlight.Location = new System.Drawing.Point(6, 6);
            this.pnlAddFlight.Name = "pnlAddFlight";
            this.pnlAddFlight.Size = new System.Drawing.Size(980, 85);
            this.pnlAddFlight.TabIndex = 1;
            this.tabFlights.Controls.Add(this.pnlAddFlight);

            // Flight City
            this.lblFlightCity.AutoSize = true;
            this.lblFlightCity.Location = new System.Drawing.Point(110, 15);
            this.lblFlightCity.Name = "lblFlightCity";
            this.lblFlightCity.Size = new System.Drawing.Size(27, 13);
            this.lblFlightCity.TabIndex = 0;
            this.lblFlightCity.Text = "City:";
            this.pnlAddFlight.Controls.Add(this.lblFlightCity);

            this.txtFlightCity.Location = new System.Drawing.Point(143, 12);
            this.txtFlightCity.Name = "txtFlightCity";
            this.txtFlightCity.Size = new System.Drawing.Size(120, 20);
            this.txtFlightCity.TabIndex = 1;
            this.txtFlightCity.Validating += new System.ComponentModel.CancelEventHandler(this.txtFlightCity_Validating);
            this.pnlAddFlight.Controls.Add(this.txtFlightCity);

            // Flight Time
            this.lblFlightTime.AutoSize = true;
            this.lblFlightTime.Location = new System.Drawing.Point(270, 15);
            this.lblFlightTime.Name = "lblFlightTime";
            this.lblFlightTime.Size = new System.Drawing.Size(33, 13);
            this.lblFlightTime.TabIndex = 2;
            this.lblFlightTime.Text = "Time:";
            this.pnlAddFlight.Controls.Add(this.lblFlightTime);

            this.txtFlightTime.Location = new System.Drawing.Point(309, 12);
            this.txtFlightTime.Name = "txtFlightTime";
            this.txtFlightTime.Size = new System.Drawing.Size(80, 20);
            this.txtFlightTime.TabIndex = 3;
            this.txtFlightTime.Validating += new System.ComponentModel.CancelEventHandler(this.txtFlightTime_Validating);
            this.pnlAddFlight.Controls.Add(this.txtFlightTime);

            // Flight Gate
            this.lblFlightGate.AutoSize = true;
            this.lblFlightGate.Location = new System.Drawing.Point(395, 15);
            this.lblFlightGate.Name = "lblFlightGate";
            this.lblFlightGate.Size = new System.Drawing.Size(33, 13);
            this.lblFlightGate.TabIndex = 4;
            this.lblFlightGate.Text = "Gate:";
            this.pnlAddFlight.Controls.Add(this.lblFlightGate);

            this.txtFlightGate.Location = new System.Drawing.Point(434, 12);
            this.txtFlightGate.Name = "txtFlightGate";
            this.txtFlightGate.Size = new System.Drawing.Size(60, 20);
            this.txtFlightGate.TabIndex = 5;
            this.txtFlightGate.Validating += new System.ComponentModel.CancelEventHandler(this.txtFlightGate_Validating);
            this.pnlAddFlight.Controls.Add(this.txtFlightGate);

            // Flight Status
            this.lblFlightStatus.AutoSize = true;
            this.lblFlightStatus.Location = new System.Drawing.Point(500, 15);
            this.lblFlightStatus.Name = "lblFlightStatus";
            this.lblFlightStatus.Size = new System.Drawing.Size(40, 13);
            this.lblFlightStatus.TabIndex = 6;
            this.lblFlightStatus.Text = "Status:";
            this.pnlAddFlight.Controls.Add(this.lblFlightStatus);

            this.cmbFlightStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFlightStatus.FormattingEnabled = true;
            this.cmbFlightStatus.Location = new System.Drawing.Point(546, 12);
            this.cmbFlightStatus.Name = "cmbFlightStatus";
            this.cmbFlightStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbFlightStatus.TabIndex = 7;
            this.pnlAddFlight.Controls.Add(this.cmbFlightStatus);

            // Flight Type
            this.lblFlightType.AutoSize = true;
            this.lblFlightType.Location = new System.Drawing.Point(10, 50);
            this.lblFlightType.Name = "lblFlightType";
            this.lblFlightType.Size = new System.Drawing.Size(34, 13);
            this.lblFlightType.TabIndex = 8;
            this.lblFlightType.Text = "Type:";
            this.pnlAddFlight.Controls.Add(this.lblFlightType);

            // Flight Type Panel with Radio Buttons
            this.pnlFlightType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pnlFlightType.Location = new System.Drawing.Point(50, 45);
            this.pnlFlightType.Name = "pnlFlightType";
            this.pnlFlightType.Size = new System.Drawing.Size(200, 30);
            this.pnlFlightType.TabIndex = 9;
            this.pnlAddFlight.Controls.Add(this.pnlFlightType);

            this.rbDeparture.AutoSize = true;
            this.rbDeparture.Checked = true;
            this.rbDeparture.Location = new System.Drawing.Point(3, 5);
            this.rbDeparture.Name = "rbDeparture";
            this.rbDeparture.Size = new System.Drawing.Size(73, 17);
            this.rbDeparture.TabIndex = 0;
            this.rbDeparture.TabStop = true;
            this.rbDeparture.Text = "Departure";
            this.rbDeparture.UseVisualStyleBackColor = true;
            this.pnlFlightType.Controls.Add(this.rbDeparture);

            this.rbArrival.AutoSize = true;
            this.rbArrival.Location = new System.Drawing.Point(82, 5);
            this.rbArrival.Name = "rbArrival";
            this.rbArrival.Size = new System.Drawing.Size(55, 17);
            this.rbArrival.TabIndex = 1;
            this.rbArrival.Text = "Arrival";
            this.rbArrival.UseVisualStyleBackColor = true;
            this.pnlFlightType.Controls.Add(this.rbArrival);

            // Flight ID
            this.lblFlightId.AutoSize = true;
            this.lblFlightId.Location = new System.Drawing.Point(10, 15);
            this.lblFlightId.Name = "lblFlightId";
            this.lblFlightId.Size = new System.Drawing.Size(52, 13);
            this.lblFlightId.TabIndex = 10;
            this.lblFlightId.Text = "Flight ID:";
            this.pnlAddFlight.Controls.Add(this.lblFlightId);

            this.txtFlightId.Location = new System.Drawing.Point(68, 12);
            this.txtFlightId.Name = "txtFlightId";
            this.txtFlightId.Size = new System.Drawing.Size(36, 20);
            this.txtFlightId.TabIndex = 11;
            this.txtFlightId.Validating += new System.ComponentModel.CancelEventHandler(this.txtFlightId_Validating);
            this.pnlAddFlight.Controls.Add(this.txtFlightId);

            // Add Flight Button
            this.btnAddFlight.Location = new System.Drawing.Point(800, 45);
            this.btnAddFlight.Name = "btnAddFlight";
            this.btnAddFlight.Size = new System.Drawing.Size(100, 23);
            this.btnAddFlight.TabIndex = 12;
            this.btnAddFlight.Text = "Add Flight";
            this.btnAddFlight.UseVisualStyleBackColor = true;
            this.btnAddFlight.Click += new System.EventHandler(this.btnAddFlight_Click);
            this.pnlAddFlight.Controls.Add(this.btnAddFlight);

            // Flight Search Panel
            this.pnlFlightSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            |System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFlightSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFlightSearch.Location = new System.Drawing.Point(6, 97);
            this.pnlFlightSearch.Name = "pnlFlightSearch";
            this.pnlFlightSearch.Size = new System.Drawing.Size(980, 47);
            this.pnlFlightSearch.TabIndex = 2;
            this.tabFlights.Controls.Add(this.pnlFlightSearch);

            // Search Flights Label
            this.lblSearchFlights.AutoSize = true;
            this.lblSearchFlights.Location = new System.Drawing.Point(10, 15);
            this.lblSearchFlights.Name = "lblSearchFlights";
            this.lblSearchFlights.Size = new System.Drawing.Size(44, 13);
            this.lblSearchFlights.TabIndex = 0;
            this.lblSearchFlights.Text = "Search:";
            this.pnlFlightSearch.Controls.Add(this.lblSearchFlights);

            // Search Flights TextBox
            this.txtSearchFlights.Location = new System.Drawing.Point(60, 12);
            this.txtSearchFlights.Name = "txtSearchFlights";
            this.txtSearchFlights.Size = new System.Drawing.Size(200, 20);
            this.txtSearchFlights.TabIndex = 1;
            this.pnlFlightSearch.Controls.Add(this.txtSearchFlights);

            // Search Type ComboBox
            this.cmbFlightSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFlightSearchType.FormattingEnabled = true;
            this.cmbFlightSearchType.Items.AddRange(new object[] {
            "City",
            "Gate",
            "Flight ID"});
            this.cmbFlightSearchType.Location = new System.Drawing.Point(270, 12);
            this.cmbFlightSearchType.Name = "cmbFlightSearchType";
            this.cmbFlightSearchType.Size = new System.Drawing.Size(121, 21);
            this.cmbFlightSearchType.TabIndex = 2;
            this.cmbFlightSearchType.SelectedIndex = 0;
            this.pnlFlightSearch.Controls.Add(this.cmbFlightSearchType);

            // Search Flights Button
            this.btnSearchFlights.Location = new System.Drawing.Point(400, 10);
            this.btnSearchFlights.Name = "btnSearchFlights";
            this.btnSearchFlights.Size = new System.Drawing.Size(75, 23);
            this.btnSearchFlights.TabIndex = 3;
            this.btnSearchFlights.Text = "Search";
            this.btnSearchFlights.UseVisualStyleBackColor = true;
            this.btnSearchFlights.Click += new System.EventHandler(this.btnSearchFlights_Click);
            this.pnlFlightSearch.Controls.Add(this.btnSearchFlights);

            // Show Only On Time Checkbox
            this.chkShowOnlyOnTime.AutoSize = true;
            this.chkShowOnlyOnTime.Location = new System.Drawing.Point(600, 14);
            this.chkShowOnlyOnTime.Name = "chkShowOnlyOnTime";
            this.chkShowOnlyOnTime.Size = new System.Drawing.Size(125, 17);
            this.chkShowOnlyOnTime.TabIndex = 4;
            this.chkShowOnlyOnTime.Text = "Show Only On Time";
            this.chkShowOnlyOnTime.UseVisualStyleBackColor = true;
            this.chkShowOnlyOnTime.CheckedChanged += new System.EventHandler(this.btnClearPassengerSearch_Click);
            this.pnlFlightSearch.Controls.Add(this.chkShowOnlyOnTime);

            // Clear Flight Search Button
            this.btnClearFlightSearch.Location = new System.Drawing.Point(480, 10);
            this.btnClearFlightSearch.Name = "btnClearFlightSearch";
            this.btnClearFlightSearch.Size = new System.Drawing.Size(75, 23);
            this.btnClearFlightSearch.TabIndex = 5;
            this.btnClearFlightSearch.Text = "Clear";
            this.btnClearFlightSearch.UseVisualStyleBackColor = true;
            this.btnClearFlightSearch.Click += new System.EventHandler(this.btnClearFlightSearch_Click);
            this.pnlFlightSearch.Controls.Add(this.btnClearFlightSearch);

            // Passengers Tab
            this.tabPassengers.Location = new System.Drawing.Point(4, 22);
            this.tabPassengers.Name = "tabPassengers";
            this.tabPassengers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPassengers.Size = new System.Drawing.Size(992, 674);
            this.tabPassengers.TabIndex = 1;
            this.tabPassengers.Text = "Passengers";
            this.tabPassengers.UseVisualStyleBackColor = true;
            this.tabControl.Controls.Add(this.tabPassengers);

            // Passengers ListBox
            this.lstPassengers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            //this.lstPassengers.FormattingEnabled = true;
            this.lstPassengers.Location = new System.Drawing.Point(6, 150);
            this.lstPassengers.Name = "lstPassengers";
            this.lstPassengers.Size = new System.Drawing.Size(980, 511);
            this.lstPassengers.TabIndex = 0;
            this.tabPassengers.Controls.Add(this.lstPassengers);

            // Add Passenger Panel
            this.pnlAddPassenger.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAddPassenger.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAddPassenger.Location = new System.Drawing.Point(6, 6);
            this.pnlAddPassenger.Name = "pnlAddPassenger";
            this.pnlAddPassenger.Size = new System.Drawing.Size(980, 85);
            this.pnlAddPassenger.TabIndex = 1;
            this.tabPassengers.Controls.Add(this.pnlAddPassenger);

            // Passenger ID
            this.lblPassengerId.AutoSize = true;
            this.lblPassengerId.Location = new System.Drawing.Point(10, 15);
            this.lblPassengerId.Name = "lblPassengerId";
            this.lblPassengerId.Size = new System.Drawing.Size(76, 13);
            this.lblPassengerId.TabIndex = 0;
            this.lblPassengerId.Text = "Passenger ID:";
            this.pnlAddPassenger.Controls.Add(this.lblPassengerId);

            this.txtPassengerId.Location = new System.Drawing.Point(92, 12);
            this.txtPassengerId.Name = "txtPassengerId";
            this.txtPassengerId.Size = new System.Drawing.Size(40, 20);
            this.txtPassengerId.TabIndex = 1;
            this.txtPassengerId.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassengerId_Validating);
            this.pnlAddPassenger.Controls.Add(this.txtPassengerId);

            // Passenger Name
            this.lblPassengerName.AutoSize = true;
            this.lblPassengerName.Location = new System.Drawing.Point(145, 15);
            this.lblPassengerName.Name = "lblPassengerName";
            this.lblPassengerName.Size = new System.Drawing.Size(38, 13);
            this.lblPassengerName.TabIndex = 2;
            this.lblPassengerName.Text = "Name:";
            this.pnlAddPassenger.Controls.Add(this.lblPassengerName);

            this.txtPassengerName.Location = new System.Drawing.Point(189, 12);
            this.txtPassengerName.Name = "txtPassengerName";
            this.txtPassengerName.Size = new System.Drawing.Size(150, 20);
            this.txtPassengerName.TabIndex = 3;
            this.txtPassengerName.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassengerName_Validating);
            this.pnlAddPassenger.Controls.Add(this.txtPassengerName);

            // Passenger Surname
            this.lblPassengerSurname.AutoSize = true;
            this.lblPassengerSurname.Location = new System.Drawing.Point(350, 15);
            this.lblPassengerSurname.Name = "lblPassengerSurname";
            this.lblPassengerSurname.Size = new System.Drawing.Size(52, 13);
            this.lblPassengerSurname.TabIndex = 4;
            this.lblPassengerSurname.Text = "Surname:";
            this.pnlAddPassenger.Controls.Add(this.lblPassengerSurname);

            this.txtPassengerSurname.Location = new System.Drawing.Point(408, 12);
            this.txtPassengerSurname.Name = "txtPassengerSurname";
            this.txtPassengerSurname.Size = new System.Drawing.Size(150, 20);
            this.txtPassengerSurname.TabIndex = 5;
            this.txtPassengerSurname.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassengerSurname_Validating);
            this.pnlAddPassenger.Controls.Add(this.txtPassengerSurname);

            // Passenger Flight ID
            this.lblPassengerFlightId.AutoSize = true;
            this.lblPassengerFlightId.Location = new System.Drawing.Point(10, 50);
            this.lblPassengerFlightId.Name = "lblPassengerFlightId";
            this.lblPassengerFlightId.Size = new System.Drawing.Size(52, 13);
            this.lblPassengerFlightId.TabIndex = 6;
            this.lblPassengerFlightId.Text = "Flight ID:";
            this.pnlAddPassenger.Controls.Add(this.lblPassengerFlightId);

            this.txtPassengerFlightId.Location = new System.Drawing.Point(92, 47);
            this.txtPassengerFlightId.Name = "txtPassengerFlightId";
            this.txtPassengerFlightId.Size = new System.Drawing.Size(40, 20);
            this.txtPassengerFlightId.TabIndex = 7;
            this.txtPassengerFlightId.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassengerFlightId_Validating);
            this.pnlAddPassenger.Controls.Add(this.txtPassengerFlightId);

            // Passenger Seat Number
            this.lblPassengerSeatNumber.AutoSize = true;
            this.lblPassengerSeatNumber.Location = new System.Drawing.Point(145, 50);
            this.lblPassengerSeatNumber.Name = "lblPassengerSeatNumber";
            this.lblPassengerSeatNumber.Size = new System.Drawing.Size(75, 13);
            this.lblPassengerSeatNumber.TabIndex = 8;
            this.lblPassengerSeatNumber.Text = "Seat Number:";
            this.pnlAddPassenger.Controls.Add(this.lblPassengerSeatNumber);

            this.txtPassengerSeatNumber.Location = new System.Drawing.Point(226, 47);
            this.txtPassengerSeatNumber.Name = "txtPassengerSeatNumber";
            this.txtPassengerSeatNumber.Size = new System.Drawing.Size(80, 20);
            this.txtPassengerSeatNumber.TabIndex = 9;
            this.txtPassengerSeatNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassengerSeatNumber_Validating);
            this.pnlAddPassenger.Controls.Add(this.txtPassengerSeatNumber);

            // Add Passenger Button
            this.btnAddPassenger.Location = new System.Drawing.Point(800, 45);
            this.btnAddPassenger.Name = "btnAddPassenger";
            this.btnAddPassenger.Size = new System.Drawing.Size(100, 23);
            this.btnAddPassenger.TabIndex = 10;
            this.btnAddPassenger.Text = "Add Passenger";
            this.btnAddPassenger.UseVisualStyleBackColor = true;
            this.btnAddPassenger.Click += new System.EventHandler(this.btnAddPassenger_Click);
            this.pnlAddPassenger.Controls.Add(this.btnAddPassenger);

            // Passenger Search Panel
            this.pnlPassengerSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPassengerSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPassengerSearch.Location = new System.Drawing.Point(6, 97);
            this.pnlPassengerSearch.Name = "pnlPassengerSearch";
            this.pnlPassengerSearch.Size = new System.Drawing.Size(980, 47);
            this.pnlPassengerSearch.TabIndex = 2;
            this.tabPassengers.Controls.Add(this.pnlPassengerSearch);

            // Search Passengers Label
            this.lblSearchPassengers.AutoSize = true;
            this.lblSearchPassengers.Location = new System.Drawing.Point(10, 15);
            this.lblSearchPassengers.Name = "lblSearchPassengers";
            this.lblSearchPassengers.Size = new System.Drawing.Size(44, 13);
            this.lblSearchPassengers.TabIndex = 0;
            this.lblSearchPassengers.Text = "Search:";
            this.pnlPassengerSearch.Controls.Add(this.lblSearchPassengers);

            // Search Passengers TextBox
            this.txtSearchPassengers.Location = new System.Drawing.Point(60, 12);
            this.txtSearchPassengers.Name = "txtSearchPassengers";
            this.txtSearchPassengers.Size = new System.Drawing.Size(200, 20);
            this.txtSearchPassengers.TabIndex = 1;
            this.pnlPassengerSearch.Controls.Add(this.txtSearchPassengers);

            // Search Passengers Button
            this.btnSearchPassengers.Location = new System.Drawing.Point(270, 10);
            this.btnSearchPassengers.Name = "btnSearchPassengers";
            this.btnSearchPassengers.Size = new System.Drawing.Size(75, 23);
            this.btnSearchPassengers.TabIndex = 2;
            this.btnSearchPassengers.Text = "Search";
            this.btnSearchPassengers.UseVisualStyleBackColor = true;
            this.btnSearchPassengers.Click += new System.EventHandler(this.btnSearchPassengers_Click);
            this.pnlPassengerSearch.Controls.Add(this.btnSearchPassengers);

            // Clear Passenger Search Button
            this.btnClearPassengerSearch.Location = new System.Drawing.Point(350, 10);
            this.btnClearPassengerSearch.Name = "btnClearPassengerSearch";
            this.btnClearPassengerSearch.Size = new System.Drawing.Size(75, 23);
            this.btnClearPassengerSearch.TabIndex = 3;
            this.btnClearPassengerSearch.Text = "Clear";
            this.btnClearPassengerSearch.UseVisualStyleBackColor = true;
            this.btnClearPassengerSearch.Click += new System.EventHandler(this.btnClearPassengerSearch_Click);
            this.pnlPassengerSearch.Controls.Add(this.btnClearPassengerSearch);

            // Show All Passengers Checkbox
            this.chkShowAllPassengers.AutoSize = true;
            this.chkShowAllPassengers.Location = new System.Drawing.Point(450, 14);
            this.chkShowAllPassengers.Name = "chkShowAllPassengers";
            this.chkShowAllPassengers.Size = new System.Drawing.Size(120, 17);
            this.chkShowAllPassengers.TabIndex = 4;
            this.chkShowAllPassengers.Text = "Show All Passengers";
            this.chkShowAllPassengers.UseVisualStyleBackColor = true;
            //this.chkShowAllPassengers.CheckedChanged += new System.EventHandler(this.chkShowAllPassengers_CheckedChanged);
            this.pnlPassengerSearch.Controls.Add(this.chkShowAllPassengers);

            // Error Provider
            this.errorProvider.ContainerControl = this;

            // CheckedListBox for flight status flags
            this.checkListBoxFlightStatusFlags = new System.Windows.Forms.CheckedListBox();
            this.checkListBoxFlightStatusFlags.FormattingEnabled = true;
            this.checkListBoxFlightStatusFlags.Location = new System.Drawing.Point(680, 12);
            this.checkListBoxFlightStatusFlags.Name = "checkListBoxFlightStatusFlags";
            this.checkListBoxFlightStatusFlags.Size = new System.Drawing.Size(120, 64);
            this.checkListBoxFlightStatusFlags.TabIndex = 13;
            this.pnlAddFlight.Controls.Add(this.checkListBoxFlightStatusFlags);

            // Add a label for it
            Label lblStatusFlags = new Label();
            lblStatusFlags.Text = "Status Flags:";
            lblStatusFlags.Location = new System.Drawing.Point(680, -5);
            lblStatusFlags.AutoSize = true;
            this.pnlAddFlight.Controls.Add(lblStatusFlags);

            // Frequent Flyer CheckBox
            this.checkBoxFrequentFlyer = new System.Windows.Forms.CheckBox();
            this.checkBoxFrequentFlyer.AutoSize = true;
            this.checkBoxFrequentFlyer.Location = new System.Drawing.Point(350, 50);
            this.checkBoxFrequentFlyer.Name = "checkBoxFrequentFlyer";
            this.checkBoxFrequentFlyer.Size = new System.Drawing.Size(95, 17);
            this.checkBoxFrequentFlyer.TabIndex = 11;
            this.checkBoxFrequentFlyer.Text = "Frequent Flyer";
            this.checkBoxFrequentFlyer.UseVisualStyleBackColor = true;
            this.pnlAddPassenger.Controls.Add(this.checkBoxFrequentFlyer);

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabFlights.ResumeLayout(false);
            this.tabPassengers.ResumeLayout(false);
            this.pnlAddFlight.ResumeLayout(false);
            this.pnlAddFlight.PerformLayout();
            this.pnlFlightType.ResumeLayout(false);
            this.pnlFlightType.PerformLayout();
            this.pnlFlightSearch.ResumeLayout(false);
            this.pnlFlightSearch.PerformLayout();
            this.pnlAddPassenger.ResumeLayout(false);
            this.pnlAddPassenger.PerformLayout();
            this.pnlPassengerSearch.ResumeLayout(false);
            this.pnlPassengerSearch.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        // Validation methods for Flight inputs
        private void txtFlightId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFlightId.Text))
            {
                errorProvider.SetError(txtFlightId, "Flight ID is required");
                e.Cancel = true;
            }
            else if (!int.TryParse(txtFlightId.Text, out int flightId) || flightId <= 0)
            {
                errorProvider.SetError(txtFlightId, "Flight ID must be a positive number");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtFlightId, "");
            }
        }

        private void txtFlightCity_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFlightCity.Text))
            {
                errorProvider.SetError(txtFlightCity, "City is required");
                e.Cancel = true;
            }
            else if (txtFlightCity.Text.Length < 2)
            {
                errorProvider.SetError(txtFlightCity, "City name must be at least 2 characters");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtFlightCity, "");
            }
        }

        private void txtFlightTime_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFlightTime.Text))
            {
                errorProvider.SetError(txtFlightTime, "Time is required");
                e.Cancel = true;
            }
            else if (!double.TryParse(txtFlightTime.Text, out double time) || time < 0 || time > 23.59)
            {
                errorProvider.SetError(txtFlightTime, "Time must be a valid value between 0.00 and 23.59");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtFlightTime, "");
            }
        }

        private void txtFlightGate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFlightGate.Text))
            {
                errorProvider.SetError(txtFlightGate, "Gate is required");
                e.Cancel = true;
            }
            else if (!int.TryParse(txtFlightGate.Text, out int gate) || gate <= 0)
            {
                errorProvider.SetError(txtFlightGate, "Gate must be a positive number");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtFlightGate, "");
            }
        }

        // Validation methods for Passenger inputs
        private void txtPassengerId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassengerId.Text))
            {
                errorProvider.SetError(txtPassengerId, "Passenger ID is required");
                e.Cancel = true;
            }
            else if (!int.TryParse(txtPassengerId.Text, out int passengerId) || passengerId <= 0)
            {
                errorProvider.SetError(txtPassengerId, "Passenger ID must be a positive number");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPassengerId, "");
            }
        }

        private void txtPassengerName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassengerName.Text))
            {
                errorProvider.SetError(txtPassengerName, "Name is required");
                e.Cancel = true;
            }
            else if (txtPassengerName.Text.Length < 2)
            {
                errorProvider.SetError(txtPassengerName, "Name must be at least 2 characters");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPassengerName, "");
            }
        }

        private void txtPassengerSurname_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassengerSurname.Text))
            {
                errorProvider.SetError(txtPassengerSurname, "Surname is required");
                e.Cancel = true;
            }
            else if (txtPassengerSurname.Text.Length < 2)
            {
                errorProvider.SetError(txtPassengerSurname, "Surname must be at least 2 characters");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPassengerSurname, "");
            }
        }

        private void txtPassengerFlightId_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassengerFlightId.Text))
            {
                errorProvider.SetError(txtPassengerFlightId, "Flight ID is required");
                e.Cancel = true;
            }
            else if (!int.TryParse(txtPassengerFlightId.Text, out int flightId) || flightId <= 0)
            {
                errorProvider.SetError(txtPassengerFlightId, "Flight ID must be a positive number");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPassengerFlightId, "");
            }
        }

        private void txtPassengerSeatNumber_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassengerSeatNumber.Text))
            {
                errorProvider.SetError(txtPassengerSeatNumber, "Seat number is required");
                e.Cancel = true;
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(txtPassengerSeatNumber.Text, @"^[0-9]{1,2}[A-F]$"))
            {
                errorProvider.SetError(txtPassengerSeatNumber, "Seat number must be in format: number(s) followed by a letter (A-F). Example: 12A");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPassengerSeatNumber, "");
            }
        }
        private void btnSearchFlights_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchFlights.Text.Trim().ToLower();
            string searchType = cmbFlightSearchType.SelectedItem?.ToString() ?? "City";

            int nrFlights;
            Flight[] flights = adminFlight.GetFlights(out nrFlights);

            lstFlights.Items.Clear();

            for (int i = 0; i < nrFlights; i++)
            {
                if (flights[i] != null)
                {
                    bool match = false;
                    string propertyValue = "";

                    // Get property value based on search type
                    switch (searchType)
                    {
                        case "City":
                            propertyValue = flights[i].city.ToLower();
                            break;
                        case "Gate":
                            propertyValue = flights[i].gate.ToString();
                            break;
                        case "Flight ID":
                            propertyValue = flights[i].flightId.ToString();
                            break;
                    }

                    match = propertyValue.Contains(searchValue);

                    if (match)
                    {
                        // Add matching flight to ListView
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
        private void btnSearchPassengers_Click(object sender, EventArgs e)
        {
            string searchValue = txtSearchPassengers.Text.Trim().ToLower();
            string searchType = cmbPassengerSearchType?.SelectedItem?.ToString() ?? "Name"; // Default to "Name"

            int nrPassengers;
            Passenger[] passengers = adminPassenger.GetPassengers(out nrPassengers);

            lstPassengers.Items.Clear();

            // Check if passengers array is valid
            if (passengers == null || nrPassengers == 0)
                return;

            for (int i = 0; i < nrPassengers; i++)
            {
                Passenger passenger = passengers[i];
                if (passenger == null) // Skip null passenger entries
                    continue;

                bool match = false;
                string propertyValue = "";

                switch (searchType)
                {
                    case "Name":
                        propertyValue = passenger.Name?.ToLower() ?? ""; // Handle null Name
                        break;
                    case "Surname":
                        propertyValue = passenger.Surname?.ToLower() ?? ""; // Handle null Surname
                        break;
                    case "Flight ID":
                        propertyValue = passenger.FlightId.ToString();
                        break;
                    case "Seat":
                        propertyValue = passenger.SeatNumber?.ToLower() ?? ""; // Handle null SeatNumber
                        break;
                }

                match = !string.IsNullOrEmpty(propertyValue) && propertyValue.Contains(searchValue);

                if (match)
                {
                    ListViewItem item = new ListViewItem(passenger.Id.ToString());
                    item.SubItems.Add(passenger.Name ?? "N/A"); // Handle missing data
                    item.SubItems.Add(passenger.Surname ?? "N/A");
                    item.SubItems.Add(passenger.FlightId.ToString());
                    item.SubItems.Add(passenger.SeatNumber ?? "N/A");
                    item.Tag = passenger;
                    lstPassengers.Items.Add(item);
                }
            }
        }

        // For Flights
        private void btnClearFlightSearch_Click(object sender, EventArgs e)
        {
            txtSearchFlights.Text = "";
            LoadFlights();
        }

        // For Passengers
        private void btnClearPassengerSearch_Click(object sender, EventArgs e)
        {
            txtSearchPassengers.Text = "";
            LoadPassengers(); 
        }
    }

}