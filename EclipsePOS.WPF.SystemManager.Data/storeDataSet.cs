namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class storeDataSet
	{
		public partial class retail_storeDataTable
		{
			public override void EndInit()
			{
				base.EndInit();
				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(retail_storeDataTable_ColumnChanged);
				this.TableNewRow += new System.Data.DataTableNewRowEventHandler(retail_storeDataTable_TableNewRow);
			}

			void retail_storeDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as retail_storeRow);
			}

			void retail_storeDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as retail_storeRow);
			}




			public void CheckValues(retail_storeRow row)
			{

				if (row.IsNull("store_no") || row.store_no.Trim().Length == 0)
				{
					row.SetColumnError("store_no", "Enter store no");
				}
				else
				{
					row.SetColumnError("store_no", "");
				}


				if (row.IsNull("store_name") || row.store_name.Trim().Length == 0)
				{
					row.SetColumnError("store_name", "Enter store name");
				}
				else
				{
					row.SetColumnError("store_name", "");
				}

				if (row.IsNull("address1") || row.address1.Length == 0)
				{
					row.SetColumnError("address1", "Enter store address1");
				}
				else
				{
					row.SetColumnError("address1", "");
				}

				if (row.IsNull("address2") || row.address2.Length == 0)
				{
					row.SetColumnError("address2", "Enter store address2");
				}
				else
				{
					row.SetColumnError("address2", "");
				}

				if (row.IsNull("address3") || row.address3.Length == 0)
				{
					row.SetColumnError("address3", "Enter store address3");
				}
				else
				{
					row.SetColumnError("address3", "");
				}






			}
		}
	}
}
