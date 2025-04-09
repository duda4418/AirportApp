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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // dataGridView1
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(760, 425);
            this.dataGridView1.TabIndex = 0;

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Passenger Management";

            this.dgvFlights = new System.Windows.Forms.DataGridView();
            this.btnAddPassenger = new System.Windows.Forms.Button();
            this.btnAddFlight = new System.Windows.Forms.Button();

            // dgvFlights
            this.dgvFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlights.Location = new System.Drawing.Point(12, 450);
            this.dgvFlights.Name = "dgvFlights";
            this.dgvFlights.Size = new System.Drawing.Size(760, 200);
            this.dgvFlights.TabIndex = 1;

            // btnAddPassenger
            this.btnAddPassenger.Text = "Add Passenger";
            this.btnAddPassenger.Location = new System.Drawing.Point(12, 660);
            this.btnAddPassenger.Click += new System.EventHandler(this.btnAddPassenger_Click);

            // btnAddFlight
            this.btnAddFlight.Text = "Add Flight";
            this.btnAddFlight.Location = new System.Drawing.Point(130, 660);
            this.btnAddFlight.Click += new System.EventHandler(this.btnAddFlight_Click);

            // Add controls to Form
            this.Controls.Add(this.dgvFlights);
            this.Controls.Add(this.btnAddPassenger);
            this.Controls.Add(this.btnAddFlight);

            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

    }
}

