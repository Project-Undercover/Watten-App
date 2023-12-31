﻿using Core.IServices.Others;
using Core.IUtils;
using Microsoft.Extensions.DependencyInjection;
using Services.Auth;
using Services.Sessions;
using Services.Users;
using Services.Utils;
using Services.Workers;

namespace Services
{
    public static class ServiceDPI
    {
        public static IServiceCollection AddServicesLayer(this IServiceCollection services)
        {
            services.AddAuthService();
            services.AddUserService();
            services.AddSessionService();


            // Singletons 
            services.AddSingleton<ITokenGenerator, JWTGenerator>();
            services.AddSingleton<IPasswordHash, BcryptPaswordHash>();
            services.AddSingleton<ITranslationService, TranslationService>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IEnumService, EnumsService>();
            services.AddSingleton<IFCMService, FCMService>();


            //services.AddHostedService<SessionReminder>();
            services.AddHostedService<SessionsStatusHS>();
            return services;
        }
    }
}