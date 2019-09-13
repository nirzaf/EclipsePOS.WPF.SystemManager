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
using System.Windows.Media;
using System.Windows.Threading;
using System.Data;
using System.Windows.Media.Animation;

using EclipsePOS.WPF.SystemManager.Infrastructure.Constants;


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Table
{
    /// <summary>
    /// Interaction logic for TableView.xaml
    /// </summary>
    public partial class TableView : UserControl, ITableView
    {
        private TableViewPresenter _presenter;
        public delegate void DlgDrawTable();
        private CollectionView myCollectionView;

        private Point _startPoint;
        private double _originalLeft;
        private double _originalTop;
        private bool _isDown;
        private bool _isDragging;
        private UIElement _originalElement;
        private SimpleCircleAdorner _overlayElement;
        private Button btnCurrentTable;
       
        
        
        public TableView()
        {
            InitializeComponent();

            

            this.cmbBoxTableGroup.SelectionChanged += new SelectionChangedEventHandler(cmbBoxTableGroup_SelectionChanged);
           // this.cmbBoxTableGroup.SelectedIndex = 0;

            this.canvasTableModel.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(canvasTableModel_PreviewMouseLeftButtonDown);
            this.canvasTableModel.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(canvasTableModel_PreviewMouseLeftButtonUp);
            this.canvasTableModel.PreviewMouseMove += new MouseEventHandler(canvasTableModel_PreviewMouseMove);
            this.KeyDown += new KeyEventHandler(TableView_KeyDown);

            this.txtBoxNumberOfGuests.PreviewTextInput += new TextCompositionEventHandler(txtBoxNumberOfGuests_PreviewTextInput);
            
        }

        public TableView(TableViewPresenter presnter)
            : this()
        {
            this._presenter = presnter;
            this._presenter.View = this;

            _presenter.OnShowTableViewPresenter();

            this.Loaded += new RoutedEventHandler(TableView_Loaded);
            this.rootControl.SizeChanged += new SizeChangedEventHandler(rootControl_SizeChanged);
        }

        void rootControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.rootControl.Height = Math.Ceiling(Application.Current.MainWindow.ActualHeight * 0.82);
        }

        void TableView_Loaded(object sender, RoutedEventArgs e)
        {
            this.LoadResources();

            try
            {
                this.cmbBoxTableGroup.SelectedIndex = 0;
            }
            catch
            {
            }

            // DrawTableModel();

        }


        void txtBoxNumberOfGuests_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !AreAllValidNumericChars(e.Text);
        }

        void TableView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape && _isDragging)
            {
                DragFinished(true);
            }
           
        }

        void canvasTableModel_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (_isDown)
            {
                if ((_isDragging == false) && ((Math.Abs(e.GetPosition(this.canvasTableModel).X - _startPoint.X) > SystemParameters.MinimumHorizontalDragDistance) ||
                    (Math.Abs(e.GetPosition(this.canvasTableModel).Y - _startPoint.Y) > SystemParameters.MinimumVerticalDragDistance)))
                {
                    DragStarted();
                }
                if (_isDragging)
                {
                    DragMoved();
                }
            }
           
        }

        void canvasTableModel_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDown)
            {
                DragFinished(false);
                e.Handled = true;
            }
        }

        void canvasTableModel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           

            if (e.Source == this.canvasTableModel)
            {
            }
            else
            {
                _isDown = true;
                _startPoint = e.GetPosition(this.canvasTableModel);
                
                _originalElement = e.Source as UIElement;
               
                btnCurrentTable = e.Source as Button;
                
                this.canvasTableModel.CaptureMouse();
                e.Handled = true;

            }
        }

        private void DragFinished(bool cancelled)
        {
            System.Windows.Input.Mouse.Capture(null);
            if (_isDragging)
            {
                AdornerLayer.GetAdornerLayer(_overlayElement.AdornedElement).Remove(_overlayElement);

                if (cancelled == false)
                {
                   // Canvas.SetTop(_originalElement, _originalTop + _overlayElement.TopOffset);
                   // Canvas.SetLeft(_originalElement, _originalLeft + _overlayElement.LeftOffset);
                   // MessageBox.Show(_overlayElement.PointFromScreen.TopOffset.ToString());
                   // MessageBox.Show(_overlayElement.LeftOffset.ToString());
                    
                    System.Data.DataRowView rowView = btnCurrentTable.DataContext as DataRowView;
                    
                    double new_row_no = Math.Floor ( int.Parse(rowView["display_row_no"].ToString()) + ( (_overlayElement.TopOffset)/50) );
                     double new_column_no = Math.Floor ( int.Parse(rowView["display_column_no"].ToString()) + ( (_overlayElement.LeftOffset)/50) );
                     rowView["display_row_no"] = new_row_no;
                     rowView["display_column_no"] = new_column_no;

                     _presenter.SetTablePosition(rowView);
               
                    
                }
                _overlayElement = null;

            }
           
            _isDragging = false;
            _isDown = false;
        }

        private void DragStarted()
        {
            _isDragging = true;
            _originalLeft = Canvas.GetLeft(_originalElement);
            _originalTop = Canvas.GetTop(_originalElement);

            _overlayElement = new SimpleCircleAdorner(_originalElement);
            AdornerLayer layer = AdornerLayer.GetAdornerLayer(_originalElement);
            layer.Add(_overlayElement);

        }

        private void DragMoved()
        {
            Point CurrentPosition = System.Windows.Input.Mouse.GetPosition(this.canvasTableModel);

            _overlayElement.LeftOffset = CurrentPosition.X - _startPoint.X;
            _overlayElement.TopOffset = CurrentPosition.Y - _startPoint.Y;

        }


        void cmbBoxTableGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                _presenter.FilterTableDetailsByTableGroupNo(int.Parse(cmbBoxTableGroup.SelectedValue.ToString()));
            }
            catch
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please set up table groups first", "Setup table", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        
        void myCollectionView_CurrentChanged(object sender, EventArgs e)
        {
            
            DrawTableModel();
        
        }

        private void LoadResources()
        {
            base.Resources.MergedDictionaries.Add((ResourceDictionary)Application.LoadComponent(new Uri(@"EclipsePOS.WPF.SystemManager.Infrastructure;;;component/Skins/BaseSkin.xaml", UriKind.Relative)));
        }


        #region ITableGroupView implementations

        public void SetTableDataContext(object data)
        {
          
            this.DataContext = data;
            myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(this.DataContext);
            myCollectionView.CurrentChanged += new EventHandler(myCollectionView_CurrentChanged);
          
           
        }

        public void DrawTableModel()
        {
                  
            gridTableModel.Children.Clear();
            //myCollectionView = (CollectionView)CollectionViewSource.GetDefaultView(this.DataContext);
            foreach (object obj in myCollectionView)
            {
                System.Data.DataRowView rowView = obj as System.Data.DataRowView;
                Button btn = new Button();
                btn.Style = (Style)FindResource("btnXLS");
                btn.DataContext = rowView;
                gridTableModel.Children.Add(btn);
                
            }
        }

        void btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            System.Data.DataRowView rowView = btn.DataContext as DataRowView;
            //this.myCollectionView.MoveCurrentTo(rowView);
            _presenter.SetTablePosition(rowView);
            
        }

      /*  void TableModelbtn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            System.Data.DataRowView rowView = btn.DataContext as DataRowView;
            //this.myCollectionView.MoveCurrentTo(rowView);
            _presenter.SetTablePosition(rowView);

        }
       * */


       

         public void SetTableGroupDataContext(IEnumerable data)
         {
             this.cmbBoxTableGroup.ItemsSource = data;
         }
        

        public void SetSelectedItemCursor()
        {
            //this.tableGroupListView.ScrollIntoView(tableGroupListView.Items.CurrentItem);
            //this.tableGroupListView.SelectedItem = tableGroupListView.Items.CurrentItem;
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

        public int SelectedTableGroupNo()
        {
            int tableGroupNo = 0;

            if (this.cmbBoxTableGroup.SelectedValue != null)
            {
                tableGroupNo = int.Parse(this.cmbBoxTableGroup.SelectedValue.ToString());
            }

            return tableGroupNo;
        }
        

        #endregion

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


    // Adorners must subclass the abstract base class Adorner.
    public class SimpleCircleAdorner : Adorner
    {
        // Be sure to call the base class constructor.
        public SimpleCircleAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
            VisualBrush _brush = new VisualBrush(adornedElement);

            _child = new Rectangle();
            _child.Width = adornedElement.RenderSize.Width;
            _child.Height = adornedElement.RenderSize.Height;


            DoubleAnimation animation = new DoubleAnimation(0.3, 1, new Duration(TimeSpan.FromSeconds(1)));
            animation.AutoReverse = true;
            animation.RepeatBehavior = System.Windows.Media.Animation.RepeatBehavior.Forever;
            _brush.BeginAnimation(System.Windows.Media.Brush.OpacityProperty, animation);

            _child.Fill = _brush;
        }

        // A common way to implement an adorner's rendering behavior is to override the OnRender
        // method, which is called by the layout subsystem as part of a rendering pass.
        protected override void OnRender(DrawingContext drawingContext)
        {
            // Get a rectangle that represents the desired size of the rendered element
            // after the rendering pass.  This will be used to draw at the corners of the 
            // adorned element.
         //   Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);

            // Some arbitrary drawing implements.
         //   SolidColorBrush renderBrush = new SolidColorBrush(Colors.Green);
         //   renderBrush.Opacity = 0.2;
         //   Pen renderPen = new Pen(new SolidColorBrush(Colors.Navy), 1.5);
         //   double renderRadius = 5.0;

            // Just draw a circle at each corner.
          //  drawingContext.DrawRectangle(renderBrush, renderPen, adornedElementRect);
           // drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopLeft, renderRadius, renderRadius);
           // drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.TopRight, renderRadius, renderRadius);
           // drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomLeft, renderRadius, renderRadius);
           // drawingContext.DrawEllipse(renderBrush, renderPen, adornedElementRect.BottomRight, renderRadius, renderRadius);
        }

        protected override Size MeasureOverride(Size constraint)
        {
            _child.Measure(constraint);
            return _child.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            _child.Arrange(new Rect(finalSize));
            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return _child;
        }

        protected override int VisualChildrenCount
        {
            get
            {
                return 1;
            }
        }

        public double LeftOffset
        {
            get
            {
                return _leftOffset;
            }
            set
            {
                _leftOffset = value;
                UpdatePosition();
            }
        }

        public double TopOffset
        {
            get
            {
                return _topOffset;
            }
            set
            {
                _topOffset = value;
                UpdatePosition();

            }
        }

        private void UpdatePosition()
        {
            AdornerLayer adornerLayer = this.Parent as AdornerLayer;
            if (adornerLayer != null)
            {
                adornerLayer.Update(AdornedElement);
            }
        
        
        }


       


        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            GeneralTransformGroup result = new GeneralTransformGroup();
            result.Children.Add(base.GetDesiredTransform(transform));
            result.Children.Add(new TranslateTransform(_leftOffset, _topOffset));
            return result;
        }



        private Rectangle _child = null;
        private double _leftOffset = 0;
        private double _topOffset = 0;
    }
}
