using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class Equipamento : EntidadeBase
{
    public string Nome;
    public Fabricante Fabricante;
    public decimal PrecoAquisicao;
    public DateTime DataFabricacao;

    public Equipamento(string nome, Fabricante fabricante, decimal precoAquisicao, DateTime dataFabricacao)
    {
        Nome = nome;
        Fabricante = fabricante;
        PrecoAquisicao = precoAquisicao;
        DataFabricacao = dataFabricacao;
    }

    public override void AtualizarRegistro(EntidadeBase registroEditado)
    {
        Equipamento equipamentoEditado = (Equipamento)registroEditado;

        Nome = equipamentoEditado.Nome;
        Fabricante = equipamentoEditado.Fabricante;
        PrecoAquisicao = equipamentoEditado.PrecoAquisicao;
    }

    public string ObterNumeroSerie()
    {
        string tresPrimeirosCaracteres = Nome.Substring(0, 3).ToUpper();

        return $"{tresPrimeirosCaracteres}-{Id}";
    }

    public override string Validar()
    {
        throw new NotImplementedException();
    }
}
