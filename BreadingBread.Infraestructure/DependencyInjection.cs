﻿using BreadingBread.Application.Interfaces;
using BreadingBread.Common;
using BreadingBread.Infraestructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BreadingBread.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add configuration
            //services.Configure<EmailServiceOptions>(configuration.GetSection("EmailService"));
            //services.Configure<FileServiceOptions>(configuration.GetSection("FileService"));
            //services.Configure<AvatarServiceOptions>(configuration.GetSection("AvatarService"));

            // Add framework services.
            services.AddSingleton<IDateTime, MachineDateTime>();
            services.AddSingleton<IRandomGenerator, RandomGenerator>();
            services.AddSingleton<IFileService, FileService>();
            services.AddSingleton<IHtmlSanitizer, HtmlSanitizer>();

            //services.AddSingleton<IAvatarService, AvatarService>();
            //services.AddSingleton<IEmailService, EmailService>();
            //services.AddSingleton<IPushNotificationService, PushNotificationService>();
            return services;
        }
    }
}
