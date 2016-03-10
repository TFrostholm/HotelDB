namespace HotelDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelContext : DbContext
    {
        public HotelContext()
            : base("name=HotelContext")
        {
        }

        public virtual DbSet<Booking> Booking { get; set; }
        public virtual DbSet<Facilities> Facilities { get; set; }
        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomFacilities> RoomFacilities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.Date_From)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.Date_To)
                .IsUnicode(false);

            modelBuilder.Entity<Facilities>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Facilities>()
                .HasMany(e => e.RoomFacilities)
                .WithRequired(e => e.Facilities)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.Guest_Address)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .HasMany(e => e.Booking)
                .WithRequired(e => e.Guest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .Property(e => e.HotelAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Room)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.Types)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.Booking)
                .WithRequired(e => e.Room)
                .HasForeignKey(e => new { e.Room_No, e.Hotel_No })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Room>()
                .HasMany(e => e.RoomFacilities)
                .WithRequired(e => e.Room)
                .HasForeignKey(e => new { e.Room_No, e.Hotel_No })
                .WillCascadeOnDelete(false);
        }
    }
}
