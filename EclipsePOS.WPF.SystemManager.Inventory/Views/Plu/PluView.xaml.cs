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

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.Plu
{
    /// <summary>
    /// Interaction logic for PluView.xaml
    /// </summary>
    public partial class PluView : UserControl, IPluView
    {
        public PluView()
        {
            InitializeComponent();
        }

        #region Events

        public void OnItemListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

           // object selectedItem = ((ListView)e.Source).SelectedItem;

           // _presenter.OnShowItemDetails(selectedItem);

           // object selectedPlu = ((ListView)e.Source).SelectedItems;

        }


        #endregion
    }
}
