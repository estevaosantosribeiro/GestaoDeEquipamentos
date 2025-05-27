using System.Text;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.ConsoleApp.Util;

namespace GestaoDeEquipamentos.ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        WebApplication app = builder.Build();

        //app.UseRouting();
        app.MapGet("/", PaginaInicial);
        app.MapGet("/fabricantes/visualizar", VisualizarFabricantes);
        //app.MapControllers();

        app.Run();
    }

    static Task PaginaInicial(HttpContext context)
    {
        string conteudo = File.ReadAllText("Html/PaginaInicial.html");

        return context.Response.WriteAsync(conteudo);
    }

    static Task VisualizarFabricantes(HttpContext context)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

        string conteudo = File.ReadAllText("ModuloFabricante/Html/Visualizar.html");

        StringBuilder stringBuilder = new StringBuilder(conteudo);

        foreach (Fabricante f in repositorioFabricante.SelecionarRegistros())
        {
            string itemLista = $"<li>{f.ToString()}</li> #fabricante#";

            stringBuilder.Replace("#fabricante#", itemLista);
        }

        stringBuilder.Replace("#fabricante#", "");

        string conteudoString = stringBuilder.ToString();

        return context.Response.WriteAsync(conteudoString);
    }
}
