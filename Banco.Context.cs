﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjGaragem
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GaragemDBEntities1 : DbContext
    {
        public GaragemDBEntities1()
            : base("name=GaragemDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_CARRO> TB_CARRO { get; set; }
        public virtual DbSet<TB_CLIENTE> TB_CLIENTE { get; set; }
        public virtual DbSet<TB_FUNCIONARIO> TB_FUNCIONARIO { get; set; }
        public virtual DbSet<TB_Venda> TB_Venda { get; set; }
    }
}
