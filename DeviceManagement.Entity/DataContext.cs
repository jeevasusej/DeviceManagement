
using DeviceManagement.Entity.Enum;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DeviceManagement.Entity
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Role>()
                         .HasData(
                new Role { Id = (byte)UserRole.Superadmin, Name = "Super Admin" },
                new Role { Id = (byte)UserRole.Admin, Name = "Admin" },
                new Role { Id = (byte)UserRole.User, Name = "User" });

            modelBuilder.Entity<Credential>()
                .Property(d => d.Id)
                .ValueGeneratedOnAdd();

            // Single Navigation Property
            // Including just one navigation property(no inverse navigation, and no foreign key property)
            // is enough to have a relationship defined by convention. 
            // You can also have a single navigation property and a foreign key property.
            modelBuilder.Entity<Device>(d =>
             {
                 d.Property(p => p.Id)
                    .ValueGeneratedOnAdd();
                 d.Property(p => p.IsDeleted)
                    .HasDefaultValue(false);

                 d.HasOne<User>(p => p.CreatedUser)
                  .WithMany().HasForeignKey(x => x.CreatedBy)
                  .OnDelete(DeleteBehavior.Restrict);

                 d.HasOne<User>(p => p.UpdatedUser)
                  .WithMany().HasForeignKey(x => x.UpdatedBy)
                  .OnDelete(DeleteBehavior.Restrict);
             });

            modelBuilder.Entity<Credential>(d =>
            {
                d.HasOne<User>(p => p.CreatedUser)
                 .WithMany().HasForeignKey(x => x.CreatedBy)
                 .OnDelete(DeleteBehavior.Restrict);

                d.HasOne<User>(p => p.UpdatedUser)
                 .WithMany().HasForeignKey(x => x.UpdatedBy)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserDevice>(d =>
            {
                d.Property(p => p.Id).ValueGeneratedOnAdd();
                d.Property(p => p.IsApproved).HasDefaultValue(false);
                d.Property(p => p.IsRejected).HasDefaultValue(false);

                d.HasOne<User>(p => p.CreatedUser)
                 .WithMany().HasForeignKey(x => x.CreatedBy)
                 .OnDelete(DeleteBehavior.Restrict);

                d.HasOne<User>(p => p.UpdatedUser)
                 .WithMany().HasForeignKey(x => x.UpdatedBy)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // One to Many Relationship
            modelBuilder.Entity<Credential>()
               .HasOne(d => d.Device)
               .WithMany(c => c.Credentials)
               .HasForeignKey(d => d.DeviceId)
               .OnDelete(DeleteBehavior.Restrict);

            // Many to Many relationship
            modelBuilder.Entity<UserDevice>()
                .HasKey(ud => new { ud.DeviceId, ud.UserId });

            modelBuilder.Entity<UserDevice>()
                   .HasOne(ud => ud.Device)
                   .WithMany(d => d.UserDevice)
                   .HasForeignKey(ud => ud.DeviceId)
                   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserDevice>()
                .HasOne(ud => ud.User)
                .WithMany(u => u.UserDevice)
                .HasForeignKey(ud => ud.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}