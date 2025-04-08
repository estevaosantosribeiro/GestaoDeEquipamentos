using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class TelaChamado
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioChamado repositorioChamado;

    public TelaChamado(RepositorioEquipamento repositorioEquipamento)
    {
        this.repositorioEquipamento = repositorioEquipamento;
        this.repositorioChamado = new RepositorioChamado();
    }

    public char ApresentarMenu()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("|             Gestão de Chamados             |");
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine();

        Console.WriteLine("Escolha a operação desejada:");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("1 - Cadastrar Chamado");
        Console.WriteLine("2 - Editar Chamado");
        Console.WriteLine("3 - Excluir Chamado");
        Console.WriteLine("4 - Visualizar Chamados");

        Console.WriteLine("5 - Voltar");

        Console.WriteLine();

        Console.Write("Escolha uma das opções: ");
        char operacaoEscolhida = Convert.ToChar(Console.ReadLine()!);

        return operacaoEscolhida;
    }

    public void CadastrarChamado()
    {
        ExibirCabecalho();

        Console.WriteLine("Cadastrando Chamado...");
        Console.WriteLine("---------------------------------------------");

        Chamado novoChamado = ObterDadosChamado();

        repositorioChamado.CadastrarChamado(novoChamado);

        Console.WriteLine();
        Console.WriteLine("O chamado foi cadastrado com sucesso!");
    }

    public void EditarChamado()
    {
        ExibirCabecalho();

        Console.WriteLine("Editando chamado...");
        Console.WriteLine("---------------------------------------------");

        VisualizarChamados(false);

        Console.Write("Digite o ID do chamado que deseja selecionar: ");
        int idChamado = Convert.ToInt32(Console.ReadLine()!.Trim());

        Chamado novoChamado = ObterDadosChamado();

        bool conseguiuEditar = repositorioChamado.EditarChamado(idChamado, novoChamado);

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O chamado foi editado com sucesso!");
    }

    public void ExcluirChamado()
    {
        ExibirCabecalho();

        Console.WriteLine("Excluindo chamado...");
        Console.WriteLine("---------------------------------------------");

        VisualizarChamados(false);

        Console.Write("Digite o ID do chamado que deseja excluir: ");
        int idChamado = Convert.ToInt32(Console.ReadLine()!.Trim());

        bool conseguiuExcluir = repositorioChamado.ExcluirChamado(idChamado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Houve um erro durante a exclusão de um registro...");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("O chamado foi excluído com sucesso!");
    }

    public void VisualizarChamados(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Console.Clear();
            Console.WriteLine("Visualizando chamados...");
            Console.WriteLine("---------------------------------------------");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -6} | {1, -12} | {2, -15} | {3, -30} | {4, -15} | {5, -15}",
            "Id", "Data de Abertura", "Título", "Descrição", "Equipamento", "Tempo Decorrido"
        );

        Chamado[] chamadosCadastrados = repositorioChamado.SelecionarChamados();

        for (int i = 0; i < chamadosCadastrados.Length; i++)
        {
            Chamado c = chamadosCadastrados[i];

            if (c == null) continue;

            string TempoDecorrido = $"{c.ObterTempoDecorrido()} dia(s)";

            Console.WriteLine(
               "{0, -6} | {1, -12} | {2, -15} | {3, -30} | {4, -15} | {5, -15}",
               c.Id, c.DataAbertura.ToShortDateString(), c.Titulo, c.Descricao, c.Equipamento.Nome, TempoDecorrido
            );
        }
    }

    public void VisualizarEquipamentos()
    {
        Console.WriteLine("Visualizando Equipamentos...");
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
            "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação"
        );

        Equipamento[] equipamentosCadastrados = repositorioEquipamento.SelecionarEquipamentos();

        for (int i = 0; i < equipamentosCadastrados.Length; i++)
        {
            Equipamento equipamento = equipamentosCadastrados[i];

            if (equipamento == null) continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                equipamento.Id,
                equipamento.Nome,
                equipamento.ObterNumeroSerie(),
                equipamento.Fabricante,
                equipamento.PrecoAquisicao.ToString("C2"),
                equipamento.DataFabricacao
            );
        }

        Console.WriteLine();
    }

    public void ExibirCabecalho()
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Controle de Chamados");
        Console.WriteLine("----------------------------------------------");

        Console.WriteLine();
    }

    public Chamado ObterDadosChamado()
    {
        Console.Write("Digite o título do chamado: ");
        string titulo = Console.ReadLine()!.Trim();

        Console.Write("Digite a descrição do chamado: ");
        string descricao = Console.ReadLine()!.Trim();

        VisualizarEquipamentos();

        Console.Write("Digite o ID do equipamento que deseja selecionar: ");
        int idEquipamento = Convert.ToInt32(Console.ReadLine()!.Trim());

        Equipamento equipamentoSelecionado = repositorioEquipamento.SelecionarEquipamentoPorId(idEquipamento);

        Chamado novoChamado = new Chamado(titulo, descricao, equipamentoSelecionado);

        return novoChamado;
    }
}
