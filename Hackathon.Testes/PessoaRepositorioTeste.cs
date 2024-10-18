using FluentAssertions;
using Hackathon.Dtos;
using Hackathon.Implementacao;
using Hackathon.Interfaces;

namespace Hackathon.Testes;

public class PessoaRepositorioTeste
{
    private readonly IPessoaRepositorio _repositorio;
    private readonly Pessoa _pessoaBase;

    public PessoaRepositorioTeste()
    {
        _repositorio = new PessoaRepositorio(); // Substitua pelo seu repositório real

        // Seed de dados no construtor
        _pessoaBase = new Pessoa
        {
            Documento = "12345678900",
            Nome = "João",
            Sobrenome = "Silva",
            DataNascimento = new DateOnly(1985, 5, 23)
        };

        // Adicionar pessoa de seed
        Task.Run(async () => await _repositorio.AdicionarAsync(_pessoaBase)).Wait();
    }

    [Fact]
    public async Task Deve_Adicionar_Pessoa_Com_Sucesso()
    {
        // Arrange
        var novaPessoa = new Pessoa
        {
            Documento = "98765432100",
            Nome = "Maria",
            Sobrenome = "Souza",
            DataNascimento = new DateOnly(1990, 10, 12)
        };

        // Act
        await _repositorio.AdicionarAsync(novaPessoa);
        var pessoaObtida = await _repositorio.ObterAsync(novaPessoa.Documento);

        // Assert
        pessoaObtida.Should().NotBeNull();
        pessoaObtida.Nome.Should().Be("Maria");
        pessoaObtida.Sobrenome.Should().Be("Souza");
    }

    [Fact]
    public async Task Deve_Atualizar_Pessoa_Com_Sucesso()
    {
        // Arrange
        var pessoaAtualizada = new Pessoa
        {
            Documento = _pessoaBase.Documento,
            Nome = "Pedro",
            Sobrenome = "Silva",
            DataNascimento = _pessoaBase.DataNascimento
        };

        // Act
        await _repositorio.AtualizarAsync(_pessoaBase.Documento, pessoaAtualizada);
        var pessoaObtida = await _repositorio.ObterAsync(_pessoaBase.Documento);

        // Assert
        pessoaObtida.Should().NotBeNull();
        pessoaObtida.Nome.Should().Be("Pedro");
    }

    [Fact]
    public async Task Deve_Remover_Pessoa_Com_Sucesso()
    {
        // Act
        await _repositorio.RemoverAsync(_pessoaBase.Documento);
        var pessoaObtida = await _repositorio.ObterAsync(_pessoaBase.Documento);

        // Assert
        pessoaObtida.Should().BeNull();
    }

    [Fact]
    public async Task Deve_Obter_Pessoa_Com_Sucesso()
    {
        // Act
        var pessoaObtida = await _repositorio.ObterAsync(_pessoaBase.Documento);

        // Assert
        pessoaObtida.Should().NotBeNull();
        pessoaObtida.Documento.Should().Be("12345678900");
    }

    [Fact]
    public async Task Deve_Listar_Pessoas_Com_Sucesso()
    {
        // Arrange
        var novaPessoa = new Pessoa
        {
            Documento = "98765432100",
            Nome = "Maria",
            Sobrenome = "Souza",
            DataNascimento = new DateOnly(1990, 10, 12)
        };

        await _repositorio.AdicionarAsync(novaPessoa);

        // Act
        var resultado = await _repositorio.ListarAsync(
            documento: "12345678900",
            nome: "João",
            dataNascimento: new DateOnly(1985, 5, 23));

        // Assert
        resultado.Should().NotBeNull();
        resultado.Count.Should().Be(1);
        resultado[0].Nome.Should().Be("João");
    }
}