﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace is_takip_proje.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbistakipEntities : DbContext
    {
        public DbistakipEntities()
            : base("name=DbistakipEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblAdmin> TblAdmins { get; set; }
        public virtual DbSet<TblDepartmanlar> TblDepartmanlars { get; set; }
        public virtual DbSet<TblFirmalar> TblFirmalars { get; set; }
        public virtual DbSet<TblGorevDetaylar> TblGorevDetaylars { get; set; }
        public virtual DbSet<TblGorevler> TblGorevlers { get; set; }
        public virtual DbSet<TblPersonel> TblPersonels { get; set; }
    }
}
