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

        public int AddItem(Item item)
        {
            var count = 0;
            try
            {
                //Setting up the SQL query to insert into the table
                var insertCommand = "Insert into [Item] (DepartmentId, ItemName, ItemLocation, ItemDesc, ItemPrice) " +
                                    "Values (@DepartmentId, @ItemName, @ItemLocation, @ItemDesc, @ItemPrice)";
                using (var con = new SqlConnection(_conString))
                using (var command = new SqlCommand(insertCommand, con))
                {
                    //Opening the connection and adding parameters to the SQL command to be executed later on
                    con.Open();
                    command.Parameters.Add("@DepartmentId", SqlDbType.Int).Value = item.DepartmentId;
                    command.Parameters.Add("@ItemName", SqlDbType.VarChar).Value = item.Name;
                    command.Parameters.Add("@ItemLocation", SqlDbType.VarChar).Value = item.Location;
                    command.Parameters.Add("@ItemDesc", SqlDbType.VarChar).Value = item.Description;
                    command.Parameters.Add("@ItemPrice", SqlDbType.Decimal).Value = item.Price;

                    //Executing the command above with all the parameters given
                    count = command.ExecuteNonQuery();
                }

            }

            //Catching exception
            catch (SqlException ex)
            {
                //Throwing the exception that was caught
                throw ex;
            }
            return count;
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
                var departmentId = reader.GetInt32(1);
                var name = reader.GetString(2);
                var description = reader.GetString(3);
                var location = reader.GetString(4);
                var price = reader.GetDecimal(5);

                items.Add(new Item(departmentId, name,  description, location, (float)price));
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
                var departmentId = reader.GetInt32(1);
                var name = reader.GetString(2);
                var description = reader.GetString(3);
                var location = reader.GetString(4);
                var price = reader.GetDecimal(5);

                var item = new Item(departmentId, name, description, location, (float) price);

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

        public void UpdateItem(Item item, int id)
        {
            //Creating connection, query, and adapter for the database
            var conn = new SqlConnection(_conString);
            var adapter = new SqlDataAdapter();
            var sql = "Update [Item] set DepartmentId = '" + item.DepartmentId + "', ItemName = '" + item.Name + "', ItemLocation = '" + item.Location + "', ItemDesc = '" + item.Description + "', ItemPrice = '" + item.Price + "' where ItemId = '" + id + "'";

            //Creating command based on the SQL string above
            var command = new SqlCommand(sql, conn);
            conn.Open();

            //Using the adapter, data is updated in the database with the new data given by the user
            adapter.InsertCommand = new SqlCommand(sql, conn);
            adapter.InsertCommand.ExecuteNonQuery();

            //Close the connection and kill the command
            command.Dispose();
            conn.Close();
        }

    }
}
