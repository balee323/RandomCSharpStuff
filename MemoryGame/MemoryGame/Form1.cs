using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private List<Image> _imageList = new List<Image>();



        private void Form1_Load(object sender, EventArgs e)
        {

            _imageList.Add(MemoryGame.Properties.Resources._1);
            _imageList.Add(MemoryGame.Properties.Resources._1);
            _imageList.Add(MemoryGame.Properties.Resources._2);
            _imageList.Add(MemoryGame.Properties.Resources._2);
            _imageList.Add(MemoryGame.Properties.Resources._3);
            _imageList.Add(MemoryGame.Properties.Resources._3);
            _imageList.Add(MemoryGame.Properties.Resources._4);
            _imageList.Add(MemoryGame.Properties.Resources._4);
            _imageList.Add(MemoryGame.Properties.Resources._5);
            _imageList.Add(MemoryGame.Properties.Resources._5);
            _imageList.Add(MemoryGame.Properties.Resources._6);
            _imageList.Add(MemoryGame.Properties.Resources._6);



            foreach (Control item in this.Controls)
            {
                if (item is PictureBox)
                {
                    var card = (Card)item;
                    card.BackOfCard = _imageList[1];
                }
                

            }


        }

        private void FlipCard(object item)
        {
            var card = (Card)item;
            card.Image = card.BackOfCard;

        }


        private void card1_Click(object sender, EventArgs e)
        { 
            FlipCard(sender);
        }

        private void card2_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
        }

        private void card3_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
        }

        private void card4_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
        }

        private void card5_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
        }

        private void card6_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
        }

        private void card7_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
        }

        private void card8_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
        }

        private void card9_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
        }

        private void card10_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
        }

        private void card11_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
        }

        private void card12_Click(object sender, EventArgs e)
        {
            FlipCard(sender);
        }
    }
}
