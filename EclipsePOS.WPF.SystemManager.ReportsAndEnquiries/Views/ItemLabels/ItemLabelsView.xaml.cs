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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Data;
using System.Printing;

using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.BarcodeLib.Symbologies;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.BarcodeLib;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.ReportingServices;



using EclipsePOS.WPF.SystemManager.PosSetup.Util;



namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.ItemLabels
{
    /// <summary>
    /// Interaction logic for ItemLabelsView.xaml
    /// </summary>
    public partial class ItemLabelsView : UserControl, IItemLabelsView
    {
        private ItemLabelsPresenter _presenter;
        private int numberAccross = 1;
        private int numberDown = 1;
        private double topMargin = .25;
        private double sideMargin = .25;
        private bool pluBarcode = false;
        private Color borderColor;
        private int barcodeTypeIndex;
        private bool printBorder;

        private LocalPrintServer ps;
        private PrintQueue pq;
       

        public ItemLabelsView()
        {
            InitializeComponent();

            if (ps == null)
            {
                ps = new LocalPrintServer();
                pq = ps.DefaultPrintQueue;
            }   

        }

        void cmbBoxOrganizationID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbBoxOrganizationID.SelectedValue != null)
            {
                this._presenter.FilterItemsByOrganizationNo(this.cmbBoxOrganizationID.SelectedValue.ToString());
            }
        }

        void sliderNumberAccross_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.textBlockNumberAcross.Text = ((int)this.sliderNumberAccross.Value).ToString();
            this.numberAccross = (int)this.sliderNumberAccross.Value;
            Properties.Settings.Default.NumberAcross = this.NumberAcross;
            Properties.Settings.Default.Save();
        }

        void sliderNumberDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.textBlockNumberDown.Text = ((int)this.sliderNumberDown.Value).ToString();
            this.numberDown = (int)this.sliderNumberDown.Value;
            Properties.Settings.Default.NumberDown = this.numberDown;
            Properties.Settings.Default.Save();
        }

        void cmbBoxBarcodeStyle_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Properties.Settings.Default.BarcodeStyle = this.cmbBoxBarcodeStyle.SelectedValue.ToString();
            Properties.Settings.Default.Save();
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82); 
        }

        public ItemLabelsView(ItemLabelsPresenter presenter)
            : this()
        {
            this._presenter = presenter;
            this._presenter.View = this;

            _presenter.OnShowItemLabels();


            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
            this.Loaded += new RoutedEventHandler(ItemLabelsView_Loaded);
          


            //
            MemberInfo[] memberInfos = typeof(BarcodeLib.TYPE).GetMembers(BindingFlags.Public | BindingFlags.Static);
            for (int i = 0; i < memberInfos.Length; i++)
            {
                this.cmbBoxBarcodeStyle.Items.Add(memberInfos[i].Name);
            }

            this.sliderNumberDown.ValueChanged += new RoutedPropertyChangedEventHandler<double>(sliderNumberDown_ValueChanged);
            this.sliderNumberAccross.ValueChanged += new RoutedPropertyChangedEventHandler<double>(sliderNumberAccross_ValueChanged);
            this.sliderSideMargin.ValueChanged += new RoutedPropertyChangedEventHandler<double>(sliderSideMargin_ValueChanged);
            this.sliderTopMargin.ValueChanged += new RoutedPropertyChangedEventHandler<double>(sliderTopMargin_ValueChanged);
           
            this.radioButtonBarcodePLU.Checked += new RoutedEventHandler(radioButtonBarcodePLU_Checked);
            this.radioButtonBarcodeSKU.Checked += new RoutedEventHandler(radioButtonBarcodeSKU_Checked);

            this.cmbBoxBarcodeStyle.SelectedValue = Properties.Settings.Default.BarcodeStyle;
            this.sliderNumberAccross.Value = Properties.Settings.Default.NumberAcross;
            this.sliderNumberDown.Value = Properties.Settings.Default.NumberDown;
            this.sliderTopMargin.Value = Properties.Settings.Default.TopMargin;
            this.sliderSideMargin.Value = Properties.Settings.Default.SideMargin;



            this.numberAccross = Properties.Settings.Default.NumberAcross;
            this.numberDown = Properties.Settings.Default.NumberDown;
            this.topMargin = Properties.Settings.Default.TopMargin;
            this.sideMargin = Properties.Settings.Default.SideMargin;
            switch (Properties.Settings.Default.FilterBy)
            {
                case "plu":
                    this.radioButtonPLU.IsChecked = true;
                    break;
                case "sku":
                    this.radioButtonSKU.IsChecked = true;
                    break;
                default:
                    this.radioButtonDescription.IsChecked = true;
                    break;

            }

            switch (Properties.Settings.Default.BarcodeColumn)
            {
                case "plu":
                    this.radioButtonBarcodePLU.IsChecked = true;
                    break;
                case "sku":
                    this.radioButtonBarcodeSKU.IsChecked = true;
                    break;
                default:
                    this.radioButtonBarcodePLU.IsChecked = true;
                    break;

            }


            this.textBlockNumberAcross.Text = Properties.Settings.Default.NumberAcross.ToString();
            this.textBlockNumberDown.Text = Properties.Settings.Default.NumberDown.ToString();
            this.textBlockTopMargin.Text = Properties.Settings.Default.TopMargin.ToString();
            this.textBlockSideMargin.Text = Properties.Settings.Default.SideMargin.ToString();


            this.cmbBoxBarcodeStyle.SelectionChanged += new SelectionChangedEventHandler(cmbBoxBarcodeStyle_SelectionChanged);

            this.cmbBoxOrganizationID.SelectionChanged += new SelectionChangedEventHandler(cmbBoxOrganizationID_SelectionChanged);
           
            this.cmbBoxOrganizationID.SelectedValue = PosSettings.Default.Organization;

            this._presenter.FilterItemsByOrganizationNo(this.cmbBoxOrganizationID.SelectedValue.ToString());

           
        }

        void radioButtonBarcodeSKU_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.BarcodeColumn = "sku";
            Properties.Settings.Default.Save();
        }

        void radioButtonBarcodePLU_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.BarcodeColumn = "plu";
            Properties.Settings.Default.Save();
        }

        void sliderTopMargin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.textBlockTopMargin.Text = Math.Round(this.sliderTopMargin.Value, 2).ToString();
            this.topMargin = Math.Round(this.sliderTopMargin.Value, 2);
            Properties.Settings.Default.TopMargin = Math.Round(this.sliderTopMargin.Value, 2);
            Properties.Settings.Default.Save();

        }

        void sliderSideMargin_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.textBlockSideMargin.Text = Math.Round(this.sliderSideMargin.Value, 2).ToString();
            this.sideMargin = Math.Round(this.sliderSideMargin.Value, 2);
            Properties.Settings.Default.SideMargin = Math.Round(this.sliderSideMargin.Value, 2);
            Properties.Settings.Default.Save();
        }

        void ItemLabelsView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();
            
            this.colorPicker.SelectedColor = Properties.Settings.Default.BorderColor;

        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        
        }

        public void SetOrganizationDataContext(IEnumerable data)
        {
            this.cmbBoxOrganizationID.ItemsSource = data;
        }

        public void SetItemsDataContext(Object data)
        {
           this.itemsListView.DataContext  = data;
        }

        public void SetFilterBtnDataContext(object command)
        {
            this.btnFilter.DataContext = command;
        }

        public void SetSelectBtnDataContext(object command)
        {
            this.btnSelect.DataContext = command;
        }

        public void SetSelectAllBtnDataContext(object command)
        {
            this.btnSelectAll.DataContext = command;
        }

        public void SetRunBtnDataContext(object command)
        {
            this.btnRun.DataContext = command;
        }

        public void AddSelectedItemLabel()
        {
            IList list =  this.itemsListView.SelectedItems;
            foreach (Object obj in list)
            {
                this.selectedItemsListView.Items.Add(obj); //this.itemsListView.SelectedItems);
            }
        }

        public void AddAllItemLabels()
        {
            IList list = this.itemsListView.Items;
            foreach (Object obj in list)
            {
                this.selectedItemsListView.Items.Add(obj); 
            }
            
        }




        public List<WPFBarcode> LabelData()
        {
            //Properties.Settings.Default.BorderColor = this.colorPicker.SelectedColor;
            //Properties.Settings.Default.Save();
            
            
            List<WPFBarcode> listLabel = new List<WPFBarcode>();
            //WPFBarcode barcode = new WPFBarcode();
           // barcode
            ItemCollection itemCollection = this.selectedItemsListView.Items;
            foreach (DataRowView  dataView in itemCollection)
            {
               // MessageBox.Show(dataView[1].ToString() );
                WPFBarcode barcode = new WPFBarcode();
                if (this.pluBarcode)
                {

                    barcode.RawData =  dataView["plu"].ToString();
                }
                else
                {
                    barcode.RawData = dataView["sku"].ToString();
                }
                barcode.ItemText = dataView["short_desc"].ToString();
                barcode.Price = double.Parse(dataView["Amount"].ToString());
                barcode.EncodedType =   (BarcodeLib.TYPE)(this.barcodeTypeIndex);
                barcode.BackColor = Colors.Black;
                barcode.ForeColor = Colors.White;
                barcode.Height = (int)((this.GetPageHight() - 50 - 2 * this.topMargin * 96 ) / this.numberDown);
                barcode.Width = (int) ( (this.GetPageWidth() - 2 * this.sideMargin * 96 ) / this.numberAccross);
               // Color c = Color.FromName(n);

                barcode.BorderColor =  new SolidColorBrush(this.borderColor );
                
                barcode.PintBorder = this.printBorder;
                
                listLabel.Add(barcode);

            }


            return listLabel;


        }

        


        public int NumberAcross
        {
            get
            {
                return numberAccross;
            }

        }

        public int NumberDown
        {
            get
            {
                return numberDown;
            }

        }

        public double TopMargin
        {
            get
            {
                return topMargin;
            }
        }

        public double SideMargin
        {
            get
            {
                return sideMargin;
            }
        }




        public string GetFilterCriteria()
        {
            if (this.radioButtonSKU.IsChecked==true)
                return "sku ";
            
            if (this.radioButtonDescription.IsChecked==true)
                return "short_desc ";
            
            if (this.radioButtonPLU.IsChecked==true)
                return "plu ";
            
            return "sku ";

        }



        public string GetFilterText()
        {
            return this.txtBoxFilter.Text.Trim();
        }


        public int NumberOfBarcodesToPrint()
        {
            return this.selectedItemsListView.Items.Count;
        }

        public void SetSelectedItemCursor()
        {
            itemsListView.ScrollIntoView(itemsListView.Items.CurrentItem);
            itemsListView.SelectedItem = itemsListView.Items.CurrentItem;
        }


        public void StartSyncAnimation()
        {
           // this.busyIndicator.IsBusy = true;
        }


        /// <summary>
        /// This method is used to end Synchronization Animation
        /// </summary>
        public void EndSyncAnimation()
        {
           // this.busyIndicator.IsBusy = false;
        }

        public void SaveSelections()
        {
            
            Properties.Settings.Default.BorderColor = this.colorPicker.SelectedColor;
            Properties.Settings.Default.Save();

            if (this.radioButtonBarcodePLU.IsChecked == true )
            {

                this.pluBarcode = true;
            }
            else
            {
                this.pluBarcode = false;
            }

            this.borderColor = this.colorPicker.SelectedColor;
            this.barcodeTypeIndex = this.cmbBoxBarcodeStyle.SelectedIndex;

            if (checkBoxPrintBorder.IsChecked == true)
            {
                this.printBorder = true;
            }
            else
            {
                this.printBorder = false;
            }
        }


        public double GetPageHight()
        {
            return (double)pq.DefaultPrintTicket.PageMediaSize.Height;
        }

        public double GetPageWidth()
        {
            return (double)pq.DefaultPrintTicket.PageMediaSize.Width;
        }

        

    }

        
}
