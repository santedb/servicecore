﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Configuration;

namespace MARC.HI.EHRS.SVC.Configuration.UI
{
    public partial class frmApply : Form
    {
        public frmApply(bool config)
        {
            InitializeComponent();
            ShowConfigurationPanels(config);
        }

        /// <summary>
        /// Show configuration panels
        /// </summary>
        private void ShowConfigurationPanels(bool config)
        {
            XmlDocument configDocument = new XmlDocument();
                    configDocument.Load(ConfigurationApplicationContext.s_configFile);
            foreach (var itm in ConfigurationApplicationContext.s_configurationPanels)
                if (itm.EnableConfiguration)
                {
                    if(itm.IsConfigured(configDocument) ^ config &&
                        !itm.AlwaysConfigure)
                        chkActions.Items.Add(itm);
                }
        }

        /// <summary>
        /// Configure features
        /// </summary>
        public static void ConfigureFeatures()
        {
            frmApply apply = new frmApply(true);
            apply.Text = "Configure Features";
            apply.lblDescription.Text = "Select the features that you would like to apply configuration for";
            if (apply.ShowDialog() == DialogResult.OK)
            {
                var progress = new frmProgress();
                int i = 0;

                XmlDocument configDocument = new XmlDocument();
                try
                {
                    // Try to make a backup
                    try
                    {
                        File.Copy(ConfigurationApplicationContext.s_configFile, ConfigurationApplicationContext.s_configFile + ".bak." + DateTime.Now.ToString("yyyy-MMM-dd"));
                    }
                    catch (Exception e)
                    {
                        if (MessageBox.Show("The configuration file could not be backed up, would you like to proceed making modifications without a backup?", "Backup failed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;
                    }

                    progress.Show();
                    configDocument.Load(ConfigurationApplicationContext.s_configFile);

                    EventHandler<ProgressChangedEventArgs> progHandler = (o, e) =>
                    {
                        progress.ActionStatus = e.ProgressPercentage;
                        progress.ActionStatusText = e.UserState.ToString();
                    };

                    foreach (IConfigurableFeature itm in apply.chkActions.CheckedItems)
                    {
                        if (itm is IReportProgressChanged)
                            (itm as IReportProgressChanged).ProgressChanged += progHandler;

                        try
                        {
                            if (!itm.Validate(configDocument))
                            {
                                MessageBox.Show(String.Format("Configuration of item '{0}' failed, validation failed", itm), "Validation Failure");
                                continue;
                            }
                        }
                        catch (ConfigurationException e)
                        {
                            MessageBox.Show(String.Format("Configuration of item '{0}' failed, validation failed with reason {1}", itm, e.Message), "Validation Failure");
                            continue;
                        }
                        progress.OverallStatus = (int)((++i / (float)apply.chkActions.CheckedItems.Count) * 100);
                        progress.OverallStatusText = String.Format("Configuring {0}...", itm.ToString());
                        Application.DoEvents();
                        itm.Configure(configDocument);

                        if (itm is IReportProgressChanged)
                            (itm as IReportProgressChanged).ProgressChanged -= progHandler;

                    }

                    // Always applied stuff changes
                    foreach (var itm in ConfigurationApplicationContext.s_configurationPanels.FindAll(o => o.AlwaysConfigure))
                    {
                        if (!itm.Validate(configDocument))
                        {
                            MessageBox.Show(String.Format("Configuration of item '{0}' failed, validation failed", itm), "Validation Failure");
                            continue;
                        }
                        itm.Configure(configDocument);
                    }
                    configDocument.Save(ConfigurationApplicationContext.s_configFile);
                    progress.OverallStatusText = "Executing post configuration tasks...";
                    ConfigurationApplicationContext.OnConfigurationApplied();
                }
                catch (Exception ex)
                {
#if DEBUG
                    MessageBox.Show(ex.ToString(), "Error Configuring Service");
#else
                    MessageBox.Show(ex.Message, "Error Configuring Service");
#endif
                    foreach (IConfigurableFeature itm in apply.chkActions.CheckedItems)
                    {

                        progress.OverallStatus = (int)((i-- / (float)ConfigurationApplicationContext.s_configurationPanels.Count) * 100);
                        progress.OverallStatusText = String.Format("Removing Configuration for {0}...", itm.ToString());
                        Application.DoEvents();

                        itm.UnConfigure(configDocument);
                    }

                    return;
                }
                finally
                {
                    progress.Close();
                }
            }
        }

        /// <summary>
        /// UnConfigure Features
        /// </summary>
        public static void UnConfigureFeatures()
        {
            frmApply apply = new frmApply(false);
            apply.Text = "UnConfigure Features";
            apply.lblDescription.Text = "Select the features that you would like to remove configuration for";
            
            if (apply.ShowDialog() == DialogResult.OK)
            {
                var progress = new frmProgress();
                try
                {
                    progress.Show();
                    XmlDocument configDocument = new XmlDocument();
                    configDocument.Load(ConfigurationApplicationContext.s_configFile);
                    int i = 0;

                    EventHandler<ProgressChangedEventArgs> progHandler = (o, e) =>
                    {
                        progress.ActionStatus = e.ProgressPercentage;
                        progress.ActionStatusText = e.UserState.ToString();
                    };

                    foreach (IConfigurableFeature itm in apply.chkActions.CheckedItems)
                    {

                        if (itm is IReportProgressChanged)
                            (itm as IReportProgressChanged).ProgressChanged += progHandler;

                        progress.OverallStatus = (int)((++i / (float)apply.chkActions.CheckedItems.Count) * 100);
                        progress.OverallStatusText = String.Format("Removing Configuration for {0}...", itm.ToString());
                        Application.DoEvents();

                        itm.UnConfigure(configDocument);

                        if (itm is IReportProgressChanged)
                            (itm as IReportProgressChanged).ProgressChanged -= progHandler;
                    }
                    configDocument.Save(ConfigurationApplicationContext.s_configFile);
                    progress.OverallStatusText = "Executing post configuration tasks...";
                    Application.DoEvents();
                    ConfigurationApplicationContext.OnConfigurationApplied();

                }
                finally
                {
                    progress.Close();
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmApply_Load(object sender, EventArgs e)
        {

        }
    }
}
