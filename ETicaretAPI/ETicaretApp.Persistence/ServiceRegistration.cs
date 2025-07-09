using ETicaretApp.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.Persistence {
    public static class ServiceRegistration {
        public static void AddPersistenceServince(this IServiceCollection services) {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql("User ID=root;Password=myPassword;Host=localhost;Port=5432;Database=ETicaretAPIDb;"));
        }
    }
}
