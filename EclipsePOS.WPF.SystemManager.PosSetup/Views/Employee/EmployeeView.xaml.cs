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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Employee
{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : UserControl, IEmployeeView
    {
        private EmployeeViewPresenter _presenter;

        public EmployeeView()
        {
            InitializeComponent();
        }

        public EmployeeView(EmployeeViewPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

            this.Loaded += new RoutedEventHandler(EmployeeView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
            this.cmbBoxOrganizationID.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationID_SelectionChanged);
            this.cmbBoxRoleID.DropDownOpened += new EventHandler(cmbBoxRoleID_DropDownOpened);
            
            this.txtBoxLogonNo.PreviewTextInput += new TextCompositionEventHandler(txtBoxLogonNo_PreviewTextInput);
            this.passwordBoxLogonPass.PreviewTextInput += new TextCompositionEventHandler(passwordBoxLogonPass_PreviewTextInput);
        }

   
        void passwordBoxLogonPass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
        }

        void txtBoxLogonNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
           
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



        void cmbBoxRoleID_DropDownOpened(object sender, EventArgs e)
        {
            this._presenter.FilterEmployeeRoleIDByOrganizationNo(this.cmbBoxOrganizationID.SelectedValue.ToString());
       
        }

       
        void cmbBoxOrganizationID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbBoxOrganizationID.SelectedValue != null)
            {
                this._presenter.FilterEmployeeByOrganizationNo(this.cmbBoxOrganizationID.SelectedValue.ToString());
            }
            this._presenter.FilterEmployeeByOrganizationNo(PosSettings.Default.Organization);
            {

            }
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void EmployeeView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            this._presenter.OnShowEmployee();
            this.cmbBoxOrganizationID.SelectedValue = PosSettings.Default.Organization;
           // _presenter.OnMoveToFirstCommandExecute(null);

        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        #region Events

        public void OnEmployeeListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

        }


        #endregion

        #region IEmployeeView implementations

        public void SetEmployeeDataContext(object data)
        {
            this.employeeListView.DataContext = data;
            this.DataContext = data;
        }


        public void SetEmployeeRoleDataContext(IEnumerable data)
        {
            this.cmbBoxRoleID.ItemsSource  = data;
        }

        public void SetOrganizationDataContext(IEnumerable data)
        {
            this.cmbBoxOrganizationID.ItemsSource = data;
        }


        public void SetSelectedItemCursor()
        {
            employeeListView.ScrollIntoView(employeeListView.Items.CurrentItem);
            employeeListView.SelectedItem = employeeListView.Items.CurrentItem;
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
            }
            return orgID;
        }


       
        public void SetFocusToFirstElement()
        {
            this.cmbBoxRoleID.Focus();
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
