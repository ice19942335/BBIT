﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BBIT.WEB.Service.Installers
{
    public class CorsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //Allow any origin + credentials
            //services.AddCors(options =>
            //{
            //    options.AddDefaultPolicy(builder =>
            //        builder.SetIsOriginAllowed(_ => true)
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowCredentials());
            //});


            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => 
                    builder.WithOrigins("http://bbit.birula.online", "http://bbit-client.abirula.com")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }
    }
}
