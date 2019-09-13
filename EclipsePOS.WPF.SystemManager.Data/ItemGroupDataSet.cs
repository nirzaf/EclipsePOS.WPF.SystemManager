namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class ItemGroupDataSet
	{
		partial class ItemGroupDataTable
		{

			public override void EndInit()
			{
				base.EndInit();

				ColumnChanged += new System.Data.DataColumnChangeEventHandler(ItemGroupDataTable_ColumnChanged);
				TableNewRow += new System.Data.DataTableNewRowEventHandler(ItemGroupDataTable_TableNewRow);
			}

			void ItemGroupDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as ItemGroupRow);
			}

			void ItemGroupDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as ItemGroupRow);
			}




			private void CheckValues(ItemGroupRow row)
			{
				// Check department_id
				if (row.IsNull("group_id") || row.group_id.Trim().Length == 0)
				{
					row.SetColumnError("group_id", "Please enter item group id");
				}
				else
				{
					row.SetColumnError("group_id", "");
				}


				//Check department Name
				if (row.IsNull("group_name") || row.group_name.Trim().Length == 0)
				{
					row.SetColumnError("group_name", "Please enter item group name");
				}
				else
				{
					row.SetColumnError("group_name", "");
				}
			}

		}
	}
}

namespace EclipsePOS.WPF.SystemManager.Data.ItemGroupDataSetTableAdapters {
    
    
    public partial class ItemGroupTableAdapter
    {

       
    }
}
