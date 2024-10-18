
# Persistência de DTOs (Pessoa, Desenvolvedor)

Este projeto visa desenvolver uma forma de persistência para os DTOs `Pessoa` e `Desenvolvedor`. Para cada DTO, existe uma interface que será utilizada como um CRUD para manipulação dos dados.

## Requisitos de cada DTO

### DTO `Desenvolvedor`
- **CodigoFuncionario:** Deverá ser único.
- **Nome:** Deve ser um nome completo, com tamanho máximo de 255 caracteres.
- **Nível:** Deve aceitar apenas os valores existentes no enumerador.
- **Salário:** Deve sempre ter apenas 2 casas decimais e ser menor que 50.000.
- **Empresa:** Deve ser o nome de uma empresa, com tamanho máximo de 255 caracteres.

### DTO `Pessoa`
- **Documento:** Deverá ser único.
- **DataNascimento:** Deve ser posterior a 01/01/1900.
- **Nome:** Será tratado como o primeiro nome da pessoa.
- **Sobrenome:** Será tratado como o sobrenome da pessoa.

## Métodos das interfaces

Cada interface deve conter 5 métodos:

- **AdicionarAsync:** Deve salvar o DTO.
- **AtualizarAsync:** Deve atualizar o DTO com a respectiva chave (codigoFuncionario, documento).
- **RemoverAsync:** Deve remover o DTO com a respectiva chave (codigoFuncionario, documento).
- **ObterAsync:** Deve retornar o DTO com a respectiva chave (codigoFuncionario, documento).
- **ListarAsync:** Deve listar os DTOs com os respectivos filtros.

## Persistência

A persistência deve ser feita em disco. A proposta é não utilizar soluções prontas, como SQLite ou outros pacotes NuGet que simplifiquem essa tarefa. O objetivo é implementar um sistema que se comporte de forma semelhante a um banco de dados, seguindo o mais próximo possível os princípios ACID.

## Testes

Serão aplicados dois tipos de testes:

1. **Testes de Aceitação:** Verificar se o sistema cumpre os requisitos propostos.
2. **Testes de Carga:** Avaliar a performance da solução.

