namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado;

public static class GeradorIds
{
    public static int IdEquipamentos = 0;

    public static int GerarIdEquipamento()
    {
        IdEquipamentos++;

        return IdEquipamentos;
    }
}
