﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarRentals.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SuperCarRentalEntities1 : DbContext
    {
        public SuperCarRentalEntities1()
            : base("name=SuperCarRentalEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<carreg> carregs { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<Rentail> Rentails { get; set; }
        public virtual DbSet<returncar> returncars { get; set; }
    }
}
