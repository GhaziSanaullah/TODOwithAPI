using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Web_API.Models;

namespace Web_API.Data_Layer
{
    public class StudentDataLayer
    {
        string _connectionString = "";

        public StudentDataLayer()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["DemoCN"].ConnectionString;
        }
        public List<Student> GetStudents()
        {
            try
            {
                List<Student> students = new List<Student>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetStudents", con);
                    command.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student studentt = new Student
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                FirstName = Convert.ToString(reader["FirstName"]),
                                LastName = Convert.ToString(reader["LastName"]),
                                Age = Convert.ToInt32(reader["Age"]),
                                Course = Convert.ToString(reader["Course"]),
                            };
                            students.Add(studentt);
                        }
                    }

                    con.Close();
                }
                return students;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetStudent due to "
                   + exception.Message, exception.InnerException);
            }
        }
        public List<Student> SearchStudents(string searchTerm)
        {
            try
            {
                List<Student> students = new List<Student>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("SearchStudents", con);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@SearchTerm", searchTerm);

                    con.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                ID = Convert.ToInt32(reader["ID"]),
                                FirstName = Convert.ToString(reader["FirstName"]),
                                LastName = Convert.ToString(reader["LastName"]),
                                Age = Convert.ToInt32(reader["Age"]),
                                Course = Convert.ToString(reader["Course"]),
                            };
                            students.Add(student);
                        }
                    }
                    con.Close();
                }
                return students;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in SearchStudents due to "
                   + exception.Message, exception.InnerException);
            }
        }
    }
}