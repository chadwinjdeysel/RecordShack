﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecordShack.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RecordShackCMSEntities : DbContext
    {
        public RecordShackCMSEntities()
            : base("name=RecordShackCMSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tblArtist> tblArtists { get; set; }
        public virtual DbSet<tblGenre> tblGenres { get; set; }
        public virtual DbSet<tblRating> tblRatings { get; set; }
        public virtual DbSet<tblRecord> tblRecords { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblRole> tblRoles { get; set; }
        public virtual DbSet<tblUserRole> tblUserRoles { get; set; }

        public System.Data.Entity.DbSet<RecordShack.View_Models.Artist.EditViewModel> EditViewModels { get; set; }
    }
}
