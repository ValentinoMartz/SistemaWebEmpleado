using Microsoft.EntityFrameworkCore;
using SistemaWebEmpleado.Models;

namespace SistemaWebEmpleado.Data
{
    public class DBEmpleados : DbContext
    {
        public DBEmpleados(DbContextOptions<DBEmpleados> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
