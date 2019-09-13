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


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.TableGroup
{
    /// <summary>
    /// Interaction logic for TableGroupView.xaml
    /// </summary>
    public partial class TableGroupView : UserControl, ITableGroupView
    {
        private TableGroupViewPresenter _presenter;

        public TableGroupView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(TableGroupView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
            this.txtBoxTableGroupNo.PreviewTextInput += new TextCompositionEventHandler(txtBoxTableGroupNo_PreviewTextInput);
        }

        void txtBoxTableGroupNo_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.AreAllValidNumericChars(e.Text);
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void TableGroupView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            _presenter.OnShowTableGroup();
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }

        public TableGroupView(TableGroupViewPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

           // this.cmbBoxConfigNo.SelectedValue = PosSettings.Default.Configuration;

        }

        public void OnTableGroupListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

        }

        #region ITableGroupView implementations

        public void SetTableGroupDataContext(object data)
        {
            this.tableGroupListView.DataContext = data;
            this.DataContext = data;
        }

       /* public void SetPosConfigDataContext(IEnumerable data)
        {
         //   this.cmbBoxConfigNo.ItemsSource = data;
        }
        */

        public void SetSelectedItemCursor()
        {
            this.tableGroupListView.ScrollIntoView(tableGroupListView.Items.CurrentItem);
            this.tableGroupListView.SelectedItem = tableGroupListView.Items.CurrentItem;
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

        /*public int SelectedConfigNo()
        {
            int configNo = 0;

            if (this.cmbBoxConfigNo.SelectedValue != null)
            {
                configNo = int.Parse(this.cmbBoxConfigNo.SelectedValue.ToString());
            }
            return configNo;
        }
        */

        #endregion

        public void SetFocusToFirstElement()
        {
            this.txtBoxTableGroupNo.Focus();
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
