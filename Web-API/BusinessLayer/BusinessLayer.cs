using System;
using System.Collections.Generic;
using System.Data;
using Web_API.Data_Layer;
using Web_API.Models;

namespace Web_API.BusinessLayer
{
    public class BL
    {
        private readonly StudentDataLayer studentDataLayer;
        public BL()
        {
            studentDataLayer = new StudentDataLayer();
        }
        public List<Student> GetStudents()
        {
            try
            {
                return studentDataLayer.GetStudents();
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                    + " is encountered in GetStudents due to " + exception.Message, exception.InnerException);
            }
        }
        public List<string> SearchStudents(string searchTerm)
        {
            try
            {
                List<Student> students = studentDataLayer.SearchStudents(searchTerm);

                List<string> firstNames = new List<string>();
                foreach (Student student in students)
                {
                    firstNames.Add(student.FirstName);
                }

                return firstNames;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                    + " is encountered in SearchStudents due to " + exception.Message, exception.InnerException);
            }
        }
        public List<Task> GetTasks()
        {
            try
            {
                TaskDataLayer taskDataLayer = new TaskDataLayer();
                return taskDataLayer.GetTasks();
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                    + " is encountered in GetTasks due to " + exception.Message, exception.InnerException);
            }
        }
        public List<CompletedTask> GetCompletedTasks()
        {
            try
            {
                TaskDataLayer taskDataLayer = new TaskDataLayer();
                return taskDataLayer.GetCompletedTasks(); 
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                    + " is encountered in GetCompletedTasks due to " + exception.Message, exception.InnerException);
            }
        }
        public int InsertTask(Task task)
        {
            try
            {
                TaskDataLayer taskDataLayer = new TaskDataLayer();
                return taskDataLayer.InsertTask(task);
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                    + " is encountered in InsertTask due to " + exception.Message, exception.InnerException);
            }
        }
        public int DeleteTask(int taskID)
        {
            try
            {
                TaskDataLayer taskDataLayer = new TaskDataLayer();
                return taskDataLayer.DeleteTask(taskID);
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in DeleteTask due to " + exception.Message, exception.InnerException);
            }
        }
        public int UpdateTaskIsCompletedStatus(int taskID, bool isCompleted)
        {
            try
            {
                TaskDataLayer taskDataLayer = new TaskDataLayer();
                return taskDataLayer.UpdateTaskIsCompletedStatus(taskID, isCompleted);
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                   + " is encountered in UpdateTaskIsCompletedStatus due to " + exception.Message, exception.InnerException);
            }
        }
        public int UpdateTaskDescription(int taskID, string description)
        {
            try
            {
                TaskDataLayer taskDataLayer = new TaskDataLayer();
                return taskDataLayer.UpdateTaskDescription(taskID, description);
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                    + " is encountered in UpdateTaskDescription due to " + exception.Message, exception.InnerException);
            }
        }
    }
}