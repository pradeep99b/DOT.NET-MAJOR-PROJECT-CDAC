using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MedLab.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MedLab.Models;

public partial class MedLabDatabaseContext : IdentityDbContext<IdentityUser>
{
    public MedLabDatabaseContext()
    {
    }

    public MedLabDatabaseContext(DbContextOptions<MedLabDatabaseContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MsSqlLocalDb;Initial Catalog=MedLabDatabase;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);

        modelBuilder.Entity<User>()
            .Property(u => u.UserRole)
            .HasConversion<string>();

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<MedLab.Models.Appointment> Appointment { get; set; } = default!;

public DbSet<MedLab.Models.Billing> Billing { get; set; } = default!;

public DbSet<MedLab.Models.City> City { get; set; } = default!;

public DbSet<MedLab.Models.Department> Department { get; set; } = default!;

public DbSet<MedLab.Models.LabAssistant> LabAssistant { get; set; } = default!;

public DbSet<MedLab.Models.Patient> Patient { get; set; } = default!;

public DbSet<MedLab.Models.Prescription> Prescription { get; set; } = default!;

public DbSet<MedLab.Models.Report> Report { get; set; } = default!;

public DbSet<MedLab.Models.SampleTracking> SampleTracking { get; set; } = default!;

public DbSet<MedLab.Models.State> State { get; set; } = default!;

public DbSet<MedLab.Models.Test> Test { get; set; } = default!;
}
