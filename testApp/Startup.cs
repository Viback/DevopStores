using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace testApp
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
            char[] delimiterChars = { ':', '@', '/'};
             string cstring = Environment.GetEnvironmentVariable("DATABASE_URL"); 
                string [] conn = cstring.Split(delimiterChars);
                //postgres://zqjjctnlwmlbhi:6f9c3f7cc013ed68bf34c263b65638d0ab97ebce95145f69ca2c1175518c7998@ec2-54-75-239-237.eu-west-1.compute.amazonaws.com:5432/djgnafl590i04
                //var connectionString = "Server = ec2-174-129-35-61.compute-1.amazonaws.com; Port = 5432; Database = d22t8omvseiqts; Username = ptzhigowuibpbo; Password = c56bbb7562dae77969cdf1eb039cc999dc718e54b3b41c70832bea28ab3c3deb; SslMode = Require; trust server certificate = true"; 
           
                var connectionString = "Server = " + conn[5] + ";"+ "Port = " + conn[6] + ";" + "Database = " + conn[7] + ";" + "Username = " + conn[3] + ";" + "Password = "+ conn[4] + ";" + "SslMode = Require; trust server certificate = true";
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddEntityFrameworkNpgsql().AddDbContext<d22t8omvseiqtsContext>(options => options.UseNpgsql(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
