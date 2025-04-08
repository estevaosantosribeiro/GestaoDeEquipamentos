using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class TelaFabricante
{
    public RepositorioFabricante repositorioFabricante;

    public TelaFabricante()
    {
        repositorioFabricante = new RepositorioFabricante();
    }

    public char ApresentarMenu()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("|           Gestão de Fabricantes            |");
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine();

        Console.WriteLine("Escolha a operação desejada:");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("1 - Cadastrar Fabricante");
        Console.WriteLine("2 - Editar Fabricante");
        Console.WriteLine("3 - Excluir Fabricante");
        Console.WriteLine("4 - Visualizar Fabricantes");

        Console.WriteLine("5 - Voltar");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char operacaoEscolhida = Convert.ToChar(Console.ReadLine()!);

        return operacaoEscolhida;
    }

    public void CadastrarFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastrando Fabricante...");
        Console.WriteLine("---------------------------------------------");

        Console.WriteLine();

        Fabricante novoFabricante = ObterDadosFabricante();

        repositorioFabricante.CadastrarFabricante(novoFabricante);

        Console.WriteLine();
        Console.WriteLine("O fabricante foi cadastrado com sucesso!");
    }

    public void EditarFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando Fabricante...");
        Console.WriteLine("---------------------------------------------");

        Console.WriteLine();

        VisualizarFabricantes(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Fabricante novoFabricante = ObterDadosFabricante();

        bool conseguiuEditar = repositorioFabricante.EditarFabricante(idSelecionado, novoFabricante);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição de um registro...");
            return;
        }
        Console.WriteLine("O fabricante foi editado com sucesso!");
    }

    public void ExcluirFabricante()
    {
        ExibirCabecalho();

        Console.WriteLine("Excluindo Fabricante...");
        Console.WriteLine("---------------------------------------------");

        VisualizarFabricantes(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioFabricante.ExcluirFabricante(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Houve um erro durante a exclusão de um registro...");
            return;
        }
        Console.WriteLine("O fabricante foi excluído com sucesso!");
    }

    public void VisualizarFabricantes(bool exibirTitulo)
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

        Fabricante[] fabricantesCadastrados = repositorioFabricante.SelecionarFabricantes();

        for (int i = 0; i < fabricantesCadastrados.Length; i++)
        {
            Fabricante f = fabricantesCadastrados[i];

            if (f == null) continue;

            string NumeroEquipamentos = $"{f.ObterNumeroEquipamentos()} equipamento(s)";

            Console.WriteLine(
               "{0, -6} | {1, -15} | {2, -20} | {3, -15} | {3, -6}",
               f.Id, f.Nome, f.Email, f.Telefone, NumeroEquipamentos
            );
        }
    }

    public void ExibirCabecalho()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Controle de Fabricantes");
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine();
    }

    public Fabricante ObterDadosFabricante()
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
