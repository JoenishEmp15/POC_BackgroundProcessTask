using Microsoft.EntityFrameworkCore;
using POC_BackGroundProcess.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POC_BackGroundProcess.Database.Data
{
    public class BackgroundProcessDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string folderPath = "Databases";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string databasePath = Path.Combine(folderPath, "BrowserInformationDatabase.db");
                optionsBuilder.UseSqlite($"data source={databasePath}");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrowserInfo>().ToTable("BrowserInfo");
        }
        public DbSet<BrowserInfo> BrowserInfo { get; set; }

        public void InitializeDatabase()
        {
            Database.Migrate();
        }

    }
}
