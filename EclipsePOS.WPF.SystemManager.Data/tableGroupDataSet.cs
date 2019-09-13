namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class tableGroupDataSet
	{
		public partial class table_groupDataTable
		{
			public override void EndInit()
			{
				base.EndInit();
				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(table_groupDataTable_ColumnChanged);
				TableNewRow += new System.Data.DataTableNewRowEventHandler(table_groupDataTable_TableNewRow);
			}

			void table_groupDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as table_groupRow);
			}

			void table_groupDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as table_groupRow);
			}

			public void CheckValues(table_groupRow row)
			{
				//Table group no
				if (row.IsNull("table_group_no") || row.table_group_no == 0)
				{
					row.SetColumnError("table_group_no", "Enter table group no");
				}
				else
				{
					row.SetColumnError("table_group_no", "");
				}

				//Table group name
				if (row.IsNull("table_group_name") || row.table_group_name.Trim().Length == 0)
				{
					row.SetColumnError("table_group_name", "Enter table group name");
				}
				else
				{
					row.SetColumnError("table_group_name", "");
				}

			}
		}
	}
}
