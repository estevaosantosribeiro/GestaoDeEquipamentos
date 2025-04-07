namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static Equipamento[] equipamentos = new Equipamento[100];
        static int contadorEquipamentos = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Escolha a operação desejada:");
                Console.WriteLine("1 - Cadastro de Equipamento");
                Console.WriteLine("4 - Visualização de Equipamentos");
                Console.WriteLine("---------------------------------------------");

                Console.Write("Digite uma opção válida: ");
                string opcaoEscolhida = Console.ReadLine();

                switch (opcaoEscolhida)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Gestão de Equipamentos");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Cadastrando equipamento...");
                        Console.WriteLine("---------------------------------------------");

                        Console.WriteLine();

                        Console.Write("Digite o nome do equipamento: ");
                        string nome = Console.ReadLine();

                        Console.Write("Digite o nome do fabricante do equipamento: ");
                        string fabricante = Console.ReadLine();

                        Console.Write("Digite o preço de aquisição: R$ ");
                        decimal precoAquisicao = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Digite a data de fabricação do equipamento: (dd/MM/yyyy) ");
                        DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

                        Equipamento novoEquipamento = new Equipamento(nome, fabricante, precoAquisicao, dataFabricacao);

                        equipamentos[contadorEquipamentos++] = novoEquipamento;

                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Gestão de Equipamentos");
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Visualizando equipamentos...");
                        Console.WriteLine("---------------------------------------------");

                        // Cabeçalho da Tabela
                        Console.WriteLine(
                            "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                            "Id", "Nome", "Num. Série", "Fabricante", "Preço", "Data de Fabricação"
                        );

                        for (int i = 0; i < equipamentos.Length; i++)
                        {
                            Equipamento equipamentoSelecionado = equipamentos[i];

                            if (equipamentoSelecionado == null) continue;

                            Console.WriteLine(
                               "{0, -10} | {1, -15} | {2, -11} | {3, -15} | {4, -15} | {5, -10}",
                               equipamentoSelecionado.Id,
                               equipamentoSelecionado.Nome,
                               equipamentoSelecionado.ObterNumeroSerie(),
                               equipamentoSelecionado.Fabricante,
                               equipamentoSelecionado.PrecoAquisicao.ToString("C2"),
                               equipamentoSelecionado.DataFabricacao.ToShortDateString()
                            );
                        }

                        Console.WriteLine();

                        break;

                    default:
                        Console.WriteLine("Saindo do programa...");
                        break;
                }

            }
            Console.ReadLine();
        }
    }
}
