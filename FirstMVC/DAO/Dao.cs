using FirstMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.UI.WebControls;

namespace FirstMVC.DAO
{
    public class Dao : System.Web.UI.Page
    {

        //_____________________________________WHY WE USE USING______________________

        //      using is used because 
        //        Using calls Dispose() explicitely
        //      using (MyClass mine = new MyClass())
        //        {
        //            mine.Action();
        //        }
        //        would do the same as:
        //      MyClass mine = new MyClass();
        //        try
        //        {
        //            mine.Action();
        //        }
        //        finally
        //        {
        //            if (mine != null)
        //                mine.Dispose();
        //        }
        //        Using using is way shorter and easier to read.



        //__________________________READING using SQLCOMMNAD with SQLDATAREADER_______________________________

        public static List<DAOModelOfMyOwn> AddUsers()
        {
            DAOModelOfMyOwn ob = null;
            List<DAOModelOfMyOwn> daolist = new List<DAOModelOfMyOwn>();
            using (SqlConnection connection = new SqlConnection("Server=.; Database=ShoppingCartT4; Integrated Security=true")) //integrated security is the windows security..
            {
                int a = 0;
                //connection.Open();     //opening the connection...
                string sqlQuery = @"select * from Customer";
                SqlCommand sqlcommand = new SqlCommand(sqlQuery, connection); //takes two parameters..sql query and connection string...
                sqlcommand.Connection.Open(); //opens connection if its not open
                a += sqlcommand.ExecuteNonQuery(); //executes the query..
                Debug.WriteLine(a);
                SqlDataReader reader = sqlcommand.ExecuteReader(); //this requires active and open database...so to read or fetch row by row
                while(reader.Read())
                {
                    ob = new DAOModelOfMyOwn()
                    {
                        customer_id = (int)reader["customer_id"],
                        username = (string)reader["username"],
                        firstname = (string)reader["firstname"],
                        password = (string)reader["password"],
                        session_id = (string)reader["session_id"],
                        lastname = (string)reader["lastname"]
                    };
                    daolist.Add(ob);
                }
            }
            return daolist;
        }




        //________________________________INSERTING DATAS SQLCOMMAND____________________________

        public static void Insert()
        {
           
            using (SqlConnection connection = new SqlConnection("Server=.; Database=ShoppingCartT4; Integrated Security=true")) //integrated security is the windows security..
            {

                string sqlQuery = @"insert into customer(customer_id,username,firstname,password,session_id,lastname) values ('321','innn','bbbb','21221','','rere')";
                SqlCommand sqlcommand = new SqlCommand(sqlQuery, connection); //takes two parameters..sql query and connection string...
                sqlcommand.Connection.Open(); //opens connection if its not open
                sqlcommand.ExecuteNonQuery(); //executes the query..

                //SqlDataReader reader = sqlcommand.ExecuteReader();
            }
            
        }



        //______________________INSERTING USING SQLPARAMETER AND SQLCOMMAND ________________________

        public static void ParameterBinding(DAOModelOfMyOwn obj)
        {
            using (SqlConnection connection = new SqlConnection("Server=.; Database=ShoppingCartT4; Integrated Security=true")) //integrated security is the windows security..
            {

                string sqlQuery = @"insert into customer(customer_id,username,firstname,password,session_id,lastname) values (@customer_id,@username,@firstname,@password,@session_id,@lastname)";
                SqlParameter param1 = new SqlParameter();
                SqlParameter param2 = new SqlParameter();
                SqlParameter param3 = new SqlParameter();
                SqlParameter param4 = new SqlParameter();
                SqlParameter param5= new SqlParameter();
                SqlParameter param6= new SqlParameter();


                param1.ParameterName = "@customer_id";
                param1.Value = obj.customer_id;

                param2.ParameterName = "@username";
                param2.Value = obj.username;

                param3.ParameterName = "@firstname";
                param3.Value = obj.firstname;

                param4.ParameterName = "@password";
                param4.Value = obj.password;

                param5.ParameterName = "@session_id";
                param5.Value = obj.session_id;

                param6.ParameterName = "@lastname";
                param6.Value = obj.lastname;


                SqlCommand sqlcommand = new SqlCommand(sqlQuery, connection); //takes two parameters..sql query and connection string...
                sqlcommand.Connection.Open(); //opens connection if its not open

                sqlcommand.Parameters.Add(param1);
                sqlcommand.Parameters.Add(param2);
                sqlcommand.Parameters.Add(param3);
                sqlcommand.Parameters.Add(param4);
                sqlcommand.Parameters.Add(param5);
                sqlcommand.Parameters.Add(param6);

                sqlcommand.ExecuteNonQuery(); //executes the query..

                //SqlDataReader reader = sqlcommand.ExecuteReader();
            }

        }



        // ________________________READING USING SQL DATAADAPTER with DATA TABLE____________________________________

        // Disconnect access to database..
        //here we wont use sqlCommand and SQl Data reader ..instead we use sqlDataAdapter and DataSet to get the same output..

        
        public static DataTable DataAdapter()
        {

            DataTable dset;
            using (SqlConnection connection = new SqlConnection("Server=.; Database=ShoppingCartT4; Integrated Security=true")) //integrated security is the windows security..
            {

                string sqlQuery = @"select * from customer";
                SqlDataAdapter sqladapter = new SqlDataAdapter(sqlQuery, connection);
                dset = new DataTable(); //it is present in System.Data 
                sqladapter.Fill(dset); //here Fill is a method which needs datatable to populate all datas and then it open connection with DB to do the transaction.

                // the FILL method of DataAdapter does all the needfull,,,open connection, executes the query, reads the data
                // fetch the data and close the connection....

            }
            return dset;
        }




        //________________________________INSERTING USING SQL DATAADAPTER and DATATABLE____________________________

        public static void InsertAgain()
        {

            using (SqlConnection connection = new SqlConnection("Server=.; Database=ShoppingCartT4; Integrated Security=true")) 
            {

                string sqlQuery = @"insert into customer(customer_id,username,firstname,password,session_id,lastname) values ('3212','innn','bbbb','21221','','rere')";
                SqlDataAdapter sqlcommand = new SqlDataAdapter(sqlQuery, connection);
                DataTable ds = new DataTable();
                sqlcommand.Fill(ds);

            }

        }


        //___________________INSERTING USING SQL DATAADAPTER and SQL PARAMETER________________________________

        public static void SQLParameterWithSQlAdapter(DAOModelOfMyOwn obj)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection("Server=.; Database=ShoppingCartT4; Integrated Security=true")) //integrated security is the windows security..
            {

                string sqlQuery = @"insert into customer(customer_id,username,firstname,password,session_id,lastname) values (@customer_id,@username,@firstname,@password,@session_id,@lastname)";
                SqlParameter param1 = new SqlParameter();
                SqlParameter param2 = new SqlParameter();
                SqlParameter param3 = new SqlParameter();
                SqlParameter param4 = new SqlParameter();
                SqlParameter param5 = new SqlParameter();
                SqlParameter param6 = new SqlParameter();


                param1.ParameterName = "@customer_id";
                param1.Value = obj.customer_id;

                param2.ParameterName = "@username";
                param2.Value = obj.username;

                param3.ParameterName = "@firstname";
                param3.Value = obj.firstname;

                param4.ParameterName = "@password";
                param4.Value = obj.password;

                param5.ParameterName = "@session_id";
                param5.Value = obj.session_id;

                param6.ParameterName = "@lastname";
                param6.Value = obj.lastname;


                SqlDataAdapter sqladapter = new SqlDataAdapter(sqlQuery, connection);

                sqladapter.SelectCommand.Parameters.Add(param1);
                sqladapter.SelectCommand.Parameters.Add(param2);
                sqladapter.SelectCommand.Parameters.Add(param3);
                sqladapter.SelectCommand.Parameters.Add(param4);
                sqladapter.SelectCommand.Parameters.Add(param5);
                sqladapter.SelectCommand.Parameters.Add(param6);

                sqladapter.Fill(dt);
            }

        }


        //______________________________________________ ****DATASET*****_____________________________________


        //it is a representation of our database..which offers a disconnected Data Source..
        //It is a collection of DATATABLES 
        // using dataset we can do transactions with multiple DATATABLES of DATASET..
        //the memory allocated by it is not in hard disk but in the memory of our web server...

        //GridView d = new GridView();
        //d.DataSource = dset;
        //d.DataBind();


        //_____________________________INSERTING of DATASET IS SAME LIKE DATATABLE____________________________

        public static void InsertAgainUsingDataSet()
        {

            using (SqlConnection connection = new SqlConnection("Server=.; Database=ShoppingCartT4; Integrated Security=true"))
            {

                string sqlQuery = @"insert into customer(customer_id,username,firstname,password,session_id,lastname) values ('1200','innn','bbbb','21221','','rere')";
                SqlDataAdapter sqlcommand = new SqlDataAdapter(sqlQuery, connection);
                DataSet ds = new DataSet();
                sqlcommand.Fill(ds);

            }

        }

        //_____________________________READING USING DATASET____________________________
        //
        //########UNSUCCESSFULL : GRIDVIEW AND DATASET..

        public static DataSet reading()
        {
            DataSet ds;
            using (SqlConnection connection = new SqlConnection("Server=.; Database=ShoppingCartT4; Integrated Security=true"))
            {

                string sqlQuery = @"select * from customer";
                SqlDataAdapter sqlcommand = new SqlDataAdapter(sqlQuery, connection);
                ds = new DataSet();
                sqlcommand.Fill(ds);

            }
            return ds;
        }
    }
}