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


namespace EclipsePOS.WPF.SystemManager.Inventory.Views.Department
{
    /// <summary>
    /// Interaction logic for DepartmentView.xaml
    /// </summary>
    public partial class DepartmentView : UserControl, IDepartmentView
    {
        private DepartmentViewPresenter _presenter;

        public DepartmentView()
        {
            InitializeComponent();

        }

        public DepartmentView(DepartmentViewPresenter presenter):this()
        {
            this._presenter = presenter;
            _presenter.View = this;

            this.Loaded += new RoutedEventHandler(DepartmentView_Loaded);

            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

            this.cmbBoxOrganizationID.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationID_SelectionChanged);
            
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void cmbBoxOrganizationID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                this._presenter.FilterDepartmentByOrganizationNo(this.cmbBoxOrganizationID.SelectedValue.ToString());
            }
            catch
            {
                this._presenter.FilterDepartmentByOrganizationNo(PosSettings.Default.Organization);
            }
        }

        void DepartmentView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            _presenter.OnShowDepartment();
            this.cmbBoxOrganizationID.SelectedValue = PosSettings.Default.Organization;
        }
        


        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        #region Events

        public void OnDepartmentListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

         }


        #endregion

        #region IDepartmentView implementations

        public void SetDeptDataContext(object data)
        {
            this.departmentListView.DataContext = data;
            this.DataContext = data;
        }

        public void SetOrganizationDataContext(IEnumerable data)
        {
            this.cmbBoxOrganizationID.ItemsSource = data;
        }

        public void SetSelectedItemCursor()
        {
            departmentListView.ScrollIntoView(departmentListView.Items.CurrentItem);
            departmentListView.SelectedItem = departmentListView.Items.CurrentItem;
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
            string orgId = "";
            try
            {
                orgId = this.cmbBoxOrganizationID.SelectedValue.ToString();
            }
            catch
            {
            }
            return orgId;
        }


        public void  SetFocusToFirstInputField()
        {
            this.txtBoxDepartmentId.Focus();
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
