using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GamingPortal.Models;

namespace GamingPortal.Data
{
    public class GamingPortalContext : DbContext
    {
        public GamingPortalContext (DbContextOptions<GamingPortalContext> options)
            : base(options)
        {
        }

        public DbSet<GamingPortal.Models.Admin> Admin { get; set; }

        public DbSet<GamingPortal.Models.User> User { get; set; }

        public DbSet<GamingPortal.Models.Gme> Gme { get; set; }
    }
}
