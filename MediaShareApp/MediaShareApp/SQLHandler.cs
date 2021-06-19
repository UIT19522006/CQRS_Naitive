﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MediaShareApp
{
	class SQLHandler
	{
        public void insertPic(byte[] img)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "nguyencongphi.database.windows.net";
                builder.UserID = "nguyencongphi";
                builder.Password = "kratos123@";
                builder.InitialCatalog = "readModel";

                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                string query = "insert into myImage values (@img)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@img", img));
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Success");
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public List<byte[]> getPic()
        {
            List<byte[]> res = new List<byte[]>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "nguyencongphi.database.windows.net";
                builder.UserID = "nguyencongphi";
                builder.Password = "kratos123@";
                builder.InitialCatalog = "readModel";

                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                string query = "select * from myImage";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    byte[] img = (byte[])(reader[0]);
                    if (img != null)
                    {
                        res.Add(img);
                    }
                }
                connection.Close();
                MessageBox.Show("Success" + res.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            return res;
        }
    }
}

