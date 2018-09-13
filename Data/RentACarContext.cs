using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RentACar.Models
{
    public class RentACarContext : DbContext
    {
        public RentACarContext (DbContextOptions<RentACarContext> options)
            : base(options)
        {
        }

        public DbSet<RentACar.Models.Auti> Auti { get; set; }
    }
}
