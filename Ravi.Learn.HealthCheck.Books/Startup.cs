using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Ravi.Learn.HealthCheck.Books.Dbcontext;
using Ravi.Learn.HealthCheck.Books.Dxos;
using Ravi.Learn.HealthCheck.Books.Entities;
using Ravi.Learn.HealthCheck.Books.Models.Response;
using Ravi.Learn.HealthCheck.Books.Repositories;

namespace Ravi.Learn.HealthCheck.Books
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var booksConnection = Configuration.GetConnectionString("BooksDb");

            services.AddDbContext<BooksContext>(options =>
            {
                var booksConnection = Configuration.GetConnectionString("BooksDb");
                options.UseSqlServer(booksConnection);
            });
            services.AddScoped<IEntityDxo<Book,BookResponse>, BookDxo>();
            services.AddScoped<IRepository<Book>, BooksRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
