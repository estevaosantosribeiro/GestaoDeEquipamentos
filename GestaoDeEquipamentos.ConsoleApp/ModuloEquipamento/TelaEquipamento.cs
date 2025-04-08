using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class TelaEquipamento
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioFabricante repositorioFabricante;

    public TelaEquipamento(RepositorioFabricante repositorioFabricante)
    {
        this.repositorioFabricante = repositorioFabricante;
        repositorioEquipamento = new RepositorioEquipamento();
    }

    public char ApresentarMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Escolha a operação desejada:");
        Console.WriteLine("1 - Cadastro de Equipamento");
        Console.WriteLine("2 - Edição de Equipamento");
        Console.WriteLine("3 - Exclusão de Equipamento");
        Console.WriteLine("4 - Visualização de Equipamentos");
        Console.WriteLine("5 - Voltar ao menu principal");
        Console.WriteLine("---------------------------------------------");

        Console.Write("Digite uma opção válida: ");
        char opcaoEscolhida = Console.ReadLine()![0];

        return opcaoEscolhida;
    }

    public void CadastrarEquipamento()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastrando equipamento...");
        Console.WriteLine("---------------------------------------------");

        Equipamento novoEquipamento = ObterDadosEquipamento();

        repositorioEquipamento.CadastrarEquipamento(novoEquipamento);

        Console.WriteLine();
        Console.WriteLine("O equipamento foi cadastrado com sucesso!");
    }

    public void EditarEquipamento()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando equipamento...");
        Console.WriteLine("---------------------------------------------");

        Console.WriteLine();

        VisualizarEquipamentos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Equipamento novoEquipamento = ObterDadosEquipamento();

        bool conseguiuEditar = repositorioEquipamento.EditarEquipamento(idSelecionado, novoEquipamento);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição de um registro...");
            return;
        }
        Console.WriteLine("O equipamento foi editado com sucesso!");
    }

    public void ExcluirEquipamento()
    {
        ExibirCabecalho();

        Console.WriteLine("Excluindo equipamentos...");
        Console.WriteLine("---------------------------------------------");

        VisualizarEquipamentos(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioEquipamento.ExcluirEquipamento(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Houve um erro durante a exclusão de um registro...");
            return;
        }
        Console.WriteLine("O equipamento foi excluído com sucesso!");
    }

    public void VisualizarEquipamentos(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Controle de Equipamentos");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Visualizando equipamentos...");
            Console.WriteLine("---------------------------------------------");
        }

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
            "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação"
        );

        Equipamento[] equipamentosCadastrados = repositorioEquipamento.SelecionarEquipamentos();

        for (int i = 0; i < equipamentosCadastrados.Length; i++)
        {
            Equipamento equipamentoSelecionado = equipamentosCadastrados[i];

            if (equipamentoSelecionado == null) continue;

            Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
               equipamentoSelecionado.Id,
               equipamentoSelecionado.Nome,
               equipamentoSelecionado.ObterNumeroSerie(),
               equipamentoSelecionado.Fabricante.Nome,
               equipamentoSelecionado.PrecoAquisicao.ToString("C2"),
               equipamentoSelecionado.DataFabricacao.ToShortDateString()
            );
        }

        Console.WriteLine();
    }

    public void VisualizarFabricantes()
    {
        Console.WriteLine("Visualizando Fabricantes...");
        Console.WriteLine("----------------------------------------------");

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

        Console.WriteLine();

    }

    public void ExibirCabecalho()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Controle de Equipamentos");
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine();
    }

    public Equipamento ObterDadosEquipamento()
    {
        Console.Write("Digite o nome do equipamento: ");
        string nome = Console.ReadLine()!;

        VisualizarFabricantes();

        Console.Write("Digite o ID do fabricante do equipamento: ");
        int idFabricante = Convert.ToInt32(Console.ReadLine()!);

        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarFabricantePorId(idFabricante);

        Console.Write("Digite o preço de aquisição: R$ ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento: (dd/MM/yyyy) ");
        DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        Equipamento novoEquipamento = new Equipamento(nome, fabricanteSelecionado, precoAquisicao, dataFabricacao);

        return novoEquipamento;
    }
}
