namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class tableDetailsDataSet
	{
		partial class table_detailsDataTable
		{
			public override void EndInit()
			{
				base.EndInit();
				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(table_detailsDataTable_ColumnChanged);
				TableNewRow += new System.Data.DataTableNewRowEventHandler(table_detailsDataTable_TableNewRow);
			}

			void table_detailsDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as table_detailsRow);
			}

			void table_detailsDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as table_detailsRow);
			}

			public void CheckValues(table_detailsRow row)
			{


				//Table name
				if (row.IsNull("table_name") || row.table_name.Trim().Length == 0)
				{
					row.SetColumnError("table_name", "Enter table name");
				}
				else
				{
					row.SetColumnError("table_name", "");
				}

			}
		}
	}
}
