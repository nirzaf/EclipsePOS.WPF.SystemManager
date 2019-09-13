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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.MenuConfig
{
    /// <summary>
    /// Interaction logic for MenuConfigView.xaml
    /// </summary>
    public partial class MenuConfigView : UserControl, IMenuConfigView 
    {
        private MenuConfigViewPresenter _presenter;

        public MenuConfigView()
        {
            InitializeComponent();
        }

        public MenuConfigView(MenuConfigViewPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
            this.Loaded += new RoutedEventHandler(MenuConfigView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);


        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void MenuConfigView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            _presenter.OnShowMenuConfigView();

        }



        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        #region Events

        public void OnMenuConfigListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

        }


        #endregion

        #region IMenuRootView implementations

        public void SetMenuConfigDataContext(object data)
        {
            this.menuConfigListView.DataContext = data;
            this.DataContext = data;
        }

        public void SetMenuIDDataContext(IEnumerable data)
        {
            this.cmbBoxMenuID.ItemsSource = data;

        }


        public void SetMenuPanelsDataContext(IEnumerable data)
        {
            this.cmbBoxMenuPanel.ItemsSource = data;

        }


        public void SetSelectedItemCursor()
        {
            menuConfigListView.ScrollIntoView(menuConfigListView.Items.CurrentItem);
            menuConfigListView.SelectedItem = menuConfigListView.Items.CurrentItem;
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


    }
}
