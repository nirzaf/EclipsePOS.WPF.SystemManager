using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.IO.Packaging;
using System.Printing;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Documents.Serialization;
using System.Windows.Media;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;

using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;


namespace EclipsePOS.WPF.SystemManager.ReportsAndEnquiries.Views.XPSDoc
{
    public class XPSDocViewPresenter
    {
        private IXPSDocView _view;
        public DelegateCommand<object> SaveCommand;


        public XPSDocViewPresenter()
        {

            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
        }


        public IXPSDocView View
        {
            set
            {
                _view = value;
            }
            get
            {
                return _view;
            }
        }

        public void OnShowXPSDoc()
        {
            View.SetSaveToDiskBtnDataContext(this.SaveCommand);
        }


        #region Save Command

        public void OnSaveCommandExecute(object obj)
        {
            
            Microsoft.Win32.SaveFileDialog saveDialog = new Microsoft.Win32.SaveFileDialog();
            saveDialog.FileName = "";
            saveDialog.Filter = "XPS Files(*.XPS)|*.xps";
            if (saveDialog.ShowDialog() == true)
            {
                string fileName = saveDialog.FileName;
                File.Delete(fileName);
                XpsDocument xpsDoc = new XpsDocument(fileName, FileAccess.ReadWrite);
                XpsDocumentWriter xpsdw = XpsDocument.CreateXpsDocumentWriter(xpsDoc);
                xpsdw.Write(View.GetDocument.Document.DocumentPaginator);
                xpsDoc.Close();
                Microsoft.Windows.Controls.MessageBox.Show("Report saved successfully", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
        
            }
        }

        public bool OnSaveCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion 




    }
}
