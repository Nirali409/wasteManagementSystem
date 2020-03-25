using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace wasteManagementSystem.Models
{
    public partial class wasteManagementContext : DbContext
    {
        public wasteManagementContext()
        {
        }

        public wasteManagementContext(DbContextOptions<wasteManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<EventUser> EventUser { get; set; }
        public virtual DbSet<ListOfLocation> ListOfLocation { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<ServiceUser> ServiceUser { get; set; }
        public virtual DbSet<TypeOfUser> TypeOfUser { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserType> UserType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-JQDVS536;Database=wasteManagement;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.Property(e => e.EventId)
                    .HasColumnName("eventId")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasColumnName("eventName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventTypeId).HasColumnName("eventTypeId");

                entity.Property(e => e.EventUserId).HasColumnName("eventUserId");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("eventType");

                entity.Property(e => e.EventTypeId)
                    .HasColumnName("eventTypeId")
                    .ValueGeneratedNever();

                entity.Property(e => e.EventTypeName)
                    .IsRequired()
                    .HasColumnName("eventTypeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventUser>(entity =>
            {
                entity.ToTable("eventUser");

                entity.Property(e => e.EventUserId)
                    .HasColumnName("eventUserId")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ListOfLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("listOfLocation");

                entity.Property(e => e.LocationId)
                    .HasColumnName("locationId")
                    .ValueGeneratedNever();

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasColumnName("locationName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("schedule");

                entity.Property(e => e.ScheduleId)
                    .HasColumnName("scheduleId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ScheduleDate)
                    .HasColumnName("scheduleDate")
                    .HasColumnType("date");

                entity.Property(e => e.ScheduleTime).HasColumnName("scheduleTime");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("service");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("serviceId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasColumnName("serviceName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ServiceType>(entity =>
            {
                entity.ToTable("serviceType");

                entity.Property(e => e.ServiceTypeId)
                    .HasColumnName("serviceTypeId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ServiceTypeName)
                    .IsRequired()
                    .HasColumnName("serviceTypeName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ServiceUser>(entity =>
            {
                entity.ToTable("serviceUser");

                entity.Property(e => e.ServiceUserId)
                    .HasColumnName("serviceUserId")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TypeOfUser>(entity =>
            {
                entity.ToTable("typeOfUser");

                entity.Property(e => e.TypeOfUserId)
                    .HasColumnName("typeOfUserId")
                    .ValueGeneratedNever();

                entity.Property(e => e.TypeOfUserName)
                    .IsRequired()
                    .HasColumnName("typeOfUserName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnName("userId")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactNumber)
                    .IsRequired()
                    .HasColumnName("contactNumber")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasColumnName("emailId")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Postalcode)
                    .IsRequired()
                    .HasColumnName("postalcode")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnName("province")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserTypeId).HasColumnName("userTypeId");
            });

            modelBuilder.Entity<UserType>(entity =>
            {
                entity.ToTable("userType");

                entity.Property(e => e.UserTypeId)
                    .HasColumnName("userTypeId")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
