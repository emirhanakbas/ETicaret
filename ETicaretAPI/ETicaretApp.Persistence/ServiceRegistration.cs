using ETicaretApp.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApp.Persistence {
    public static class ServiceRegistration {
        public static void AddPersistenceServince(this IServiceCollection services) {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configurations.ConnectionString));
        }
    }
}
