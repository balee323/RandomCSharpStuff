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

       private GameEngine _gameEngine;

    
        private void Form1_Load(object sender, EventArgs e)
        {

            _gameEngine = new GameEngine(this);
            _gameEngine.StartGame();
         
        }

    


        private void card1_Click(object sender, EventArgs e)
        {
            _gameEngine.FlipCard(sender);

        }

        private void card2_Click(object sender, EventArgs e)
        {
            _gameEngine.FlipCard(sender);

        }

        private void card3_Click(object sender, EventArgs e)
        {
            _gameEngine.FlipCard(sender);

        }

        private void card4_Click(object sender, EventArgs e)
        {
            _gameEngine.FlipCard(sender);

        }

        private void card5_Click(object sender, EventArgs e)
        {
            _gameEngine.FlipCard(sender);

        }

        private void card6_Click(object sender, EventArgs e)
        {
            _gameEngine.FlipCard(sender);

        }

        private void card7_Click(object sender, EventArgs e)
        {
            _gameEngine.FlipCard(sender);

        }

        private void card8_Click(object sender, EventArgs e)
        {
            _gameEngine.FlipCard(sender);

        }

        private void card9_Click(object sender, EventArgs e)
        {
            _gameEngine.FlipCard(sender);

        }

        private void card10_Click(object sender, EventArgs e)
        {
            _gameEngine.FlipCard(sender);

        }

        private void card11_Click(object sender, EventArgs e)
        {
            _gameEngine.FlipCard(sender);

        }

        private void card12_Click(object sender, EventArgs e)
        {
            _gameEngine.FlipCard(sender);

        }
    }
}
