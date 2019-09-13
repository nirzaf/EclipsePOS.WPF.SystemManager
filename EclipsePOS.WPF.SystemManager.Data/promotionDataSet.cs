namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class promotionDataSet
	{
		public partial class promotionDataTable
		{
			public override void EndInit()
			{
				base.EndInit();
				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(promotionDataTable_ColumnChanged);
				this.TableNewRow += new System.Data.DataTableNewRowEventHandler(promotionDataTable_TableNewRow);
			}

			void promotionDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				CheckValues(e.Row as promotionRow);
			}

			void promotionDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				CheckValues(e.Row as promotionRow);
			}

			public void CheckValues(promotionRow row)
			{

				if (row.IsNull("promotion_no") || row.promotion_no <= 0)
				{
					row.SetColumnError("promotion_no", "Enter promotion no");
				}
				else
				{
					row.SetColumnError("promotion_no", "");
				}


				if (row.IsNull("promotion_val1") || row.promotion_val1 <= 0)
				{
					row.SetColumnError("promotion_val1", "Enter promotion value qualifier");
				}
				else
				{
					row.SetColumnError("promotion_val1", "");
				}



				if (row.IsNull("promotion_dval1") || row.promotion_dval1 <= 0)
				{
					row.SetColumnError("promotion_dval1", "Enter promotion quantity qualifier");
				}
				else
				{
					row.SetColumnError("promotion_dval1", "");
				}


				if (row.IsNull("promotion_class") || row.promotion_class.Trim().Length == 0)
				{
					row.SetColumnError("promotion_class", "Enter promotion operator class");
				}
				else
				{
					row.SetColumnError("promotion_class", "");
				}



				if (row.IsNull("promotion_string") || row.promotion_string.Trim().Length == 0)
				{
					row.SetColumnError("promotion_string", "Enter promotion text");
				}
				else
				{
					row.SetColumnError("promotion_string", "");
				}

			}


		}
	}
}
