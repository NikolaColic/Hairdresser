using Hair.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hair.Data.Context
{
    public class HairdresserDbContext : DbContext
    {
        public HairdresserDbContext(DbContextOptions<HairdresserDbContext> options) : base(options)
        {

        }
        public DbSet<FavouriteHairdresser> FavouriteHairdresser { get; set; }
        public DbSet<Hairdresser> Hairdresser { get; set; }
        public DbSet<HairdresserImage> HairdresserImage { get; set; }
        public DbSet<Municipality> Municipality { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<SocialHairdresser> SocialHairdresser { get; set; }
        public DbSet<SocialNetwork> SocialNetwork { get; set; }
        public DbSet<User> User { get; set; }
    }
}
