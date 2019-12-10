using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemFinder;
using ItemFinder.ItemFinderDataSetTableAdapters;

namespace ItemFinderClassLibrary.DAL
{
    public class DepartmentDao
    {
        private string _conString;
        DepartmentTableAdapter _tableAdapter = new DepartmentTableAdapter();

        public DepartmentDao(string conString)
        {
            _conString = conString;
        }

        public List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            //open a db connection
            SqlConnection con = new SqlConnection(_conString);
            con.Open();

            //create a sql command
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from [Department]";
            command.Connection = con;

            //execute command and fetch results
            SqlDataReader reader = command.ExecuteReader();

            //loop till all records have not been read to populate the list
            while (reader.Read())
            {
                var name = reader.GetString(2);
                var storeId = reader.GetInt32(0);
                var description = reader.GetString(3);

                departments.Add(new Department(name, storeId, description));
            }

            //close all
            reader.Close();
            con.Close();

            return departments;
        }

        /// <summary>
        /// Get a department ID by name
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>Id of dept</returns>
        public int GetDepartmentId(string name)
        {
            ItemFinderDataSet.DepartmentDataTable rows = _tableAdapter.GetData();

            //cast from datarow to accountsrow
            var filteredRows = (ItemFinderDataSet.DepartmentRow[])rows.Select($"DepartmentName='{name}'");

            if (filteredRows.Length == 1)
                return filteredRows[0].DepartmentId;

            return -1;
        }
    }
}
