/*using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MedLab.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MedLab.Models;

public partial class MedLabContext : DbContext , : IdentityDbContext<IdentityUser>
{
    public MedLabContext()
    {
    }

    public MedLabContext(DbContextOptions<MedLabContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedLab;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<MedLab.Models.ContactMessage> ContactMessage { get; set; } = default!;

public DbSet<MedLab.Models.Invoice> Invoice { get; set; } = default!;

public DbSet<MedLab.Models.Payment> Payment { get; set; } = default!;

public DbSet<MedLab.Models.RefreshToken> RefreshToken { get; set; } = default!;

public DbSet<MedLab.Models.Report> Report { get; set; } = default!;

public DbSet<MedLab.Models.Test> Test { get; set; } = default!;

public DbSet<MedLab.Models.User> User { get; set; } = default!;

public DbSet<MedLab.Models.TestBooking> TestBooking { get; set; } = default!;

public DbSet<MedLab.Models.TestCategory> TestCategory { get; set; } = default!;
}
*/

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MedLab.Models;
using Microsoft.AspNetCore.Identity;

namespace MedLab.Models
{
    public partial class MedLabContext : IdentityDbContext<IdentityUser>
    {
        public MedLabContext()
        {
        }

        public MedLabContext(DbContextOptions<MedLabContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedLab;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Ensures Identity models are created
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<ContactMessage> ContactMessage { get; set; } = default!;
        public DbSet<Invoice> Invoice { get; set; } = default!;
        public DbSet<Payment> Payment { get; set; } = default!;
        public DbSet<RefreshToken> RefreshToken { get; set; } = default!;
        public DbSet<Report> Report { get; set; } = default!;
        public DbSet<Test> Test { get; set; } = default!;
        public DbSet<TestBooking> TestBooking { get; set; } = default!;
        public DbSet<TestCategory> TestCategory { get; set; } = default!;
    }
}
