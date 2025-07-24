using AntiAge.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AntiAge.Tests
{
    public class InMemoryDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public InMemoryDbContext(DbContextOptions<InMemoryDbContext> options)
            : base(options) { }
    }
}
