using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
//using System.Windows;


namespace EclipsePOS.WPF.SystemManager.Data.Util
{
    // Decorate the settings class with a SettingsProvider attribute
    // This tells ApplicationSettingsBase to use a non-default provider (e.g. not the 
    // LocalFileSettingsProvider, which targets the .config file)
    [SettingsProvider(typeof(EclipsePOS.WPF.SystemManager.Data.Util.EclipseSettingsProvider))]

    public class PosSettings : ApplicationSettingsBase
    {

        private static PosSettings posSettings;

        public static PosSettings Default
        {
            get
            {
                if (posSettings == null)
                {
                    posSettings = new PosSettings();
                }
                return posSettings;
            }
        }


        [ApplicationScopedSetting]
        [DefaultSettingValue("0")]
        public int Organization
        {
            get { return (int)this["organization"]; }
            set { this["organization"] = value; }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("0")]
        public int Store
        {
            get { return (int)this["store"]; }
            set { this["store"] = value; }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("0")]
        public int Station
        {
            get { return (int)this["station"]; }
            set { this["station"] = value; }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("0")]
        public int Configuration
        {
            get { return (int)this["configuration"]; }
            set { this["configuration"] = value; }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("")]
        public string DataSource
        {
            get { return (string)this["dataSource"]; }
            set { this["dataSource"] = value; }
        }

        [ApplicationScopedSetting]
        [DefaultSettingValue("Data Source=.\\SQLEXPRESS;Initial Catalog=possite;Integrated Security=True")]
        public string possiteConnectionString
        {
            get
            {
                return ((string)(this["possiteConnectionString"]));
            }
            set
            {
                this["possiteConnectionString"] = value;
            }
        }


    }
}
