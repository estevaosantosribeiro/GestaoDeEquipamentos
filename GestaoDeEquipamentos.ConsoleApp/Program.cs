using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.Util;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        // criar um servidor web
        WebApplicationBuilder builder = WebApplication.CreateBuilder();

        WebApplication app = builder.Build();

        app.MapGet("/", OlaMundo);

        app.Run();
    }

    static Task OlaMundo(HttpContext context)
    {
        context.Response.ContentType = "text/plain; charset=utf-8";

        return context.Response.WriteAsync("Olá mundo!");
    }
}
