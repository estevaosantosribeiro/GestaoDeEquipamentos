using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.Util;

public class TelaPrincipal
{
    private char opcaoPrincipal;
    private RepositorioFabricante repositorioFabricante;
    private RepositorioEquipamento repositorioEquipamento;
    private RepositorioChamado repositorioChamado;

    public TelaPrincipal()
    {
        this.repositorioFabricante = new RepositorioFabricante();
        this.repositorioEquipamento = new RepositorioEquipamento();
        this.repositorioChamado = new RepositorioChamado();
    }

    public void ApresentarMenuPrincipal()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("|           Gestão de Equipametos            |");
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine();

        Console.WriteLine("1 - Controle de Equipamentos");
        Console.WriteLine("2 - Controle de Chamados");
        Console.WriteLine("3 - Controle de Fabricantes");
        Console.WriteLine("S - Sair");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");

        opcaoPrincipal = Console.ReadLine()![0];
    }

    public TelaBase ObterTela()
    {
        if (opcaoPrincipal == '1')
            return new TelaFabricante(repositorioFabricante);
        else if (opcaoPrincipal == '2')
            return new TelaEquipamento(repositorioEquipamento, repositorioFabricante);
        else if (opcaoPrincipal == '3')
            return new TelaChamado(repositorioChamado, repositorioEquipamento);

        return null!;
    }
}