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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.StoreGroup
{
    /// <summary>
    /// Interaction logic for StoreGroupView.xaml
    /// </summary>
    public partial class StoreGroupView : UserControl, IStoreGroupView
    {
        private StoreGroupViewPresenter _presenter;

        public StoreGroupView()
        {
            InitializeComponent();
        }

        public StoreGroupView(StoreGroupViewPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

            this.Loaded += new RoutedEventHandler(StoreGroupView_Loaded);
        }

        void StoreGroupView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            _presenter.OnShowStoreGroup();

        }


        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        #region Events

        public void OnStoreGroupListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

        }


        #endregion

        #region IStoreGroupView implementations

        public void SetStoreGroupDataContext(object data)
        {
            this.storeGroupListView.DataContext = data;
            this.DataContext = data;
        }



        public void SetSelectedItemCursor()
        {
            storeGroupListView.ScrollIntoView(storeGroupListView.Items.CurrentItem);
            storeGroupListView.SelectedItem = storeGroupListView.Items.CurrentItem;
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
