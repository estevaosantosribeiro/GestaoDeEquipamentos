using System.Collections;
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante : TelaBase<Fabricante>, ITelaCrud
{
    public RepositorioFabricante repositorioFabricante;

    public TelaFabricante(RepositorioFabricante repositorioFabricante)
        : base("Fabricante", repositorioFabricante)
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
            "{0, -6} | {1, -15} | {2, -20} | {3, -15} | {4, -25}",
            "Id", "Nome", "E-mail", "Telefone", "Quantidade de Equipamentos"
        );

        List<Fabricante> registros = repositorioFabricante.SelecionarRegistros();

        foreach (var f in registros)
        {
            Console.WriteLine(
               "{0, -6} | {1, -15} | {2, -20} | {3, -15} | {4, -6}",
               f.Id, f.Nome, f.Email, f.Telefone, f.QuantidadeEquipamentos
            );
        }

        Console.ReadLine();
    }

    public override Fabricante ObterDados()
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
