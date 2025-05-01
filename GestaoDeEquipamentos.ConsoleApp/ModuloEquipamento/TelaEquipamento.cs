using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using Microsoft.Win32;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class TelaEquipamento : TelaBase
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioFabricante repositorioFabricante;

    public TelaEquipamento(
        RepositorioEquipamento repositorioEquipamento, 
        RepositorioFabricante repositorioFabricante
    ) : base("Equipamento", repositorioEquipamento)
    {
        this.repositorioEquipamento = repositorioEquipamento;
        this.repositorioFabricante = repositorioFabricante;
    }

    public override void CadastrarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastrando equipamento...");
        Console.WriteLine("---------------------------------------------");

        Equipamento novoEquipamento = (Equipamento)ObterDados();

        repositorioEquipamento.CadastrarRegistro(novoEquipamento);

        Console.WriteLine();
        Console.WriteLine("O equipamento foi cadastrado com sucesso!");
    }

    public override void EditarRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando equipamento...");
        Console.WriteLine("---------------------------------------------");

        Console.WriteLine();

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Equipamento novoEquipamento = (Equipamento)ObterDados();
        
        bool conseguiuEditar = repositorioEquipamento.EditarRegistro(idSelecionado, novoEquipamento);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição de um registro...");
            return;
        }
        Console.WriteLine("O equipamento foi editado com sucesso!");
    }

    public override void ExcluirRegistro()
    {
        ExibirCabecalho();

        Console.WriteLine("Excluindo equipamentos...");
        Console.WriteLine("---------------------------------------------");

        VisualizarRegistros(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = repositorioEquipamento.ExcluirRegistro(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Houve um erro durante a exclusão de um registro...");
            return;
        }
        Console.WriteLine("O equipamento foi excluído com sucesso!");
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

        Console.WriteLine();

    }

    public override void VisualizarRegistros(bool exibirTitulo)
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

        EntidadeBase[] registros = repositorioEquipamento.SelecionarRegistros();
        Equipamento[] equipamentosCadastrados = new Equipamento[100];

        for (int i = 0; i < registros.Length; i++)
            equipamentosCadastrados[i] = (Equipamento)registros[i];

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

    public override EntidadeBase ObterDados()
    {
        Console.Write("Digite o nome do equipamento: ");
        string nome = Console.ReadLine()!;

        VisualizarFabricantes();

        Console.Write("Digite o ID do fabricante do equipamento: ");
        int idFabricante = Convert.ToInt32(Console.ReadLine()!);

        Fabricante fabricanteSelecionado = (Fabricante)repositorioFabricante.SelecionarRegistroPorId(idFabricante);

        Console.Write("Digite o preço de aquisição: R$ ");
        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Digite a data de fabricação do equipamento: (dd/MM/yyyy) ");
        DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

        Equipamento novoEquipamento = new Equipamento(nome, fabricanteSelecionado, precoAquisicao, dataFabricacao);

        return novoEquipamento;
    }
}
