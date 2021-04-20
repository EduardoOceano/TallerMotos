using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


namespace TallerMotos.Models
{
    public class Contexto: DbContext
    {
        public Contexto([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Accesorios> Accesorios { get; set; }
    }
}
