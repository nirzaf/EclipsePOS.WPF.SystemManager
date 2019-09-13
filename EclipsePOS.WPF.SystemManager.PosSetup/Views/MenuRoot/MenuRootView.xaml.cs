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



namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.MenuRoot
{
    /// <summary>
    /// Interaction logic for MenuRootView.xaml
    /// </summary>
    public partial class MenuRootView : UserControl, IMenuRoot
    {
        MenuRootPresenter _presenter;

        public MenuRootView()
        {
            InitializeComponent();

            
        }

        public MenuRootView(MenuRootPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

            this.Loaded += new RoutedEventHandler(MenuRootView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

            
            this.cmbBoxConfigNo.SelectionChanged += new SelectionChangedEventHandler(cmbBoxConfigNo_SelectionChanged);

            this.txtBoxPanelId.PreviewTextInput += new TextCompositionEventHandler(txtBoxPanelId_PreviewTextInput);

          

        }

        

        void txtBoxPanelId_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
        }

        void cmbBoxConfigNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _presenter.FilterMenuPanelsByConfigNo(int.Parse(this.cmbBoxConfigNo.SelectedValue.ToString()));
                _presenter.OnFilter(int.Parse(this.cmbBoxConfigNo.SelectedValue.ToString()));
            }
            catch
            {
                _presenter.FilterMenuPanelsByConfigNo(PosSettings.Default.Configuration);
                _presenter.OnFilter(PosSettings.Default.Configuration);

            }
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void MenuRootView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            _presenter.OnShowMenuRoot();
            this.cmbBoxConfigNo.SelectedValue = PosSettings.Default.Configuration;

        }


        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        #region Events

        public void OnMenuPanelsListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

            try
            {
                this._presenter.OnFilter(int.Parse(this.cmbBoxConfigNo.SelectedValue.ToString()));
            }
            catch
            {
                this._presenter.OnFilter(PosSettings.Default.Configuration);
            }

        }


        #endregion

        #region IMenuRootView implementations

        public void SetMenuRootDataContext(object data)
        {
            this.menuPanelsListView.DataContext = data;
            this.DataContext = data;

        }

        public void SetPosKeyDataContext(IEnumerable data)
        {
            this.listBoxPosKeys.ItemsSource  = data;
           
        }

        public void SetMenuPanelsDataContext(IEnumerable data)
        {
            //this.listBoxMenuPanels.ItemsSource = data;


        }

        public void SetPosConfigDataContext(IEnumerable data)
        {
           this.cmbBoxConfigNo.ItemsSource = data;
        }


        public void SetSelectedItemCursor()
        {
            menuPanelsListView.ScrollIntoView(menuPanelsListView.Items.CurrentItem);
            menuPanelsListView.SelectedItem = menuPanelsListView.Items.CurrentItem;
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

        public void SetAddPosKeyBtnDataContext(object command)
        {
            this.btnAddPosKey.DataContext = command;
        }
        
        public void SetChangePosKeyBtnDataContext(object command)
        {
            this.btnChangePosKey.DataContext = command;
        }

        public void SetDeletePosKeyBtnDataContext(object command)
        {
            this.btnDeletePosKey.DataContext = command;
        }

        #endregion

        public int SelectedConfigNo()
        {
            int configNo = 0;

            if (this.cmbBoxConfigNo.SelectedValue != null)
            {
                configNo = int.Parse(this.cmbBoxConfigNo.SelectedValue.ToString());
            }
            return configNo;
            
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
            this.txtBoxPanelId.Focus();
        }



    }
}
