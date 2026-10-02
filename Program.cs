
using Microsoft.Data.SqlClient;
using System.Data;

namespace ado.net_project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // define contion string 
            string connction = "Server=.\\SQLEXPRESS;Database=ado;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true";
            // define connction with data base

            SqlConnection sqlConnection = new SqlConnection(connction);

            // define opject 
            SqlDataAdapter sqladpter=new SqlDataAdapter("select * from Employes",sqlConnection);

            SqlCommandBuilder sqlpelder=new SqlCommandBuilder(sqladpter); // علشان الداتا تسمع في الداتا بيز في  حاله الاضافه 

            DataTable dataTable = new DataTable(); // reed from data base  data row and data colum 


            // sava data in data base 

            sqladpter.Fill(dataTable);

            ///to want print data base

            foreach (DataRow item in dataTable.Rows)
            {
                Console.WriteLine($"the ID = {item["ID"]} | Fname = {item["fname"]} | Lname = {item["lname"]} | age = {item["age"]}");
            }

            Console.WriteLine("______________________");
            ///// add row in data base 
            
            DataRow newemp= dataTable.NewRow();

            newemp["Id"] = 5;
            newemp["fname"] = "ahmed";
            newemp["Lname"] = "waled";
            newemp["age"] = 55;

            dataTable.Rows.Add(newemp);

            foreach (DataRow item in dataTable.Rows)
            {
                Console.WriteLine($"the ID = {item["ID"]} | Fname = {item["fname"]} | Lname = {item["lname"]} | age = {item["age"]}");
            }
            sqladpter.Update(dataTable);





        }
    }
}
