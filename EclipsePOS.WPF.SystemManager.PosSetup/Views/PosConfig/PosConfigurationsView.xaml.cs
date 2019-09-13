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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosConfig
{
    /// <summary>
    /// Interaction logic for PosConfigurationsView.xaml
    /// </summary>
    public partial class PosConfigurationsView : UserControl, IPosConfigurationsView
    {
        private PosConfigurationsViewPresenter _presenter;

        public PosConfigurationsView()
        {
            InitializeComponent();
        }

        public PosConfigurationsView(PosConfigurationsViewPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

            this.Loaded += new RoutedEventHandler(PosConfigurationsView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void PosConfigurationsView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            this._presenter.OnShowPosConfig();
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        #region Events

        public void OnPosConfigurationsListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

        }


        #endregion

        #region IDepartmentView implementations

        public void SetPosConfigDataContext(object data)
        {
            this.posConfigurationsListView.DataContext = data;
            this.DataContext = data;
        }



        public void SetSelectedItemCursor()
        {
           this.posConfigurationsListView.ScrollIntoView(posConfigurationsListView.Items.CurrentItem);
           this.posConfigurationsListView.SelectedItem = posConfigurationsListView.Items.CurrentItem;
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

        public void SetFocusToFirstElement()
        {
            this.txtBoxName.Focus();
        }
        

    }
}
