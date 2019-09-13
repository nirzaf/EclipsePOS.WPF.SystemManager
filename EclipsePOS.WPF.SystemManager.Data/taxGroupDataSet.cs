namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class taxGroupDataSet
	{

		public partial class tax_groupDataTable
		{

			public override void EndInit()
			{
				base.EndInit();
				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(tax_groupDataTable_ColumnChanged);
				TableNewRow += new System.Data.DataTableNewRowEventHandler(tax_groupDataTable_TableNewRow);
			}

			void tax_groupDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as tax_groupRow);
			}

			void tax_groupDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as tax_groupRow);
			}

			public void CheckValues(tax_groupRow row)
			{
				//Check tax group id
				if (row.IsNull("tax_group_id") || row.tax_group_id.Trim().Length == 0)
				{
					row.SetColumnError("tax_group_id", "Enter tax group no");
				}
				else
				{
					row.SetColumnError("tax_group_id", "");
				}

				//Check tax group name
				if (row.IsNull("tax_group_name") || row.tax_group_name.Trim().Length == 0)
				{
					row.SetColumnError("tax_group_name", "Enter tax group name");
				}
				else
				{
					row.SetColumnError("tax_group_name", "");
				}



			}

		}
	}
}
