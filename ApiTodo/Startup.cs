using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Spx.Adm.TodoContexts;
using Spx.Adm.Todo.Servicos;
using Spx.Adm.Todo.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using FluentValidation.AspNetCore;

namespace TodoApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContextEntidade>(opt =>
               opt.UseInMemoryDatabase("TodoList"));

            services.AddSingleton<ITodoItemsServico, TodoServico>();
            services.AddControllers();
            services.AddMvc()
                .AddFluentValidation(fvc =>
                            fvc.RegisterValidatorsFromAssemblyContaining<Startup>());
            // Add framework services.
            services.AddMvc();
        }

        private void FluentValidation(MvcOptions obj)
        {
            throw new NotImplementedException();
        }

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
