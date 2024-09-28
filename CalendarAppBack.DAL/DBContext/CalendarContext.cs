using System;
using System.Collections.Generic;
using CalendarAppBack.Model;
using Microsoft.EntityFrameworkCore;

namespace CalendarAppBack.DAL;

public partial class CalendarContext : DbContext
{
    public CalendarContext()
    {
    }

    public CalendarContext(DbContextOptions<CalendarContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<UserCalendar> UserCalendars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
       

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.IdAppointment).HasName("PK__Appointm__44E34BD4CA68C4DF");

            entity.ToTable("Appointment");

            entity.Property(e => e.IdAppointment).HasColumnName("idAppointment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy).HasColumnName("createdBy");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.FirstNameClient)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("firstNameClient");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.NameAppointment)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nameAppointment");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Appointme__creat__4CA06362");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Appointme__idSer__4AB81AF0");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__Rol__E5045C54B068AA23");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.NameRole)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nameRole");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.IdService).HasName("PK__Services__0E3EA45BF33FAAE2");

            entity.Property(e => e.IdService).HasColumnName("idService");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.DescriptionServicios)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descriptionServicios");
            entity.Property(e => e.NameService)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nameService");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
        });

        modelBuilder.Entity<UserCalendar>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__UserCale__3717C982B89B0EC8");

            entity.ToTable("UserCalendar");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("createdAt");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("passwordUser");
            entity.Property(e => e.Rol).HasColumnName("rol");
            entity.Property(e => e.StateUser)
                .HasDefaultValueSql("((1))")
                .HasColumnName("stateUser");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updatedAt");
            entity.Property(e => e.UrlPhoto)
                .HasColumnType("text")
                .HasColumnName("urlPhoto");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("userName");

            entity.HasOne(d => d.RolNavigation).WithMany(p => p.UserCalendars)
                .HasForeignKey(d => d.Rol)
                .HasConstraintName("FK__UserCalenda__rol__440B1D61");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
