using MVCAppWithDB.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCAppWithModel.Repository
{
    public class StudentRepository
    {

        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["getconn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Student details    
        public bool AddStudent(StudentModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("AddStudentDetails", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //To view Student details with generic list     
        public List<StudentModel> GetAllStudents()
        {
            connection();
            List<StudentModel> StudentList = new List<StudentModel>();

            SqlCommand com = new SqlCommand("GetStudents", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            //Bind StudentListModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {
                StudentList.Add(
                    new StudentModel
                    {

                        ID = Convert.ToInt32(dr["Id"]),
                        Name = Convert.ToString(dr["Name"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"])
                    }
                    );
            }
            return StudentList;
        }
        //To Update Student details    
        public bool UpdateStudent(StudentModel obj)
        {
            connection();
            SqlCommand com = new SqlCommand("UpdateStudentDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", obj.ID);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@City", obj.City);
            com.Parameters.AddWithValue("@Address", obj.Address);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete Student details    
        public bool DeleteStudent(int Id)
        {
            connection();
            SqlCommand com = new SqlCommand("DeleteStudentById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ID", Id);

            con.Open(); 
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}