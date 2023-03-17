using Microsoft.Extensions.DependencyInjection;

namespace CaseManagement.API.Extensions
{
    /// <summary>
    /// To implement CORS Policy
    /// </summary>
    public static class CorsServiceExtension
    {
        private static readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins().AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                        //builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                    });
            });
        }
    }
}
