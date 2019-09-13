using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;


namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.Users
{
    public class UsersViewPresenter
    {
        private IUsersView _view;
        private CollectionView _colView;

        private EclipsePOS.WPF.SystemManager.Data.usersDataSet usersData;
      
        private EclipsePOS.WPF.SystemManager.Data.usersDataSetTableAdapters.TableAdapterManager taManager = new EclipsePOS.WPF.SystemManager.Data.usersDataSetTableAdapters.TableAdapterManager();

        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;


        public UsersViewPresenter()
        {
            MoveToFirstCommand = new DelegateCommand<object>(OnMoveToFirstCommandExecute, OnMoveToFirstCommandCanExecute);
            MoveToPreviousCommand = new DelegateCommand<object>(OnMoveToPreviousCommandExecute, OnMoveToPreviousCommandCanExecute);
            MoveToNextCommand = new DelegateCommand<object>(OnMoveToNextCommandExecute, OnMoveToNextCommandCanExecute);
            MoveToLastCommand = new DelegateCommand<object>(OnMoveToLastCommandExecute, OnMoveToLastCommandCanExecute);

            DeleteCommand = new DelegateCommand<object>(OnDeleteCommandExecute, OnDeleteCommandCanExecute);
            AddCommand = new DelegateCommand<object>(OnAddCommandExecute, OnAddCommandCanExecute);
            RevertCommand = new DelegateCommand<object>(OnRevertCommandExecute, OnRevertCommandCanExecute);
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);
        }

        public IUsersView View
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

        public void OnShowUsers()
        {

            //Users
            usersData = new EclipsePOS.WPF.SystemManager.Data.usersDataSet();
            EclipsePOS.WPF.SystemManager.Data.usersDataSetTableAdapters.subTableAdapter usersTa = new EclipsePOS.WPF.SystemManager.Data.usersDataSetTableAdapters.subTableAdapter();
            usersTa.Fill(usersData.sub);
            View.SetUsersDataContext(usersData.sub);

            _colView = CollectionViewSource.GetDefaultView(usersData.sub) as CollectionView;
            taManager.subTableAdapter = usersTa;

            
            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetAddBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);


        }


        public void SetUserPassword(string password)
        {
            EclipsePOS.WPF.SystemManager.Data.usersDataSet.subRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row as EclipsePOS.WPF.SystemManager.Data.usersDataSet.subRow;
            dataRow.subscriber_pass = password.Trim();

        }

        #region MoveToFirst Command

        public void OnMoveToFirstCommandExecute(object obj)
        {
            _colView.MoveCurrentToFirst();
            View.SetSelectedItemCursor();
        }

        public bool OnMoveToFirstCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion
        #region MoveToPrevioust Command

        public void OnMoveToPreviousCommandExecute(object obj)
        {
            _colView.MoveCurrentToPrevious();
            View.SetSelectedItemCursor();
        }

        public bool OnMoveToPreviousCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region MoveToNext Command

        public void OnMoveToNextCommandExecute(object obj)
        {
            _colView.MoveCurrentToNext();
            View.SetSelectedItemCursor();
        }

        public bool OnMoveToNextCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region MoveToLast Command

        public void OnMoveToLastCommandExecute(object obj)
        {
            _colView.MoveCurrentToLast();
            View.SetSelectedItemCursor();
        }

        public bool OnMoveToLastCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Delete Command

        public void OnDeleteCommandExecute(object obj)
        {
            System.Data.DataRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;
            dataRow.Delete();

        }

        public bool OnDeleteCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Add Command

        public void OnAddCommandExecute(object obj)
        {
            if (!usersData.HasErrors)
            {

                EclipsePOS.WPF.SystemManager.Data.usersDataSet.subRow dataRow = usersData.sub.NewsubRow();

                //dataRow.subscriber_id = 999;
                dataRow.subscriber_name  = "";
                dataRow.subscriber_pass = "";
                
                usersData.sub.AddsubRow(dataRow);

                _colView.MoveCurrentToLast();
                View.SetSelectedItemCursor();
                View.SetFocusToFirstElement();
            }

        }

        public bool OnAddCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Revert Command

        public void OnRevertCommandExecute(object obj)
        {
            if (usersData.HasChanges())
            {
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to loose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    usersData.RejectChanges();
                }
            }

        }

        public bool OnRevertCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region Save Command

        public void OnSaveCommandExecute(object obj)
        {
            if (usersData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    if (usersData.HasChanges())
                    {
                        if (taManager.UpdateAll(usersData) > 0)
                        {
                            Microsoft.Windows.Controls.MessageBox.Show("Saved", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }
                catch
                {
                    Microsoft.Windows.Controls.MessageBox.Show("Unable to save changes" , "Save command", MessageBoxButton.OK, MessageBoxImage.Error);
                    usersData.RejectChanges();
                }
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
