using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.Util;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

public class RepositorioEquipamento : RepositorioBase<Equipamento>, IRepositorioEquipamento
{
    public RepositorioEquipamento(ContextoDados contexto) : base(contexto)
    {
    }

    protected override List<Equipamento> ObterRegistros()
    {
        return contexto.Equipamentos;
    }
}
