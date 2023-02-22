using Microsoft.AspNetCore.Authentication.JwtBearer;
using OmniMud.WebClient.Hubs;
using OmniMud.WebClient.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;

namespace OmniMud.WebClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            builder.Services.AddMvc();
            builder.Services.AddSignalR();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseMiddleware<AzureGoogleAuthenticationMiddleware>();            
            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.MapHub<OmniMudHub>("/omniMudHub");

            app.Run();
        }
    }
}