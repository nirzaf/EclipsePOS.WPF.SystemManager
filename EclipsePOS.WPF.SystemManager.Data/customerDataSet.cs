namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class customerDataSet
	{
		public partial class customerDataTable
		{
			public override void EndInit()
			{
				base.EndInit();
				this.ColumnChanging += new System.Data.DataColumnChangeEventHandler(customerDataTable_ColumnChanging);
				this.TableNewRow += new System.Data.DataTableNewRowEventHandler(customerDataTable_TableNewRow);
			}

			void customerDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as customerRow);
			}

			void customerDataTable_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as customerRow);
			}


			public void CheckValues(customerRow row)
			{
				if (row.IsNull("customer_search_key") || row.customer_search_key.Trim().Length == 0)
				{
					row.SetColumnError("customer_search_key", "Enter a search key");
				}
				else
				{
					row.SetColumnError("customer_search_key", "");
				}


				if (row.IsNull("tax_id") || row.tax_id.Trim().Length == 0)
				{
					row.SetColumnError("tax_id", "Enter a tax id");
				}
				else
				{
					row.SetColumnError("tax_id", "");
				}


				if (row.IsNull("customer_first_name") || row.customer_first_name.Trim().Length == 0)
				{
					row.SetColumnError("customer_first_name", "Enter a first name");
				}
				else
				{
					row.SetColumnError("customer_first_name", "");
				}



				if (row.IsNull("customer_last_name") || row.customer_last_name.Trim().Length == 0)
				{
					row.SetColumnError("customer_last_name", "Enter a last name");
				}
				else
				{
					row.SetColumnError("customer_last_name", "");
				}




			}


		}
	}
}
