﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

#nullable enable

namespace HardenWindowsSecurity
{
    public partial class GUIProtectWinSecurity
    {
        // During offline mode, this is the path that the button for MicrosoftSecurityBaselineZipPath assigns
        public static string MicrosoftSecurityBaselineZipPath = string.Empty;

        // During offline mode, this is the path that the button for Microsoft365AppsSecurityBaselineZipPath assigns
        public static string Microsoft365AppsSecurityBaselineZipPath = string.Empty;

        // During offline mode, this is the path that the button for LGPOZipPath assigns
        public static string LGPOZipPath = string.Empty;

        // List of all the selected categories in a thread safe way
        public static ConcurrentQueue<string> SelectedCategories = new ConcurrentQueue<string>();

        // List of all the selected subcategories in a thread safe way
        public static ConcurrentQueue<string> SelectedSubCategories = new ConcurrentQueue<string>();

        // Set a flag indicating that the required files for the Offline operation mode have been processed
        // When the execute button was clicked, so it won't run twice
        public static bool StartFileDownloadHasRun = false;

        // View for the ProtectWindowsSecurity
        public static System.Windows.Controls.UserControl? View;

        public static System.Windows.Controls.Grid? parentGrid;
        public static System.Windows.Controls.Primitives.ToggleButton? mainTabControlToggle;
        public static System.Windows.Controls.ContentControl? mainContentControl;
        public static System.Windows.Style? mainContentControlStyle;

        // Defining the correlation between Categories and which Sub-Categories they activate
        public static System.Collections.Hashtable correlation = new System.Collections.Hashtable(StringComparer.OrdinalIgnoreCase)
            {
                { "MicrosoftSecurityBaselines", new string[] { "SecBaselines_NoOverrides" } },
                { "MicrosoftDefender", new string[] { "MSFTDefender_SAC", "MSFTDefender_NoDiagData", "MSFTDefender_NoScheduledTask", "MSFTDefender_BetaChannels" } },
                { "LockScreen", new string[] { "LockScreen_CtrlAltDel", "LockScreen_NoLastSignedIn" } },
                { "UserAccountControl", new string[] { "UAC_NoFastSwitching", "UAC_OnlyElevateSigned" } },
                { "CountryIPBlocking", new string[] { "CountryIPBlocking_OFAC" } },
                { "DownloadsDefenseMeasures", new string[] { "DangerousScriptHostsBlocking" } },
                { "NonAdminCommands", new string[] { "ClipboardSync" } }
            };

        public static System.Windows.Controls.ListView? categories;
        public static System.Windows.Controls.ListView? subCategories;
        public static System.Windows.Controls.CheckBox? selectAllCategories;
        public static System.Windows.Controls.CheckBox? selectAllSubCategories;

        // fields for Log related elements
        public static System.Windows.Controls.TextBox? txtFilePath;
        public static System.Windows.Controls.Button? logPath;
        public static System.Windows.Controls.Primitives.ToggleButton? log;
        public static System.Windows.Controls.Primitives.ToggleButton? EventLogging;

        // fields for Offline-Mode related elements
        public static System.Windows.Controls.Grid? grid2;
        public static System.Windows.Controls.Primitives.ToggleButton? enableOfflineMode;
        public static System.Windows.Controls.Button? microsoftSecurityBaselineZipButton;
        public static System.Windows.Controls.TextBox? microsoftSecurityBaselineZipTextBox;
        public static System.Windows.Controls.Button? microsoft365AppsSecurityBaselineZipButton;
        public static System.Windows.Controls.TextBox? microsoft365AppsSecurityBaselineZipTextBox;
        public static System.Windows.Controls.Button? lgpoZipButton;
        public static System.Windows.Controls.TextBox? lgpoZipTextBox;

        // Execute button variables
        public static System.Windows.Controls.Primitives.ToggleButton? ExecuteButton;
        public static System.Windows.Controls.Grid? ExecuteButtonGrid;
        public static System.Windows.Controls.Image? ExecuteButtonImage;


        // Flag to run the event for view load only once to prevent file download multiple times when switching between views etc.
        public static bool LoadEventHasBeenTriggered = false;

        public static System.Windows.Controls.ComboBox? ProtectionPresetComboBox;

        public static string? SelectedProtectionPreset;

        // Defining the presets configurations for the protection
        public static System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, List<string>>> PresetsIntel = new System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, List<string>>>(StringComparer.OrdinalIgnoreCase)
{
    {
        "preset: basic", new System.Collections.Generic.Dictionary<string, List<string>>
        {
            { "Categories", new List<string> { "MicrosoftSecurityBaselines", "Microsoft365AppsSecurityBaselines", "MicrosoftDefender", "OptionalWindowsFeatures" } },
            { "SubCategories", new List<string> {} }
        }
    },
    {
        "preset: recommended", new System.Collections.Generic.Dictionary<string, List<string>>
        {
            { "Categories", new List<string> { "MicrosoftSecurityBaselines", "Microsoft365AppsSecurityBaselines", "MicrosoftDefender", "AttackSurfaceReductionRules", "BitLockerSettings", "TLSSecurity", "LockScreen", "UserAccountControl", "WindowsFirewall", "OptionalWindowsFeatures", "WindowsNetworking", "MiscellaneousConfigurations", "WindowsUpdateConfigurations", "EdgeBrowserConfigurations", "DownloadsDefenseMeasures", "NonAdminCommands" } },
            { "SubCategories", new List<string> { "DangerousScriptHostsBlocking" } }
        }
    },
    {
       "preset: complete", new System.Collections.Generic.Dictionary<string, List<string>>
        {
            { "Categories", new List<string> { "MicrosoftSecurityBaselines", "Microsoft365AppsSecurityBaselines", "MicrosoftDefender", "AttackSurfaceReductionRules", "BitLockerSettings", "TLSSecurity", "LockScreen", "UserAccountControl", "WindowsFirewall", "OptionalWindowsFeatures", "WindowsNetworking", "MiscellaneousConfigurations", "WindowsUpdateConfigurations", "EdgeBrowserConfigurations", "CountryIPBlocking", "DownloadsDefenseMeasures", "NonAdminCommands" } },
            { "SubCategories", new List<string> { "MSFTDefender_SAC", "UAC_OnlyElevateSigned", "CountryIPBlocking_OFAC", "DangerousScriptHostsBlocking" } }
        }
    }
};

    }
}

