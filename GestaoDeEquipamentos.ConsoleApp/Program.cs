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

        app.MapGet("/fabricantes/cadastrar", ExibirFormularioCadastroFabricantes);
        app.MapPost("/fabricantes/cadastrar", CadastrarFabricante);

        app.MapGet("/fabricantes/visualizar", VisualizarFabricantes);
        //app.MapControllers();

        app.Run();
    }

    static Task PaginaInicial(HttpContext context)
    {
        string conteudo = File.ReadAllText("Compartilhado/Html/PaginaInicial.html");

        return context.Response.WriteAsync(conteudo);
    }

    static Task ExibirFormularioCadastroFabricantes(HttpContext context)
    {
        string conteudo = File.ReadAllText("ModuloFabricante/Html/Cadastrar.html");

        return context.Response.WriteAsync(conteudo);
    }

    static Task CadastrarFabricante(HttpContext context)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

        string nome = context.Request.Form["nome"].ToString();
        string email = context.Request.Form["email"].ToString();
        string telefone = context.Request.Form["telefone"].ToString();

        Fabricante novoFabricante = new Fabricante(nome, email, telefone);

        repositorioFabricante.CadastrarRegistro(novoFabricante);

        string conteudo = File.ReadAllText("Compartilhado/Html/Notificacao.html");

        StringBuilder sb = new StringBuilder(conteudo);

        sb.Replace("#mensagem#", $"O registro \"{novoFabricante.Nome}\" foi cadastrado com sucesso!");

        string conteudoString = sb.ToString();

        return context.Response.WriteAsync(conteudoString);

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
