namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class posConfigDataSet
	{

		public partial class pos_configDataTable
		{

			public override void EndInit()
			{
				base.EndInit();
				this.TableNewRow += new System.Data.DataTableNewRowEventHandler(pos_configDataTable_TableNewRow);
				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(pos_configDataTable_ColumnChanged);

			}

			void pos_configDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				CheckValues(e.Row as pos_configRow);
			}

			void pos_configDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				CheckValues(e.Row as pos_configRow);
			}


			public void CheckValues(pos_configRow row)
			{

				if (row.IsNull("name") || row.name.Trim().Length == 0)
				{
					row.SetColumnError("name", "Enter name");
				}
				else
				{
					row.SetColumnError("name", "");
				}

			}
		}
	}
}
