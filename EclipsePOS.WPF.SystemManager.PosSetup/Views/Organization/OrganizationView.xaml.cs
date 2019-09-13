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
using System.Data;
using EclipsePOS.WPF.SystemManager.Data;
using System.Windows.Media.Animation;
using System.Collections;


using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Organization
{
    /// <summary>
    /// Interaction logic for OrganizationsView.xaml
    /// </summary>
    public partial class OrganizationsView : UserControl, IOrganizationView
    {
        private OrganizationViewPresenter _presenter;
        public OrganizationsView()
        {
            InitializeComponent();

           
        }

        public OrganizationsView(OrganizationViewPresenter presenter):this()
        {
            this._presenter = presenter;
            _presenter.View = this;

            this.Loaded += new RoutedEventHandler(OrganizationsView_Loaded);

            
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

            //this.txtBoxOrganizationId.PreviewTextInput += new TextCompositionEventHandler(txtBoxOrganizationId_PreviewTextInput);
            this.txtBoxShipmentCodeLength.PreviewTextInput += new TextCompositionEventHandler(txtBoxShipmentCodeLength_PreviewTextInput);
            this.txtBoxShipmentNextNumber.PreviewTextInput += new TextCompositionEventHandler(txtBoxShipmentNextNumber_PreviewTextInput); 

            

        }

        void txtBoxShipmentNextNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
        }

        void txtBoxShipmentCodeLength_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
        }

        

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void OrganizationsView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadResources();

            _presenter.OnShowOrganizations();

            this.txtBoxOrganizationId.Focus();

           

        }



       

        public void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }

        #region Events

        public void OnOrgView_SelectionChanged(object sender, RoutedEventArgs e)
        {
           
            object selectedOrg = ((ListView)e.Source).SelectedItem;

          //  _presenter.OnShowOrganizationDetails(selectedOrg);
           

        }

        
        #endregion

     
        
        #region IOrganizationView members

     
        public void SetOrganizationDataContext(object data)
        {
            this.organizationListView.DataContext = data;
            this.DataContext = data;
        }

        public void SetCurrencyDataContext(IEnumerable data )
        {
            this.cmbBoxHomeCurrencyCode.ItemsSource  = data;
        }

        
        public void SetSelectedItemCursor()
        {
            this.organizationListView.ScrollIntoView(this.organizationListView.Items.CurrentItem);
            this.organizationListView.SelectedItem = this.organizationListView.Items.CurrentItem;
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

       
              
       /*
        public void NotifySchemaChanges()
        {
            tbSchemaChanged.Visibility = Visibility.Visible;
            imgSchemaChanged.Visibility = Visibility.Visible;
            Storyboard StoryboardSchemaChanged = (Storyboard)FindResource("StoryboardSchemaChanged");
            StoryboardSchemaChanged.Begin(this.rootControl, true);
        }
        * */

        /// <summary>
        /// This method is used to start Synchronization Animation
        /// </summary>
       /* public void StartSyncAnimation()
        {
            imgSync.Visibility = Visibility.Visible;
            tbSync.Visibility = Visibility.Visible;
            Storyboard storyboardRotation = (Storyboard)FindResource("StoryboardRotation");
            storyboardRotation.Begin(rootControl, true);
        }
        * */

        /// <summary>
        /// This method is used to end Synchronization Animation
        /// </summary>
       /* public void EndSyncAnimation()
        {
            Storyboard storyboardRotation = (Storyboard)FindResource("StoryboardRotation");
            storyboardRotation.Stop(rootControl);
            Storyboard StoryboardEndSyncAnimation = (Storyboard)FindResource("StoryboardEndSyncAnimation");
            StoryboardEndSyncAnimation.Begin(rootControl);
        }
        * */

        public void SetFocusToFirstElement()
        {
            this.txtBoxOrganizationId.Focus();
        }


        #endregion


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


        public void SetColumnsEnabled(bool flag)
        {
           
            int count = VisualTreeHelper.GetChildrenCount(this.organizationGrid);
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    UIElement child = (UIElement)VisualTreeHelper.GetChild(this.organizationGrid, i);
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

            this.txtBoxShipmentCodeLength.IsEnabled = flag;
            this.txtBoxShipmentNextNumber.IsEnabled = flag;
            this.txtBoxShipmentPrefix.IsEnabled = flag;
           

        }

        


    }
}
