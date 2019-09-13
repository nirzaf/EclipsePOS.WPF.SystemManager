using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;

using EclipsePOS.WPF.SystemManager.PosSetup.Util;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.StartupSetting
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl, ISettings
    {
        private SettingsViewPresenter _presenter;
        //private PosSettings posSettings;

        public SettingsView()
        {
            InitializeComponent();

             
            
        }

        void cmbBoxStoreNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _presenter.FilterAll(cmbBoxOrganizationID.SelectedValue.ToString(), cmbBoxStoreNo.SelectedValue.ToString() );
         
            }
            catch (Exception e1)
            {
               // Microsoft.Windows.Controls.MessageBox.Show(e1.ToString(), "Error",  MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void cmbBoxOrganizationID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _presenter.FilterAll(cmbBoxOrganizationID.SelectedValue.ToString(), cmbBoxStationNo.SelectedValue.ToString() );
            }
            catch (Exception e2)
            {
               // Microsoft.Windows.Controls.MessageBox.Show(e2.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
     
            }

        }

        public SettingsView(SettingsViewPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

           // this._presenter.OnShowSettings();

            this.Loaded += new RoutedEventHandler(SettingsView_Loaded);
            
            
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

            this.cmbBoxOrganizationID.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationID_SelectionChanged);
            this.cmbBoxStoreNo.SelectionChanged += new SelectionChangedEventHandler(cmbBoxStoreNo_SelectionChanged);

            
            this.cmbBoxConfigNo.SelectedValue = PosSettings.Default.Configuration;
            if (PosSettings.Default.PrintReceiptImmediate)
            {
                this.cmbBoxPrintReceiptOptions.SelectedValue = "true";
            }
            else
            {
                this.cmbBoxPrintReceiptOptions.SelectedValue = "false";
            }
            if (PosSettings.Default.Debug)
            {
                this.cmdBoxDebugMode.SelectedValue = "true";
            }
            else
            {
                this.cmdBoxDebugMode.SelectedValue = "false";
            }
            
           
        }
                

        void SettingsView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();

                 
          
        }


        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
            // this.Flter();
        }



        public void SaveSettings()
        {
            try
            {
                // Properties.Settings.Default.Organization =  int.Parse(this.cmbBoxOrganizationID.SelectedValue.ToString());
                PosSettings.Default.Organization = this.cmbBoxOrganizationID.SelectedValue.ToString();
                PosSettings.Default.Store = this.cmbBoxStoreNo.SelectedValue.ToString();
                PosSettings.Default.Station = int.Parse(this.cmbBoxStationNo.SelectedValue.ToString());
                PosSettings.Default.Configuration = int.Parse(this.cmbBoxConfigNo.SelectedValue.ToString());
                PosSettings.Default.PrintReceiptImmediate = bool.Parse(this.cmbBoxPrintReceiptOptions.SelectedValue.ToString());
                PosSettings.Default.Debug = bool.Parse(this.cmdBoxDebugMode.SelectedValue.ToString());
            }
            catch
            {
            }
            PosSettings.Default.Save();
        }
       

        public void SetOrganizationDataContext(IEnumerable data)
        {
            this.cmbBoxOrganizationID.ItemsSource = data;
        }

        public void SetStoreDataContext(IEnumerable data)
        {
            this.cmbBoxStoreNo.ItemsSource = data;
        }

        public void SetStationDataContext(IEnumerable data)
        {
            this.cmbBoxStationNo.ItemsSource = data;
        }

        public void SetPosConfigDataContext(IEnumerable data)
        {
            this.cmbBoxConfigNo.ItemsSource = data;
        }

        public void SetSaveBtnDataContext(object command)
        {
           this.btnSave.DataContext = command;
        }


        public string Organization
        {
            get
            {
                try
                {
                    return this.cmbBoxOrganizationID.SelectedValue.ToString();
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    this.cmbBoxOrganizationID.SelectedValue = value;
                }
                catch
                {
                }
            }
        }


        public string Store
        {
            get
            {
                try
                {
                    return this.cmbBoxStoreNo.SelectedValue.ToString();
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                try
                {
                    this.cmbBoxStoreNo.SelectedValue = value;
                }
                catch
                {
                }
            }
        }

        public int Station
        {
            get
            {
                try
                {
                    return int.Parse( this.cmbBoxStationNo.SelectedValue.ToString());
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                try
                {
                    this.cmbBoxStationNo.SelectedValue = value.ToString();
                }
                catch
                {
                }
            }
        }



    }
}
