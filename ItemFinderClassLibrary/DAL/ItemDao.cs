using System;
using System.Collections.Generic;
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
    }
}
