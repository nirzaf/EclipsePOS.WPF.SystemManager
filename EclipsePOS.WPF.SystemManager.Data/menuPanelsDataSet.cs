namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class menuPanelsDataSet
	{
		public partial class menu_panelsDataTable
		{
			public override void EndInit()
			{
				base.EndInit();

				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(menu_panelsDataTable_ColumnChanged);
				this.TableNewRow += new System.Data.DataTableNewRowEventHandler(menu_panelsDataTable_TableNewRow);
			}

			void menu_panelsDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as menu_panelsRow);
			}

			void menu_panelsDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as menu_panelsRow);
			}

			public void CheckValues(menu_panelsRow row)
			{
				//Panel id
				if (row.IsNull("panel_id") || row.panel_id <= 0)
				{
					row.SetColumnError("panel_id", "Enter panel id");
				}
				else
				{
					row.SetColumnError("panel_id", "");
				}

				//Panel name
				if (row.IsNull("panel_name") || row.panel_name.Trim().Length <= 0)
				{
					row.SetColumnError("panel_name", "Enter panel name");
				}
				else
				{
					row.SetColumnError("panel_name", "");
				}


				//Panel class
				if (row.IsNull("panel_class_name") || row.panel_class_name.Trim().Length <= 0)
				{
					row.SetColumnError("panel_class_name", "Enter panel class name");
				}
				else
				{
					row.SetColumnError("panel_class_name", "");
				}


			}


		}
	}
}
