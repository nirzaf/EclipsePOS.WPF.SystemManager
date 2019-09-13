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

namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.PosParam
{
    /// <summary>
    /// Interaction logic for PosParamView.xaml
    /// </summary>
    public partial class PosParamView : UserControl, IPosParamView
    {
        private PosParamViewPresenter _presenter;

        public PosParamView()
        {
            InitializeComponent();

            
            //int defaultConfig = PosSettings.Default.Configuration;
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);

            this.txtBoxParamValue.PreviewTextInput += new TextCompositionEventHandler(txtBoxParamValue_PreviewTextInput);

          
        }

        void txtBoxParamValue_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string val = this.cmbBoxParamType.SelectedValue.ToString();
            if ( string.Equals(val, "1" ))
            {
                e.Handled = !AreAllValidNumericChars(e.Text);
            }
           
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        void cmbBoxConfigNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (this.cmbBoxConfigNo.SelectedValue != null)
                {
                    _presenter.FilterPosParamByConfigNo(int.Parse(this.cmbBoxConfigNo.SelectedValue.ToString()));
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString()); 
            }
        }

        public PosParamView(PosParamViewPresenter presenter):this()
        {
            this._presenter = presenter;
            this._presenter.View = this;
            
            this.LoadResources();

            this._presenter.OnShowPosParam();

            this.cmbBoxConfigNo.SelectionChanged += new SelectionChangedEventHandler(cmbBoxConfigNo_SelectionChanged);

            this.cmbBoxConfigNo.SelectedValue  = PosSettings.Default.Configuration.ToString();
            _presenter.FilterPosParamByConfigNo(PosSettings.Default.Configuration);
            //this.Flter();

           // this.posParamListView.SelectionChanged += new SelectionChangedEventHandler(posParamListView_SelectionChanged);

            
            
        }

        void posParamListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // posDisplay.Source  = new im
            //MessageBox.Show(posParamListView.SelectedItems[0].ToString());
         /*   System.Data.DataRowView dataRow = posParamListView.SelectedItem as System.Data.DataRowView;
            switch ( int.Parse(dataRow[3].ToString()) )
            {
                case 1: //line display
                    posDisplay.Source = new BitmapImage(new Uri(@"../../Images/LineDisplay1.png", UriKind.RelativeOrAbsolute));
                    break;
                case 2: // Printer
                    posDisplay.Source = new BitmapImage(new Uri(@"../../Images/252.ico", UriKind.RelativeOrAbsolute));
                    break;
                case 3: // pos workbench
                    posDisplay.Source = new BitmapImage(new Uri(@"../../Images/posDisplay.png", UriKind.RelativeOrAbsolute));
                    break;
                case 4: // pos workbench
                    posDisplay.Source = new BitmapImage(new Uri(@"../../Images/posDisplay.png", UriKind.RelativeOrAbsolute));
                    break;
                case 5: // Terminal Report
                    posDisplay.Source = new BitmapImage(new Uri(@"../../Images/252.ico", UriKind.RelativeOrAbsolute));
                    break;
                case 6:// Miscellaneous 
                    posDisplay.Source = new BitmapImage(new Uri(@"../../Images/102_153.ico", UriKind.RelativeOrAbsolute));
                    break;
                default:
                    posDisplay.Source = new BitmapImage(new Uri(@"../../Images/102_153.ico", UriKind.RelativeOrAbsolute));
                     break;
            }
          * */
        }
    


        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
           // this.Flter();
        }


        #region Events

        public void OnPosParamListView_SelectionChanged(object sender, RoutedEventArgs e)
        {

            object selectedItem = ((ListView)e.Source).SelectedItem;

            _presenter.OnShowHelpText(selectedItem);

        }


        #endregion

        #region IPosParamView implementations

        public void SetPosParamDataContext(object data)
        {
            this.posParamListView.DataContext = data;
            this.DataContext = data;
        }

        public void SetPosConfigDataContext(IEnumerable data)
        {
            this.cmbBoxConfigNo.ItemsSource = data;
        }



        public void SetSelectedItemCursor()
        {
            posParamListView.ScrollIntoView(posParamListView.Items.CurrentItem);
            posParamListView.SelectedItem = posParamListView.Items.CurrentItem;
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
           // this.btnDelete.DataContext = command;
        }

        public void SetAddBtnDataContext(object command)
        {
           // this.btnAdd.DataContext = command;
        }

        public void SetRevertBtnDataContext(object command)
        {
            this.btnRevert.DataContext = command;
        }

        public void SetSaveBtnDataContext(object command)
        {
            this.btnSave.DataContext = command;
        }

        public void SetHelpText(string text)
        {
           // this.textBlockHelp.Text =text;
            //this.richTxtBoxHelp.add
        }


        #endregion

        /*
        public void Flter()
        {
            CollectionViewSource dataCollection = CollectionViewSource.GetDefaultView(this.posParamListView.ItemsSource) as CollectionViewSource;
            dataCollection.Filter += new FilterEventHandler(dataCollection_Filter);
        }

        void dataCollection_Filter(object sender, FilterEventArgs e)
        {
            System.Data.DataRow posParamRow = ((System.Data.DataRowView)e.Item).Row;
        }

        */

        private bool AreAllValidNumericChars(string str)
        {
            bool ret = true;
            if (str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencyGroupSeparator |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.CurrencySymbol |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.NegativeSign |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.NegativeInfinitySymbol |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentDecimalSeparator |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentGroupSeparator |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.PercentSymbol |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.PerMilleSymbol |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.PositiveInfinitySymbol |
                 str == System.Globalization.NumberFormatInfo.CurrentInfo.PositiveSign)
                return ret;


            int l = str.Length;
            for (int i = 0; i < l; i++)
            {
                char ch = str[i];
                ret &= Char.IsDigit(ch);
            }

            if (!ret) Commands.Beep(500, 50);
            return ret;
        }
    }
}
