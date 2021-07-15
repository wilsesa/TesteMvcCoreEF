using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteMvcCoreEF.Models;

namespace TesteMvcCoreEF.Data
{
    public class TesteMvcCoreEFContext : DbContext
    {
        public TesteMvcCoreEFContext (DbContextOptions<TesteMvcCoreEFContext> options)
            : base(options)
        {
        }

        public DbSet<TesteMvcCoreEF.Models.PacienteViewModel> PacienteViewModel { get; set; }
    }
}
