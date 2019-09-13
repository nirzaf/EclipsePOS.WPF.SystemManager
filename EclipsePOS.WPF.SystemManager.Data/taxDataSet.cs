namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class taxDataSet
	{
		public partial class taxDataTable
		{
			public override void EndInit()
			{
				base.EndInit();
				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(taxDataTable_ColumnChanged);
				TableNewRow += new System.Data.DataTableNewRowEventHandler(taxDataTable_TableNewRow);
			}

			void taxDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as taxRow);
			}

			void taxDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as taxRow);
			}


			public void CheckValues(taxRow row)
			{
				row.ClearErrors();

				//Check tax id
				if (row.IsNull("tax_id") || row.tax_id <= 0)
				{
					row.SetColumnError("tax_id", "Enter tax id");
				}
				else
				{
					row.SetColumnError("tax_id", "");
				}

				//Check tax group id
				if (row.IsNull("tax_group_id") || row.tax_group_id.Trim().Length == 0)
				{
					row.SetColumnError("tax_group_id", "Enter tax group no");
				}
				else
				{
					row.SetColumnError("tax_group_id", "");
				}

				//Short description
				if (row.IsNull("short_desc") || row.short_desc.Trim().Length == 0)
				{
					row.SetColumnError("short_desc", "Enter tax description");
				}
				else
				{
					row.SetColumnError("short_desc", "");
				}

				//Rate
				if (row.IsNull("rate") || row.rate < 0)
				{
					row.SetColumnError("rate", "Enter tax rate");
				}
				else
				{
					row.SetColumnError("rate", "");
				}

			}


		}


	}
}
