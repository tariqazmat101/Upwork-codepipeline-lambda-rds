using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;

using System;
using System.IO;
using System.Collections;


using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pomelo.EntityFrameworkCore.MySql;

namespace lambda
{
    public class Startup
    {
    private AmazonS3Client s3client;
    private string bucketName;
    private string accessKeyId;
    private string secretAccessKey;
    private string REGION;
    private string token;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;


            // Upwork Code
//              accessKeyId = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY_ID");
//              secretAccessKey = Environment.GetEnvironmentVariable("AWS_SECRET_ACCESS_KEY");
//              REGION = Environment.GetEnvironmentVariable("AWS_REGION");
//              token = Environment.GetEnvironmentVariable("AWS_SESSION_TOKEN");
//             bucketName =  Environment.GetEnvironmentVariable("bucketName");
//             s3client = new AmazonS3Client( accessKeyId,secretAccessKey, token, Amazon.RegionEndpoint.GetBySystemName(REGION));

        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
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
                endpoints.MapGet("/", async context =>
                {
                     // EFS connection test 
                    await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
                    foreach(string fileName in Directory.GetFiles("/mnt/storage"))
                        await context.Response.WriteAsync(fileName);
                    
                    //Aurora Connection test. 
                    var connection = new Context();

                    if(await connection.Database.CanConnectAsync()) {await context.Response.WriteAsync("\n Lambda succesfully connected to Aurora!");}
                    else await context.Response.WriteAsync("Can't connect"); 
                });
            });
        }
    }
}


public class Context : DbContext
    {
        private string username;
        private string password;
        private string endpoint;

        private string connectionString;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            username = Environment.GetEnvironmentVariable("DBusername");
            password = Environment.GetEnvironmentVariable("DBpassword");
            endpoint = Environment.GetEnvironmentVariable("DBendpoint");

            connectionString = $"server={endpoint};database=UpworkDB;user={username};password={password};";
            Console.WriteLine(connectionString);

            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }