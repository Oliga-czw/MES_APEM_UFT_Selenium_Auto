﻿using System;
using WD_UFT_Selenium_Auto.Library.BaseLibrary;
using WD_UFT_Selenium_Auto.Library.SeleniumLibrary;
using WD_UFT_Selenium_Auto.Product.WD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace WD_UFT_Selenium_Auto.TestCase
{
    public partial class WD_TestCase
    {
        [TestCaseID(38246)]
        [Title("A message should show when no scale can be selected automatically")]
        [TestCategory(ProductArea.WD)]
        [Priority(CasePriority.Medium)]
        [TestCategory(CaseState.Started)]
        [TestCategory(AutomationTool.UFT_Selenium)]
        [Owner(AutomationEngineer.Ziru)]
        [Timeout(600000)]

        [TestMethod]
        public void VSTS_38246()
        {
            string Resultpath = Base_Directory.ResultsDir + CaseID;
            LogStep(@"1. Open Wd client and login");
            Application.LaunchWDAndLogin();
            Thread.Sleep(5000);
            LogStep(@"2. click into Material_Dispensing");
            WD.mainWindow.HomeInternalFrame.MaterialDispensing.Click();
            LogStep(@"3. select the material");
            WD.mainWindow.Material_SelectionInternalFrame.materialTable.Row("X0125").Click();
            var Required_value = WD.mainWindow.Material_SelectionInternalFrame.materialTable._UFT_Table.GetCell(0, "Clean Required").Value;

            WD.mainWindow.Material_SelectionInternalFrame.next.Click();
            if (Required_value.ToString() == "Yes")
            {
                WD.mainWindow.BoothCleanInternalFrame.cleanComplete.Click();
            }
            LogStep(@"3. enter the Barcode");
            WD.mainWindow.ScaleWeightInternalFrame.barcode._UFT_Editor.SetText("test\n");
            var message = WD.MessageDialog.Lable.Text;
            //System.IO.File.WriteAllText("C:/Users/qaone1/Desktop/eee.txt", message);
            Base_Assert.AreEqual(message, "Container barcode is not recognized. Scan another container.");
            WD.mainWindow.GetSnapshot(Resultpath + "POPMessage.PNG");

        }

    }
}