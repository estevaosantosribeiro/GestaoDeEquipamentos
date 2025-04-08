
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class Fabricante
{
    public int Id;
    public string Nome;
    public string Email;
    public string Telefone;

    public Fabricante(string nome, string email, string telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }

    public int ObterNumeroEquipamentos()
    {
        //Equipamento[] equipamentosCadastrados = repositorioEquipamento.SelecionarEquipamentos();

        //int numeroEquipamentos = 0;

        //for (int i = 0; i < equipamentosCadastrados.Length; i++)
        //{
        //    if (equipamentosCadastrados[i] == null) continue;

        //    if (equipamentosCadastrados[i].Fabricante.Id == Id)
        //    {
        //        numeroEquipamentos++;
        //    }
        //}

        //return numeroEquipamentos;
        return 1;
    }
}
