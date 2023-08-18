using System;
using System.Collections.Generic;
using System.Web.Http;
using Web_API.Models;
using Web_API.BusinessLayer;

namespace Web_API.Controllers
{
    public class StudentController : ApiController
    {
        private readonly BL businessLayer;

        public StudentController()
        {
            businessLayer = new BL();
        }
        [HttpGet]
        [Route("GetStudents")]
        public IEnumerable<Student> GetStudents()
        {
            try
            {
                List<Student> student = businessLayer.GetStudents();
                return student;
            }
            catch (Exception exception)
            {
                throw new Exception("An exception of type " + exception.GetType().ToString()
                    + " is encountered in GetStudents due to " + exception.Message, exception.InnerException);
            }
        }
        [HttpGet]
        [Route("SearchStudents")]
        public IHttpActionResult Search(string searchTerm)
        {
            var firstNames = businessLayer.SearchStudents(searchTerm);
            return Ok(firstNames);
        }
    }
}