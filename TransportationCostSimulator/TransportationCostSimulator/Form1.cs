using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransportationCostSimulator.Models;

namespace TransportationCostSimulator
{
    public partial class Form1 : Form
    {

        Panel Map;
        Label Distance;

        private bool _isSelectingCurrentLocation = false;
        private bool _isSelectingDestination = false;
        private PictureBox _currentLocation;
        private PictureBox _destination;

        private double _distanceToDestination = 0;

        public Form1()
        {
            AddMapPanel();
            AddMapDistanceLabel();
            AddLocationsToMap();
            InitializeComponent();          
        }

        private void AddMapPanel()
        {

            this.Map = new System.Windows.Forms.Panel();
            this.Map.BackgroundImage = global::TransportationCostSimulator.Properties.Resources.Daegu;
            this.Map.Location = new System.Drawing.Point(60, 12);
            this.Map.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Map.Name = "Map";
            this.Map.Size = new System.Drawing.Size(848, 591);
            this.Map.TabIndex = 3;
            this.Controls.Add(Map);
        }

        private void AddMapDistanceLabel()
        {

            this.Distance = new System.Windows.Forms.Label();
            this.Distance.AutoSize = true;
            this.Distance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Distance.ForeColor = System.Drawing.Color.Fuchsia;
            this.Distance.Location = new System.Drawing.Point(312, 556);
            this.Distance.Name = "LblDistance";
            this.Distance.Size = new System.Drawing.Size(80, 20);
            this.Distance.TabIndex = 0;
            this.Distance.Text = "Distance";
            this.Distance.Visible = false;

            Map.Controls.Add(this.Distance);

        }


        private void AddLocationsToMap()
        {
            Locations.MapLocations.ForEach(Locale => CreateLocationPicBox(Locale.LocationName, Locale.LocationCoordinates));
        }


        private PictureBox CreateLocationPicBox(string name, Point location)
        {
            var pictureBox = new System.Windows.Forms.PictureBox();

            pictureBox.BackColor = System.Drawing.Color.Transparent;
            pictureBox.BackgroundImage = global::TransportationCostSimulator.Properties.Resources.Location2;
            pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            pictureBox.Location = location;
            pictureBox.Name = name;
            pictureBox.Size = new System.Drawing.Size(37, 37);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox.TabIndex = 3;
            pictureBox.TabStop = false;
            pictureBox.WaitOnLoad = true;
            pictureBox.Anchor = AnchorStyles.Top;
            pictureBox.Click += new System.EventHandler(this.Location_Click);
            pictureBox.Parent = this.Map;
            this.Map.Controls.Add(pictureBox);

            return pictureBox;

        }

        private void Location_Click(object sender, EventArgs e)
        {
            var location = (PictureBox)sender;

            if (_isSelectingCurrentLocation)
            {
                _currentLocation = location;
                txtCurrenLocation.Text = location.Name;
                _isSelectingCurrentLocation = false;
            }
            else if (_isSelectingDestination)
            {
                _destination = location;
                txtDestination.Text = location.Name;
                _isSelectingDestination = false;
                CalculateDistanceToDestination();
            }

            HighLightToggler();
        }

        private void SetCurrentLocation_Click(object sender, EventArgs e)
        {
            _isSelectingCurrentLocation = true;
            HighLightToggler();
        }


        private void HighLightToggler()
        {
            foreach (Control control in this.Map.Controls)
            {
                if (control is PictureBox)
                {
                    if (_isSelectingCurrentLocation || _isSelectingDestination)
                    {
                        control.BackColor = Color.Green;
                    }
                    else
                    {
                        control.BackColor = Color.Transparent;
                    }
                }
     
            }
        }

        private void BtnSetDestination_Click(object sender, EventArgs e)
        {
            _isSelectingDestination = true;
            HighLightToggler();
        }


        private void CalculateDistanceToDestination()
        {
            var x1 = _currentLocation.Location.X;
            var y1 = _currentLocation.Location.Y;
            var x2 = _destination.Location.Y;
            var y2 = _destination.Location.Y;

            //d = sqr( p(x2 − x1)^2 + (y2 − y1)^2 )
            _distanceToDestination = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)); //distance formula from geometry (square root of (x2-x1)^2 + (y2-y1)^2

            //lets scale the distance
            _distanceToDestination = _distanceToDestination / 12;
            
            Distance.Visible = true;
            Distance.BringToFront();
            Distance.Text = $"Distance: {_distanceToDestination.ToString("0.00")} Km";
            this.Refresh();
            CalulateTransportationCosts();
        }



        private void CalulateTransportationCosts()
        {

            var costOfTransportationType = new List<KeyValuePair<string, decimal>>();

            foreach(Transportation transporation in AllTransporation.AvaliableTransporation)
            {
                var cost = transporation.CostPerKm * (decimal)_distanceToDestination;
                costOfTransportationType.Add(new KeyValuePair<string, decimal>(transporation.TransporationType, cost));
            };


            SuggestBestModeOfTransport(costOfTransportationType);
        }



        private void SuggestBestModeOfTransport(List<KeyValuePair<string, decimal>> costOfTransportationType)
        {


            var ordered = costOfTransportationType.OrderBy(x => x.Value);

            foreach (KeyValuePair<string, decimal> item in ordered)
            {
                lstAdvisor.Items.Add($"Cost of using {item.Key} is ${item.Value.ToString("0.00")}.");
            }

            lstAdvisor.SelectedIndex = 0; 
        }


    }
}
