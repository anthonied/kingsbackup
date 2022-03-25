using System;
using Pervasive.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

namespace Liquid.Classes
{
	/// <summary> 
	/// Summary description for SQLOps. 
	/// </summary> 
	public class SQLOps
	{
		public SQLOps()
		{
		}

		//FJC = First Join Column 

		//SJC = Second Join Column 

		public static DataTable Join(DataTable First, DataTable Second, DataColumn[] FJC, DataColumn[] SJC)
		{
			//Create Empty Table 
			DataTable table = new DataTable("Join");

			// Use a DataSet to leverage DataRelation 
			using (DataSet ds = new DataSet())
			{
				//Add Copy of Tables 
				ds.Tables.AddRange(new DataTable[] { First.Copy(), Second.Copy() });

				//Identify Joining Columns from First 
				DataColumn[] parentcolumns = new DataColumn[FJC.Length];

				for (int i = 0; i < parentcolumns.Length; i++)
				{
					parentcolumns[i] = ds.Tables[0].Columns[FJC[i].ColumnName];
				}

				//Identify Joining Columns from Second 
				DataColumn[] childcolumns = new DataColumn[SJC.Length];

				for (int i = 0; i < childcolumns.Length; i++)
				{
					childcolumns[i] = ds.Tables[1].Columns[SJC[i].ColumnName];
				}

				//Create DataRelation 
				DataRelation r = new DataRelation(string.Empty, parentcolumns, childcolumns, false);
				ds.Relations.Add(r);

				//Create Columns for JOIN table 
				for (int i = 0; i < First.Columns.Count; i++)
				{
					table.Columns.Add(First.Columns[i].ColumnName, First.Columns[i].DataType);
				}

				for (int i = 0; i < Second.Columns.Count; i++)
				{
					//Beware Duplicates 
					if (!table.Columns.Contains(Second.Columns[i].ColumnName))
						table.Columns.Add(Second.Columns[i].ColumnName, Second.Columns[i].DataType);
					else
						table.Columns.Add(Second.Columns[i].ColumnName + "_Second", Second.Columns[i].DataType);
				}


				//Loop through First table 
				table.BeginLoadData();

				foreach (DataRow firstrow in ds.Tables[0].Rows)
				{
					//Get "joined" rows 
					DataRow[] childrows = firstrow.GetChildRows(r);
					if (childrows != null && childrows.Length > 0)
					{
						object[] parentarray = firstrow.ItemArray;
						foreach (DataRow secondrow in childrows)
						{
							object[] secondarray = secondrow.ItemArray;
							object[] joinarray = new object[parentarray.Length + secondarray.Length];
							Array.Copy(parentarray, 0, joinarray, 0, parentarray.Length);
							Array.Copy(secondarray, 0, joinarray, parentarray.Length, secondarray.Length);
							table.LoadDataRow(joinarray, true);
						}
					}
					else
					{
						object[] parentarray = firstrow.ItemArray;
						object[] joinarray = new object[parentarray.Length];
						Array.Copy(parentarray, 0, joinarray, 0, parentarray.Length);
						table.LoadDataRow(joinarray, true);
					}
				}
				table.EndLoadData();
			}

			return table;
		}

		public static DataTable Join(DataTable First, DataTable Second, DataColumn FJC, DataColumn SJC)
		{
			return SQLOps.Join(First, Second, new DataColumn[] { FJC }, new DataColumn[] { SJC });
		}

		public static DataTable Join(DataTable First, DataTable Second, string FJC, string SJC)
		{
			return SQLOps.Join(First, Second, new DataColumn[] { First.Columns[FJC] }, new DataColumn[] { First.Columns[SJC] });
		}
	}
 
	public class Connect
	{
		public static string LiquidConnectionString = Global.sSolPMSConn;
		public static string PastelConnectionString = Global.sPastelConn;
		public static string sAccessConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + ConfigurationSettings.AppSettings["AccessDatapath"] + " ;Persist Security Info=False";

		public static DataSet getDataSet(string sSQL, string sTable, PsqlConnection conn)
		{
			DataSet ds = new DataSet();   
			// create a data adapter 
			PsqlDataAdapter da = new PsqlDataAdapter(sSQL, conn);
		    
			da.Fill(ds, sTable);
			return (ds);
		}

		public static PsqlCommand getDataCommand(string sSQL, PsqlConnection conn)
		{
			try
			{
				if (conn == null)
				{
					try
					{
						conn = new PsqlConnection(LiquidConnectionString);
						conn.Open();
					}
					catch (PsqlException ex)
					{
						throw ex;
					}
				}
				else if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				PsqlCommand cmdSQL = new PsqlCommand(sSQL, conn);
				return cmdSQL;
			}
			catch
			{ 
				return null;
			}
		}

		public static DataSet getDataSet(string sSQL, string sTable, OleDbConnection conn)
		{
			DataSet ds = new DataSet();
			// create a data adapter 
			OleDbDataAdapter da = new OleDbDataAdapter(sSQL, conn);
			da.Fill(ds, sTable);
			return (ds);
		}
		//
		//Connection for access DB
		public static OleDbCommand getDataCommand(string sSQL, OleDbConnection conn)
		{
			try
			{
				if (conn == null)
				{
					try
					{
						conn = new OleDbConnection(LiquidConnectionString);
						conn.Open();
					}
					catch (OleDbException ex)
					{
						throw ex;
					}
				}
				else if (conn.State == ConnectionState.Closed)
				{
					conn.Open();
				}
				OleDbCommand cmdSQL = new OleDbCommand(sSQL, conn);
				return cmdSQL;
			}
			catch
			{
				return null;
			}
		}

		//FJC = First Join Column

		//SJC = Second Join Column

		public static DataTable Join(DataTable First, DataTable Second, DataColumn[] FJC, DataColumn[] SJC)
		{

			//Create Empty Table

			DataTable table = new DataTable("Join");


			// Use a DataSet to leverage DataRelation

			using (DataSet ds = new DataSet())
			{

				//Add Copy of Tables

				ds.Tables.AddRange(new DataTable[] { First.Copy(), Second.Copy() });


				//Identify Joining Columns from First

				DataColumn[] parentcolumns = new DataColumn[FJC.Length];

				for (int i = 0; i < parentcolumns.Length; i++)
				{

					parentcolumns[i] = ds.Tables[0].Columns[FJC[i].ColumnName];

				}

				//Identify Joining Columns from Second

				DataColumn[] childcolumns = new DataColumn[SJC.Length];

				for (int i = 0; i < childcolumns.Length; i++)
				{

					childcolumns[i] = ds.Tables[1].Columns[SJC[i].ColumnName];

				}


				//Create DataRelation

				DataRelation r = new DataRelation(string.Empty, parentcolumns, childcolumns, false);

				ds.Relations.Add(r);


				//Create Columns for JOIN table

				for (int i = 0; i < First.Columns.Count; i++)
				{

					table.Columns.Add(First.Columns[i].ColumnName, First.Columns[i].DataType);

				}

				for (int i = 0; i < Second.Columns.Count; i++)
				{

					//Beware Duplicates

					if (!table.Columns.Contains(Second.Columns[i].ColumnName))

						table.Columns.Add(Second.Columns[i].ColumnName, Second.Columns[i].DataType);

					else

						table.Columns.Add(Second.Columns[i].ColumnName + "_Second", Second.Columns[i].DataType);

				}


				//Loop through First table

				table.BeginLoadData();

				foreach (DataRow firstrow in ds.Tables[0].Rows)
				{

					//Get "joined" rows

					DataRow[] childrows = firstrow.GetChildRows(r);

					if (childrows != null && childrows.Length > 0)
					{

						object[] parentarray = firstrow.ItemArray;

						foreach (DataRow secondrow in childrows)
						{

							object[] secondarray = secondrow.ItemArray;

							object[] joinarray = new object[parentarray.Length + secondarray.Length];

							Array.Copy(parentarray, 0, joinarray, 0, parentarray.Length);

							Array.Copy(secondarray, 0, joinarray, parentarray.Length, secondarray.Length);

							table.LoadDataRow(joinarray, true);

						}

					}

				}

				table.EndLoadData();

			}


			return table;

		}


		public static DataTable Join(DataTable First, DataTable Second, DataColumn FJC, DataColumn SJC)
		{

			return SQLOps.Join(First, Second, new DataColumn[] { FJC }, new DataColumn[] { SJC });

		}

		public static DataTable Join(DataTable First, DataTable Second, string FJC, string SJC)
		{
			
			return SQLOps.Join(First, Second, new DataColumn[] { First.Columns[FJC] }, new DataColumn[] { First.Columns[SJC] });

		}


	}
}