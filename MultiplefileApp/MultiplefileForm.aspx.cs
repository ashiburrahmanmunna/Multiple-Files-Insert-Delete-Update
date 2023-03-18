using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;


namespace MultiplefileApp
{
    public partial class MultiplefileForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ML3UPSH\\SQLEXPRESS;Initial Catalog=MultiplefileApp;Persist Security Info=True;User ID=sa;Password=Munna12345");

            //SqlCommand cmd = new SqlCommand(@"INSERT INTO [dbo].[MultiplefileApp] ([ID] ,[Name], [Multiplefile])     
            //VALUES('" + ID.Text+ "', '"+Name.Text+ "', '"+ FileUpload1+"')", con); 

            SqlCommand cmd = new SqlCommand("INSERT INTO MultiplefileApp(ID,Name,Multiplefile) VALUES(@ID,@Name,@FileUpload1)", con);

            con.Open();
            
            Response.Write("Data inserted successfully");
            

            if (FileUpload1.HasFiles)
            {
                foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                {
                    cmd.Parameters.AddWithValue("@ID", ID.Text);
                    cmd.Parameters.AddWithValue("@Name", Name.Text);
                    cmd.Parameters.AddWithValue("@FileUpload1", file.FileName);
                    file.SaveAs(Path.Combine(Server.MapPath("/Files/"), file.FileName));
                    
                }
            }
            
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            con.Close();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ML3UPSH\\SQLEXPRESS;Initial Catalog=MultiplefileApp;Persist Security Info=True;User ID=sa;Password=Munna12345");
            SqlCommand cmd = new SqlCommand(@"DELETE FROM [dbo].[MultiplefileApp]
            WHERE [ID]='"+ID.Text+ "'",con);
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Write("Data deleted successfully");
            con.Close();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-ML3UPSH\\SQLEXPRESS;Initial Catalog=MultiplefileApp;Persist Security Info=True;User ID=sa;Password=Munna12345");
            SqlCommand cmd = new SqlCommand(@"UPDATE [dbo].[MultiplefileApp]   
            SET [ID] = '"+ID.Text+ "'  ,[Name] = '"+Name.Text+ "' , [Multiplefile]='"+ FileUpload1+"'  WHERE [ID]= '" + ID.Text+"'",con);
            con.Open();
            cmd.ExecuteNonQuery();
            Response.Write("Data Updated successfully");
            con.Close();
        }
    }
}