using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TallerMotos.Models;
using TallerMotos.Models.ViewData;


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
        
        public DbSet<Facturas> Facturas { get; set; }
        
        public DbSet<TallerMotos.Models.Productos> Productos { get; set; }

        public DbSet<TallerMotos.Models.Proveedores> Proveedores { get; set; }
        
        public DbSet<TallerMotos.Models.VentasLineas> VentasLineas { get; set; }
        
        public DbSet<TallerMotos.Models.Usuarios> Usuarios { get; set; }
        
        public DbSet<TallerMotos.Models.ViewData.Fabricantes> Fabricantes { get; set; }
    }
}
