using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    class Card : PictureBox
    {

        public int ImageNumber { get; set; }

        public bool IsMatched { get; set; }

        public bool IsFlippedOver { get; set; }

        public Image FrontOfCard { get; set; }

        public Image BackOfCard { get; set; }

    }
}
