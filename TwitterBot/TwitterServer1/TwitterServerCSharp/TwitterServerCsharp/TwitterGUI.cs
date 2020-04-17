using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;



namespace TwitterServerCsharp
{
    public partial class TwitterGUI : Form
    {      

        private TwitterizerWrapper twitterService;
        private bool ServiceStarted = false; //for timer
        private string LatestDirectMessage = "";
        private string LatestDirectMsgSender = "";
        private string LatestDirectMsgID = "";
        private string coins = "";
        private string cash = "";
        private bool CashRequest = false;
        private bool CoinRequest = false;

        public TwitterGUI()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load1(object sender, EventArgs e)
        {
            // twitterService = new TweetSharpService(); //Not using
            twitterService = new TwitterizerWrapper();
        }


        /// <summary>
        /// Private function which starts a new thread and assigns the thread to an infinite loop
        /// </summary>
        private void Start()
        {

            ServiceStarted = true;

            timer1.Interval = 15000;
            timer1.Start();
            timer1.Tick += Timer1_Tick;

            timer2.Interval = 60000;
            timer2.Start();
            timer2.Tick += Timer2_Tick;



            //if (threadStarted == false)
            //{
            //    threadStarted = true;
            //    t = new Thread(NewThreadTask);
            //    try
            //    {
            //        t.Start();
            //        LogToMonitor("2nd thread Started");
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Error starting thread.");
            //    }
            //}
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ServiceStarted)
                {
                    getDirectMessages();
                    LogToMonitor(LatestDirectMsgSender + "  |  " + LatestDirectMessage + "  |  " + LatestDirectMsgID);
                    getCoins();
                    getCashFromCoins();
                    LogToMonitor(cash + "  |  " + coins + "  |  ");
                    UpdateDB();

                }
            }
            catch (Exception ex)
            {
                LogToMonitor(ex.Message);
            }
          
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            TxtServerMonitor.Text = "";
        }


        private void getDirectMessages()
        {
            coins = "";
            cash = "";
            LatestDirectMessage = "";
            LatestDirectMsgID = "";
            LatestDirectMsgSender = "";

          twitterService.GetDirectMessage(); //call to get latest Direct Message
          LatestDirectMessage = twitterService.LatestDirectMessage;
          LatestDirectMsgSender = twitterService.LatestDirectMsgSender;
          LatestDirectMsgID = twitterService.LatestDirectMsgID;
      }


        private void getCoins()  //caLled first
        {
            TwitterServer1.ConvertCoins convertCoins = new TwitterServer1.ConvertCoins();
            double cash =0.0;

            if (Double.TryParse(LatestDirectMessage, out cash))
            {
                CoinRequest = true;         
                coins = convertCoins.ConvertToCoins(cash);
            }
            else
            {
                CashRequest = true;
            }
       }


        private void getCashFromCoins()
        {
            if (CashRequest)
            {
                TwitterServer1.ConvertCoins convertCoins = new TwitterServer1.ConvertCoins();
                cash = (convertCoins.CoinToDollarValue(LatestDirectMessage).ToString());
                coins = LatestDirectMessage;
            }
            if (cash == "-1")
            {
                //could not covert coin string to cash
                CashRequest = false;
            }


        }


        private void UpdateDB()
        {

            TwitterServer1.Connection DBConn = new TwitterServer1.Connection();

            if (DBConn.test() != true)
            {
                MessageBox.Show("error connecting to Database.");
                //return;
                System.Environment.Exit(1);
            }

            try
            {
                Dictionary<string, string> Procedure1parameters = new Dictionary<string, string>();

                string StoredProcedureName1 = "CheckIFMessageIdExists";
                Procedure1parameters.Add("MsgID", LatestDirectMsgID);

                if (int.Parse(DBConn.ExecuteReturnStoredProcedure(StoredProcedureName1, Procedure1parameters)) < 1)
                {
                    try
                    {
                        Dictionary<string, string> parameters = new Dictionary<string, string>();

                        string StoredProcedureName2 = "AddTwitterTransaction";

                        Random rand1 = new Random(DateTime.Now.Minute);
                        Random rand2 = new Random(DateTime.Now.Millisecond);
                        Double generated1 = rand1.NextDouble();
                        Double generated2 = rand2.NextDouble();

                        double result = ((generated1) / (generated2));
                        string recieptNum = result.ToString();

                        parameters.Add("MsgID", LatestDirectMsgID);
                        parameters.Add("MsgText", LatestDirectMessage);
                        parameters.Add("MsgSender", LatestDirectMsgSender);
                        parameters.Add("CashEntered", cash);
                        parameters.Add("CoinsEntered", coins);
                        parameters.Add("recieptNum", recieptNum);

                        DBConn.ExecuteNoReturnStoredProcedure(StoredProcedureName2, parameters);

                        SendMessageResponse();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Running Stored Procedure: 'AddTwitterTransaction'   ||    " + ex.Message);
                        ServiceStarted = false;
                        System.Environment.Exit(1);
                    }

                }
            }     
            catch (Exception e)
            {
                MessageBox.Show("Error Running Stored Procedure: 'CheckIFMessageIdExists'   ||    " + e.Message);
                ServiceStarted = false;
                System.Environment.Exit(1);
            }
          }

       

        private void SendMessageResponse()
        {

            if (CoinRequest)
            {
                twitterService.sendDirectMessage("(" + LatestDirectMessage + ")" + " -> " + coins, LatestDirectMsgSender);
            }

            else if (CashRequest)
            {
                twitterService.sendDirectMessage("(" + LatestDirectMessage + ")" + " -> " + cash, LatestDirectMsgSender);
            }

            else
            {


                AnnoyingAutoResponses response = new AnnoyingAutoResponses();

                twitterService.sendDirectMessage(response.GetResponse(LatestDirectMessage), LatestDirectMsgSender);
            }
            CoinRequest = false;
            CashRequest = false;
        }



        private void LogToMonitor(string LogMessage)
        {
            TxtServerMonitor.Text = TxtServerMonitor.Text + System.Environment.NewLine + LogMessage;
        }



#region "Button Click Events"

        private void btnSendDM_Click(object sender, EventArgs e)
        {
            twitterService.sendDirectMessage(TxtTwitterUser.Text, textBox1.Text);
        }

 
        private void BtnReplyDM_Click(object sender, EventArgs e)
        {
          
        }

        private void btnSendTweet_Click(object sender, EventArgs e)
        {
            twitterService.sendTweet(textBox1.Text);
        }

        private void BtnGetDM_Click(object sender, EventArgs e)
        {
            txtBoxDirectMessages.Text = twitterService.GetDirectMessage();
        }


        private void BtnStartService_Click(object sender, EventArgs e)
        {
            LogToMonitor("Starting Service");
            Start();
        }


        private void BtnStopService_Click(object sender, EventArgs e)
        {
            LogToMonitor("Stopping Service");
            ServiceStarted = false;

            //if (threadStarted == true)
            //{
            //    try
            //    {
            //        t.Abort();
            //        LogToMonitor("2nd thread Stopped");
            //        threadStarted = false;
            //    }
            //    catch
            //    {
            //        MessageBox.Show("Error stopping thread.");
            //    }
            //}
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #endregion


    }
}
