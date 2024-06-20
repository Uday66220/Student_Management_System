using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMS.Models;

namespace SMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendencesController : ControllerBase
    {
        StudentManagementContext SContext;
        public AttendencesController()
        {
            SContext = new StudentManagementContext();
        }
        // GET: api/<AttendencesController>
        [HttpGet]
        public IEnumerable<Attendence> Get()
        {
            IEnumerable<Attendence> attendences = SContext.Attendences;
            return attendences;
        }

        // GET api/<AttendencesController>/5
        [HttpGet("{id}")]
        public Attendence Get(int id)
        {
            Attendence s = SContext.Attendences.Find(id);
            return s;
        }

        // POST api/<AttendencesController>
        [HttpPost]
        public void Post([FromBody] Attendence value)
        {
            SContext.Attendences.Add(value);
            SContext.SaveChanges();
        }

        // PUT api/<AttendencesController>/5
        //update
        [HttpPut("{id}")]
        public void Put(int id, Attendence value)
        {
            if (id == value.Student_id)
            {
                SContext.Attendences.Update(value);
                SContext.SaveChanges();
            }
            
        }

            

        

        // DELETE api/<AttendencesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Attendence s = SContext.Attendences.Find(id);
            SContext.Attendences.Remove(s);
            SContext.SaveChanges();
        }
    }
}
