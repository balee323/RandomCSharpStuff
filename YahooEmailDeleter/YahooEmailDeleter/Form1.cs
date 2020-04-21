using System;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Forms;


namespace YahooEmailDeleter
{
    public partial class Form1 : Form
    {
        private SeleniumYahooDeleteManager _seleniumYahooDeleteManager;

        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private CancellationToken _cancellationToken;

        public Form1()
        {
            InitializeComponent();
            _cancellationToken = _tokenSource.Token;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _tokenSource = new CancellationTokenSource();
            _cancellationToken = _tokenSource.Token;
     
            var userName = txtUserName.Text;
            var password = txtPassword.Text;

            Action<string> showMessage = ShowMessage;

            if (string.IsNullOrWhiteSpace(userName)
                || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("User name and/or password box can't be blank.");
                return;
            }
            else
            {
                busySpinner.Visible = true;

                _seleniumYahooDeleteManager = new SeleniumYahooDeleteManager(userName: userName, password: password, showMessage, _cancellationToken);
                _seleniumYahooDeleteManager.StartProcess();
            }
            
        }


        private void ShowMessage(string message)
        {

            this.BeginInvoke((MethodInvoker)delegate ()
            {
                this.Activate();
                lblMessage.Text = message + lblMessage.Text;
                MessageBox.Show(message);
            });
    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            busySpinner.Visible = false;
            _tokenSource.Cancel(); //cancel operation
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _seleniumYahooDeleteManager.ContinueProcess();
        }
    }
}
