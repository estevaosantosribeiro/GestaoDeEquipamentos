using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using GestaoDeEquipamentos.ConsoleApp.Models;
using GestaoDeEquipamentos.ConsoleApp.Extensoes;

namespace GestaoDeEquipamentos.ConsoleApp.Controllers;

[Route("fabricantes")]
public class ControladorFabricante : Controller
{
    [HttpGet("cadastrar")]
    public IActionResult Cadastrar()
    {
        CadastrarFabricanteViewModel cadastrarVM = new();

        return View("Cadastrar", cadastrarVM);
    }

    [HttpPost("cadastrar")]
    public IActionResult Cadastrar(CadastrarFabricanteViewModel cadastrarVM)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

        Fabricante novoFabricante = cadastrarVM.ParaEntidade();

        repositorioFabricante.CadastrarRegistro(novoFabricante);

        NotificacaoViewModel notificacaoVM = new(
            "Fabricante Cadastrado!",
            $"O registro \"{novoFabricante.Nome}\" foi cadastrado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("editar/{id:int}")]
    public IActionResult Editar(int id)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        EditarFabricanteViewModel editarVM = new(
            id,
            fabricanteSelecionado.Nome,
            fabricanteSelecionado.Email,
            fabricanteSelecionado.Telefone
        );

        return View(editarVM);
    }

    [HttpPost("editar/{id:int}")]
    public IActionResult Editar([FromRoute] int id, EditarFabricanteViewModel editarVM)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

        Fabricante fabricanteEditado = editarVM.ParaEntidade();

        repositorioFabricante.EditarRegistro(id, fabricanteEditado);

        NotificacaoViewModel notificacaoVM = new(
            "Fabricante Editado!",
            $"O registro \"{fabricanteEditado.Nome}\" foi editado com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("excluir/{id:int}")]
    public IActionResult Excluir([FromRoute] int id)
    {
        ContextoDados contextoDados = new(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

        Fabricante fabricanteSelecionado = repositorioFabricante.SelecionarRegistroPorId(id);

        ExcluirFabricanteViewModel excluirVM = new(
            fabricanteSelecionado.Id,
            fabricanteSelecionado.Nome
        );

        return View(excluirVM);
    }

    [HttpPost("excluir/{id:int}")]
    public IActionResult ExcluirFabricante(int id)
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

        repositorioFabricante.ExcluirRegistro(id);

        NotificacaoViewModel notificacaoVM = new(
            "Fabricante Excluído!",
            "O registro foi excluído com sucesso!"
        );

        return View("Notificacao", notificacaoVM);
    }

    [HttpGet("visualizar")]
    public IActionResult Visualizar()
    {
        ContextoDados contextoDados = new ContextoDados(true);
        IRepositorioFabricante repositorioFabricante = new RepositorioFabricante(contextoDados);

        List<Fabricante> fabricantes = repositorioFabricante.SelecionarRegistros();

        VisualizarFabricantesViewModel visualizarVM = new VisualizarFabricantesViewModel(fabricantes);

        return View("Visualizar", visualizarVM);
    }
}
