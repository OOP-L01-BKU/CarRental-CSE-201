﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalv1
{
    public partial class AddVehicleForm : Form
    {
        private string type;
        private int rentCost;
        private string plateCode;
        private string brand;
        private float mileAge;
        bool input = false;
        private VehicleRentalManagement _data = null;

        public AddVehicleForm(VehicleRentalManagement vehicleRentalManagementModel)
        {
            this._data = vehicleRentalManagementModel;
            InitializeComponent();
        }

        // add vehicle
        private void button1_Click(object sender, EventArgs e)
        {
            if (input)
            {
                try
                {
                    int fleetId = int.Parse(FleetID.Text);
                    Fleet f = _data.GetFleetByID(fleetId);

                    if (this.plateCode == null || this.type == null)
                    {
                        MessageBox.Show("failure");
                    }
                    else if (type == "Car")
                    {
                        if ((this.brand == null) && (this.rentCost == 0))
                        {
                            Car addCar = new Car(mileAge, plateCode, Fleet.MaxVehicleID);
                            if (f.AddCarIntoVehicleFleet(addCar))
                            {
                                MessageBox.Show("Success");
                            }
                            else
                            {
                                MessageBox.Show("failure");
                            }
                        }
                        else
                        {
                            Car addCar = new Car(mileAge, plateCode, Fleet.MaxVehicleID, brand, rentCost);
                            if (f.AddCarIntoVehicleFleet(addCar))
                            {
                                MessageBox.Show("Success");
                            }
                            else
                            {
                                MessageBox.Show("failure");
                            }
                        }
                    }
                    else if (type == "Truck")
                    {
                        if ((this.brand == null) && (this.rentCost == 0))
                        {
                            Truck addCar = new Truck(mileAge, plateCode, Fleet.MaxVehicleID);
                            if (f.AddTruckIntoVehicleFleet(addCar))
                            {
                                MessageBox.Show("Success");
                            }
                            else
                            {
                                MessageBox.Show("Failue");
                            }
                        }
                        else
                        {
                            Truck addCar = new Truck(mileAge, plateCode, Fleet.MaxVehicleID, brand, rentCost);
                            if (f.AddTruckIntoVehicleFleet(addCar))
                            {
                                MessageBox.Show("Success");
                            }
                            else
                            {
                                MessageBox.Show("Failue");
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Fleet doesn't exist or wrong format");
                }
            }
            else
            {
                MessageBox.Show("Wrong input!!!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cancel form
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // add rent cost
            
            int a;
            if (int.TryParse(textBox4.Text, out a))
            {
                input = true;
                this.rentCost = Int32.Parse(this.textBox2.Text);
            }
            else
            {
                input = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // add plate code
            this.plateCode = this.textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            // add brand
            this.brand = this.textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            // add mile age
            
            float a;
            if (float.TryParse(textBox5.Text, out a))
            {
                input = true;
                this.mileAge = float.Parse(this.textBox5.Text);
            }
            else
            {
                input = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.type = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.type = radioButton2.Text;
        }

        private void AddVehicleForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
