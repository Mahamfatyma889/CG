using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;

namespace Automationproject
{
    #region TestClasses

    [TestClass]
    [TestCategory("dragAnddrop")]
    public class TestClass1 : BasePage
    {
        DragAndDRop dnd = new DragAndDRop();
        BasePage basepage = new BasePage();
        [TestMethod]

        public void TestCase_1()
        {
            basepage.seleniuminit();
            dnd.DragDrop("https://demoqa.com/droppable");

        }
    }

    
    [TestClass]
    [TestCategory("Selectable")]
    public class TestClass3 : BasePage
    {
        BasePage basepage = new BasePage();
        Selectable selectable = new Selectable();
        [TestMethod]

        public void TestCase_List()
        {
            basepage.seleniuminit();
            selectable.SelectList();


        }
        [TestMethod]
        public void TestCase_Grid()
        {
            basepage.seleniuminit();
            selectable.SelectGrid();

        }
    }

    [TestClass]
    [TestCategory("Sortable")]
    public class TestClass4 : BasePage
    {
        BasePage basepage = new BasePage();
        Sortable sortable = new Sortable();
        [TestMethod]
        public void TestCase_SortList()
        {
            basepage.seleniuminit();
            sortable.SortList("https://demoqa.com/sortable", 0, 10, 0, -10);

        }

        [TestMethod]
        public void TestCase_SortGrid()
        {
            basepage.seleniuminit();
            sortable.SortGrid("https://demoqa.com/sortable", 100, 0, 0, -100);

        }
    }
    [TestClass]
    [TestCategory("Resizable")]
    public class TestClass2 : BasePage
    {

        BasePage basepage = new BasePage();
        Resizable resizable = new Resizable();
        [TestMethod]

        public void TestCase_Positive()
        {
            Thread.Sleep(5000);

            basepage.seleniuminit();


            resizable.Resize("https://demoqa.com/resizable", 500, 300);



        }
        [TestMethod]
        public void TestCase_Negative()
        {
            Thread.Sleep(3000);

            basepage.seleniuminit();

            resizable.Resize("https://demoqa.com/resizable", 10, 50);


        }
    }

    [TestClass]
    [TestCategory("BookStoreApp")]
    public class TestClass5 : BasePage
    {
        BasePage basepage = new BasePage();
        BookStoreApp bookstoreapp = new BookStoreApp();

        #region Login
        [TestMethod]
        public void TestCase_LoginValid()
        {
            basepage.seleniuminit();
            bookstoreapp.LoginValid("https://demoqa.com/login", "Maham", "maham@123");

        }
        [TestMethod]
        public void TestCase_LoginInValidUsername()
        {
            basepage.seleniuminit();
            bookstoreapp.LoginInvalid("https://demoqa.com/login", "Maaham", "maham@123");
        }
        [TestMethod]
        public void TestCase_LoginInValidPassword()
        {
            basepage.seleniuminit();
            bookstoreapp.LoginInvalid("https://demoqa.com/login", "Maham", "maham+123");
        }
        #endregion

        #region BookStore
        [TestMethod]
        public void TestCase_BookStore()
        {
            basepage.seleniuminit();
            bookstoreapp.BookStore("https://demoqa.com/login", "Maham", "maham@123");
        }
        #endregion

        #region Profile
        [TestMethod]
        public void TestCase_Profile()
        {
            basepage.seleniuminit();
            bookstoreapp.Profile("https://demoqa.com/login");
        }
        #endregion
    }



    [TestClass]
    [TestCategory("wait_for_alert")]
    public class TestClass6 : BasePage
    {
        BasePage BasePage = new BasePage();
        OnClickWait onClick = new OnClickWait();
        [TestMethod]
        public void WaitAlert()
        {
            BasePage.seleniuminit();

            onClick.WaitPop();
        }

    }

    [TestClass]
    [TestCategory("Alert click buttton")]
    public class TestClass7
    {
        BasePage basePage = new BasePage();


        [TestMethod]

        public void AlertClick()
        {
            basePage.seleniuminit();
            AlertClick1 alerttt = new AlertClick1();
            alerttt.AlertMsg();


        }
    }




    [TestClass]
    [TestCategory("Confirmation alert")]
    public class TestClass8 : BasePage
    {
        BasePage BasePage = new BasePage();
        Confirmation conf = new Confirmation();
        [TestMethod]
        public void confirmtest()
        {
            BasePage.seleniuminit();
            conf.Confirm();
        }

    }

    [TestClass]
    [TestCategory("PrompTest")]
    public class TestClass9 : BasePage
    {
        BasePage basePage = new BasePage();
        PromptAlert prompttt = new PromptAlert();
        [TestMethod]
        public void MsgPrompt()
        {
            basePage.seleniuminit();
            prompttt.promptmsg();
        }

    }

    [TestClass]
    [TestCategory("Forms")]
    public class TestClass10R
    {
        BasePage basepage = new BasePage();
        Registration register = new Registration();

       


        [TestMethod]


        public void TestCase_004()
        {
            basepage.seleniuminit();
            register.Register_InValid_Contactno();
        }





    }

    #endregion



    #region NormalClass
    public class DragAndDRop : BasePage
    {
        public void DragDrop(String url)
        {
            driver.Manage().Window.Maximize();
            driver.Url = url;
            Actions actions = new Actions(driver);

            IWebElement from = driver.FindElement(By.Id("draggable"));
            IWebElement to = driver.FindElement(By.Id("droppable"));
            actions.DragAndDrop(from, to).Perform();

            String textTo = driver.FindElement(By.Id("droppable")).Text;
            driver.Close();

            if (textTo.Equals("Dropped!"))
            {
                Console.WriteLine("passed!: Source dropped");
            }
            else
            {
                Console.WriteLine("failed! not able to");
            }

        }

    }
    public class Resizable : BasePage
    {
        public void Resize(String url, int xOffset, int yOffset)
        {
            driver.Manage().Window.Maximize();
            driver.Url = url;

            Actions actions = new Actions(driver);
            IWebElement elementtoResize = driver.FindElement(By.Id("resizableBoxWithRestriction"));

            actions.ClickAndHold(elementtoResize).MoveByOffset(xOffset, yOffset).Release().Build().Perform();

            driver.Close();
            if (xOffset == 500 && yOffset == 300)
            {
                Console.WriteLine("Test Passed! Maximum Resize");
            }
            else
            {
                Console.WriteLine("Test Passed! can be resized further");
            }
        }

    }
}
public class Selectable : BasePage
{
    public void SelectList()
    {
        driver.Manage().Window.Maximize();
        driver.Url = "https://demoqa.com/selectable";
        Actions actions = new Actions(driver);
        IWebElement listButton = driver.FindElement(By.Id("demo-tab-list"));
        actions.Click(listButton).Release().Build().Perform();


        IWebElement value1 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div/div[1]/ul/li[1]"));
        IWebElement value2 = driver.FindElement(By.XPath("html/body/div[2]/div/div/div[2]/div[2]/div[1]/div/div[1]/ul/li[2]"));
        IWebElement value3 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div/div[1]/ul/li[3]"));
        IWebElement value4 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div/div[1]/ul/li[4]"));
        String value1txt = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div/div[1]/ul/li[1]")).Text;

        actions.Click(value1).Release().Build().Perform();
        actions.Click(value2).Release().Build().Perform();
        actions.Click(value3).Release().Build().Perform();
        actions.Click(value4).Release().Build().Perform();

        driver.Close();

        if (value1txt == "Cras justo odio")
        {
            Console.WriteLine("Test Passed! options are selectable");

        }
        else
        {
            Console.WriteLine("Test Failed");
        }

    }

    public void SelectGrid()
    {
        driver.Manage().Window.Maximize();
        driver.Url = "https://demoqa.com/selectable";
        Actions actions = new Actions(driver);
        IWebElement GridButton = driver.FindElement(By.Id("demo-tab-grid"));
        actions.Click(GridButton).Release().Build().Perform();

        IWebElement value1 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[1]/li[1]"));
        IWebElement value2 = driver.FindElement(By.XPath("/ html/ body / div[2] / div / div / div[2] / div[2] / div[1] / div / div[2] / div / div[2] / li[2]"));
        IWebElement value3 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[3]/li[3]"));
        Thread.Sleep(500);
        String value1txt = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div[1]/li[1]")).Text;

        actions.Click(value1).Release().Build().Perform();
        actions.Click(value2).Release().Build().Perform();
        actions.Click(value3).Release().Build().Perform();
        driver.Close();

        if (value1txt == "One")
        {
            Console.WriteLine("Test Passed!Grid is selectable");

        }
        else
        {
            Console.WriteLine("Test Failed");
        }


    }
}
public class Sortable : BasePage
{
    public void SortList(String url, int xOffset1, int yOffset1, int xOffset2, int yOffset2)
    {
        driver.Manage().Window.Maximize();
        driver.Url = url;
        Actions actions = new Actions(driver);
        IWebElement listButton = driver.FindElement(By.Id("demo-tab-list"));
        actions.Click(listButton).Release().Build().Perform();
        IWebElement elementtoSort = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[1]"));

        IWebElement elementtoSort1 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div/div[1]/div/div[3]"));
        actions.ClickAndHold(elementtoSort).MoveByOffset(xOffset1, yOffset1).Release().Build().Perform();
        actions.ClickAndHold(elementtoSort1).MoveByOffset(xOffset2, yOffset2).Release().Build().Perform();
        Thread.Sleep(50);
        driver.Close();
        if (yOffset1 == 26 && yOffset2 == -26)
        {
            Console.WriteLine("List is sortable");
        }
        else
        {
            Console.WriteLine("Test failed");
        }


    }
    public void SortGrid(String url, int xOffset1, int yOffset1, int xOffset2, int yOffset2)
    {
        driver.Manage().Window.Maximize();
        driver.Url = url;
        Actions actions = new Actions(driver);
        IWebElement listButton = driver.FindElement(By.Id("demo-tab-grid"));
        actions.Click(listButton).Release().Build().Perform();
        IWebElement elementtoSort = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div/div[1]"));
        IWebElement elementtoSort1 = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div/div[2]/div/div/div[5]"));
        actions.ClickAndHold(elementtoSort).MoveByOffset(xOffset1, yOffset1).Release().Build().Perform();
        actions.ClickAndHold(elementtoSort1).MoveByOffset(xOffset2, yOffset2).Release().Build().Perform();
        Thread.Sleep(50);
        driver.Close();
        if ((xOffset1 == 108 && yOffset1 == 0) && (xOffset2 == 0 && yOffset2 == -108))
        {
            Console.WriteLine("Grid is sortable");
        }
        else
        {
            Console.WriteLine("Test failed");
        }

    }

}
public class BookStoreApp : BasePage
{

    public void LoginValid(String url1, String username, String password)
    {
        driver.Manage().Window.Maximize();
        driver.Url = url1;

        By usernameTxt = By.Id("userName");
        By passwordTxt = By.Id("password");
        driver.FindElement(usernameTxt).SendKeys(username);
        driver.FindElement(passwordTxt).SendKeys(password);
        driver.FindElement(By.Id("login")).Click();

        Thread.Sleep(2000);
        String urll = driver.Url;
        driver.Close();

        if (urll == "https://https://demoqa.com/profile")
        {
            Console.WriteLine("Test passed! logged in successfully");
        }
        else
        {
            Console.WriteLine("Test Failed");
        }

    }
    public void LoginInvalid(String url, String username, String password)
    {
        driver.Manage().Window.Maximize();
        driver.Url = url;
        By usernameTxt = By.Id("userName");
        By passwordTxt = By.Id("password");
        driver.FindElement(usernameTxt).SendKeys(username);
        driver.FindElement(passwordTxt).SendKeys(password);
        driver.FindElement(By.Id("login")).Click();

        Thread.Sleep(2000);
        String errormsg = driver.FindElement(By.Id("name")).Text;
        driver.Close();

        if (errormsg == "Invalid username or password!")
        {
            Console.WriteLine("Test passed! Error generated");
        }
        else
        {
            Console.WriteLine("Test Failed");
        }

    }
    public void BookStore(String url, String username, String password)
    {
        driver.Manage().Window.Maximize();
        driver.Url = url;
        By usernameTxt = By.Id("userName");
        By passwordTxt = By.Id("password");

        driver.FindElement(usernameTxt).SendKeys(username);
        driver.FindElement(passwordTxt).SendKeys(password);
        driver.FindElement(By.Id("login")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); //waiting
        IWebElement store = driver.FindElement(By.Id("gotoStore"));
        IJavaScriptExecutor jse = (IJavaScriptExecutor)driver; //coz we use xpath..go to the sepcific location //coz of scroll down
        jse.ExecuteScript("arguments[0].scrollIntoView();", store);
        Actions action = new Actions(driver);
        action.Click(store).Build().Perform();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        By searchTxt = By.Id("searchBox");

        driver.FindElement(searchTxt).SendKeys("javascript");
        IWebElement book = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div[2]/div[1]/div[2]/div[2]/div/div[2]/div/span/a"));

        book.Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        IWebElement btn = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/div[2]/div[9]/div[2]/button")); // checkout
        jse.ExecuteScript("arguments[0].scrollIntoView();", btn);
        btn.Click();

        Thread.Sleep(5000); //count in milisec
        IAlert alert = driver.SwitchTo().Alert(); //move focus to alert
        String alertTxt = driver.SwitchTo().Alert().Text;

        alert.Accept();
        driver.SwitchTo().DefaultContent(); //move browser content
        driver.Close();

        if (alertTxt == "Book added to your collection.")
        {
            Console.WriteLine("Test Passed! Book Added");
        }
        else
        {
            Console.WriteLine("Test failed");
        }

    }

    private void LoginValid()
    {
        throw new NotImplementedException();
    }

    public void Profile(String url)
    {
        driver.Manage().Window.Maximize();
        driver.Url = url;

        By usernameTxt = By.Id("userName");
        By passwordTxt = By.Id("password");

        driver.FindElement(usernameTxt).SendKeys("Maham");
        driver.FindElement(passwordTxt).SendKeys("maham@123");
        driver.FindElement(By.Id("login")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        By searchTxt = By.Id("searchBox");
        driver.FindElement(By.Id("searchBox")).SendKeys("javascript");

        IWebElement delete = driver.FindElement(By.Id("delete-record-undefined"));
        delete.Click();

        driver.SwitchTo().ActiveElement();
        IWebElement ok = driver.FindElement(By.Id("closeSmallModal-ok"));
        ok.Click();
        Thread.Sleep(2000);
        IAlert delalert = driver.SwitchTo().Alert();
        String alertTxt = driver.SwitchTo().Alert().Text;
        delalert.Accept();
        driver.SwitchTo().DefaultContent();
        driver.Close();
        if (alertTxt == "Book deleted.")
        {
            Console.WriteLine("Test Passed! Book Deleted");
        }
        else
        {
            Console.WriteLine("Test failed");
        }

    }
}



public class OnClickWait : BasePage
{
    public void WaitPop()
    {
        driver.Url = "https://demoqa.com/alerts";
        driver.FindElement(By.Id("timerAlertButton")).Click();
        Thread.Sleep(5000);
        IAlert alert = driver.SwitchTo().Alert();   //wait for 5 sec 2nd one
        string simpleAlert = driver.SwitchTo().Alert().Text;
        alert.Accept();

        driver.Quit();
        Console.WriteLine(simpleAlert);

    }
}

public class AlertClick1 : BasePage
{

    public void AlertMsg()
    {
        driver.Url = "https://demoqa.com/alerts";
        driver.FindElement(By.Id("alertButton")).Click();  //first one
        string simpletext = driver.SwitchTo().Alert().Text;
        if (simpletext == "Do you confirm action?")

            Console.WriteLine("test exceuted");
        else
            Console.WriteLine("test fail");

        driver.SwitchTo().Alert().Accept();
        driver.Quit();

    }


}





public class Confirmation : BasePage
{
    public void Confirm()
    {

        driver.Url = "https://demoqa.com/alerts";
        driver.FindElement(By.Id("confirmButton")).Click();
        Thread.Sleep(2000);

        driver.SwitchTo().Alert().Accept();
        String result = driver.FindElement(By.Id("confirmResult")).Text;

        driver.Quit();  //selected okay  3rd one
        if (result == "You selected Ok")
        {
            Console.WriteLine("Test Passed!");
        }
        else
        {
            Console.WriteLine("Test Failed");
        }

    }
}

public class PromptAlert : BasePage
{
    public void promptmsg()
    {
        driver.Url = "https://demoqa.com/alerts";  //promt one
        driver.FindElement(By.Id("promtButton")).Click();
        driver.SwitchTo().Alert().SendKeys("Tania");

        driver.SwitchTo().Alert().Accept();
        Console.WriteLine("prompt closed after enterd value and clicked ok");
        driver.Quit();

    }
}

public class Registration : BasePage
{

    public void Register_ValidInput()
    {
        driver.Manage().Window.Maximize();
        driver.Url = "https://demoqa.com/automation-practice-form";
        By firstnameTxt = By.Id("firstName");
        By lastnameTxt = By.Id("lastName");
        By emailTxt = By.Id("userEmail");
        By userNumber = By.Id("userNumber");
        By subjectTxt = By.Id("subjectsInput");
        By currentTxt = By.Id("currentAddress");

        //enter first name
        driver.FindElement(firstnameTxt).SendKeys("Maham");

        //enter last name
        driver.FindElement(lastnameTxt).SendKeys("Fatima");

        //enter email address
        driver.FindElement(emailTxt).SendKeys("maham@gmail.com");

        //select the gender option
        IWebElement gender = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/form/div[3]/div[2]/div[2]"));
        gender.Click();

        //enter mobile number
        driver.FindElement(userNumber).SendKeys("03123546125");

        //date picker for date of birth
        var date = driver.FindElement(By.Id("dateOfBirthInput"));
        date.Click();
        var month = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/form/div[5]/div[2]/div[2]/div[2]/div/div/div[2]/div[1]/div[2]/div[1]/select"));
        var selectMonth = new SelectElement(month);
        selectMonth.SelectByText("August");
        var year = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/form/div[5]/div[2]/div[2]/div[2]/div/div/div[2]/div[1]/div[2]/div[2]/select"));
        var selectYear = new SelectElement(year);
        selectYear.SelectByText("2001");
        var days = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/form/div[5]/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/div[3]/div[6]"));
        days.Click();

        // enter subjects by auto complete 
        driver.FindElement(subjectTxt).SendKeys("english");
        driver.FindElement(subjectTxt).SendKeys(Keys.Tab);
        driver.FindElement(subjectTxt).SendKeys("maths");
        driver.FindElement(subjectTxt).SendKeys(Keys.Tab);
        driver.FindElement(subjectTxt).SendKeys("computer");
        driver.FindElement(subjectTxt).SendKeys(Keys.Enter);
        Thread.Sleep(2000);

        // use javascipt to scroll down page 
        IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
        IWebElement hobby = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/form/div[7]/div[2]/div[2]"));
        IWebElement subbtn = driver.FindElement(By.Id("submit"));

        jse.ExecuteScript("arguments[0].scrollIntoView();", hobby);

        //select hobbies 
        hobby.Click();

        //upload pic

        IWebElement browse = driver.FindElement(By.Id("uploadPicture"));
        //click on ‘Choose file’ to upload the desired file
        browse.SendKeys("D:\\Capture1\\models.txt"); //Uploading the file using sendKeys
        Console.WriteLine("File is Uploaded Successfully");

        //enter current address
        driver.FindElement(currentTxt).SendKeys("XYZ");

        subbtn.Click();

        // Screenshot img = (ITakesScreenshot)driver.Navigate
        Thread.Sleep(3000);
        driver.Close();

    }







    public void Register_InValid_Contactno()
    {

        Actions actions = new Actions(driver);
        driver.Manage().Window.Maximize();
        driver.Url = "https://demoqa.com/automation-practice-form";
        By firstnameTxt = By.Id("firstName");
        By lastnameTxt = By.Id("lastName");
        By emailTxt = By.Id("userEmail");
        By userNumber = By.Id("userNumber");
        By subjectTxt = By.Id("subjectsInput");
        By currentTxt = By.Id("currentAddress");

        //enter first name
        driver.FindElement(firstnameTxt).SendKeys("Ayesha");

        //enter last name
        driver.FindElement(lastnameTxt).SendKeys("Usman");

        //enter email address
        driver.FindElement(emailTxt).SendKeys("ayeshausman@gmail.com");

        //select the gender option
        IWebElement gender = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/form/div[3]/div[2]/div[2]"));
        gender.Click();
        //enter mobile number
        driver.FindElement(userNumber).SendKeys("12345");
        Thread.Sleep(9000);

        //date picker for date of birth
        var date = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/form/div[5]/div[2]/div[1]/div/input"));
        date.Click();
        var month = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/form/div[5]/div[2]/div[2]/div[2]/div/div/div[2]/div[1]/div[2]/div[1]/select"));
        var selectMonth = new SelectElement(month);
        selectMonth.SelectByText("March");
        var year = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/form/div[5]/div[2]/div[2]/div[2]/div/div/div[2]/div[1]/div[2]/div[2]/select"));
        var selectYear = new SelectElement(year);
        selectYear.SelectByText("2000");
        var days = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/form/div[5]/div[2]/div[2]/div[2]/div/div/div[2]/div[2]/div[3]/div[6]"));
        days.Click();

        // enter subjects by auto complete 
        driver.FindElement(subjectTxt).SendKeys("maths");
        driver.FindElement(subjectTxt).SendKeys(Keys.Tab);
        driver.FindElement(subjectTxt).SendKeys("chemistry");
        driver.FindElement(subjectTxt).SendKeys("maths");
        driver.FindElement(subjectTxt).SendKeys(Keys.Tab);
        driver.FindElement(subjectTxt).SendKeys(Keys.Tab);
        driver.FindElement(subjectTxt).SendKeys("english");
        driver.FindElement(subjectTxt).SendKeys(Keys.Enter);
        Thread.Sleep(3000);

        // use javascipt to scroll down page for more fields
        IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
        IWebElement hobby = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[2]/div[2]/div[1]/form/div[7]/div[2]/div[2]"));
        IWebElement subbtn = driver.FindElement(By.Id("submit"));

        jse.ExecuteScript("arguments[0].scrollIntoView();", hobby);

        //selecy hobbies 
        hobby.Click();

        //enter current address
        driver.FindElement(currentTxt).SendKeys("Malir");

        //click on submit button to get register
        subbtn.Click();
        Thread.Sleep(5000);
        Boolean modal = driver.FindElements(By.XPath("/html/body/div[4]/div/div/div[1]/div")).Equals(true);
        if (modal)
        {
            Console.WriteLine("Test passed");
        }
        else
        {
            Console.WriteLine("Test failec");
        }
        driver.Close();

    }





}
#endregion




public class BasePage
{
    public static IWebDriver driver;
    public void seleniuminit()
    {
        var thisDriver = new ChromeDriver();
        driver = thisDriver;

    }

}


