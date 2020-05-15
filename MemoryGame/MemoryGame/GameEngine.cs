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

        private Card _firstFlipped;
        private Card _secondFlipped;
        private int _cardsFlipped;

        private List<KeyValuePair<Image, int>> _imageList = new List<KeyValuePair<Image, int>>();
        private List<Card> _cards = new List<Card>();

        private Form1 _form1;

        public GameEngine(Form1 form1)
        {
            _form1 = form1;

        }

        public void StartGame()
        {
            _imageList.Clear();
            _cards.Clear();

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
                    card.FrontOfCard = MemoryGame.Properties.Resources.bluecardback;
                    _cards.Add(card);
                    i++;
                }
            }
        }


        public void FlipCard(object item)
        {
            var card = (Card)item;

            if (card.IsMatched)
            {
                return;
            }

            _cardsFlipped++;

            if (_cardsFlipped > 3)
            {
                FlipAllCardsBackOver();
            }
            else if (_cardsFlipped == 1)
            {
                _firstFlipped = card;
                card.Image = card.BackOfCard;
                _form1.Refresh();
            }
            else if (_cardsFlipped == 2)
            {
                _secondFlipped = card;
                card.Image = card.BackOfCard;
                _form1.Refresh();
                CheckForMatch();           
            }      
        }


        private void FlipAllCardsBackOver()
        {
            _cardsFlipped = 0;

            foreach (Card card in _cards)
            {
                if (!card.IsMatched)
                {
                    card.Image = card.FrontOfCard;
                }            
            }
        }

        private void CheckForMatch()
        {
            Task.Delay(1000).Wait();  //to show second card for a bit
            if (_cardsFlipped < 3 && _firstFlipped != null && _secondFlipped != null)
            {
                if(_firstFlipped.ImageNumber == _secondFlipped.ImageNumber)
                {
                    _firstFlipped.IsMatched = true;
                    _secondFlipped.IsMatched = true;
                    _cardsFlipped = 0;

                }
                else
                {
                    FlipAllCardsBackOver();
                }
            }
        }


        private List<T> Shuffle<T>(IEnumerable<T> collection)
        {
            Random r = new Random();
            collection = collection.OrderBy(a => r.Next()).ToList();

            return collection.ToList();
        }


    }
}
