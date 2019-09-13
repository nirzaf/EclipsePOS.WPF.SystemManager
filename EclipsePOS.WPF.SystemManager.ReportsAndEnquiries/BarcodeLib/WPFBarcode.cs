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
using System.Globalization;

using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.BarcodeLib.Symbologies;
using EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.BarcodeLib;


namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.BarcodeLib
{
    #region Enums
    public enum TYPE : int { UNSPECIFIED, UPCA, UPCE, UPC_SUPPLEMENTAL_2DIGIT, UPC_SUPPLEMENTAL_5DIGIT, EAN13, EAN8, Interleaved2of5, Standard2of5, Industrial2of5, CODE39, CODE39Extended, Codabar, BOOKLAND, ISBN, JAN13, MSI_Mod10, MSI_2Mod10, MSI_Mod11, MSI_Mod11_Mod10, Modified_Plessey, CODE11, USD8, UCC12, UCC13, LOGMARS, CODE128, CODE128A, CODE128B, CODE128C, CODE93 };
    public enum SaveTypes : int { JPG, BMP, PNG, GIF, TIFF, UNSPECIFIED };
    #endregion


    public class WPFBarcode
    {
        

        #region Variables
        private IBarcode ibarcode = new BarcodeLib.Symbologies.Blank();
        private string Raw_Data = "";
        private string Encoded_Value = "";
        private string _Country_Assigning_Manufacturer_Code = "N/A";
        private TYPE Encoded_Type = TYPE.UNSPECIFIED;
        private Image _Encoded_Image = null;
        private Color _ForeColor = Colors.Black;
        private Color _BackColor = Colors.White;
        private int _Width = 300;
        private int _Height = 150;
        private bool _IncludeLabel = false;
        private double _EncodingTime = 0;
        private string _XML = "";
      //  private ImageFormat _ImageFormat = ImageFormat.Jpeg;
        private string itemText = "";
        private double price;
        private SolidColorBrush _BorderColor = Brushes.Black;
        private bool _printBorder = false;
        #endregion


         #region Constructors
        /// <summary>
        /// Default constructor.  Does not populate the raw data.  MUST be done via the RawData property before encoding.
        /// </summary>
        public WPFBarcode()
        {
            //constructor
        }//Barcode
        /// <summary>
        /// Constructor. Populates the raw data. No whitespace will be added before or after the barcode.
        /// </summary>
        /// <param name="data">String to be encoded.</param>
        public WPFBarcode(string data)
        {
            //constructor
            this.Raw_Data = data;
        }//Barcode

        public WPFBarcode(string data, TYPE iType)
        {
            this.Raw_Data = data;
            this.Encoded_Type = iType;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the raw data to encode.
        /// </summary>
        public string RawData
        {
            get { return Raw_Data; }
            set { Raw_Data = value; }
        }//RawData
        /// <summary>
        /// Gets the encoded value.
        /// </summary>
        public string EncodedValue
        {
            get { return Encoded_Value; }
        }//EncodedValue
        /// <summary>
        /// Gets the Country that assigned the Manufacturer Code.
        /// </summary>
        public string Country_Assigning_Manufacturer_Code
        {
            get { return _Country_Assigning_Manufacturer_Code; }
        }//Country_Assigning_Manufacturer_Code
        /// <summary>
        /// Gets or sets the Encoded Type (ex. UPC-A, EAN-13 ... etc)
        /// </summary>
        public TYPE EncodedType
        {
            set { Encoded_Type = value; }
            get { return Encoded_Type; }
        }//EncodedType


        /// <summary>
        /// Gets the Image of the generated barcode.
        /// </summary>
        public Image EncodedImage
        {
            get
            {
                return _Encoded_Image;
            }
        }//EncodedImage
        /// <summary>
        /// Gets or sets the color of the bars. (Default is black)
        /// </summary>
        public Color ForeColor
        {
            get { return this._ForeColor; }
            set { this._ForeColor = value; }
        }//ForeColor
        /// <summary>
        /// Gets or sets the background color. (Default is white)
        /// </summary>
        public Color BackColor
        {
            get { return this._BackColor; }
            set { this._BackColor = value; }
        }//BackColor
        /// <summary>
        /// Gets or sets the width of the image to be drawn. (Default is 300 pixels)
        /// </summary>
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        /// <summary>
        /// Gets or sets the height of the image to be drawn. (Default is 150 pixels)
        /// </summary>
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        /// <summary>
        /// Gets or sets whether a label should be drawn below the image.
        /// </summary>
        public bool IncludeLabel
        {
            set { this._IncludeLabel = value; }
            get { return this._IncludeLabel; }
        }
        /// <summary>
        /// Gets or sets the amount of time in milliseconds that it took to encode and draw the barcode.
        /// </summary>
        public double EncodingTime
        {
            get { return _EncodingTime; }
            set { _EncodingTime = value; }
        }
        /// <summary>
        /// Gets the XML representation of the Barcode data and image.
        /// </summary>
        public string XML
        {
            get { return _XML; }
        }
        /// <summary>
        /// Gets or sets the image format to use when encoding and returning images. (Jpeg is default)
        /// </summary>
       // public ImageFormat ImageFormat
       // {
       //     get { return _ImageFormat; }
       //     set { _ImageFormat = value; }
       // }
        

        /// <summary>
        /// Gets the list of errors encountered.
        /// </summary>
        public List<string> Errors
        {
            get { return this.ibarcode.Errors; }
        }


        /// <summary>
        /// Gets or sets the item text.
        /// </summary>
        public string ItemText
        {
            get { return itemText; }
            set { itemText = value; }
        }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        public double Price
        {
            get { return price; }
            set { price = value; }
        }//RawData


        /// <summary>
        /// Gets or sets the color of the bars. (Default is black)
        /// </summary>
        public SolidColorBrush BorderColor
        {
            get { return this._BorderColor; }
            set { this._BorderColor = value; }
        }//ForeColor

        /// <summary>
        /// Gets or sets the color of the bars. (Default is black)
        /// </summary>
        public bool PintBorder
        {
            get { return this._printBorder; }
            set { this._printBorder = value; }
        }

       
        #endregion  


        #region Functions
        #region General Encode
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, string StringToEncode, int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            return Encode(iType, StringToEncode);
        }//Encode(TYPE, string, int, int)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <param name="Width">Width of the resulting barcode.(pixels)</param>
        /// <param name="Height">Height of the resulting barcode.(pixels)</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, string StringToEncode, Color ForeColor, Color BackColor, int Width, int Height)
        {
            this.Width = Width;
            this.Height = Height;
            return Encode(iType, StringToEncode, ForeColor, BackColor);
        }//Encode(TYPE, string, Color, Color, int, int)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <param name="DrawColor">Foreground color</param>
        /// <param name="BackColor">Background color</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, string StringToEncode, Color ForeColor, Color BackColor)
        {
            this.BackColor = BackColor;
            this.ForeColor = ForeColor;
            return Encode(iType, StringToEncode);
        }//(Image)Encode(Type, string, Color, Color)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        /// <param name="StringToEncode">Raw data to encode.</param>
        /// <returns>Image representing the barcode.</returns>
        public Image Encode(TYPE iType, string StringToEncode)
        {
            Raw_Data = StringToEncode;
            return Encode(iType);
        }//(Image)Encode(TYPE, string)
        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.  Also generates an Image of the barcode.
        /// </summary>
        /// <param name="iType">Type of encoding to use.</param>
        internal Image Encode(TYPE iType)
        {
            Encoded_Type = iType;
            return Encode();
        }//Encode()


        public Image Encode(TYPE iType, string StringToEncode, Color ForeColor, Color BackColor, int Width, int Height, string itemText, double price)
        {
            this.Width = Width;
            this.Height = Height;
            this.ItemText = itemText;
            this.Price = price;
            return Encode(iType, StringToEncode, ForeColor, BackColor);
        }




        /// <summary>
        /// Encodes the raw data into binary form representing bars and spaces.
        /// </summary>
        internal Image Encode()
        {
            ibarcode.Errors.Clear();

            DateTime dtStartTime = DateTime.Now;

            //make sure there is something to encode
            if (Raw_Data.Trim() == "")
                throw new Exception("EENCODE-1: Input data not allowed to be blank.");

            if (this.EncodedType == TYPE.UNSPECIFIED)
                throw new Exception("EENCODE-2: Symbology type not allowed to be unspecified.");

            this.Encoded_Value = "";
            this._Country_Assigning_Manufacturer_Code = "N/A";

            switch (this.Encoded_Type)
            {
                case TYPE.UCC12:
                case TYPE.UPCA: //Encode_UPCA();
                    ibarcode = new UPCA(Raw_Data);
                    break;
                case TYPE.UCC13:
                case TYPE.EAN13: //Encode_EAN13();
                    ibarcode = new EAN13(Raw_Data);
                    break;
                case TYPE.Interleaved2of5: //Encode_Interleaved2of5();
                    ibarcode = new Interleaved2of5(Raw_Data);
                    break;
                case TYPE.Industrial2of5:
                case TYPE.Standard2of5: //Encode_Standard2of5();
                    ibarcode = new Standard2of5(Raw_Data);
                    break;
                case TYPE.LOGMARS:
                case TYPE.CODE39: //Encode_Code39();
                    ibarcode = new Code39(Raw_Data);
                    break;
                case TYPE.CODE39Extended:
                    ibarcode = new Code39(Raw_Data, true);
                    break;
                case TYPE.Codabar: //Encode_Codabar();
                    ibarcode = new Codabar(Raw_Data);
                    break;
              //  case TYPE.PostNet: //Encode_PostNet();
              //      ibarcode = new Postnet(Raw_Data);
              //      break;
                case TYPE.ISBN:
                case TYPE.BOOKLAND: //Encode_ISBN_Bookland();
                    ibarcode = new ISBN(Raw_Data);
                    break;
                case TYPE.JAN13: //Encode_JAN13();
                    ibarcode = new JAN13(Raw_Data);
                    break;
                case TYPE.UPC_SUPPLEMENTAL_2DIGIT: //Encode_UPCSupplemental_2();
                    ibarcode = new UPCSupplement2(Raw_Data);
                    break;
                case TYPE.MSI_Mod10:
                case TYPE.MSI_2Mod10:
                case TYPE.MSI_Mod11:
                case TYPE.MSI_Mod11_Mod10:
                case TYPE.Modified_Plessey: //Encode_MSI();
                    ibarcode = new MSI(Raw_Data, Encoded_Type);
                    break;
                case TYPE.UPC_SUPPLEMENTAL_5DIGIT: //Encode_UPCSupplemental_5();
                    ibarcode = new UPCSupplement5(Raw_Data);
                    break;
                case TYPE.UPCE: //Encode_UPCE();
                    ibarcode = new UPCE(Raw_Data);
                    break;
                case TYPE.EAN8: //Encode_EAN8();
                    ibarcode = new EAN8(Raw_Data);
                    break;
                case TYPE.USD8:
                case TYPE.CODE11: //Encode_Code11();
                    ibarcode = new Code11(Raw_Data);
                    break;
                case TYPE.CODE128: //Encode_Code128();
                    ibarcode = new Code128(Raw_Data);
                    break;
                case TYPE.CODE128A:
                    ibarcode = new Code128(Raw_Data, Code128.TYPES.A);
                    break;
                case TYPE.CODE128B:
                    ibarcode = new Code128(Raw_Data, Code128.TYPES.B);
                    break;
                case TYPE.CODE128C:
                    ibarcode = new Code128(Raw_Data, Code128.TYPES.C);
                    break;
               // case TYPE.ITF14:
               //     ibarcode = new ITF14(Raw_Data);
               //     break;
                case TYPE.CODE93:
                    ibarcode = new Code93(Raw_Data);
                    break;
                default: throw new Exception("EENCODE-2: Unsupported encoding type specified.");
            }//switch

            this.Encoded_Value = ibarcode.Encoded_Value;
            this.Raw_Data = ibarcode.RawData;
            this._EncodingTime = ((TimeSpan)(DateTime.Now - dtStartTime)).TotalMilliseconds;

           // _Encoded_Image = (Image)Generate_Image();
            _Encoded_Image = this.Generate_vector_image();

            //_XML = GetXML();

            return EncodedImage;
        }//Encode



        private Image Generate_vector_image()
        {


            int iBarWidth = (Width-40) / Encoded_Value.Length;
            int shiftAdjustment = ((Width-40) % Encoded_Value.Length) / 2;

        //    Canvas canvas = new Canvas();
            
            DrawingGroup drawingGroupWithoutGuidelines = new DrawingGroup();

            DrawingContext drawingContext = drawingGroupWithoutGuidelines.Open();

            //Draw a white border
           // drawingContext.DrawRectangle(Brushes.White, new Pen(Brushes.YellowGreen, 1), new Rect(0, 0, Width-1, Height-1));

            if (this.PintBorder)
            {
                drawingContext.DrawRoundedRectangle(Brushes.White, new Pen(this.BorderColor, 2), new Rect(5, 5, Width-35 , Height - 20), 5, 5);
            }

            // Print item text
            if (this.itemText.Length > Width - 100)
            {
                this.itemText = this.itemText.Substring(0, Width - 100);
            }
            FormattedText formattedItemText = new FormattedText(this.ItemText, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Verdana"), 14, Brushes.Black);
            formattedItemText.TextAlignment = TextAlignment.Left;
            drawingContext.DrawText(formattedItemText, new Point(20, 20));
           
            
            //Print price
            FormattedText formattedPrice = new FormattedText(String.Format("{0:c}", this.Price),
                CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Verdana"), 36, Brushes.Black);
            formattedPrice.SetFontWeight(FontWeights.Bold);
            formattedPrice.TextAlignment = TextAlignment.Right;
            drawingContext.DrawText(formattedPrice, new Point(Width-40, 40));

            FormattedText formattedText = new FormattedText(this.RawData,
                            CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight, new Typeface("Verdana"), 14, Brushes.Black);
            formattedText.TextAlignment = TextAlignment.Center;
            drawingContext.DrawText(formattedText, new Point(Width / 2, Height-35 ));

            
            
            drawingContext.Close();

            Pen pen = new Pen(Brushes.Black, iBarWidth);

            int pos = 0;

            while (pos < Encoded_Value.Length)
            {
                if (Encoded_Value[pos] == '1')
                {
                   // drawingContext.DrawLine(pen, new Point(pos * iBarWidth + shiftAdjustment, 25), new Point(pos * iBarWidth + shiftAdjustment, Height));
                    GeometryDrawing lineL = new GeometryDrawing(
                    Brushes.Black,
                    pen,
                    new LineGeometry( new Point(pos * iBarWidth + shiftAdjustment, 90), new Point(pos * iBarWidth + shiftAdjustment, Height-35 ))
                        );
                    drawingGroupWithoutGuidelines.Children.Add(lineL);
                }
                 pos++;
            }//while

           


            // Use an Image control and a DrawingImage to
            // display the drawing.
            DrawingImage drawingImage01 = new DrawingImage(drawingGroupWithoutGuidelines);

            // Freeze the DrawingImage for performance benefits.
            drawingImage01.Freeze();
        
            Image image01 = new Image();
            image01.Source = drawingImage01;
            image01.Stretch = Stretch.None;
            image01.HorizontalAlignment = HorizontalAlignment.Center;
            image01.VerticalAlignment = VerticalAlignment.Center;
            image01.Margin= new Thickness(0, 10, 0, 10);
           
            return image01;
        }


        #endregion
        
        #endregion


    }
}
