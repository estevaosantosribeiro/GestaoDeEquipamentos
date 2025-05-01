using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado;

public class Chamado : EntidadeBase
{
    public string Titulo;
    public string Descricao;
    public Equipamento Equipamento;
    public DateTime DataAbertura;

    public Chamado(string titulo, string descricao, Equipamento equipamento)
    {
        Titulo = titulo;
        Descricao = descricao;
        Equipamento = equipamento;
        DataAbertura = DateTime.Now;
    }

    public int ObterTempoDecorrido()
    {
        TimeSpan diferencaTempo = DateTime.Now.Subtract(DataAbertura);

        return diferencaTempo.Days;
    }

    public override void AtualizarRegistro(EntidadeBase registroEditado)
    {
        Chamado chamadoEditado = (Chamado)registroEditado;

        Titulo = chamadoEditado.Titulo;
        Descricao = chamadoEditado.Descricao;
        Equipamento = chamadoEditado.Equipamento;
    }

    public override string Validar()
    {
        throw new NotImplementedException();
    }
}
