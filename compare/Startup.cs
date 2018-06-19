using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using compare.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace compare
{
  public class Startup
  {
    public Startup(IConfiguration config) => Configuration = config;

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddTransient<IProductRepository, ProductRepository>();
      services.AddTransient<IManufactureRepository, ManufactureRepository>();
      services.AddTransient<ICategoryRepository, CategoryRepository>();
      services.AddTransient<IUserRepository, UserRepository>();
      services.AddTransient<ICriteriaRepository, CriteriaRepository>();
      services.AddTransient<IReviewRepository, ReviewRepository>();
      services.AddTransient<ISpecRepository, SpecRepository>();
      services.AddTransient<IProductSpecRepository, ProductSpecRepository>();
      services.AddTransient<ITagRepository, TagRepository>();
      string conString = Configuration["ConnectionStrings:DefaultConnection"];
      services.AddDbContext<DataContext>(options =>
      {
        options.EnableSensitiveDataLogging(true);
        options.UseSqlServer(conString);
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseDeveloperExceptionPage();
      app.UseStatusCodePages();
      app.UseStaticFiles();
      app.UseMvcWithDefaultRoute();
    }
  }
}
