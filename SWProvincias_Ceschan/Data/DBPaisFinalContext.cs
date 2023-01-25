using Microsoft.EntityFrameworkCore;
using SWProvincias_Ceschan.Models;

namespace SWProvincias_Ceschan.Data
{
    public class DBPaisFinalContext:DbContext
    {
        public DBPaisFinalContext(DbContextOptions<DBPaisFinalContext> options) : base(options) { }

        //Propiedades
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
    }
}
