namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class stationDataSet
	{

		public partial class posDataTable
		{
			public override void EndInit()
			{
				base.EndInit();
				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(posDataTable_ColumnChanged);
				this.TableNewRow += new System.Data.DataTableNewRowEventHandler(posDataTable_TableNewRow);
			}

			void posDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				CheckValues(e.Row as posRow);
			}

			void posDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				CheckValues(e.Row as posRow);
			}

			public void CheckValues(posRow row)
			{

				if (row.IsNull("pos_no") || row.pos_no <= 0)
				{
					row.SetColumnError("pos_no", "Enter station no");
				}
				else
				{
					row.SetColumnError("pos_no", "");
				}

				if (row.IsNull("short_desc") || row.short_desc.Trim().Length == 0)
				{
					row.SetColumnError("short_desc", "Enter station name");
				}
				else
				{
					row.SetColumnError("short_desc", "");
				}

				if (row.IsNull("store_no") || row.store_no.Trim().Length == 0)
				{
					row.SetColumnError("store_no", "Enter store no");
				}
				else
				{
					row.SetColumnError("store_no", "");
				}

			}
		}
	}
}
