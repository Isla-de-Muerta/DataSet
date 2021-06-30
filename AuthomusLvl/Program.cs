using System;

namespace AuthomusLvl
{
    class Program
    {
        static void Main(string[] args)
        {
            //var dataset = LibraryDataSet.CreateDataSet();
            //LibraryDataSet.CreateTables(dataset);
            //LibraryDal.LoadData(dataset, "Authors");
            //LibraryDataSet.ShowDataByDataTableReader(dataset.Tables[0]);

            var library = new LibraryDal("Authors");
            var authorTable = library.DataSet.Tables[0];
            var authorRow = authorTable.NewRow();
            authorRow["FullName"] = "Nicholo Maquiavellie";
            authorTable.Rows.Add(authorRow);
            library.UpdateDataBase();
            LibraryDataSet.ShowData(library.DataSet);
        }
    }
}
