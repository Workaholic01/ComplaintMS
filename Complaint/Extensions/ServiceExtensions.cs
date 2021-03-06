﻿using Complaint.Core.Account;
using Complaint.Core.ComplaintCore;
using Complaint.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Complaint.Services.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSQLContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddEntityFrameworkSqlServer().AddDbContext<RepositoryContext>(x => x.UseSqlServer(config["ConnectionStrings:DefaultConnection"]));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IComplaintService, ComplaintService>();
        }
    }
}
