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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.MenuPanels
{
    /// <summary>
    /// Interaction logic for MenuPanelsView.xaml
    /// </summary>
    public partial class MenuPanelsView : UserControl, IMenuPanelsView
    {
        private MenuPanelsViewPresenter _presenter;

        public MenuPanelsView()
        {
            InitializeComponent();
        }

        public MenuPanelsView(MenuPanelsViewPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

            this.Loaded += new RoutedEventHandler(MenuPanelsView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void MenuPanelsView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            _presenter.OnShowMenuPanels();
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        #region Events

        public void OnMenuPanelsListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

        }


        #endregion

        #region IMenuRootView implementations

        public void SetMenuPanelsDataContext(object data)
        {
            this.menuPanelsListView.DataContext = data;
            this.DataContext = data;
        }

        public void SetConfigNoDataContext(IEnumerable data)
        {
            //this.cmbBoxConfigNo.ItemsSource = data;

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

        #endregion

    }
}
