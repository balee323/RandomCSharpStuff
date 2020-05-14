using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGame
{
    class GameEngine
    {

        private Form1 _form1;

        public GameEngine(Form1 form1)
        {
            _form1 = form1;

        }

        public void StartGame()
        {
            _imageList.Add(new KeyValuePair<Image, int>(MemoryGame.Properties.Resources._1, 1));
            _imageList.Add(new KeyValuePair<Image, int>(MemoryGame.Properties.Resources._1, 1));
            _imageList.Add(new KeyValuePair<Image, int>(MemoryGame.Properties.Resources._2, 2));
            _imageList.Add(new KeyValuePair<Image, int>(MemoryGame.Properties.Resources._2, 2));
            _imageList.Add(new KeyValuePair<Image, int>(MemoryGame.Properties.Resources._3, 3));
            _imageList.Add(new KeyValuePair<Image, int>(MemoryGame.Properties.Resources._3, 3));
            _imageList.Add(new KeyValuePair<Image, int>(MemoryGame.Properties.Resources._4, 4));
            _imageList.Add(new KeyValuePair<Image, int>(MemoryGame.Properties.Resources._4, 4));
            _imageList.Add(new KeyValuePair<Image, int>(MemoryGame.Properties.Resources._5, 5));
            _imageList.Add(new KeyValuePair<Image, int>(MemoryGame.Properties.Resources._5, 5));
            _imageList.Add(new KeyValuePair<Image, int>(MemoryGame.Properties.Resources._6, 6));
            _imageList.Add(new KeyValuePair<Image, int>(MemoryGame.Properties.Resources._6, 6));

            _imageList = Shuffle(_imageList);

            int i = 0;
            foreach (Control item in _form1.Controls)
            {
                if (item is PictureBox)
                {
                    var card = (Card)item;
                    card.BackOfCard = _imageList[i].Key;
                    card.ImageNumber = _imageList[i].Value;
                    i++;
                }
            }
        }


        private List<KeyValuePair<Image, int>> _imageList = new List<KeyValuePair<Image, int>>();

        public List<T> Shuffle<T>(IEnumerable<T> collection)
        {
            Random r = new Random();
            collection = collection.OrderBy(a => r.Next()).ToList();

            return collection.ToList();
        }



    }
}
