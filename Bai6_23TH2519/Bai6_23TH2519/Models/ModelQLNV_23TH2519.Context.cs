﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bai6_23TH2519.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLNV_23TH2519Entities : DbContext
    {
        public QLNV_23TH2519Entities()
            : base("name=QLNV_23TH2519Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<QuanTri> QuanTris { get; set; }
    }
}
