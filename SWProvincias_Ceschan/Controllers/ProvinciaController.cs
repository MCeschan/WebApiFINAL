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
    public class ProvinciaController : ControllerBase
    {
        //ESTO ES INYECCIÓN DE DEPENDENCIA---INICIA
        //propiedad
        private readonly DBPaisFinalContext context;

        //constructor
        public ProvinciaController(DBPaisFinalContext context)
        {
            this.context = context;
        }
        //FINALIZA
        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get()
        {
            return context.Provincias.ToList();

        }
        [HttpPost]
        public ActionResult Post(Provincia provincia)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            context.Provincias.Add(provincia); 
            context.SaveChanges();
            return Ok(); 

        }
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Provincia provincia)
        {
            if (id != provincia.IdProvincia)
            {
                return BadRequest();
            }
            context.Entry(provincia).State = EntityState.Modified; 
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Provincia> Delete(int id)
        {
            var provincia = (from a in context.Provincias
                         where a.IdProvincia == id
                         select a).SingleOrDefault();
           

            if (provincia == null)
            {
                return NotFound();
            }
            context.Provincias.Remove(provincia);
            context.SaveChanges();
            return provincia;

        }
    }
}
