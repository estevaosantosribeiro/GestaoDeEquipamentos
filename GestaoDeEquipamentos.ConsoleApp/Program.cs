namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Gestão de Equipamentos");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Escolha a operação desejada:");
                Console.WriteLine("1 - Controle de Equipamentos");
                Console.WriteLine("2 - Controle de Chamados");
                Console.WriteLine("---------------------------------------------");

                Console.Write("Digite uma opção válida: ");
                string opcaoEscolhida = Console.ReadLine();

                switch (opcaoEscolhida)
                {
                    case "1":
                        ControleEquipamentos();
                        break;
                    case "2":
                        ControleChamados();
                        break;
                    default:
                        Console.WriteLine("Houve um erro, por favor tente novamente!");
                        break;
                }
            }
        }

        static void ControleEquipamentos()
        {
            TelaEquipamento telaEquipamento = new TelaEquipamento();

            bool continuar = true;

            while (continuar)
            {
                string opcaoEscolhida = telaEquipamento.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case "1":
                        telaEquipamento.CadastrarEquipamento();
                        break;

                    case "2":
                        telaEquipamento.EditarEquipamento();
                        break;

                    case "3":
                        telaEquipamento.ExcluirEquipamento();
                        break;

                    case "4":
                        telaEquipamento.VisualizarEquipamentos(true);
                        break;

                    default:
                        Console.WriteLine("Voltando ao menu principal...");
                        continuar = false;
                        break;
                }

                Console.ReadLine();
            }
        }

        static void ControleChamados()
        {
            TelaChamado telaChamado = new TelaChamado();

            bool continuar = true;

            while (continuar)
            {
                string opcaoEscolhida = telaChamado.ApresentarMenu();

                switch (opcaoEscolhida)
                {
                    case "1":
                        telaChamado.CriarChamado();
                        break;

                    case "2":
                        telaChamado.EditarChamado();
                        break;

                    case "3":
                        telaChamado.ExcluirChamado();
                        break;

                    case "4":
                        telaChamado.VisualizarChamados(true);
                        break;

                    default:
                        Console.WriteLine("Voltando ao menu principal...");
                        continuar = false;
                        break;
                }

                Console.ReadLine();
            }
        }
    }
}
