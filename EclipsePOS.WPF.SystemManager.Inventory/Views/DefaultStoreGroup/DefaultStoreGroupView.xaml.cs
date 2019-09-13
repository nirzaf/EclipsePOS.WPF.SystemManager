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

namespace EclipsePOS.WPF.SystemManager.Inventory.Views.DefaultStoreGroup
{
    /// <summary>
    /// Interaction logic for DefaultStoreGroupView.xaml
    /// </summary>
    public partial class DefaultStoreGroupView : UserControl, IDefaultStoreGroupView
    {
        private DefaultStoreGroupViewPresenter _presenter;

        public DefaultStoreGroupView()
        {
            InitializeComponent();
        }

        public DefaultStoreGroupView(DefaultStoreGroupViewPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
            this.Loaded += new RoutedEventHandler(DefaultStoreGroupView_Loaded);
        }

        void DefaultStoreGroupView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            _presenter.OnShowDefaultStoreGroup();
            
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }

        #region IDefaultStoreGroupView implementations
        public void SetStoreGroupDataContext(IEnumerable data)
        {
            this.cmbBoxStoreGroup.DataContext = data;
         
        }
        #endregion
    }
}
