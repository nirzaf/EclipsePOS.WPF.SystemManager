using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.ComponentModel;
using System.Windows;

using Microsoft.Practices.Composite.Presentation.Events;
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

using EclipsePOS.WPF.SystemManager.PosSetup.Views.PosKey;
using EclipsePOS.WPF.SystemManager.Data.Util;
using EclipsePOS.WPF.SystemManager.Data;




namespace EclipsePOS.WPF.SystemManager.PosSetup.Views.MenuRoot
{
    public class MenuRootPresenter
    {
        private IUnityContainer _container;
        private IRegionManager _regionManager;

        private IMenuRoot _view;
        private CollectionView _colView;
        private CollectionView _colViewPosKeys;
        

        private EclipsePOS.WPF.SystemManager.Data.posConfigDataSet posConfigData;
        private EclipsePOS.WPF.SystemManager.Data.posKeyDataSet posKeyData;
        private EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSet menuPanelsData;
       // private EclipsePOS.WPF.SystemManager.Data.menuConfigDataSet menuConfigData;

        private EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.TableAdapterManager menuPanelTaManager = new EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.TableAdapterManager();
        private EclipsePOS.WPF.SystemManager.Data.posKeyDataSetTableAdapters.TableAdapterManager posKeyTaManager = new  EclipsePOS.WPF.SystemManager.Data.posKeyDataSetTableAdapters.TableAdapterManager();

        public DelegateCommand<object> MoveToFirstCommand;
        public DelegateCommand<object> MoveToPreviousCommand;
        public DelegateCommand<object> MoveToNextCommand;
        public DelegateCommand<object> MoveToLastCommand;

        public DelegateCommand<object> DeleteCommand;
        public DelegateCommand<object> AddCommand;
        public DelegateCommand<object> RevertCommand;
        public DelegateCommand<object> SaveCommand;

        public DelegateCommand<object> AddPosKeyCommand;
        public DelegateCommand<object> DeletePosKeyCommand;
        public DelegateCommand<object> ChangePosKeyCommand;

        

        
        public MenuRootPresenter(IUnityContainer container, IRegionManager regionManager)
        {
            this._container = container;
            this._regionManager = regionManager;

            MoveToFirstCommand = new DelegateCommand<object>(OnMoveToFirstCommandExecute, OnMoveToFirstCommandCanExecute);
            MoveToPreviousCommand = new DelegateCommand<object>(OnMoveToPreviousCommandExecute, OnMoveToPreviousCommandCanExecute);
            MoveToNextCommand = new DelegateCommand<object>(OnMoveToNextCommandExecute, OnMoveToNextCommandCanExecute);
            MoveToLastCommand = new DelegateCommand<object>(OnMoveToLastCommandExecute, OnMoveToLastCommandCanExecute);

            DeleteCommand = new DelegateCommand<object>(OnDeleteCommandExecute, OnDeleteCommandCanExecute);
            AddCommand = new DelegateCommand<object>(OnAddCommandExecute, OnAddCommandCanExecute);
            RevertCommand = new DelegateCommand<object>(OnRevertCommandExecute, OnRevertCommandCanExecute);
            SaveCommand = new DelegateCommand<object>(OnSaveCommandExecute, OnSaveCommandCanExecute);

            AddPosKeyCommand = new DelegateCommand<object>(OnAddPosKeyCommandExecute, OnAddPosKeyCommandCanExecute);
            DeletePosKeyCommand = new DelegateCommand<object>(OnDeletePosKeyCommandExecute, OnDeletePosKeyCommandCanExecute);
            ChangePosKeyCommand = new DelegateCommand<object>(OnChangePosKeyCommandExecute, OnChangePosKeyCommandCanExecute);

        }

        

        public IMenuRoot View
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

        public void OnShowMenuRoot()
        {
            //PosConfigData
            posConfigData = new EclipsePOS.WPF.SystemManager.Data.posConfigDataSet();
            EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter posConfigTa = new EclipsePOS.WPF.SystemManager.Data.posConfigDataSetTableAdapters.pos_configTableAdapter();
            posConfigTa.Fill(posConfigData.pos_config);
            View.SetPosConfigDataContext(posConfigData.pos_config);


            //MenuRoot
            menuPanelsData = new EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSet();
            EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.menu_panelsTableAdapter menuPanelsTa = new  EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSetTableAdapters.menu_panelsTableAdapter();
            menuPanelsTa.Fill(menuPanelsData.menu_panels);
            View.SetMenuRootDataContext(menuPanelsData.menu_panels);

            _colView = CollectionViewSource.GetDefaultView(menuPanelsData.menu_panels) as CollectionView;
            menuPanelTaManager.menu_panelsTableAdapter = menuPanelsTa;

            //PosKey
            posKeyData = new  EclipsePOS.WPF.SystemManager.Data.posKeyDataSet();
            EclipsePOS.WPF.SystemManager.Data.posKeyDataSetTableAdapters.pos_keyTableAdapter posKeyTa = new  EclipsePOS.WPF.SystemManager.Data.posKeyDataSetTableAdapters.pos_keyTableAdapter();
            posKeyTa.Fill(posKeyData.pos_key);
            View.SetPosKeyDataContext(posKeyData.pos_key);

            _colViewPosKeys = CollectionViewSource.GetDefaultView(posKeyData.pos_key) as CollectionView;
            posKeyTaManager.pos_keyTableAdapter = posKeyTa;


            
           


            View.SetMoveToFirstBtnDataContext(MoveToFirstCommand);
            View.SetMoveToPreviousBtnDataContext(MoveToPreviousCommand);
            View.SetMoveToNextBtnDataContext(MoveToNextCommand);
            View.SetMoveToLastBtnDataContext(MoveToLastCommand);

            View.SetDeleteBtnDataContext(DeleteCommand);
            View.SetAddBtnDataContext(AddCommand);
            View.SetRevertBtnDataContext(RevertCommand);
            View.SetSaveBtnDataContext(SaveCommand);
            View.SetAddPosKeyBtnDataContext(AddPosKeyCommand);
            View.SetChangePosKeyBtnDataContext(ChangePosKeyCommand);
            View.SetDeletePosKeyBtnDataContext(DeletePosKeyCommand);
            
        }


        public void OnFilter(int configNo)
        {

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(posKeyData.pos_key) as BindingListCollectionView;
            //view1.CustomFilter = "role_id = 1001";
            try
            {
                System.Data.DataRow menuPanelRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;
                if (menuPanelRow != null)
                {
                   view1.CustomFilter = "panel_id =" + menuPanelRow["panel_id"].ToString()+ "and config_no =" + configNo.ToString();
                }
             }
            catch
            {
            }
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
            if (_colView.IsCurrentBeforeFirst) _colView.MoveCurrentToFirst();
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
            if (_colView.IsCurrentAfterLast) _colView.MoveCurrentToLast();
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
            try
            {
                System.Data.DataRow dataRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;
                dataRow.Delete();
            }
            catch
            {
            }

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
            if (!menuPanelsData.HasErrors)
            {

               EclipsePOS.WPF.SystemManager.Data.menuPanelsDataSet.menu_panelsRow dataRow = menuPanelsData.menu_panels.Newmenu_panelsRow();

                dataRow.config_no = View.SelectedConfigNo();
                dataRow.panel_id = 0;
                dataRow.panel_name = "";
                dataRow.panel_class_name = "";

                menuPanelsData.menu_panels.Addmenu_panelsRow(dataRow);

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
            if (menuPanelsData.HasChanges() || posKeyData.HasChanges())
            {   
                MessageBoxResult result = Microsoft.Windows.Controls.MessageBox.Show("Are sure you want to lose all your changes", "Revert command", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    posKeyData.RejectChanges();
                    menuPanelsData.RejectChanges();
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
            if (menuPanelsData.HasErrors || posKeyData.HasErrors )
            {
                Microsoft.Windows.Controls.MessageBox.Show("Please correct the errors first", "Save command", MessageBoxButton.OK,  MessageBoxImage.Error);
            }
            else
            {
                if (menuPanelsData.HasChanges())
                {
                    if (menuPanelTaManager.UpdateAll(menuPanelsData) > 0)
                    {
                        Microsoft.Windows.Controls.MessageBox.Show("Saved pos menus", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                if (posKeyData.HasChanges())
                {
                    if (posKeyTaManager.UpdateAll(posKeyData) > 0 )
                    {
                        Microsoft.Windows.Controls.MessageBox.Show("Saved pos keys", "Save command", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
           

        }

        public bool OnSaveCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Add Pos Key Command

        public void OnAddPosKeyCommandExecute(object obj)
        {
            if (menuPanelsData.HasErrors)
            {
                Microsoft.Windows.Controls.MessageBox.Show("Correct erros and save changes befor createing pos keys", "Add command", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
                if (menuPanelsData.HasChanges() )
                {
                    Microsoft.Windows.Controls.MessageBox.Show("Save changes befor createing pos keys", "Add command", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                    if (_colView.CurrentItem != null)
                    {

                       this.OnFilter( View.SelectedConfigNo() );
                        
                        EclipsePOS.WPF.SystemManager.Data.posKeyDataSet.pos_keyRow dataRow = posKeyData.pos_key.Newpos_keyRow();

                        System.Data.DataRow menuPanelRow = ((System.Data.DataRowView)_colView.CurrentItem).Row;

                        this.GetNextKeyCode();

                        dataRow.config_no = int.Parse(menuPanelRow["config_no"].ToString());
                        dataRow.panel_id = int.Parse(menuPanelRow["panel_id"].ToString());
                        dataRow.key_text = "";
                        dataRow.key_type = 0;
                        dataRow.key_val = 0;
                        dataRow.key_code = this.GetNextKeyCode();
                        dataRow.device_type = 0;
                        dataRow.x_loc = 0;
                        dataRow.y_loc = 0;
                        dataRow.key_height = 0;
                        dataRow.key_width = 0;
                        dataRow.fg_color = 0;
                        dataRow.bg_color = 0;
                        dataRow.attr = 0;
                        dataRow.flags = "";
                        dataRow.logout_disable = 1;
                        dataRow.key_class = "";
                        dataRow.param = "";
                        dataRow.image = "";

                        posKeyData.pos_key.Addpos_keyRow(dataRow);
                       

                        PosKeyView view1 = _container.Resolve<PosKeyView>();
                        view1.SetDataContext(posKeyData.pos_key);
                        this._colViewPosKeys.MoveCurrentToLast();
                        
                        int response = view1.ShowInputDialog();

                        if (response > 0)
                        {

                        }
                        else
                        {
                            this.OnDeletePosKeyCommandExecute(null);
                           
                        }
                       

                    }
                }


        }

        public bool OnAddPosKeyCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        #region Change Pos Key Command

        public void OnChangePosKeyCommandExecute(object obj)
        {

            PosKeyView view1 = _container.Resolve<PosKeyView>();
          //  System.Data.DataRow dataRow = ((System.Data.DataRowView)_colViewPosKeys.CurrentItem).Row;
           // view1.SetDataContext(dataRow);
            view1.SetDataContext(posKeyData.pos_key);
            int response = view1.ShowInputDialog();
            if (response > 0)
            {

            }


        }

        public bool OnChangePosKeyCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion


        #region Delete Pos Key Command

        public void OnDeletePosKeyCommandExecute(object obj)
        {

            try
            {
                //PosKeyView view1 = _container.Resolve<PosKeyView>();
                System.Data.DataRow dataRow = ((System.Data.DataRowView)_colViewPosKeys.CurrentItem).Row;
                //view1.SetDataContext(dataRow);
                //  int response = view1.ShowInputDialog();
                //  if (response > 0)
                //  {
                dataRow.Delete();
                //  }
            }
            catch
            {

            }


        }

        public bool OnDeletePosKeyCommandCanExecute(object obj)
        {
            // Implement business logic for myCommand enablement.
            return true;
        }

        #endregion

        public void FilterMenuPanelsByConfigNo(int configNo)
        {

            BindingListCollectionView view1 = CollectionViewSource.GetDefaultView(this.menuPanelsData.menu_panels) as BindingListCollectionView;

            if (view1 != null)
            {
                view1.CustomFilter = "config_no = " + configNo.ToString();

             }

        }


        private int GetNextKeyCode()
        {
            int nextKeyCode = 0;

            try
            {
                string expression = "max(key_code) > 0";
                System.Data.DataRow[] dataRow = this.posKeyData.Tables[0].Select(expression);

                foreach (System.Data.DataRow dr in dataRow)
                {
                    //MessageBox.Show(dr["key_code"].ToString());
                    int tmp = int.Parse(dr["key_code"].ToString());
                    if (tmp > nextKeyCode) nextKeyCode = tmp;

                }
            }
            catch
            {
            }

            return ++nextKeyCode;

        }


   
    }
}
