using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterServerCsharp
{
    class AnnoyingAutoResponses
    {


       public string GetResponse(string inputResponse)
        {
            string outputResponse = "";
        
            if (inputResponse.ToUpper().Contains("HI") || inputResponse.ToUpper().Contains("HELLO") || inputResponse.ToUpper().Contains("HEY") || inputResponse.ToUpper().Contains("WHAT'S UP"))
            {
                outputResponse = getHelloResponses(inputResponse);
            }


            else
            {
                outputResponse = getRandomResponses(inputResponse);
            }


            return outputResponse;
        }


        private string getHelloResponses(string HelloInput)
        {

            string HelloResponse = "";

   

            Random randAnswer = new Random();
            int num = randAnswer.Next(5);
            if (num == 0)
            {
                HelloResponse = ("Well Hello there!");
            }
            if (num == 1)
            {
                HelloResponse = ("I always like talking to you!");
            }
            if (num == 2)
            {
                HelloResponse = ("You again!  Don't you have work to do?");
            }
            if (num == 3)
            {
                HelloResponse = ("What's up!");
            }
            if (num == 4)
            {
                HelloResponse = ("My Friend, what is on your mind!");
            }



            return HelloResponse;
        }


        private string getRandomResponses(string HelloInput)
        {

            string RandomResponse = "";

            Random randAnswer = new Random();
            int num = randAnswer.Next(7);
            if (num == 0)
            {
                RandomResponse = ("Well aren't we having fun!");
            }
            if (num == 1)
            {
                RandomResponse = ("Do you eat veggies?");
            }
            if (num == 2)
            {
                RandomResponse = ("Dirty socks really smell!");
            }
            if (num == 3)
            {
                RandomResponse = ("Don't Smoke!");
            }
            if (num == 4)
            {
                RandomResponse = ("Redrum in reverse is murder!");
            }

            if (num == 5)
            {
                RandomResponse = ("These messages are not recorded, so don't worry.  This stays between us.  I promise");
            }

            if (num == 6)
            {
                RandomResponse = ("You can tell me anything!");
            }
          

            return RandomResponse;
        }












    }
}
