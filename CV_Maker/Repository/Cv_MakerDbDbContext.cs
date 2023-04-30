using System;
using System.Collections.Generic;
using CV_Maker.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CV_Maker.Repository;

public partial class Cv_MakerDbDbContext : DbContext
{
    public Cv_MakerDbDbContext()
    {
    }

    public Cv_MakerDbDbContext(DbContextOptions<Cv_MakerDbDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PersonalDetail> PersonalDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-6NI3VK2\\SQLEXPRESS;Initial Catalog=CV_MakerDb;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonalDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Personal__3214EC079CDC45B3");
        });
        modelBuilder.Entity<PersonalDetail>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
