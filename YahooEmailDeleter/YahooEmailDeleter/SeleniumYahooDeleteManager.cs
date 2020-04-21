using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Forms = System.Windows.Forms;

namespace YahooEmailDeleter
{
    class SeleniumYahooDeleteManager
    {

        private string _userName;
        private string _password;
        private IWebDriver _driver;
        private Action<string> _showMessage;
        private CancellationToken _cancellationToken;


        public SeleniumYahooDeleteManager(string userName, string password, Action<string> showMessage, CancellationToken cancellationToken)
        {
            this._userName = userName;
            this._password = password;
            this._showMessage = showMessage;
            this._cancellationToken = cancellationToken;

           
        }


        public void StartProcess()
        {
            var task = Task.Run(
                new Action(() => { 
                    OpenBrowser();
                    GoToWebsite();
                    Login();
                }).Invoke,
                _cancellationToken
                );
        }


        public void ContinueProcess()
        {
            var task = Task.Run(
                new Action(() => {
                    GoToEmail();
                    DeleteEmails();
                    //CloseDriver();
                }).Invoke
                );
        }


        private void OpenBrowser()
        {
            _driver = new ChromeDriver();
        }


        private void GoToWebsite()
        {
            _driver.Navigate().GoToUrl("https://login.yahoo.com/");
        }

        private void Login()
        {

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            if (!_cancellationToken.IsCancellationRequested)
            {
                //enter login
                var loginBox = _driver.FindElement(By.Id("login-username"));
                loginBox.SendKeys(_userName);
                Task.Delay(2000).Wait();
                loginBox.SendKeys(Keys.Enter);
            }
            else
            {
                CloseDriver();
            }


            if (!_cancellationToken.IsCancellationRequested)
            {
                Task.Delay(2000).Wait();

                //enter password
                var passwordBox = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-passwd")));
                passwordBox.SendKeys(_password);
                Task.Delay(2000).Wait();
                passwordBox.SendKeys(Keys.Enter);
            }
            else
            {
                CloseDriver();
            }
 
            if (!_cancellationToken.IsCancellationRequested)
            {

                Task.Delay(2000).Wait();
                var byEmail = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#challenge-selector-challenge > form > ul > li:nth-child(2) > button")));
                Task.Delay(500).Wait();
                byEmail.SendKeys(Keys.Enter);

                Task.Delay(500).Wait();

                _showMessage("please enter your 2-factor code.");
               
            }
            else
            {
                CloseDriver();
            }
            
        }



        private void GoToEmail()
        {

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            var emailNav = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#header-nav-bar > li:nth-child(1) > a")));
            Task.Delay(500).Wait();
            emailNav.SendKeys(Keys.Enter);
            Task.Delay(500).Wait();            
        }

        private void DeleteEmails()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        


            while (!_cancellationToken.IsCancellationRequested)
            {
                try
                {
                    var selectAll = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#selectAllButton > button")));
                    selectAll.SendKeys(Keys.Enter);
                    Task.Delay(1000).Wait();
                    var deleteBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#msgListForm > table > tbody > tr:nth-child(1) > td > div > table > tbody > tr > td:nth-child(2) > div > span.J_x.D_X.M_3Y3Gk.P_3LQ7g > button.b_n.D_X.A_6EqO.u_e69.H_6LEV.i_6LEV.o_h.P_Z2guAVt.G_e.V_M.C4_Z2aVTcY.q_Z25N1By.q4_ZB0RNU.Q_eo6")));
                    deleteBtn.SendKeys(Keys.Enter);
                    Task.Delay(2000).Wait();
                }
                catch (Exception e)
                {
                    ; //poop.. it will be ok!  It's just deleting your valuable emails :)
                    _driver.Navigate().Refresh();
                }
  

            }

            CloseDriver();
            _showMessage("process cancelled");
        }

        private void CloseDriver()
        {
            _driver.Quit();
            _driver.Dispose();
          
        }
    }

}
