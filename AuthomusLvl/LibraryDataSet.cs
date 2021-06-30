using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AuthomusLvl
{
    public static class LibraryDataSet
    {
        public static DataSet CreateDataSet()
        {
            var dataSet = new DataSet();

            dataSet.ExtendedProperties.Add("Database owner", "Isl");
            dataSet.ExtendedProperties.Add("Data creation", DateTime.Now);
            dataSet.ExtendedProperties.Add("Version", "V1");

            return dataSet;
        }

        public static DataSet CreateTables(DataSet ds)
        {
            var dataTable = new DataTable("Authors");
            var idColumn = new DataColumn("AuthorId", typeof(int))
            {
                AutoIncrement = true,
                AutoIncrementSeed = 0,
                AutoIncrementStep = 1,
                AllowDBNull = false
            };

            var nameColumn = new DataColumn("Name", typeof(string))
            {
                AllowDBNull = false,
                MaxLength = 100
            };

            dataTable.Columns.AddRange(new DataColumn[] { idColumn, nameColumn });
            dataTable.PrimaryKey = new DataColumn[] { dataTable.Columns[0] };

            var dataRow = dataTable.NewRow();
            dataRow["Name"] = "Isl";

            var dataRow2 = dataTable.NewRow();
            dataRow2["Name"] = "Ramis";

            var dataRow3 = dataTable.NewRow();
            dataRow3["Name"] = "Anuar";

            dataTable.Rows.Add(dataRow);
            dataTable.Rows.Add(dataRow2);
            dataTable.Rows.Add(dataRow3);

            ds.Tables.Add(dataTable);
            return ds;
        }

        public static void ShowDataByDataTableReader(DataTable dataTable)
        {
            var dtReader = new DataTableReader(dataTable);

            while (dtReader.Read())
            {
                for (int i = 0; i < dtReader.FieldCount; i++)
                {
                    Console.Write("\t{0}\t", dtReader[i].ToString());
                }
                Console.WriteLine();
            }
        }

        public static void ShowData(DataSet ds)
        {
            foreach (var table in ds.Tables)
            {
                var tb = (DataTable)table;

                for (int i = 0; i < tb.Columns.Count; i++)
                {
                    Console.Write(tb.Columns[i] + "\t");
                }

                Console.WriteLine();

                for (int j = 0; j < tb.Rows.Count; j++)
                {
                    for (int k = 0; k < tb.Columns.Count; k++)
                    {
                        Console.Write(tb.Rows[j].ItemArray[k] + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
