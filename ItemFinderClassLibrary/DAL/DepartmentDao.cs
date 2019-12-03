using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemFinderClassLibrary.DAL
{
    public class DepartmentDao
    {
        private string _conString;

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
                var departmentId = reader.GetInt32(0);
                var description = reader.GetString(3);

                departments.Add(new Department(name, departmentId, description));
            }

            //close all
            reader.Close();
            con.Close();

            return departments;
        }
    }
}
