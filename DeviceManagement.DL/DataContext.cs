using DeviceManagement.DL.Modal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManagement.DL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditTrail>()
                    .Property(u => u.Id)
                    .ValueGeneratedOnAdd();

            modelBuilder.Entity<AuditTrail>()
                    .HasOne(p => p.User)
                    .WithMany(b => b.AuditTrails)
                    .HasForeignKey(p => p.UserId)
                    .HasConstraintName("ForeignKey_AuditTrail_User");

            modelBuilder.Entity<Device>()
                   .Property(u => u.Id)
                   .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserDevice>().HasKey(ud => new { ud.UserId, ud.DeviceId });
            modelBuilder.Entity<UserDevice>()
                   .HasOne<User>(ud => ud.User)
                   .WithMany(u => u.UserDevices)
                   .HasForeignKey(ud => ud.UserId);

            modelBuilder.Entity<UserDevice>()
                     .HasOne<Device>(up => up.Device)
                     .WithMany(p => p.UserDevice)
                     .HasForeignKey(ud => ud.DeviceId);

            modelBuilder.Entity<UserDevice>()
                  .HasOne(ud => ud.DeviceStatus)
                  .WithMany(ds => ds.UserDevice)
                  .HasForeignKey(ud => ud.Status)
                  .HasConstraintName("ForeignKey_UserDevice_DeviceStatus");

            modelBuilder.Entity<User>()
                  .Property(u => u.LastLoginOn)
                  .IsRequired(false);
            modelBuilder.Entity<UserDevice>()
                  .Property(u => u.RejectedOn)
                  .IsRequired(false);
            modelBuilder.Entity<UserDevice>()
                  .Property(u => u.RequestedOn)
                  .IsRequired(true);

            modelBuilder.Entity<User>()
                  .HasOne(p => p.Role)
                  .WithMany(b => b.Users)
                  .HasForeignKey(p => p.RoleId)
                  .HasConstraintName("ForeignKey_User_Role");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<UserDevice> UserDevices { get; set; }
        public DbSet<AuditTrail> AuditTrails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<DeviceStatus> DeviceStatus { get; set; }
    }
}
