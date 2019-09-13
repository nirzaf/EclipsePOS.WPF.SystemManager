namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class posTransUploadDataSet
	{
		partial class pos_trans_uploadDataTable
		{
			public override void EndInit()
			{
				base.EndInit();
				ColumnChanged += new System.Data.DataColumnChangeEventHandler(pos_trans_uploadDataTable_ColumnChanged);
				TableNewRow += new System.Data.DataTableNewRowEventHandler(pos_trans_uploadDataTable_TableNewRow);
			}

			void pos_trans_uploadDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as pos_trans_uploadRow);
			}

			void pos_trans_uploadDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as pos_trans_uploadRow);
			}


			public void CheckValues(pos_trans_uploadRow row)
			{

				if (row.IsNull("upload_session_no") || row.upload_session_no.Length == 0)
				{
					row.SetColumnError("upload_session_no", "Enter a valid upload session number");
				}
				else
				{
					row.SetColumnError("upload_session_no", "");
				}

				/*       if (row.IsNull("fiscal_period") || row.fiscal_period <= 0)
					   {
						   row.SetColumnError("fiscal_period", "Enter a valid fiscal period");
					   }
					   else
					   {
						   row.SetColumnError("fiscal_period", "");
					   } */

				/*     if (row.IsNull("fiscal_year") || row.fiscal_year.Length == 0)
					 {
						 row.SetColumnError("fiscal_year", "Enter a valid fiscal year");
					 }
					 else
					 {
						 row.SetColumnError("fiscal_year", "");
					 } */

				if (row.IsNull("remarks") || row.remarks.Length == 0)
				{
					row.SetColumnError("remarks", "Enter posting text");
				}
				else
				{
					row.SetColumnError("remarks", "");
				}
			}
		}
	}
}
