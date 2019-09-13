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
using System.Xml;
using EclipsePOS.WPF.SystemManager.PosSetup.Util;

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.EmployeeRoles
{
    /// <summary>
    /// Interaction logic for EmployeeRolesView.xaml
    /// </summary>
    public partial class EmployeeRolesView : UserControl, IEmployeeRolesView
    {
        private EmployeeRolesViewPresenter _presenter;
       // private CollectionView _colViewManagedRoleEvent;


        public EmployeeRolesView()
        {
            InitializeComponent();
        }

        public EmployeeRolesView(EmployeeRolesViewPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

            this.Loaded += new RoutedEventHandler(EmployeeRolesView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

            
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void EmployeeRolesView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();

            this._presenter.OnShowEmployeeRoles();

            this.cmbBoxOrganizationID.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationID_SelectionChanged);

            this.cmbBoxOrganizationID.SelectedValue = PosSettings.Default.Organization;

            this._presenter.FilterEmployeeRolesByOrganizationNo(PosSettings.Default.Organization);

            this.listBoxManagedRoleEvents.SelectionChanged += new SelectionChangedEventHandler(listBoxManagedRoleEvents_SelectionChanged);

        }

        void listBoxManagedRoleEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CollectionView _colView = CollectionViewSource.GetDefaultView(this.listBoxManagedRoleEvents.ItemsSource) as CollectionView;
            _colView.MoveCurrentTo(this.listBoxManagedRoleEvents.SelectedItem);
            //_colView.MoveCurrentToNext();
        }

        void cmbBoxOrganizationID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbBoxOrganizationID.SelectedValue != null)
            {
                this._presenter.FilterEmployeeRolesByOrganizationNo(this.cmbBoxOrganizationID.SelectedValue.ToString());
            }
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        #region Events

        public void OnEmployeeRolesListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;
            _presenter.OnFilter();

        }

       
        #endregion

        #region IDepartmentView implementations

        public void SetEmployeeRolesDataContext(object data)
        {
            this.emloyeeRolesListView.DataContext = data;
            this.DataContext = data;
        }


        public void SetEmployeeRoleEventDataContext(IEnumerable data)
        {
            this.listBoxRoleEvents.ItemsSource = data;
        }

        public void SetOrganizationDataContext(IEnumerable data)
        {
            this.cmbBoxOrganizationID.ItemsSource = data;
        }

        public void SetManagedPosEventDataContext(IEnumerable data)
        {
            this.listBoxManagedRoleEvents.ItemsSource = data;
            /*
            XmlDataProvider xdp = this.TryFindResource("ManagedPosEvents") as XmlDataProvider;
            if (xdp != null)
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path.Substring(6));
                xdp.Document = doc;
                xdp.XPath = "PosEvents";
            }
            */
          //  CollectionViewSource collSource = CollectionViewSource.GetDefaultView();
            //_colViewManagedRoleEvent = (CollectionView) this.TryFindResource("ManagedPosEvents");

          //  _colViewManagedRoleEvent = CollectionViewSource.GetDefaultView(xdp) as CollectionView;

            //_colViewManagedRoleEvent.MoveCurrentToLast();
           // this.listBoxManagedRoleEvents.
        }

        public void SetSelectedItemCursor()
        {
            this.emloyeeRolesListView.ScrollIntoView(this.emloyeeRolesListView.Items.CurrentItem);
            this.emloyeeRolesListView.SelectedItem = this.emloyeeRolesListView.Items.CurrentItem;
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

        public void SetAddEventDataContext(object command)
        {
            this.btnAddEvent.DataContext = command;
        }

        public void SetRemoveEventDataContext(object command)
        {
            this.btnRemoveEvent.DataContext = command;
        }

        public string SelectedRoleEvent()
        {
           // XmlElement element = this.listBoxManagedRoleEvents.SelectedItem as XmlElement;
           // XmlAttribute attr = element.GetAttributeNode("name");
           // return attr.InnerText;
            string selectedEvent = this.listBoxManagedRoleEvents.SelectedValue as string;
            return selectedEvent;
        }


        #endregion

        public string SelectedOrganizationId()
        {
            string orgId = "";

            try 
            {
                orgId = cmbBoxOrganizationID.SelectedValue.ToString();
            }
            catch
            {
            }
            return orgId;

        }

        public void SetFocusToRoleName()
        {
            this.txtBoxRoleID.Focus();
        }

        public void MoveToNextManagedEvent()
        {
            _presenter.OnFilter();
            
            CollectionView _colView = CollectionViewSource.GetDefaultView(this.listBoxManagedRoleEvents.ItemsSource) as CollectionView;
            _colView.MoveCurrentToNext();
          
            this.listBoxManagedRoleEvents.SelectedItem = this.listBoxManagedRoleEvents.Items.CurrentItem;
           
        }

        public void RemoveSelectedRoleEvent()
        {
           // DataRow 
           System.Data.DataRowView dataRowView = this.listBoxRoleEvents.SelectedItem as System.Data.DataRowView;
           if (dataRowView != null)
           {
               dataRowView.Delete();
           }
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
