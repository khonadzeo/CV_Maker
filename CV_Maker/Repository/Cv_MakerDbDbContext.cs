using System;
using System.Collections.Generic;
using CV_Maker.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace CV_Maker.Repository;
/// <summary>
/// database configurations
/// </summary>
public partial class Cv_MakerDbDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public Cv_MakerDbDbContext()
    {
    }

    public Cv_MakerDbDbContext(IConfiguration configuration,DbContextOptions<Cv_MakerDbDbContext> options)
        : base(options)
    {
        _configuration = configuration; 
    }

    public virtual DbSet<PersonalDetail> PersonalDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = _configuration.GetConnectionString("CV_Maker");
        if (!optionsBuilder.IsConfigured) 
        {
            optionsBuilder.UseSqlServer(config);
        
        }

    }


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
