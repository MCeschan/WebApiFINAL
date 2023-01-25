using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWAdventureWorks_Ceschan.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace SWAdventureWorks_Ceschan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AdventureWorks2019Context context;

        //constructor
        public DepartmentController(AdventureWorks2019Context context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Department>> Get()
        {
            return context.Departments.ToList();

        }
        [HttpGet("{id}")]
        public ActionResult<Department> GetById(short id)
        {
            Department department = (from a in context.Departments
             where a.DepartmentId == id
            select a).SingleOrDefault();
            return department;
 
        }
        [HttpGet("listado/{name}")] 
        public ActionResult<IEnumerable<Department>> GetEdad(string name)
        {
            List<Department> departamentos = (from a in context.Departments
                                   where a.Name == name
                                   select a).ToList();
            return departamentos;

        }
        [HttpPost]
        public ActionResult Post(Department department)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            context.Departments.Add(department); 
            context.SaveChanges();
            return Ok(); 

        }
        //
        //
        //-----------ADICIONALES
        //
        //
        [HttpPut("{id}")]
        public ActionResult Put(short id, [FromBody] Department department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }
            context.Entry(department).State = EntityState.Modified; 
            context.SaveChanges(); 
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Department> Delete(short id)
        {
            var department = (from a in context.Departments
                             where a.DepartmentId == id
                             select a).SingleOrDefault();

            if (department == null)
            {
                return NotFound();
            }
            context.Departments.Remove(department);
            context.SaveChanges();
            return department;

        }
    }
}
