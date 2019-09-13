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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Surcharge
{
    /// <summary>
    /// Interaction logic for SerchageView.xaml
    /// </summary>
    public partial class SerchargeView : UserControl, ISerchargeView
    {
        private SurchargeViewPresenter _presenter;

        public SerchargeView()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(SerchargeView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
            this.cmbBoxOrganizationID.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationID_SelectionChanged);
            this.cmbBoxTaxExempt.SelectionChanged += new SelectionChangedEventHandler(cmbBoxTaxExempt_SelectionChanged);
            this.cmbBoxTaxId.SelectionChanged += new SelectionChangedEventHandler(cmbBoxTaxId_SelectionChanged);
            this.cmbBoxTaxInclusive.SelectionChanged += new SelectionChangedEventHandler(cmbBoxTaxInclusive_SelectionChanged);
        }

        void cmbBoxTaxInclusive_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.SurchargeView_tax_inclusive = short.Parse(this.cmbBoxTaxInclusive.SelectedValue.ToString());
                Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        void cmbBoxTaxId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.SurchargeView_tax_group = this.cmbBoxTaxId.SelectedValue.ToString();
                Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        void cmbBoxTaxExempt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Properties.Settings.Default.SurchargeView_tax_exempt = short.Parse(this.cmbBoxTaxExempt.SelectedValue.ToString());
                Properties.Settings.Default.Save();
            }
            catch
            {
            }
        }

        void cmbBoxOrganizationID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbBoxOrganizationID.SelectedValue != null)
            {
                this._presenter.FilterSurchargesByOrganizationNo(this.cmbBoxOrganizationID.SelectedValue.ToString());
            }
            else
            {
                this._presenter.FilterSurchargesByOrganizationNo(PosSettings.Default.Organization);
            }
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void SerchargeView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            this._presenter.OnShowSurcharge();
            this.cmbBoxOrganizationID.SelectedValue = PosSettings.Default.Organization;
        }

        public SerchargeView(SurchargeViewPresenter presenter)
            : this()
        {
            this._presenter = presenter;

            this._presenter.View = this;
        }
        
        
        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }

        #region IPromotionView implementations

        public void SetSurchargeDataContext(object data)
        {
            this.surchargeListView.DataContext = data;
            this.DataContext = data;
        }

        public void SetOrganizationDataContext(IEnumerable data)
        {
            this.cmbBoxOrganizationID.ItemsSource = data;
        }


        public void SetSelectedItemCursor()
        {
            this.surchargeListView.ScrollIntoView(surchargeListView.Items.CurrentItem);
            this.surchargeListView.SelectedItem = surchargeListView.Items.CurrentItem;
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

        public void SetTaxGroupDataContext(IEnumerable data)
        {
            this.cmbBoxTaxId.ItemsSource = data;
        }

        



        public string SelectedOrganizationNo()
        {

            string orgID = PosSettings.Default.Organization;

            try
            {
                orgID = this.cmbBoxOrganizationID.SelectedValue.ToString();
            }
            catch
            {
            }
            return orgID;

        }


        public void SetFocusToFirstElement()
        {
           this.txtBoxSurchargeCode.Focus();
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


        #endregion


    }
}
