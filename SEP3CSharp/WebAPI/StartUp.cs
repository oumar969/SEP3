using Application.DaoInterfaces;
using Application.Logic;
using Application.LogicInterfaces;
using Domain.Models;
using FileData;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using JavaPersistenceClient.DAOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Types;
using WebAPI.Mutations;
using WebAPI.Queries;
using WebAPI.Schema;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using ISchema = HotChocolate.ISchema;

namespace WebApi
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
            services.AddMvc();

            // Register your services
            services.AddScoped<IUserDao, UserDao>();
            services.AddScoped<IUserLogic, UserLogic>();
            // ... other necessary services

            // Register GraphQL services
            services.AddScoped<ISchema, UserSchema>();

            services.AddScoped<UserQuery>();
            services.AddScoped<UserMutation>();
            services.AddScoped<UserType>();
            services.AddScoped<UserInputType>();

            // Adding GraphQL Server
            services.AddGraphQL(options =>
                {
                    // Configure options if needed
                })
                .AddSystemTextJson(); // Use AddNewtonsoftJson if using Newtonsoft.Json
        }



        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserDao db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Use GraphQL middleware
            app.UseGraphQL<ISchema>(); // This sets up the GraphQL endpoint
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions()); // This sets up the Playground

            app.UseMvc();

            // Seed database if necessary
            db.EnsureSeedData();
        }
    }
}
