﻿using HP.LFT.SDK;
using HP.LFT.SDK.WinForms;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using MES_APEM_UFT_Selenium_Auto.Library.BaseLibrary;
using MES_APEM_UFT_Selenium_Auto.Product.WD;
using IWindow = HP.LFT.SDK.StdWin.IWindow;
using Application = MES_APEM_UFT_Selenium_Auto.Library.BaseLibrary.Application;
using MES_APEM_UFT_Selenium_Auto.Product.APEM;
using System.Diagnostics;
using MES_APEM_UFT_Selenium_Auto.Product.DataBaseWizard;
using HP.LFT.SDK.Java;

namespace MES_APEM_UFT_Selenium_Auto
{
    [TestClass]
    public class UftDeveloperSeleniumTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void TestMethod1()
        {
            SdkConfiguration config = new SdkConfiguration();
            SDK.Init(config);
            Thread.Sleep(3000);
            //Application.LaunchMocAndLogin();
            //Thread.Sleep(5000);
            //APEM.MocmainWindow.RPLDesign.ClickSignle();
            //APEM.MocmainWindow.RPLDesignInternalFrame.AddRPL_Button.ClickSignle();
            //Thread.Sleep(4000);
            //APEM.MocmainWindow.RPLManagementInternalFrame.RPLName.SendKeys("testRpl");
            //APEM.MocmainWindow.RPLManagementInternalFrame.RPLDescription.SendKeys("for testhahhah");
            //APEM.MocmainWindow.RPLManagementInternalFrame.ConfirmChanges_Button.ClickSignle();
            //if (APEM.MocmainWindow.AddReasonDialog.IsExist())
            //{
            //    APEM.MocmainWindow.AddReasonDialog.Reason.SendKeys("for UFT test");
            //    APEM.MocmainWindow.AddReasonDialog.OK.Click();
            //}
            //Thread.Sleep(4000);
            //APEM.MocmainWindow.RPLManagementInternalFrame.RPLTabControl.Select("Basic Phase Libraries");
            //Thread.Sleep(3000);
            //APEM.MocmainWindow.RPLManagementInternalFrame.SelectBPL_Button.ClickSignle();
            //Thread.Sleep(5000);
            //APEM.MocmainWindow.AvailableBPLDialog.AvailableBPLList.SelectItems("AAA_BPL (Version 1)");
            //APEM.MocmainWindow.AvailableBPLDialog.OK.Click();
            //Thread.Sleep(3000);
            //APEM.MocmainWindow.RPLManagementInternalFrame.RPLTabControl.Select("RPL Data");
            //Thread.Sleep(3000);
            //APEM.MocmainWindow.RPLManagementInternalFrame.LoadDesigner_Button.ClickSignle();
            //Thread.Sleep(3000);
            //// UP
            APEM.PFCEditorWindow.UnitProcedure._UFT_CheckBox.Click();
            Thread.Sleep(8000);
            Mouse.Click(APEM.PFCEditorWindow.PFCDesignAppInternalFrame.ControlLinkUiObject._UFT_UiObject.AbsoluteLocation);
            Thread.Sleep(3000);
            MOC_Fuction.AssertDesignWindow();
            //copy
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.UnitProcedureUiObject.Click();
            APEM.PFCEditorWindow.CopyButton.ClickSignle();
            if (APEM.LoseCopiedDialog.IsExist(3000))
            {
                APEM.LoseCopiedDialog.YesButton.Click();
            }
            Thread.Sleep(5000);
            //paste

            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.FirstLink.Click();
            APEM.PFCEditorWindow.PasteButton.ClickSignle();
            if (APEM.PFCEditorWindow.PasteRenamedDialog.IsExist(3000))
            {
                APEM.PFCEditorWindow.PasteRenamedDialog.Close();
            }
            MOC_Fuction.AssertDesignWindow();
            //drag to other location
            var UnitProcedure1 = APEM.PFCEditorWindow.PFCDesignAppInternalFrame.UnitProcedureUiObject1;
            UnitProcedure1.Click();
            Mouse.DragAndDrop(UnitProcedure1.AbsoluteLocation, APEM.PFCEditorWindow.PFCDesignAppInternalFrame.FirstLink.AbsoluteLocation, MouseButton.Left);
            MOC_Fuction.AssertDesignWindow();
            //cut
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.UnitProcedureUiObject1.Click();
            APEM.PFCEditorWindow.CutButton.ClickSignle();
            Thread.Sleep(5000);
            APEM.CutElementDialog.YesButton.Click();
            MOC_Fuction.AssertDesignWindow();
            //delete
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.FirstLink.Click();
            APEM.PFCEditorWindow.PasteButton.ClickSignle();
            if (APEM.PFCEditorWindow.PasteRenamedDialog.IsExist(3000))
            {
                APEM.PFCEditorWindow.PasteRenamedDialog.Close();
            }
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.UnitProcedureUiObject1.Click();
            APEM.PFCEditorWindow._UFT_Window.SendKeys(HP.LFT.SDK.Keys.Delete);
            Thread.Sleep(5000);
            MOC_Fuction.AssertDesignWindow();
            ////APEM.PFCEditorWindow.Parallel._UFT_CheckBox.Click();
            ////Thread.Sleep(5000);
            ////Mouse.Click(APEM.PFCEditorWindow.PFCDesignAppInternalFrame.FirstLink.AbsoluteLocation);
            ////Thread.Sleep(3000);
            ////APEM.PFCEditorWindow.UnitProcedure._UFT_CheckBox.Click();
            ////Thread.Sleep(5000);
            ////Mouse.Click(APEM.PFCEditorWindow.PFCDesignAppInternalFrame.LinkUiObject.AbsoluteLocation);
            ////Thread.Sleep(3000);
            ////APEM.PFCEditorWindow.UnitProcedure._UFT_CheckBox.Click();
            ////Thread.Sleep(5000);
            ////Mouse.Click(APEM.PFCEditorWindow.PFCDesignAppInternalFrame.ParallelDivergentUiObject._UFT_UiObject.AbsoluteLocation);
            ////Thread.Sleep(3000);
            ////MOC_Fuction.AssertDesignWindow();
            //OP
            APEM.PFCEditorWindow.UnitProcedure._UFT_CheckBox.Click();
            Thread.Sleep(5000);
            Mouse.Click(APEM.PFCEditorWindow.PFCDesignAppInternalFrame.ControlLinkUiObject._UFT_UiObject.AbsoluteLocation);
            Thread.Sleep(3000);
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.UnitProcedureUiObject.DoubleClick();
            Thread.Sleep(8000);
            APEM.PFCEditorWindow.Operation._UFT_CheckBox.Click();
            Thread.Sleep(8000);
            Mouse.Click(APEM.PFCEditorWindow.PFCDesignAppInternalFrame.ControlLinkUiObject._UFT_UiObject.AbsoluteLocation);
            Thread.Sleep(3000);
            MOC_Fuction.AssertDesignWindow();
            //copy
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.OperationUiObject.Click();
            APEM.PFCEditorWindow.CopyButton.ClickSignle();
            if (APEM.LoseCopiedDialog.IsExist(3000))
            {
                APEM.LoseCopiedDialog.YesButton.Click();
            }
            Thread.Sleep(5000);
            //paste

            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.FirstLink.Click();
            APEM.PFCEditorWindow.PasteButton.ClickSignle();
            if (APEM.PFCEditorWindow.PasteRenamedDialog.IsExist(3000))
            {
                APEM.PFCEditorWindow.PasteRenamedDialog.Close();
            }
            MOC_Fuction.AssertDesignWindow();
            //drag to other location
            var Operation1 = APEM.PFCEditorWindow.PFCDesignAppInternalFrame.OperationUiObject1;
            Operation1.Click();
            Mouse.DragAndDrop(Operation1.AbsoluteLocation, APEM.PFCEditorWindow.PFCDesignAppInternalFrame.FirstLink.AbsoluteLocation, MouseButton.Left);
            MOC_Fuction.AssertDesignWindow();
            //cut
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.OperationUiObject1.Click();
            APEM.PFCEditorWindow.CutButton.ClickSignle();
            Thread.Sleep(5000);
            APEM.CutElementDialog.YesButton.Click();
            MOC_Fuction.AssertDesignWindow();
            //delete
            Thread.Sleep(5000);
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.OperationUiObject.Click();
            APEM.PFCEditorWindow._UFT_Window.SendKeys(HP.LFT.SDK.Keys.Delete);
            Thread.Sleep(5000);
            MOC_Fuction.AssertDesignWindow();
            //Phase
            APEM.PFCEditorWindow.Operation._UFT_CheckBox.Click();
            Thread.Sleep(8000);
            Mouse.Click(APEM.PFCEditorWindow.PFCDesignAppInternalFrame.ControlLinkUiObject._UFT_UiObject.AbsoluteLocation);
            Thread.Sleep(3000);
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.OperationUiObject.DoubleClick();
            Thread.Sleep(5000);
            APEM.PFCEditorWindow.TabbedPaneControl.Select(2);
            Thread.Sleep(2000);
            APEM.PFCEditorWindow.First_Phase.Click();
            Thread.Sleep(8000);
            Mouse.Click(APEM.PFCEditorWindow.PFCDesignAppInternalFrame.ControlLinkUiObject._UFT_UiObject.AbsoluteLocation);
            Thread.Sleep(3000);
            MOC_Fuction.AssertDesignWindow();
            //copy
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.PhaseUiObject.Click();
            APEM.PFCEditorWindow.CopyButton.ClickSignle();
            if (APEM.LoseCopiedDialog.IsExist(3000))
            {
                APEM.LoseCopiedDialog.YesButton.Click();
            }
            Thread.Sleep(5000);
            //paste

            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.FirstLink.Click();
            APEM.PFCEditorWindow.PasteButton.ClickSignle();
            if (APEM.PFCEditorWindow.PasteRenamedDialog.IsExist(3000))
            {
                APEM.PFCEditorWindow.PasteRenamedDialog.Close();
            }
            MOC_Fuction.AssertDesignWindow();
            //drag to other location
            var phaphase1 = APEM.PFCEditorWindow.PFCDesignAppInternalFrame.PhaseUiObject1;
            phaphase1.Click();
            Mouse.DragAndDrop(phaphase1.AbsoluteLocation, APEM.PFCEditorWindow.PFCDesignAppInternalFrame.FirstLink.AbsoluteLocation, MouseButton.Left);
            MOC_Fuction.AssertDesignWindow();
            //cut
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.PhaseUiObject1.Click();
            APEM.PFCEditorWindow.CutButton.ClickSignle();
            Thread.Sleep(5000);
            APEM.CutElementDialog.YesButton.Click();
            MOC_Fuction.AssertDesignWindow();
            //delete
            Thread.Sleep(5000);
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.PhaseUiObject.Click();
            APEM.PFCEditorWindow._UFT_Window.SendKeys(HP.LFT.SDK.Keys.Delete);
            Thread.Sleep(5000);
            MOC_Fuction.AssertDesignWindow();
            //Import the attached RPL and check its design structure at three levels in the PFC editor
            APEM.PFCEditorWindow.BackButton.ClickSignle();
            Thread.Sleep(2000);
            APEM.PFCEditorWindow.BackButton.ClickSignle();
            Thread.Sleep(2000);
            MOC_Fuction.ImportRPLDesign("RPL_DERMS_PACK_01_02.CHK");
            MOC_Fuction.AssertDesignWindow();
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.UnitProcedureUiObject1.DoubleClick();
            Thread.Sleep(4000);
            MOC_Fuction.AssertDesignWindow();
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame.OperationUiObject1.DoubleClick();
            Thread.Sleep(4000);
            MOC_Fuction.AssertDesignWindow();
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame._UFT_InterFrame.Resize(325, 790);
            Thread.Sleep(4000);
            MOC_Fuction.AssertDesignWindow();
            APEM.PFCEditorWindow.PFCDesignAppInternalFrame._UFT_InterFrame.Resize(1104, 852);
            Thread.Sleep(4000);
            MOC_Fuction.AssertDesignWindow();







        }



        [TestCleanup]
        public void TestCleanup()
        {
            
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }
        public string CaseID = "prepareInitial";
    }
}
        