using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CRUD.Models
{
    public partial class DBTestContext : DbContext
    {
  
        public DBTestContext(DbContextOptions<DBTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("server=DEV04\\SQL2017;database=DBTest;integrated security=false;user id=sa;password=sasa");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

//            modelBuilder.Entity<Employee>(entity =>
//            {
//                entity.Property(e => e.Id).HasColumnName("id");

//                entity.Property(e => e.Name)
//                    .HasColumnName("name")
//                    .HasMaxLength(150);

//                entity.Property(e => e.Phone)
//                    .HasColumnName("phone")
//                    .HasMaxLength(50);

//                entity.Property(e => e.Ssn)
//                    .HasColumnName("ssn")
//                    .HasMaxLength(50);
//            });
//        }
    }
}
