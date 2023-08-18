using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Web_API.Models;

namespace Web_API.Data_Layer
{
    public class TaskDataLayer
    {
        string _connectionString = "";
        public TaskDataLayer()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["DemoCN"].ConnectionString;
        }
        public List<Task> GetTasks()
        {
            try
            {
                List<Task> tasks = new List<Task>();
                using (SqlConnection con=new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetTasks", con);
                    command.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    using (SqlDataReader reader=command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Task task = new Task
                            {
                                TaskID = reader["TaskID"] != DBNull.Value ? Convert.ToInt32(reader["TaskID"]) : 0,
                                Description = reader["Description"] != DBNull.Value ? Convert.ToString(reader["Description"]) : string.Empty,
                                Position = reader["Position"] != DBNull.Value ? Convert.ToInt32(reader["Position"]) : 0,
                                CreatedAt = reader["CreatedAt"] != DBNull.Value ? Convert.ToDateTime(reader["CreatedAt"]) : DateTime.MinValue,
                                UpdatedAt = reader["UpdatedAt"] != DBNull.Value ? Convert.ToDateTime(reader["UpdatedAt"]) : DateTime.MinValue,
                                IsCompleted = reader["IsCompleted"] != DBNull.Value ? Convert.ToBoolean(reader["IsCompleted"]) : false
                            };
                            tasks.Add(task);
                        }
                    }
                    con.Close();
                }
                return tasks;
            }
            catch(Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetTasks due to "
                   + exception.Message, exception.InnerException);
            }
        }
        public List<CompletedTask> GetCompletedTasks()
        {
            try
            {
                List<CompletedTask> completedTasks = new List<CompletedTask>();
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("GetCompletedTasks", con);
                    command.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CompletedTask completedTask = new CompletedTask
                            {
                                CompletedTaskID = Convert.ToInt32(reader["CompletedTaskID"]),
                                TaskID = Convert.ToInt32(reader["TaskID"]),
                                CompletedAt = Convert.ToDateTime(reader["CompletedAt"])
                            };
                            completedTasks.Add(completedTask);
                        }
                    }

                    con.Close();
                }
                return completedTasks;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in GetCompletedTasks due to "
                   + exception.Message, exception.InnerException);
            }
        }
        public int InsertTask(Task task)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("InsertTask", con);
                    command.CommandType = CommandType.StoredProcedure;

                    
                    command.Parameters.AddWithValue("@Description", task.Description);
                    command.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);

                    con.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    con.Close();

                    return rowsAffected;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in InsertTask due to "
                   + exception.Message, exception.InnerException);
            }
        }
        public int DeleteTask(int taskID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("DeleteTask", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TaskID", taskID);

                    con.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    con.Close();

                    return rowsAffected;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in DeleteTask due to "
                   + exception.Message, exception.InnerException);
            }
        }
        public int UpdateTaskIsCompletedStatus(int taskID, bool isCompleted)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("UpdateTaskIsCompletedStatus", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TaskID", taskID);
                    command.Parameters.AddWithValue("@IsCompleted", isCompleted);

                    con.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    con.Close();

                    return rowsAffected;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UpdateTaskIsCompletedStatus due to "
                   + exception.Message, exception.InnerException);
            }
        }
        public int UpdateTaskDescription(int taskID, string description)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    SqlCommand command = new SqlCommand("UpdateTaskDescription", con);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TaskID", taskID);
                    command.Parameters.AddWithValue("@Description", description);

                    con.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    con.Close();

                    return rowsAffected;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                    + " is encountered in UpdateTaskDescription due to "
                    + exception.Message, exception.InnerException);
            }
        }
    }
}