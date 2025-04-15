using System.Drawing;
using System.Windows.Forms;
using System;

namespace AirportAppUI
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dgvFlights;
        private System.Windows.Forms.Button btnAddPassenger;
        private System.Windows.Forms.Button btnAddFlight;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Text = "Airport Management App";
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Passengers Label
            Label lblPassengers = new Label();
            lblPassengers.Text = "Passengers";
            lblPassengers.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblPassengers.Location = new Point(20, 20);
            lblPassengers.AutoSize = true;
            this.Controls.Add(lblPassengers);

            // Passenger Grid
            this.dataGridView1 = new DataGridView();
            this.dataGridView1.Location = new Point(20, 50);
            this.dataGridView1.Size = new Size(950, 250);
            this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.Add(this.dataGridView1);

            // Add Passenger Button
            this.btnAddPassenger = new Button();
            this.btnAddPassenger.Text = "Add Passenger";
            this.btnAddPassenger.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.btnAddPassenger.Size = new Size(150, 40);
            this.btnAddPassenger.Location = new Point(20, 310);
            this.btnAddPassenger.Click += new EventHandler(this.btnAddPassenger_Click);
            this.Controls.Add(this.btnAddPassenger);

            // Flights Label
            Label lblFlights = new Label();
            lblFlights.Text = "Flights";
            lblFlights.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblFlights.Location = new Point(20, 370);
            lblFlights.AutoSize = true;
            this.Controls.Add(lblFlights);

            // Flights Grid
            this.dgvFlights = new DataGridView();
            this.dgvFlights.Location = new Point(20, 400);
            this.dgvFlights.Size = new Size(950, 200);
            this.dgvFlights.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvFlights.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.Add(this.dgvFlights);

            // Add Flight Button
            this.btnAddFlight = new Button();
            this.btnAddFlight.Text = "Add Flight";
            this.btnAddFlight.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.btnAddFlight.Size = new Size(150, 40);
            this.btnAddFlight.Location = new Point(20, 610);
            this.btnAddFlight.Click += new EventHandler(this.btnAddFlight_Click);
            this.Controls.Add(this.btnAddFlight);

            // --- Passenger Search ---
            TextBox txtSearchPassenger = new TextBox();
            txtSearchPassenger.Name = "txtSearchPassenger";
            txtSearchPassenger.Size = new Size(200, 30);
            txtSearchPassenger.Location = new Point(200, 310);
            this.Controls.Add(txtSearchPassenger);

            Button btnSearchPassenger = new Button();
            btnSearchPassenger.Text = "Search Passenger";
            btnSearchPassenger.Size = new Size(150, 40);
            btnSearchPassenger.Location = new Point(410, 305);
            btnSearchPassenger.Click += new EventHandler(this.btnSearchPassenger_Click);
            this.Controls.Add(btnSearchPassenger);

            // --- Flight Search ---
            TextBox txtSearchFlight = new TextBox();
            txtSearchFlight.Name = "txtSearchFlight";
            txtSearchFlight.Size = new Size(200, 30);
            txtSearchFlight.Location = new Point(200, 610);
            this.Controls.Add(txtSearchFlight);

            Button btnSearchFlight = new Button();
            btnSearchFlight.Text = "Search Flight";
            btnSearchFlight.Size = new Size(150, 40);
            btnSearchFlight.Location = new Point(410, 605);
            btnSearchFlight.Click += new EventHandler(this.btnSearchFlight_Click);
            this.Controls.Add(btnSearchFlight);

            // lblName
            lblName = new Label();
            lblName.Text = "Name:";
            lblName.Location = new Point(12, 500);
            lblName.ForeColor = Color.Black;
            this.Controls.Add(lblName);

            // lblSurname
            lblSurname = new Label();
            lblSurname.Text = "Surname:";
            lblSurname.Location = new Point(12, 530);
            lblSurname.ForeColor = Color.Black;
            this.Controls.Add(lblSurname);


        }


    }
}