using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MusicBox.Models
{
    public class MusicBoxDBContext : DbContext
    {
        public MusicBoxDBContext() : base("AzureConnection") { }

        public DbSet<RegisteredUser> RegisteredUser { get; set; }
        public DbSet<VIPUser> VIPUser { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Ad> Ad { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<Song> Song { get; set; }
  
        protected override void OnModelCreating(DbModelBuilder modelBuilder) { modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); }
    }
}