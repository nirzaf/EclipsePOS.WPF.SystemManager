namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class ItemsDataSet
	{
		partial class itemDataTable
		{

			public override void EndInit()
			{
				base.EndInit();
				ColumnChanged += new System.Data.DataColumnChangeEventHandler(itemDataTable_ColumnChanged);
				TableNewRow += new System.Data.DataTableNewRowEventHandler(itemDataTable_TableNewRow);
			}

			void itemDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as itemRow);
			}

			void itemDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as itemRow);
			}

			public void CheckValues(itemRow row)
			{

				if (row.IsNull("sku") || row.sku.Trim().Length == 0)
				{
					row.SetColumnError("sku", "Enter sku");
				}
				else
				{
					row.SetColumnError("sku", "");
				}

				if (row.IsNull("short_desc") || row.short_desc.Trim().Length == 0)
				{
					row.SetColumnError("short_desc", "Enter item description");
				}
				else
				{
					row.SetColumnError("short_desc", "");
				}

				//   if (row.IsNull("plu") || row.plu <= 0)
				//   {
				//       row.SetColumnError("plu", "Enter plu");
				//   }
				//   else
				//   {
				//       row.SetColumnError("plu", "");
				//   
				//   }

				if (row.IsNull("tax_group_id") || row.tax_group_id.Trim().Length == 0)
				{
					row.SetColumnError("tax_group_id", "Select_tax_group");
				}
				else
				{
					row.SetColumnError("tax_group_id", "");

				}


				if (row.IsNull("amount") || row.amount <= 0)
				{
					if (row.IsNull("pricing_opt") || row.pricing_opt != 3)
					{
						row.SetColumnError("amount", "Enter price");
					}
					else
					{
						row.SetColumnError("amount", "");
					}
				}
				else
				{
					row.SetColumnError("amount", "");

				}

				//if ( (row..amount <= 0))
				//{
				//    row.SetColumnError("amount", "Enter price");
				//}
				//else
				//{
				//    row.SetColumnError("amount", "");
				//}


			}
		}
	}
}

namespace EclipsePOS.WPF.SystemManager.Data.ItemsDataSetTableAdapters {
    
    
    public partial class itemTableAdapter {
    }
}
