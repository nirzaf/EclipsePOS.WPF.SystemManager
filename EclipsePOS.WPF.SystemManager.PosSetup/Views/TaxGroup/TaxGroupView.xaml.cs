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


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.TaxGroup
{
    /// <summary>
    /// Interaction logic for TaxGroupView.xaml
    /// </summary>
    public partial class TaxGroupView : UserControl, ITaxGroupView
    {
        private TaxGroupViewPresenter _presenter;

        public TaxGroupView()
        {
            InitializeComponent();
        }

        public TaxGroupView(TaxGroupViewPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

           // _presenter.OnShowTaxGroup();

            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

            this.cmbBoxOrganizationID.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationID_SelectionChanged);
           // this.cmbBoxOrganizationID.SelectedValue = PosSettings.Default.Organization;
           
            this.Loaded += new RoutedEventHandler(TaxGroupView_Loaded);
            
        }

        void cmbBoxOrganizationID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbBoxOrganizationID.SelectedValue != null)
            {
                this._presenter.FilterEmployeeByOrganizationNo(this.cmbBoxOrganizationID.SelectedValue.ToString());
            }
            else
            {
                this._presenter.FilterEmployeeByOrganizationNo(PosSettings.Default.Organization);
            }
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void TaxGroupView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            this._presenter.OnShowTaxGroup();
            this.cmbBoxOrganizationID.SelectedValue = PosSettings.Default.Organization;
        
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        #region Events

        public void OnTaxGroupListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

        }


        #endregion

        #region ITaxGroupView implementations

        public void SetTaxGroupDataContext(object data)
        {
            this.taxGroupListView.DataContext = data;
            this.DataContext = data;
        }

        public void SetOrganizationDataContext(IEnumerable data)
        {
            this.cmbBoxOrganizationID.ItemsSource = data;
        }


        public void SetSelectedItemCursor()
        {
            taxGroupListView.ScrollIntoView(taxGroupListView.Items.CurrentItem);
            taxGroupListView.SelectedItem = taxGroupListView.Items.CurrentItem;
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


        public string SelectedOrganizationNo()
        {
            string orgID = "";

            try
            {
                orgID = this.cmbBoxOrganizationID.SelectedValue.ToString();
            }
            catch
            {
                orgID = PosSettings.Default.Organization;
            }
            return orgID;
        }

        public void SetFocusToFirstElement()
        {
            this.txtBoxTaxGroupNo.Focus();
        }

        public void SetColumnsEnabled(bool flag)
        {

            int count = VisualTreeHelper.GetChildrenCount(this.dataGrid);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.dataGrid, i);
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
