using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado;

public abstract class RepositorioBase<T> where T : EntidadeBase<T>
{
    private List<T> registros = new List<T>();
    private int contadorRegistros = 0;

    protected ContextoDados contexto;

    public RepositorioBase(ContextoDados contexto)
    {
        this.contexto = contexto;

        registros = ObterRegistros();

        int maiorId = 0;

        foreach (var registro in registros)
        {
            if (registro.Id > maiorId)
                maiorId = registro.Id;
        }

        contadorRegistros = maiorId;
    }

    protected abstract List<T> ObterRegistros();

    public void CadastrarRegistro(T novoRegistro)
    {
        novoRegistro.Id = ++contadorRegistros;

        registros.Add(novoRegistro);

        contexto.Salvar();
    }

    public bool EditarRegistro(int idRegistro, T registroEditado)
    {
        foreach (T registro in registros)
        {
            if (registro.Id == idRegistro)
            {
                registro.AtualizarRegistro(registroEditado);

                contexto.Salvar();

                return true;
            }
        }

        return false;
    }

    public bool ExcluirRegistro(int idRegistro)
    {
        T registroSelecionado = SelecionarRegistroPorId(idRegistro);

        if (registroSelecionado != null)
        {
            registros.Remove(registroSelecionado);

            contexto.Salvar();

            return true;
        }

        return false;
    }

    public List<T> SelecionarRegistros()
    {
        return registros;
    }

    public T SelecionarRegistroPorId(int idRegistro)
    {
        foreach (T item in registros)
        {
            if (item.Id == idRegistro)
                return item;
        }

        return null!;
    }
}
