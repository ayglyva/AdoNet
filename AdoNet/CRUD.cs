using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AdoNet
{
    public class CRUD
    {
        public static string connectionString = "Data Source=DESKTOP-KHPHNGJ\\SQLEXPRESS; Database=register; Integrated Security = True;";

        public static SqlConnection sqlConnection = new SqlConnection(connectionString);

        static void Select()
        {
            string query = "select * from [register].[dbo].[Table]";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

           
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Console.WriteLine(item["Id"] + " " + item["Name"]);
            }
        }

        static void Select(string text)
        {
            string query = $"select * from [register].[dbo].[Table] where Name like N'%{text}%'";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);

            DataSet ds = new DataSet();

            adapter.Fill(ds);

            foreach (DataRow item in ds.Tables[0].Rows)
            {
                Console.WriteLine(item["Id"] + " " + item["Name"]);
            }
        }


        static void Insert(int Id, string Name, int Age)
        {
            string query = $"insert into [dbo].[Table] (Id,Name,Age) values ('{Id}','{Name}','{Age}')";

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);


            sqlCommand.ExecuteNonQuery();
        }

        static void Delete(int id)
        {
            string query = $"delete from [dbo].[Table] where Id={id}";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }


        static void Update(int id, string Name)
        {
            string query = $"update [dbo].[Table] set Name='{Name}' where Id={id}";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        } 


        static void Main()
        {
            sqlConnection.Open();         
            
            int id = Convert.ToInt32(Console.ReadLine());

           string text =Console.ReadLine();

         //   int age = Convert.ToInt32(Console.ReadLine());


           // Select();

            //Select(text);

            //  Insert( id,text,age);

            //  Delete(id);

            Update(id, text);
            sqlConnection.Close();
        }


    }
}
