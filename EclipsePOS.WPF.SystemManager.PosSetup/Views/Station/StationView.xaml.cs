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

using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Station
{
    /// <summary>
    /// Interaction logic for StationView.xaml
    /// </summary>
    public partial class StationView : UserControl, IStationView
    {
        private StationViewPresenter _presenter;

        public StationView()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(StationView_Loaded);

            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
            
            this.cmbBoxOrganizationID.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationID_SelectionChanged);
            this.cmbBoxStoreNo.DropDownOpened += new EventHandler(cmbBoxStoreNo_DropDownOpened);

            this.txtBoxPosNo.PreviewTextInput += new TextCompositionEventHandler(txtBoxPosNo_PreviewTextInput);   
        }

        void StationView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();

            _presenter.OnShowStation();

            this.cmbBoxOrganizationID.SelectedValue = PosSettings.Default.Organization;
            
        }

        void txtBoxPosNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.AreAllValidNumericChars(e.Text);
        }

        void cmbBoxStoreNo_DropDownOpened(object sender, EventArgs e)
        {
            _presenter.FilterStoreByOrganizationNo(this.cmbBoxOrganizationID.SelectedValue.ToString());
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
  
        }

        void cmbBoxOrganizationID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                this._presenter.FilterStationByOrganizationNo(this.cmbBoxOrganizationID.SelectedValue.ToString());
            }
            catch
            {
                this._presenter.FilterStationByOrganizationNo(PosSettings.Default.Organization);
            }
        }

        public StationView(StationViewPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
           
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        #region Events

        public void OnStationListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

        }


        #endregion

        #region IDepartmentView implementations

        public void SetStationDataContext(object data)
        {
            this.stationListView.DataContext = data;
            this.DataContext = data;
        }



        public void SetSelectedItemCursor()
        {
            stationListView.ScrollIntoView(stationListView.Items.CurrentItem);
            stationListView.SelectedItem = stationListView.Items.CurrentItem;
        }

        public void SetMoveToFirstBtnDataContext(object command)
        {
            this.btnMoveFirst.DataContext = command;
        }

        public void SetMoveToPreviousBtnDataContext(object command)
        {
            this.btnMovePrevious.DataContext = command;
        }

        public void SetMoveToNextBtnDataContext(object command)
        {
            this.btnMoveNext.DataContext = command;
        }

        public void SetMoveToLastBtnDataContext(object command)
        {
            this.btnMoveLast.DataContext = command;
        }


        public void SetDeleteBtnDataContext(object command)
        {
            this.btnDelete.DataContext = command;
        }

        public void SetAddBtnDataContext(object command)
        {
            this.btnAdd.DataContext = command;
        }

        public void SetRevertBtnDataContext(object command)
        {
            this.btnRevert.DataContext = command;
        }

        public void SetSaveBtnDataContext(object command)
        {
            this.btnSave.DataContext = command;
        }

        #endregion


        public void SetOrganizationDataContext(IEnumerable data)
        {
            this.cmbBoxOrganizationID.ItemsSource = data;
        }

        public void SetStoreNoDataContext(IEnumerable data)
        {
            this.cmbBoxStoreNo.ItemsSource = data;
        }

        public string SelectedOrganizationNo()
        {
            string orgID = ""; // PosSettings.Default.Organization;

            try
            {
                orgID = this.cmbBoxOrganizationID.SelectedValue.ToString();
            }
            catch
            {
            }            
            return orgID;
        }


        private bool AreAllValidNumericChars(string str)
        {
            bool ret = true;

            int l = str.Length;
            for (int i = 0; i < l; i++)
            {
                char ch = str[i];
                ret &= Char.IsDigit(ch);
            }

            if (!ret) Commands.Beep(500, 50);
            return ret;
        }

        public void SetFocusToFirstElement()
        {
            this.cmbBoxStoreNo.Focus();
        }

        public void SetColumnsEnabled(bool flag)
        {

            int count = VisualTreeHelper.GetChildrenCount(this.stationGrid);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.stationGrid, i);
                    if (child is TextBox)
                    {
                        ((TextBox)child).IsEnabled = flag;
                    }
                    if (child is ComboBox)
                    {
                        ((ComboBox)child).IsEnabled = flag;
                    }
                }
            }

            


        }


    }
}
