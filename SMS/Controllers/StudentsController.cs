using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SMS.Models;


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
        [HttpGet("Get")]
        public IEnumerable<Student> Get()
        {
           IEnumerable<Student> students = SContext.Students;
            return students;
        }

        // GET api/<StudentsController>/5
        //1) Check studentID in get student by id call
        [HttpGet("GetbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Student s=SContext.Students.Find(id);
            if (s != null)
            {
                return Ok(s);
            }
            return BadRequest("The student not exist");
        }

        // POST api/<StudentsController>
        //2) Check student data before performing add student operation i.e.,
        //a) check if year is not in the past
        //b) check if class id exists or not(make a db call using the given class id)
        //c) check if roll number is not negative
        //3) Check if the student was added correctly after the add operation
        [HttpPost("Post")]
        public async Task<IActionResult> Post(Student value)
        {
            if (value.Year>DateTime.Now.Year)
            {
                return BadRequest("Year should be below the current year");
                
            }
            var cl = SContext.Classes.Include(x => x.Students)
                .Select(x => new Class
                {
                    ClassId = x.ClassId,
                    ClassTeacherId = x.ClassTeacherId,
                    Students=x.Students
                }) ;

            var cid=cl.Where(x => x.ClassId == value.ClassId).ToList();
            if (cid.Any()==false)
            {
                return BadRequest("ClassId is not valid");
            }
            if (value.RollNo < 0)
            {
                return BadRequest("Roll No(Studentid) is not valid");
            }

            if (ModelState.IsValid)
            {
                SContext.Students.Add(value);
                SContext.SaveChanges();
                return Ok("Student added Successfully");
            }
            else
            {
                return BadRequest("Student not added");
            }
        }

        // PUT api/<StudentsController>/5
        //update
        [HttpPut("Update/{id}")]
        public void Put(int id, Student value)
        {
            SContext.Students.Update(value);

        }

        // DELETE api/<StudentsController>/5
        //4) Check if the student exists before performing delete operation
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Student s= SContext.Students.Find( id);
            if (s != null)
            {
                var ss=SContext.StudentSubjects.Find(id);
                if (ss != null)
                {
                    SContext.StudentSubjects.Remove(ss);
                    SContext.SaveChanges();
                }

                SContext.Students.Remove(s);
                SContext.SaveChanges();
                return Ok("Student Deleted Successfully");
            }
            return BadRequest("Student Not Exist");
        }
    }
}
