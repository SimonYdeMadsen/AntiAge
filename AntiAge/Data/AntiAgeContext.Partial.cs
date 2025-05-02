using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Entities;

namespace WebApplication1.Data;

public partial class AntiAgeContext(DbContextOptions<AntiAgeContext> options) : IdentityDbContext<User, IdentityRole<int>, int>(options)
{
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("identity");

        modelBuilder.Entity<User>(entity =>
        {
            // Specify the primary key column name
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("user_id"); // Map Id to user_id

            // Set the table name
            entity.ToTable("Users");
        });
    }

}
//public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User, IdentityRole<int>, int>(options)
//{
//    //public DbSet<BioMarker> BioMarkers { get; set; }
//    //public DbSet<UsersBioMarker> UsersBioMarkers { get; set; }

//    protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
//        base.OnModelCreating(modelBuilder);

//        modelBuilder.HasDefaultSchema("identity");

//        modelBuilder.Entity<User>(entity =>
//        {
//            // Specify the primary key column name
//            entity.HasKey(u => u.Id);
//            entity.Property(u => u.Id).HasColumnName("user_id"); // Map Id to user_id

//            // Set the table name
//            entity.ToTable("Users");
//        });
//    }
//}
//    modelBuilder.Entity<BioMarker>().ToTable("Biomarkers");
//    modelBuilder.Entity<UsersBioMarker>().ToTable("Users_Biomarkers");

//    modelBuilder.Entity<User>().HasKey(user => user.Id);
//    modelBuilder.Entity<BioMarker>().HasKey(biomarker => biomarker.Id);
//    modelBuilder.Entity<UsersBioMarker>().HasKey(ub => ub.Id);

//    modelBuilder.Entity<UsersBioMarker>()
//        .HasOne(ub => ub.User)
//        .WithMany(u => u.UsersBioMarkers)
//        .HasForeignKey(ub => ub.UserId);

//    modelBuilder.Entity<UsersBioMarker>()
//        .HasOne(ub => ub.BioMarker)
//        .WithMany(b => b.UsersBioMarkers)
//        .HasForeignKey(ub => ub.BioMarkerId);
//}