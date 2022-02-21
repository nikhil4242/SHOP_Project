using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHOP_Project.APIModel;

namespace SHOP_Project.Dataabase
{
    public class DatabaseSetting : DbContext
    {
        public DatabaseSetting(DbContextOptions<DatabaseSetting> options) : base(options)
        { }
       

        public DbSet<Login> Login { get; set; }

        public DbSet<SingUp> singup { get; set; }
    }
}
