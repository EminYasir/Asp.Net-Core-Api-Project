﻿using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-L94UTMQ\\MSSQLSERVER5;initial catalog=HotelApiDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Room>(entry =>
            {
                entry.ToTable("Rooms", tb => tb.HasTrigger("Roomdecrease"));
            });
            builder.Entity<Room>(entry =>
            {
                entry.ToTable("Staffs", tb => tb.HasTrigger("Roomincrease"));
            });
            builder.Entity<Staff>(entry =>
            {
                entry.ToTable("Staffs", tb => tb.HasTrigger("StaffDecrease"));
            });
            builder.Entity<Staff>(entry =>
            {
                entry.ToTable("Staffs", tb => tb.HasTrigger("Staffincrease"));
            });
            builder.Entity<Guest>(entry =>
            {
                entry.ToTable("Guests", tb => tb.HasTrigger("Customerdecrease"));
            });
            builder.Entity<Guest>(entry =>
            {
                entry.ToTable("Guests", tb => tb.HasTrigger("Customerincrease"));
            });
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SendMessage> SendMessages { get; set; }
        public DbSet<MessageCategory> MessageCategories { get; set; }
        public DbSet<WorkLocation> WorkLocations { get; set; }
    }
}
