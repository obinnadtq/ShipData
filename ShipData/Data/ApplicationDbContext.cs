
using Microsoft.EntityFrameworkCore;
using ShipData.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShipData.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Ship> Ships { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string dataSource = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Data.db");

            options.UseSqlite($"Data Source={dataSource};");
        }

    }
}
