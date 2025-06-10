using Dsw2025Ej14.Api.Domain;

namespace Dsw2025Ej14.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var persistencia = new PersistenciaEnMemoria();
            await persistencia.LoadProductsAsync();
            builder.Services.AddSingleton<IPersistencia>(persistencia);

            var app = builder.Build();

                app.UseSwagger();
                app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.MapGet("/health-check", () => Results.Ok("Healthy"));

            app.Run();
        }
    }
}