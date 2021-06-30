using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AuthomusLvl
{
    public class LibraryDal
    {
        private const string connectionString = "Data Source=N205-10;Initial Catalog=Library;Integrated Security=True";

        private string _tableName;
        private string _query;
        public DataSet DataSet { get; }

        public LibraryDal(string tableName)
        {
            _tableName = tableName;
            _query = string.Format("select * from {0}", _tableName);
            DataSet = new DataSet();
            LoadData();
        }

        //public static DataSet GetAuthorById(DataSet ds, int authorId)
        //{
        //    string sqlQuery = string.Format("GetAuthorNameById");

        //    using (var connection = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            connection.Open();

        //            var sqlCommand = new SqlCommand(sqlQuery);
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            sqlCommand.Parameters.Add(new SqlParameter("@Id", authorId));

        //            var adapter = new SqlDataAdapter(sqlCommand);

        //            adapter.Fill(ds);
        //        }
        //        catch (Exception exception)
        //        {
        //            Console.WriteLine(exception.Message);
        //        }

        //        return ds;
        //    }
        //}

        public void UpdateDataBase()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sqlAdapter = new SqlDataAdapter(_query, connection);
                var sqlCommandBuilder = new SqlCommandBuilder(sqlAdapter);

                Console.WriteLine(sqlCommandBuilder.GetInsertCommand().CommandText);
                Console.WriteLine(sqlCommandBuilder.GetDeleteCommand().CommandText);
                Console.WriteLine(sqlCommandBuilder.GetUpdateCommand().CommandText);

                sqlAdapter.Update(DataSet);
            }
        }

        private DataSet LoadData()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    var sqlDataAdapter = new SqlDataAdapter(_query, connection);
                    sqlDataAdapter.Fill(DataSet);

                    return DataSet;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                return DataSet;
            }
        }
    }
}
