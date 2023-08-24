﻿using HP.LFT.SDK;
using HP.LFT.SDK.StdWin;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MES_APEM_UFT_Selenium_Auto.Library.BaseLibrary;
using MES_APEM_UFT_Selenium_Auto.Product.DataBaseWizard;
using MES_APEM_UFT_Selenium_Auto.Product.APEM;
using MES_APEM_UFT_Selenium_Auto.Product.APRM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MES_APEM_UFT_Selenium_Auto.Library.BaseLibrary
{
    class mMDM_Fuction
    {
        public static void GML_Configure_mMDM_Admin_1()
        {
            Application.LaunchmMDMAdmin();
            mMDM.AdminWizardWindow.Next.Click();
            //select DB
            mMDM.AdminWizardWindow.DirectDbConn.Click();
            mMDM.AdminWizardWindow.Next.Click();
            mMDM.AdminWizardWindow.Finish.Click();
            //Wait mMDM Administrator Wizard re-pops up.
            //select DB server
            mMDM.AdminWizardWindow.SQLServer.Click();
            mMDM.AdminWizardWindow.ServerName.SendKeys(Environment.MachineName);
            mMDM.AdminWizardWindow.Next.Click();
            //set username,password and test
            mMDM.AdminWizardWindow.UserName.SetText(DBInfo.Info["username"]);
            mMDM.AdminWizardWindow.Password.SetSecure(DBInfo.Info["password"]);
            mMDM.AdminWizardWindow.Test.Click();
            //check success
            string message = mMDM.SuccessDialog.Message.Text;
            Assert.AreEqual("Successful!", message);
            mMDM.SuccessDialog.OK.Click();
            //input DB name
            mMDM.AdminWizardWindow.DBName.SendKeys("ODM");
            if (mMDM.AdminWizardWindow.EmptyDatabase.IsEnabled)
            {
                mMDM.AdminWizardWindow.EmptyDatabase.Click();
                mMDM.AdminWizardWindow.Create.Click();
            }
            mMDM.AdminWizardWindow.Next.Click();
            mMDM.AdminWizardWindow.Next.Click();
            //finish
            mMDM.AdminWizardWindow.Finish.Click();
            //check sucess
            Assert.IsTrue(mMDM.mMDMAdminWindow.CreatingDatabaseWindow.Exists(3000));
            mMDM.mMDMAdminWindow.CreatingDatabaseWindow.Close();
            mMDM.mMDMAdminWindow.Close();
        }

        public static void GML_Configure_mMDM_BulkLoad()
        {
            //change file to add BPCWebAdmin
            Base_File.CopyFile(Base_Directory.MachineAliasConfig, Base_Directory.mMDMWorkSpace, true);
            Application.LaunchmMDMBulkLoad();
            mMDM.BulkLoadWizardWindow.ImportDataFromOneOrMoreBulkLoadFiles.Click();
            mMDM.BulkLoadWizardWindow.Next.Click();
            //select WorkSpace
            mMDM.BulkLoadWizardWindow.Select.Click();
            mMDM.AspenWorkSpaceWindow.Advanced.Click();
            mMDM.AspenWorkSpaceWindow.ConnectToASpecificWorkspace.Click();
            mMDM.AspenWorkSpaceWindow.WorkspaceComboBox.Select("BPCWebAdmin");
            mMDM.AspenWorkSpaceWindow.OK.Click();
            mMDM.BulkLoadWizardWindow.Next.Click();
            mMDM.BulkLoadWizardWindow.Finish.Click();
            //Wait Bulk Load Import Wizard pops up
            Assert.IsTrue(mMDM.BulkLoadImportWizardWindow.IsExist(10));
            mMDM.BulkLoadImportWizardWindow.Next.Click();
            mMDM.BulkLoadImportWizardWindow.Add.Click();
            //import mMDM UGM GML backup.xml
            mMDM.OpenFileDialog.FileName.SendKeys(Base_Directory.GMLBackup);
            mMDM.OpenFileDialog.Open.Click();
            mMDM.BulkLoadImportWizardWindow.Next.Click();
            mMDM.BulkLoadImportWizardWindow.Next.Click();
            mMDM.BulkLoadImportWizardWindow.Finish.Click();
            //import Import Times dialog pops up
            Assert.IsTrue(mMDM.ImportTimesDialog.IsExist(5));
            mMDM.ImportTimesDialog.Yes.Click();
            //Change View dialog?not pop up
            //save bulk load
            mMDM.BulkLoadaAfterImportWindow.SetActive();
            //wait for finish
            for (int i = 0; i < 5; i++)
                {
                if (mMDM.BulkLoadaAfterImportWindow.SaveButton.IsEnabled)
                {
                    break;
                }
                else
                {
                    Thread.Sleep(2000);
                }
            }
            mMDM.BulkLoadaAfterImportWindow.SaveButton.Click();
            Thread.Sleep(2000);
            mMDM.BulkLoadaAfterImportWindow.Close();
        }

        public static void GML_Configure_mMDM_Editor()
        {
            Application.LaunchmMDMEditor();
        }
    }
}
