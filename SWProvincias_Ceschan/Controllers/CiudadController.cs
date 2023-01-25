using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProvincias_Ceschan.Data;
using SWProvincias_Ceschan.Models;
using System.Collections.Generic;
using System.Linq;

namespace SWProvincias_Ceschan.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        //ESTO ES INYECCIÓN DE DEPENDENCIA---INICIA
        //propiedad
        private readonly DBPaisFinalContext context;

        //constructor
        public CiudadController(DBPaisFinalContext context)
        {
            this.context = context;
        }
        //FINALIZA
        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> Get()
        {
            return context.Ciudades.ToList();

        }
        [HttpPost]
        public ActionResult Post(Ciudad ciudad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Ciudades.Add(ciudad);
            context.SaveChanges();
            return Ok();

        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Ciudad ciudad)
        {
            if (id != ciudad.IdCiudad)
            {
                return BadRequest();
            }
            context.Entry(ciudad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Ciudad> Delete(int id)
        {
            var ciudad = (from a in context.Ciudades
                             where a.IdCiudad == id
                             select a).SingleOrDefault();


            if (ciudad == null)
            {
                return NotFound();
            }
            context.Ciudades.Remove(ciudad);
            context.SaveChanges();
            return ciudad;

        }
    }
}
