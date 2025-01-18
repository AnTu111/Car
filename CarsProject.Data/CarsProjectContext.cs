using CarsProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsProject.Data
{
    public class CarsProjectContext : DbContext
    {
        public CarsProjectContext
            (
                DbContextOptions<CarsProjectContext> options
            ) : base(options) { }

        public DbSet<Car> Cars { get; set; }

    }
}
