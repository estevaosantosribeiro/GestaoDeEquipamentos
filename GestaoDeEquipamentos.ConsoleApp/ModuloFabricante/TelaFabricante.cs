using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante : TelaBase
{
    public RepositorioFabricante repositorioFabricante;

    public TelaFabricante(RepositorioFabricante repositorioFabricante) : base("Fabricante", repositorioFabricante)
    {
        this.repositorioFabricante = repositorioFabricante;
    }

    public override void VisualizarRegistros(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Console.Clear();
            Console.WriteLine("Visualizando chamados...");
            Console.WriteLine("---------------------------------------------");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -15} | {2, -20} | {3, -15} | {3, -25}",
            "Id", "Nome", "E-mail", "Telefone", "Quantidade de Equipamentos"
        );

        EntidadeBase[] registros = repositorioFabricante.SelecionarRegistros();
        Fabricante[] fabricantesCadastrados = new Fabricante[registros.Length];

        for (int i = 0; i < registros.Length; i++)
            fabricantesCadastrados[i] = (Fabricante)registros[i];

        for (int i = 0; i < fabricantesCadastrados.Length; i++)
        {
            Fabricante f = fabricantesCadastrados[i];

            if (f == null) continue;

            Console.WriteLine(
               "{0, -6} | {1, -15} | {2, -20} | {3, -15} | {3, -6}",
               f.Id, f.Nome, f.Email, f.Telefone, f.QuantidadeEquipamentos
            );
        }
    }

    public override EntidadeBase ObterDados()
    {
        Console.Write("Digite o nome do fabricante: ");
        string nome = Console.ReadLine()!;

        Console.Write("Digite o e-mail do fabricante: ");
        string email = Console.ReadLine()!;

        Console.Write("Digite o telefone do fabricante: ");
        string telefone = Console.ReadLine()!;

        Fabricante novoFabricante = new Fabricante(nome, email, telefone);

        return novoFabricante;
    }
}
