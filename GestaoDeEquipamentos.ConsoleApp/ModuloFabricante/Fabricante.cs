
using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

public class Fabricante : EntidadeBase
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Telefone { get; set; }
    public Equipamento[] Equipamentos { get; private set; }
    public int QuantidadeEquipamentos
    {
        get
        {
            int contador = 0;

            for (int i = 0; i < Equipamentos.Length; i++)
            {
                if (Equipamentos[i] != null)
                {
                    contador++;
                }
            }

            return contador;
        }
    }

    public Fabricante(string nome, string email, string telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }

    public override void AtualizarRegistro(EntidadeBase registroEditado)
    {
        Fabricante fabricanteEditado = (Fabricante)registroEditado;

        Nome = fabricanteEditado.Nome;
        Email = fabricanteEditado.Email;
        Telefone = fabricanteEditado.Telefone;
    }

    public override string Validar()
    {
        throw new NotImplementedException();
    }
}
