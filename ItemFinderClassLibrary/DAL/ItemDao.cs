using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemFinderClassLibrary.DAL
{
    public class ItemDao
    {
        private string _conString;

        public ItemDao(string conString)
        {
            _conString = conString;
        }

        public List<Item> GetItems()
        {
            List<Item> items = new List<Item>();

            //open a db connection
            SqlConnection con = new SqlConnection(_conString);
            con.Open();

            //create a sql command
            SqlCommand command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from [Item]";
            command.Connection = con;

            //execute command and fetch results
            SqlDataReader reader = command.ExecuteReader();

            //loop till all records have not been read to populate the list
            while (reader.Read())
            {
                var name = reader.GetString(2);
                var departmentId = reader.GetInt32(1);
                var description = reader.GetString(4);
                var price = reader.GetDecimal(5);
                var imagePath = reader.GetString(6);
                var location = reader.GetString(3);

                items.Add(new Item(name, departmentId, description, (float) price, imagePath, location));
            }

            //close all
            reader.Close();
            con.Close();

            return items;
        }

        public Item GetItem(int id)
        {

            //open a db connection
            var con = new SqlConnection(_conString);
            con.Open();

            //create a sql command
            var command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from [Item] where ItemId = '" + id + "'";
            command.Connection = con;

            //execute command and fetch results
            var reader = command.ExecuteReader();

            //loop till all records have not been read to populate the list
            while (reader.Read())
            {
                var name = reader.GetString(2);
                var departmentId = reader.GetInt32(1);
                var description = reader.GetString(4);
                var price = reader.GetDecimal(5);
                var imagePath = reader.GetString(6);
                var location = reader.GetString(3);

                var item = new Item(name, departmentId, description, (float)price, imagePath, location);

                //close all
                reader.Close();
                con.Close();

                return item;

            }

            return null;
        }

        public DataTable PullAllData()
        {
            //Setting up query
            var table = new DataTable();
            var query = "select * from [Item]";

            //Creating connection and command text objects
            var conn = new SqlConnection(_conString);
            var cmd = new SqlCommand(query, conn);
            conn.Open();

            //Create data adapter
            var da = new SqlDataAdapter(cmd);

            //This will query the database and return the result to the DataTable
            da.Fill(table);
            conn.Close();
            da.Dispose();
            return table;
        }

    }
}
