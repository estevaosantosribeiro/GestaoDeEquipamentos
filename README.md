# Gestao de Equipamentos

## Controle de Equipamentos

![](https://i.imgur.com/q7ouye7.gif)

## Sobre o Projeto

Este projeto tem como objetivo automatizar o controle de equipamentos e manuten��es realizados na empresa onde Junior trabalha. Com este sistema, � poss�vel registrar, visualizar, editar e excluir equipamentos, al�m de gerenciar chamados de manuten��o de forma pr�tica e eficiente.

## Funcionalidades

- **Cadastro de Equipamentos**: Permite registrar novos equipamentos no sistema com nome, n�mero de s�rie, fabricante, data de fabrica��o e pre�o de aquisi��o.  
- **Edi��o de Equipamentos**: Possibilita a atualiza��o completa das informa��es de um equipamento j� registrado.  
- **Visualiza��o de Equipamentos**: Exibe uma lista com todos os equipamentos cadastrados, mostrando dados como nome, fabricante, data de fabrica��o e valor.  
- **Exclus�o de Equipamentos**: Permite remover permanentemente um equipamento do invent�rio.  
- **Abertura de Chamados**: Registra manuten��es realizadas em equipamentos, com t�tulo, descri��o, equipamento relacionado e data de abertura.  
- **Edi��o de Chamados**: Permite modificar todas as informa��es de um chamado j� registrado.  
- **Visualiza��o de Chamados**: Lista todos os chamados registrados, incluindo o t�tulo, equipamento vinculado, data de abertura e tempo em aberto.  
- **Exclus�o de Chamados**: Remove chamados de manuten��o do sistema, atualizando a lista automaticamente.

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compila��o e execu��o do projeto.

## Como usar

1. Clone o reposit�rio:

```sh
git clone https://github.com/estevaosantosribeiro/GestaoDeEquipamentos.git
```

2. Navegue at� a pasta raiz do projeto:

```sh
cd GestaoDeEquipamentos
```

3. Restaure as depend�ncias:

```sh
dotnet restore
```

4. Compile o projeto:

```sh
dotnet build
```

5. Execute o jogo:

```sh
dotnet run
```