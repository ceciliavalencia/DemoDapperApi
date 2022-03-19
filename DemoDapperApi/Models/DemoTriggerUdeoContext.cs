using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DemoDapperApi.Models
{
    public partial class DemoTriggerUdeoContext : DbContext
    {
        public DemoTriggerUdeoContext()
        {
        }

        public DemoTriggerUdeoContext(DbContextOptions<DemoTriggerUdeoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AuditoriaUsuario> AuditoriaUsuarios { get; set; }
        public virtual DbSet<Call> Calls { get; set; }
        public virtual DbSet<CallOutcome> CallOutcomes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-TM0P2M4\\SQLEXPRESS;Database=DemoTriggerUdeo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<AuditoriaUsuario>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioCreador)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Call>(entity =>
            {
                entity.ToTable("call");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CallOutcomeId).HasColumnName("call_outcome_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time");
            });

            modelBuilder.Entity<CallOutcome>(entity =>
            {
                entity.ToTable("call_outcome");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OutcomeText)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("outcome_text");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("city_name");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.Lat)
                    .HasColumnType("decimal(9, 6)")
                    .HasColumnName("lat");

                entity.Property(e => e.Long)
                    .HasColumnType("decimal(9, 6)")
                    .HasColumnName("long");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("country_code")
                    .IsFixedLength(true);

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("country_name");

                entity.Property(e => e.CountryNameEng)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("country_name_eng");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("customer_address");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("customer_name");

                entity.Property(e => e.NextCallDate)
                    .HasColumnType("date")
                    .HasColumnName("next_call_date");

                entity.Property(e => e.TsInserted)
                    .HasColumnType("datetime")
                    .HasColumnName("ts_inserted");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("last_name");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF9787D54AE9");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
