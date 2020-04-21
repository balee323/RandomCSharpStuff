using StockInfoGrabber.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockGrabberNonAsync
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.progressBar1.Increment(10);

            AlphaVantageAPIClient client = new AlphaVantageAPIClient();

            var data = client.GetLatestStockData(textBox1.Text);
            this.progressBar1.Increment(30);


            this.progressBar1.Increment(10);
            PopulateListBox(data);
            this.progressBar1.Value = 100;
        }


        private void PopulateListBox(Tuple<TodayStockValue, StockMeta> data)
        {
            listBox1.Items.Add("Stock Symbol: " + data.Item2.Symbol);
            listBox1.Items.Add("Stock Details: " + data.Item2.Information);
            listBox1.Items.Add("data last refreshed on: " + data.Item2.LastRefreshed);
            this.progressBar1.Increment(10);
            listBox1.Items.Add("Today's opening value: " + data.Item1.Open);
            listBox1.Items.Add("Today's high: " + data.Item1.High);
            listBox1.Items.Add("Today's low: " + data.Item1.Low);
            this.progressBar1.Increment(10);
            listBox1.Items.Add("Volume: " + data.Item1.Volume);
        }

    }
}
