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
        public DbSet<Zone> Zones { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<ArtistArtwork> ArtworkEvents { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region Artist and Artwork Many to Many DB Relationship
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
            #endregion
            #region Artwork to Event Many to Many DB Relationship
            modelBuilder.Entity<ArtworkEvent>()
               .HasKey(bc => new { bc.ArtworkId, bc.EventId });
            modelBuilder.Entity<ArtworkEvent>()
                .HasOne(bc => bc.Artwork)
                .WithMany(b => b.ArtworkEvents)
                .HasForeignKey(bc => bc.ArtworkId);
            modelBuilder.Entity<ArtworkEvent>()
                .HasOne(bc => bc.Event)
                .WithMany(c => c.ArtworkEvents)
                .HasForeignKey(bc => bc.EventId);
            #endregion
        }
    }
}
