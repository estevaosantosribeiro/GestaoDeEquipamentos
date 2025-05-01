﻿using System.Collections;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado;

public abstract class RepositorioBase<T> where T : EntidadeBase<T>
{
    private List<T> registros = new List<T>();
    private int contadorRegistros = 0;

    public void CadastrarRegistro(T novoRegistro)
    {
        novoRegistro.Id = ++contadorRegistros;

        registros.Add(novoRegistro);
    }

    public bool EditarRegistro(int idRegistro, T registroEditado)
    {
        foreach (T registro in registros)
        {
            if (registro.Id == idRegistro)
            {
                registro.AtualizarRegistro(registroEditado);

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
