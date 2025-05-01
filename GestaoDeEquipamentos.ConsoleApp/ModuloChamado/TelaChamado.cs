using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class TelaChamado : TelaBase
{
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioChamado repositorioChamado;

    public TelaChamado(
        RepositorioChamado repositorioChamado, 
        RepositorioEquipamento repositorioEquipamento
    ) : base("Chamado", repositorioChamado)
    {
        this.repositorioChamado = repositorioChamado;
        this.repositorioEquipamento = repositorioEquipamento;
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

        EntidadeBase[] registros = repositorioEquipamento.SelecionarRegistros();
        Equipamento[] equipamentosCadastrados = new Equipamento[100];

        for (int i = 0; i < registros.Length; i++)
            equipamentosCadastrados[i] = (Equipamento)registros[i];

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
            "{0, -6} | {1, -12} | {2, -15} | {3, -30} | {4, -15} | {5, -15}",
            "Id", "Data de Abertura", "Título", "Descrição", "Equipamento", "Tempo Decorrido"
        );

        EntidadeBase[] registros = repositorioChamado.SelecionarRegistros();
        Chamado[] chamadosCadastrados = new Chamado[registros.Length];

        for (int i = 0; i < registros.Length; i++)
            chamadosCadastrados[i] = (Chamado)registros[i];

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

    public override EntidadeBase ObterDados()
    {
        Console.Write("Digite o título do chamado: ");
        string titulo = Console.ReadLine()!.Trim();

        Console.Write("Digite a descrição do chamado: ");
        string descricao = Console.ReadLine()!.Trim();

        VisualizarEquipamentos();

        Console.Write("Digite o ID do equipamento que deseja selecionar: ");
        int idEquipamento = Convert.ToInt32(Console.ReadLine()!.Trim());

        Equipamento equipamentoSelecionado = (Equipamento)repositorioEquipamento.SelecionarRegistroPorId(idEquipamento);

        Chamado novoChamado = new Chamado(titulo, descricao, equipamentoSelecionado);

        return novoChamado;
    }
}
