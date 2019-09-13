namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class currencyCodeDataSet
	{

		public partial class currency_codeDataTable
		{
			public override void EndInit()
			{
				base.EndInit();
				this.ColumnChanged += new System.Data.DataColumnChangeEventHandler(currency_codeDataTable_ColumnChanged);
				TableNewRow += new System.Data.DataTableNewRowEventHandler(currency_codeDataTable_TableNewRow);


			}

			void currency_codeDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as currency_codeRow);
			}

			void currency_codeDataTable_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as currency_codeRow);
			}

			public void CheckValues(currency_codeRow row)
			{

				if (row.IsNull("currency_code") || row.currency_code.Trim().Length == 0)
				{
					row.SetColumnError("currency_code", "Enter currency code");
				}
				else
				{
					row.SetColumnError("currency_code", "");
				}

				if (row.IsNull("currency_name") || row.currency_name.Length == 0)
				{
					row.SetColumnError("currency_name", "Enter currency name");
				}
				else
				{
					row.SetColumnError("currency_name", "");
				}

				if (row.IsNull("symbol") || row.symbol.Length == 0)
				{
					row.SetColumnError("symbol", "Enter currency symbol");
				}
				else
				{
					row.SetColumnError("symbol", "");
				}

				if (row.IsNull("pos_key_number") || row.pos_key_number <= 0)
				{
					row.SetColumnError("pos_key_number", "Enter a unique pos key number");
				}
				else
				{
					row.SetColumnError("pos_key_number", "");
				}




			}

		}

	}
}
