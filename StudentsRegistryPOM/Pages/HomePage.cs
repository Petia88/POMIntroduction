﻿using OpenQA.Selenium;

namespace StudentsRegistryPOM.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/";

        public IWebElement ElementStudentsCount => driver.FindElement(By.CssSelector("body > p > b"));

        public int StudentsCount()
        {
            string studentsCountString = this.ElementStudentsCount.Text;
            return int.Parse(studentsCountString);
        }

    }
}