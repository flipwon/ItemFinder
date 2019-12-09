using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ItemFinder;
using ItemFinder.ItemFinderDataSetTableAdapters;
using ItemFinderClassLibrary;

namespace ItemFinderClassLibrary.Logic
{
    public class UserDao
    {
        
        UsersTableAdapter _usersAdapter = new UsersTableAdapter();

        public (int, int) AddRecord(string userName, string password, string role = "User")
        {
            byte[] bSalt = LoginHelper.GenerateSalt();
            string encPassword = LoginHelper.GeneratePasswordHash(password, bSalt, 20000);

            //_adapter.Insert(userName, encPassword);
            SqlCommand cmd = new SqlCommand("InsertUserAccount");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = _usersAdapter.Connection;


            //sequence of parameters is as declared, count, uname, password, id

            SqlParameter pCount = cmd.CreateParameter();
            pCount.Direction = ParameterDirection.ReturnValue;
            pCount.DbType = DbType.Int32;
            cmd.Parameters.Add(pCount);

            cmd.Parameters.AddWithValue("@uName", userName);
            cmd.Parameters.AddWithValue("@password", encPassword);
            cmd.Parameters.AddWithValue("@role", role);

            SqlParameter pId = cmd.CreateParameter();
            pId.ParameterName = "@Id";
            pId.Direction = ParameterDirection.Output;
            pId.DbType = DbType.Int32;
            cmd.Parameters.Add(pId);

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();

            //return id and count.
            return (Convert.ToInt32(cmd.Parameters[4].Value), Convert.ToInt32(cmd.Parameters[0].Value));
        }

        public string GetEncPassword(string userName)
        {
            ItemFinderDataSet.UsersDataTable rows = _usersAdapter.GetData();

            //cast from datarow to accountsrow
            var filteredRows = (ItemFinderDataSet.UsersRow[])rows.Select($"UserName='{userName}'");

            if (filteredRows.Length == 1)
                return filteredRows[0].Password;

            return null;
        }

        public string GetUserRole(string userName)
        {
            /*
            SqlCommand cmd = new SqlCommand("GetUserRole");
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = _usersAdapter.Connection;

            cmd.Parameters.AddWithValue("@uName", userName);

            cmd.Connection.Open();
            cmd.ExecuteNonQuery();

            var whatever = cmd.Parameters[1].Value;

            return (string)cmd.Parameters["@role"].Value;*/
            ItemFinderDataSet.UsersDataTable rows = _usersAdapter.GetData();

            //cast from datarow to accountsrow
            var filteredRows = (ItemFinderDataSet.UsersRow[])rows.Select($"UserName='{userName}'");

            if (filteredRows.Length == 1)
                return filteredRows[0].Role;

            return null;
        }
    }
}
