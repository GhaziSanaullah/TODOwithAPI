using System;
using System.Collections.Generic;
using System.Web.Http;
using Web_API.Models;
using Web_API.BusinessLayer;

namespace Web_API.Controllers
{
    public class TaskController : ApiController
    {
        private readonly BL taskBusinessLayer;
        public TaskController()
        {
            taskBusinessLayer = new BL();
        }
        [HttpGet]
        [Route("GetTasks")]
        public IEnumerable<Task> GetTasks()
        {
            try
            {
                List<Task> tasks = taskBusinessLayer.GetTasks();
                return tasks;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                    + " is encountered in GetTasks due to " + exception.Message, exception.InnerException);
            }
        }
        [HttpGet]
        [Route("GetCompletedTasks")]
        public IEnumerable<CompletedTask> GetCompletedTasks()
        {
            try
            {
                List<CompletedTask> completedTasks = taskBusinessLayer.GetCompletedTasks();
                return completedTasks;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                    + " is encountered in GetCompletedTasks due to " + exception.Message, exception.InnerException);
            }
        }
        [HttpPost]
        [Route("InsertTask")]
        public IHttpActionResult InsertTask(Task task)
        {
            try
            {
                int rowsAffected = taskBusinessLayer.InsertTask(task);
                if (rowsAffected > 0)
                {
                    return Ok("Task inserted successfully");
                }
                else
                {
                    return BadRequest("Failed to insert task");
                }
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        [HttpPost]
        [Route("DeleteTask/{taskID}")]
        public IHttpActionResult DeleteTask(int taskID)
        {
            try
            {
                int rowsAffected = taskBusinessLayer.DeleteTask(taskID);
                if (rowsAffected > 0)
                {
                    return Ok("Task deleted successfully");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        [HttpPost]
        [Route("UpdateTaskIsCompletedStatus/{taskID}/{isCompleted}")]
        public IHttpActionResult UpdateTaskIsCompletedStatus(int taskID, bool isCompleted)
        {
            try
            {
                int rowsAffected = taskBusinessLayer.UpdateTaskIsCompletedStatus(taskID, isCompleted);

                if (rowsAffected > 0)
                {
                    return Ok("Task completion status updated successfully");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
        [HttpPost]
        [Route("UpdateTaskDescription/{taskID}")]
        public IHttpActionResult UpdateTaskDescription(int taskID, [FromBody] string newDescription)
        {
            try
            {
                int rowsAffected = taskBusinessLayer.UpdateTaskDescription(taskID, newDescription);

                if (rowsAffected > 0)
                {
                    return Ok("Task description updated successfully");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }
        }
    }
}