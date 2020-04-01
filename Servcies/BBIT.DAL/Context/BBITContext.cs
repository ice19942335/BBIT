using System;
using System.Collections.Generic;
using System.Text;
using BBIT.Domain.Entities.Auth.Identity.User;
using BBIT.Domain.Entities.Auth.JWT;
using BBIT.Domain.Entities.Flat;
using BBIT.Domain.Entities.House;
using BBIT.Domain.Entities.Tenant;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BBIT.DAL.Context
{
    public class BBITContext : IdentityDbContext<AppUser>
    {
        public BBITContext(DbContextOptions<BBITContext> options) : base(options) { }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<House> Houses { get; set; }

        public DbSet<Flat> Flats { get; set; }

        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
