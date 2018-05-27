using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;

namespace FaceBot.Business
{
    class FacebookBusiness
    {

        public List<String> getListUsers()
        {
            List<String> list = new List<string>();

            list.Add("Mariana Macena");
            list.Add("Samantha Cortez");
            list.Add("Silas Pascoal Dos Santos");
            list.Add("Bruna Rodrigues");
            list.Add("Victor Osés");
            list.Add("Kevin Meeira");
            list.Add("Juliana Costa Melo");
            list.Add("Viviane Suelen");
            
            return list;
        }

        public void LoginAndRedirectPostFacebook() {
            List<String> friends;
            

            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--start-maximized");

            using (var driver = new FirefoxDriver(options)) {
                try
                {
                    driver.Manage().Window.Maximize();
                    
                    //Realizando Login
                    driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["facebookLogin"]);
                    driver.FindElementByCssSelector("input#email").SendKeys(ConfigurationManager.AppSettings["login"]);
                    driver.FindElementByCssSelector("input#pass").SendKeys(ConfigurationManager.AppSettings["senha"]);
                    driver.FindElementByCssSelector("button#loginbutton").Click();

                    //Pressiona botão ESC
                    Actions action = new Actions(driver);
                    action.SendKeys(Keys.Escape).Build().Perform();
                    
                    driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["facebookPost"]);

                    friends = getListUsers();

                    while (true)
                    {
                        foreach (var friend in friends)
                        {
                            //Comenta nome dos amigos no facebook
                            Thread.Sleep(3500);
                            CommentUsersInPost(driver, friend);
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public void CommentUsersInPost(FirefoxDriver driver, string friend)
        {
            bool isExist = true;

            while (isExist)
            {
                try
                {
                    driver.FindElementByCssSelector("textarea#composerInput").Click();
                    isExist = false;
                }
                catch (Exception)
                {
                    isExist = true;
                }
            }

            Thread.Sleep(1500);
            driver.FindElements(By.CssSelector("[class*='cp dy dz']")).First().Click();
            Thread.Sleep(1500);
            driver.FindElement(By.CssSelector("[class*='bp bq br bs']")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.CssSelector("[class*='bn bo bp']")).SendKeys(friend);
            Thread.Sleep(1500);
            driver.FindElement(By.CssSelector("[class*='bb bc bd bq br']")).Click();
            Thread.Sleep(1500);
            var checkBoxConfirmFriend = driver.FindElement(By.CssSelector("[class*='n']"));
            checkBoxConfirmFriend.FindElements(By.XPath("//input[@type='checkbox']")).First().Click();
            Thread.Sleep(1500);
            driver.FindElement(By.CssSelector("[class*='bb bc bd cb br']")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.CssSelector("[class*='be bf bg']")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.CssSelector("[class*='be bf bg']")).SendKeys(".");
            Thread.Sleep(1500);
            driver.FindElement(By.CssSelector("[class*='bm bd bv bw bx']")).Click();
        }
    }
}
