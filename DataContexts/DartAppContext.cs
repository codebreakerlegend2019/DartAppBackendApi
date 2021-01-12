using DartAppSingapore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DartAppSingapore.DataContexts
{
    public class DartAppContext:DbContext
    {
        public DartAppContext(DbContextOptions<DartAppContext> options):base(options)
        {

        }

        #region Tables
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Artwork> ArtWorks { get; set; }
        public DbSet<ArtistGroup> ArtistGroups { get; set; }
        #endregion
    }
}
