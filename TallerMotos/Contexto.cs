﻿using System;
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
        public DbSet<TallerMotos.Models.Empleados> Empleados { get; set; }
        //public virtual DbSet<Clientes> Clientes { get; set; }
        //public virtual DbSet<Empleados> Empleados { get; set; }
    }
}
