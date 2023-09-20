using System;
using Microsoft.EntityFrameworkCore;
using MojammatApi.Models;

namespace MojammatApi.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Users> users { get; set; }

        public DbSet<RequestedServices> services { get; set; }

        public DbSet<Visitor> visitors { get; set; }

        public DbSet<Invoices> invoices { get; set; }

        public DbSet<Attachments> attachments { get; set; }

        public DbSet<AppSetting> appSettings { get; set; }



    }

}

