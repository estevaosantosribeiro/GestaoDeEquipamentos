namespace GestaoDeEquipamentos.ConsoleApp;

public class TelaChamado
{
    public Chamado[] chamados = new Chamado[100];
    public int contadorChamados = 0;

    public string ApresentarMenu()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Escolha a operação desejada:");
        Console.WriteLine("1 - Criação de Chamado");
        Console.WriteLine("2 - Edição de Chamado");
        Console.WriteLine("3 - Exclusão de Chamado");
        Console.WriteLine("4 - Visualização de Chamados");
        Console.WriteLine("5 - Voltar ao menu principal");
        Console.WriteLine("---------------------------------------------");

        Console.Write("Digite uma opção válida: ");
        string opcaoEscolhida = Console.ReadLine()!;

        return opcaoEscolhida;
    }

    public void CriarChamado()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Criando chamado...");
        Console.WriteLine("---------------------------------------------");

        Console.WriteLine();

        Console.Write("Digite o título do chamado: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite a descrição do chamado: ");
        string descricao = Console.ReadLine();

        Console.Write("Digite o id do equipamento: ");
        int idEquipamento = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite a data de abertura do chamado: (dd/MM/yyyy) ");
        DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

        Chamado novoChamado = new Chamado(titulo, descricao, idEquipamento, dataAbertura);
        novoChamado.Id = GeradorIds.GerarIdEquipamento();

        chamados[contadorChamados++] = novoChamado;
    }

    public void EditarChamado()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Editando chamado...");
        Console.WriteLine("---------------------------------------------");

        Console.WriteLine();

        VisualizarChamados(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine();

        Console.Write("Digite o título do chamado: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite a descrição do chamado: ");
        string descricao = Console.ReadLine();

        Console.Write("Digite o id do equipamento: ");
        int idEquipamento = Convert.ToInt32(Console.ReadLine());

        Console.Write("Digite a data de abertura do chamado: (dd/MM/yyyy) ");
        DateTime dataAbertura = Convert.ToDateTime(Console.ReadLine());

        Chamado novoChamado = new Chamado(titulo, descricao, idEquipamento, dataAbertura);

        bool conseguiuEditar = false;

        for (int i = 0; i < chamados.Length; i++)
        {
            if (chamados[i] == null) continue;

            else if (chamados[i].Id == idSelecionado)
            {
                chamados[i].Titulo = novoChamado.Titulo;
                chamados[i].Descricao = novoChamado.Descricao;
                chamados[i].IdEquipamento = novoChamado.IdEquipamento;
                chamados[i].DataAbertura = novoChamado.DataAbertura;

                conseguiuEditar = true;
            }
        }

        if (!conseguiuEditar)
        {
            Console.WriteLine("Houve um erro durante a edição de um registro...");
            return;
        }
        Console.WriteLine("O chamado foi editado com sucesso!");
    }

    public void ExcluirChamado()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Gestão de Equipamentos");
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Excluindo chamado...");
        Console.WriteLine("---------------------------------------------");

        VisualizarChamados(false);

        Console.Write("Digite o ID do registro que deseja selecionar: ");
        int idSelecionado = Convert.ToInt32(Console.ReadLine());

        bool conseguiuExcluir = false;

        for (int i = 0; i < chamados.Length; i++)
        {
            if (chamados[i] == null) continue;

            else if (chamados[i].Id == idSelecionado)
            {
                chamados[i] = null;
                conseguiuExcluir = true;
            }
        }

        if (!conseguiuExcluir)
        {
            Console.WriteLine("Houve um erro durante a exclusão de um registro...");
            return;
        }
        Console.WriteLine("O chamado foi excluído com sucesso!");
    }

    public void VisualizarChamados(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Gestão de Equipamentos");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Visualizando chamados...");
            Console.WriteLine("---------------------------------------------");
        }

        // Cabeçalho da Tabela
        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -10}",
            "Id", "Título", "Descrição", "Equipamento", "Data de Abertura"
        );

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado chamadoSelecionado = chamados[i];

            if (chamadoSelecionado == null) continue;

            Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -20} | {3, -15} | {4, -10}",
               chamadoSelecionado.Id,
               chamadoSelecionado.Titulo,
               chamadoSelecionado.Descricao,
               chamadoSelecionado.IdEquipamento,
               chamadoSelecionado.DataAbertura.ToShortDateString()
            );
        }

        Console.WriteLine();
    }
}
