using AutoMapper.Configuration.Annotations;
using DartAppSingapore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public DbSet<ArtistArtwork> ArtistArtworks { get; set; } // Comment out everytime you migrate
        //public DbSet<ArtistGroup> ArtistGroups { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ArtistArtwork>()
                .HasKey(bc => new { bc.ArtworkId, bc.ArtistId });
            modelBuilder.Entity<ArtistArtwork>()
                .HasOne(bc => bc.Artist)
                .WithMany(b => b.ArtistArtworks)
                .HasForeignKey(bc => bc.ArtistId);
            modelBuilder.Entity<ArtistArtwork>()
                .HasOne(bc => bc.Artwork)
                .WithMany(c => c.ArtistArtworks)
                .HasForeignKey(bc => bc.ArtworkId);
        }
    }
}
