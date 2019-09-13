namespace EclipsePOS.WPF.SystemManager.Data
{


	public partial class currencyDataSet
	{


		public partial class currencyDataTable
		{
			public override void EndInit()
			{
				base.EndInit();
				this.ColumnChanging += new System.Data.DataColumnChangeEventHandler(currencyDataTable_ColumnChanging);
				this.TableNewRow += new System.Data.DataTableNewRowEventHandler(currencyDataTable_TableNewRow);
			}

			void currencyDataTable_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e)
			{
				this.CheckValues(e.Row as currencyRow);
			}

			void currencyDataTable_TableNewRow(object sender, System.Data.DataTableNewRowEventArgs e)
			{
				this.CheckValues(e.Row as currencyRow);
			}


			public void CheckValues(currencyRow row)
			{

				if (row.IsNull("conversion_rate") || row.conversion_rate <= 0)
				{
					row.SetColumnError("conversion_rate", "Enter conversion rate");
				}
				else
				{
					row.SetColumnError("conversion_rate", "");
				}

				if (row.IsNull("source_currency") || row.source_currency.Trim().Length == 0)
				{
					row.SetColumnError("source_currency", "Enter source currency code");
				}
				else
				{
					row.SetColumnError("source_currency", "");
				}



				if (row.IsNull("home_currency") || row.home_currency.Trim().Length == 0)
				{
					row.SetColumnError("home_currency", "Enter home curreny");
				}
				else
				{
					row.SetColumnError("home_currency", "");
				}



			}




		}

	}
}
