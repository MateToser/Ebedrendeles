﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ebedrendeles_adatbazis
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class cnAdatbazis : DbContext
    {
        public cnAdatbazis()
            : base("name=cnAdatbazis")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<enKosar> enKosarSet { get; set; }
        public virtual DbSet<enAlacarte> enAlacarteSet { get; set; }
        public virtual DbSet<enEtelek> enEtelekSet { get; set; }
        public virtual DbSet<enMenu> enMenuSet { get; set; }
        public virtual DbSet<enNetelek> enNetelekSet { get; set; }
        public virtual DbSet<enFelhasznalo> enFelhasznaloSet { get; set; }
    }
}
