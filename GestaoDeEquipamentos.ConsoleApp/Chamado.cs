namespace GestaoDeEquipamentos.ConsoleApp;

public class Chamado
{
    public int Id;
    public string Titulo;
    public string Descricao;
    public int IdEquipamento;
    public DateTime DataAbertura;

    public Chamado(string titulo, string descricao, int idEquipamento, DateTime dataAbertura)
    {
        Titulo = titulo;
        Descricao = descricao;
        IdEquipamento = idEquipamento;
        DataAbertura = dataAbertura;
    }
}
