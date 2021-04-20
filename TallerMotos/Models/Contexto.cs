using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TallerMotos.Models;


namespace TallerMotos.Models
{
    public class Contexto: DbContext
    {
        public Contexto([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Clientes> Clientes { get; set; }
        
        public virtual DbSet<Empleados> Empleados { get; set; }
        
        public DbSet<TallerMotos.Models.Talleres> Talleres { get; set; }
        
        public DbSet<TallerMotos.Models.Motos> Motos { get; set; }
        
        public DbSet<TallerMotos.Models.Servicios> Servicios { get; set; }
        public DbSet<Talleres> Talleres { get; set; }
        
        public DbSet<Facturas> Facturas { get; set; }
        
        public DbSet<TallerMotos.Models.Productos> Productos { get; set; }
        
        public DbSet<TallerMotos.Models.VentasLineal> VentasLineal { get; set; }
    }
}
