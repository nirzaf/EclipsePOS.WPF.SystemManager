namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class usersDataSet
	{


		partial class subDataTable
		{

			public override void EndInit()
			{
				base.EndInit();

				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(subDataTable_ColumnChanged);
				TableNewRow += new System.Data.DataTableNewRowEventHandler(subDataTable_TableNewRow);
			}

			void subDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as subRow);
			}

			void subDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as subRow);
			}


			public void CheckValues(subRow row)
			{

				//Check sun name
				if (row.IsNull("subscriber_name") || row.subscriber_name.Trim().Length == 0)
				{
					row.SetColumnError("subscriber_name", "Enter user name");
				}
				else
				{
					row.SetColumnError("subscriber_name", "");
				}

				//Check sun passworde
				if (row.IsNull("subscriber_pass") || row.subscriber_pass.Trim().Length == 0)
				{
					row.SetColumnError("subscriber_pass", "Enter user password");
				}
				else
				{
					row.SetColumnError("subscriber_pass", "");
				}



			}


		}
	}
}
