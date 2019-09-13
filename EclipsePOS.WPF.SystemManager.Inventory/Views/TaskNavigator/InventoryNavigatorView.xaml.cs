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

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.TaskNavigator
{
    /// <summary>
    /// Interaction logic for InventoryTaskNavigatorView.xaml
    /// </summary>
    public partial class InventoryNavigatorView : UserControl, IInventoryNavigatorView
    {
        private InventoryNavigatorViewPresenter _presenter;

        public InventoryNavigatorView()
        {
            InitializeComponent();
        }

        public InventoryNavigatorView(InventoryNavigatorViewPresenter presenter): this()
        {
            this._presenter = presenter;
            _presenter.View = this;

            this.Loaded += new RoutedEventHandler(InventoryNavigatorView_Loaded);

            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged); 
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82);
        }

        void InventoryNavigatorView_Loaded(object sender, RoutedEventArgs e)
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        public void SetDataContextDeptView(ICommand command)
        {
            this.btnItemDepartment.DataContext = command;
        }

        public void SetDataContextItemGroupView(ICommand command)
        {
            this.btnItemGroup.DataContext = command;
        }


        public void SetDataContextItemListView(ICommand command)
        {
            this.btnItemList.DataContext = command;
        }

      /*  public void SetDataContextStoreGroupView(ICommand command)
        {
            this.btnChangeStoreGroup.DataContext = command;
        }
       * */

        public void SetDataContextStockDiaryView(ICommand command)
        {
            this.btnStockDiary.DataContext = command;
        }

    }
}
