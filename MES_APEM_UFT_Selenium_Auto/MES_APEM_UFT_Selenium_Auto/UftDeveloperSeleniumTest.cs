﻿using HP.LFT.SDK;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using MES_APEM_UFT_Selenium_Auto.Product.APEM;
using System.Windows.Forms;
using System;
using HP.LFT.SDK.StdWin;
using System.Diagnostics;
using MES_APEM_UFT_Selenium_Auto.Library.SeleniumLibrary;
using MES_APEM_UFT_Selenium_Auto.Library.BaseLibrary;
using MES_APEM_UFT_Selenium_Auto.Product.ApemMobile;
using OpenQA.Selenium;
using System.Drawing;
using MES_APEM_UFT_Selenium_Auto.Product.APEM.MOC_TemplatesModule;
using System.IO;
using MES_APEM_UFT_Selenium_Auto.Product.WD;
using System.Collections.Generic;
using MES_APEM_UFT_Selenium_Auto.Product.DataBaseWizard;
using OpenQA.Selenium.Interactions;
using Spire.Pdf;
using System.Text;
using Spire.Pdf.Texts;
using MES_APEM_UFT_Selenium_Auto.Product.APRM;
using MES_APEM_UFT_Selenium_Auto.Product.SQLplus;
using Application = MES_APEM_UFT_Selenium_Auto.Library.BaseLibrary.Application;

namespace MES_APEM_UFT_Selenium_Auto
{
    [TestClass]
    public class UftDeveloperSeleniumTest
    {

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void TestMethod1()
        {
            //SdkConfiguration config = new SdkConfiguration();
            //SDK.Init(config);
            //Thread.Sleep(3000);

            Selenium_Driver driver = new Selenium_Driver(Browser.chrome);
            Web_Fuction.gotoWDWeb(driver);
            driver.Wait();
            Web_Fuction.login();
            driver.Wait();
            // LogStep(@"2. Go and admin and signature");
            Web_Fuction.gotoTab(WDWebTab.admin);
            Web.Administration_Page.Signatures.Click();
            Thread.Sleep(3000);
            Web.Signature_Page.Reset_Cancel_Weighing_signatures[3].FindElement(By.TagName("input")).Click();
            Web.Signature_Page.NewSource_Signatures[3].FindElement(By.TagName("input")).Click();
            Thread.Sleep(3000);
            Web.Signature_Page.Apply.Click();
            Thread.Sleep(3000);
            Web.Signature_Page.Apply_OK.Click();
            Thread.Sleep(5000);
            string signautres_file = "10 aspen wd signautres_32414 bulk load.xml";
            WD_Fuction.Bulkload_Export(signautres_file);
            Web.Signature_Page.Reset_Cancel_Weighing_signatures[1].FindElement(By.TagName("input")).Click();
            Web.Signature_Page.NewSource_Signatures[1].FindElement(By.TagName("input")).Click();
            Thread.Sleep(3000);
            Web.Signature_Page.Apply.Click();
            Thread.Sleep(3000);
            Web.Signature_Page.Apply_OK.Click();
            WD_Fuction.Bulkload(signautres_file);
            driver.Refresh();
            Thread.Sleep(5000);
            
            Assert.IsNotNull(Web.Signature_Page.Reset_Cancel_Weighing_signatures[3].FindElement(By.TagName("input")).GetAttribute("checked"));
            Assert.IsNotNull(Web.Signature_Page.NewSource_Signatures[3].FindElement(By.TagName("input")).GetAttribute("checked"));
        }





    }

}
