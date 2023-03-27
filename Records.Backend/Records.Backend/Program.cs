using Microsoft.Extensions.Configuration;
using System.Reflection;
using Records.Application;
using Records.Appllication.Common.Mappings;
using Records.Appllication.Interfaces;
using Records.Persistence;
internal class Program
{

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IRecordsDbContext).Assembly));
        });

        // Add services to the container.
        builder.Services.AddApplication();
        builder.Services.AddPersistence(builder.Configuration);

        builder.Services.AddControllers();
        builder.Services.AddCors(
            options=> options.AddPolicy("AllowAll", policy=>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            }));

        var app = builder.Build();

        

        app.UseRouting();
        app.UseHttpsRedirection();
        app.UseCors("AllowAll");
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
        app.Run();
    }
}
