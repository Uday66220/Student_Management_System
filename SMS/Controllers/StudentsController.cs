using Microsoft.AspNetCore.Mvc;
using SMS.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        StudentManagementContext SContext;
        public StudentsController() 
        {
            SContext= new StudentManagementContext();
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
           IEnumerable<Student> students = SContext.Students;
            return students;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            Student s=SContext.Students.Find(id);
            return s;
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Student value)
        {
            SContext.Students.Add( value);
            SContext.SaveChanges();
        }

        // PUT api/<StudentsController>/5
        //update
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Student value)
        {
            SContext.Students.Update(value);

        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Student s= SContext.Students.Find( id);
            SContext.Students.Remove(s);
            SContext.SaveChanges();
        }
    }
}
