using Microsoft.EntityFrameworkCore;
using SnackisWebAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SnackisWebAPI.Data
{
    public class SnackisWebApiContext : DbContext
    {
        public SnackisWebApiContext(DbContextOptions<SnackisWebApiContext> options) : base(options)
        {

        }

        public DbSet<BadWord> BadWords { get; set; }

    }

}
