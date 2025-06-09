# Gestao de Equipamentos

## Controle de Equipamentos

![](https://i.imgur.com/AcU0BxT.gif)

## Sobre o Projeto

Este projeto tem como objetivo automatizar o controle de equipamentos e manutenções realizados na empresa onde Junior trabalha. Com este sistema, é possível registrar, visualizar, editar e excluir equipamentos, além de gerenciar chamados de manutenção de forma prática e eficiente.

## Funcionalidades

- **Cadastro de Equipamentos**: Permite registrar novos equipamentos no sistema com nome, número de série, fabricante, data de fabricação e preço de aquisição.  
- **Edição de Equipamentos**: Possibilita a atualização completa das informações de um equipamento já registrado.  
- **Visualização de Equipamentos**: Exibe uma lista com todos os equipamentos cadastrados, mostrando dados como nome, fabricante, data de fabricação e valor.  
- **Exclusão de Equipamentos**: Permite remover permanentemente um equipamento do inventário.  
- **Abertura de Chamados**: Registra manutenções realizadas em equipamentos, com título, descrição, equipamento relacionado e data de abertura.  
- **Edição de Chamados**: Permite modificar todas as informações de um chamado já registrado.  
- **Visualização de Chamados**: Lista todos os chamados registrados, incluindo o título, equipamento vinculado, data de abertura e tempo em aberto.  
- **Exclusão de Chamados**: Remove chamados de manutenção do sistema, atualizando a lista automaticamente.

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.

## Como usar

1. Clone o repositório:

```sh
git clone https://github.com/estevaosantosribeiro/GestaoDeEquipamentos.git
```

2. Navegue até a pasta raiz do projeto:

```sh
cd GestaoDeEquipamentos
```

3. Restaure as dependências:

```sh
dotnet restore
```

4. Compile o projeto:

```sh
dotnet build
```

5. Execute o programa:

```sh
dotnet run
```
