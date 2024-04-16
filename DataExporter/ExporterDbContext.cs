﻿using DataExporter.Model;
using Microsoft.EntityFrameworkCore;


namespace DataExporter
{
    public class ExporterDbContext : DbContext
    {
        public DbSet<Policy> Policies { get; set; }

        public ExporterDbContext(DbContextOptions<ExporterDbContext> options) : base(options)
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseInMemoryDatabase("ExporterDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Policy>().HasData(new Policy() { Id = 1, PolicyNumber = "HSCX1001", Premium = 200, StartDate = new DateTime(2024, 4, 1) },
                new Policy() { Id = 2, PolicyNumber = "HSCX1002", Premium = 153, StartDate = new DateTime(2024, 4, 5) },
                new Policy() { Id = 3, PolicyNumber = "HSCX1003", Premium = 220, StartDate = new DateTime(2024, 3, 10) },
                new Policy() { Id = 4, PolicyNumber = "HSCX1004", Premium = 200, StartDate = new DateTime(2024, 5, 1) },
                new Policy() { Id = 5, PolicyNumber = "HSCX1005", Premium = 100, StartDate = new DateTime(2024, 4, 1) });

            modelBuilder.Entity<Note>().HasData(new Note() { Id=1,PolicyId=1,Text= "Note 1 for HSCX1001 policy" },
                new Note() { Id = 2, PolicyId = 1, Text = "Note 2 for HSCX1001 policy" },
                new Note() { Id = 3, PolicyId = 1, Text = "Note 3 for HSCX1001 policy" },
                new Note() { Id = 4, PolicyId = 1, Text = "Note 4 for HSCX1001 policy" },
                new Note() { Id = 5, PolicyId = 2, Text = "Note 1 for HSCX1002 policy" },
                new Note() { Id = 6, PolicyId = 2, Text = "Note 2 for HSCX1002 policy" },
                new Note() { Id = 7, PolicyId = 3, Text = "Note 1 for HSCX1003 policy" },
                new Note() { Id = 8, PolicyId = 3, Text = "Note 2 for HSCX1003 policy" },
                new Note() { Id = 9, PolicyId = 4, Text = "Note 1 for HSCX1004 policy" },
                new Note() { Id = 10, PolicyId = 5, Text = "Note 1 for HSCX1005 policy" })
;
            base.OnModelCreating(modelBuilder);
        }
    }
}
