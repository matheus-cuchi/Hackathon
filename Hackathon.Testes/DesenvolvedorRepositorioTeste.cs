using FluentAssertions;
using Hackathon.Dtos;
using Hackathon.Dtos.Enumeradores;
using Hackathon.Implementacao;
using Hackathon.Interfaces;

namespace Hackathon.Testes;

public class DesenvolvedorRepositorioTeste
{
    private readonly IDesenvolvedorRepositorio _repositorio;
    private readonly Desenvolvedor _desenvolvedorBase;

    public DesenvolvedorRepositorioTeste()
    {
        _repositorio = new DesenvolvedorRepositorio();

        _desenvolvedorBase = new Desenvolvedor
        {
            CodigoFuncionario = 1,
            Nome = "João Silva",
            Nivel = NivelEnum.Senior,
            Salario = 40000.50m,
            Empresa = "Tech Corp"
        };

        GerarDados().GetAwaiter().GetResult();
    }

    private async Task GerarDados()
    {
        var desenvolvedores = new List<Desenvolvedor>
        {
            _desenvolvedorBase,
            new()
            {
                CodigoFuncionario = 2,
                Nome = "Luan Silva",
                Nivel = NivelEnum.Senior,
                Salario = 30000.50m,
                Empresa = "Tech Corp"
            },
            new()
            {
                CodigoFuncionario = 3,
                Nome = "Maurino Souza",
                Nivel = NivelEnum.Junior,
                Salario = 3000.00m,
                Empresa = "Tech Corp"
            },
        };

        foreach (var dev in desenvolvedores)
        {
            await _repositorio.AdicionarAsync(dev);
        }
    }

    [Fact]
    public async Task Deve_Adicionar_Desenvolvedor_Com_Sucesso()
    {
        // Arrange
        var novoDesenvolvedor = new Desenvolvedor
        {
            CodigoFuncionario = 67890,
            Nome = "Maria Souza",
            Nivel = NivelEnum.Pleno,
            Salario = 35000.25m,
            Empresa = "Dev Inc"
        };

        // Act
        await _repositorio.AdicionarAsync(novoDesenvolvedor);
        var desenvolvedorObtido = await _repositorio.ObterAsync(novoDesenvolvedor.CodigoFuncionario);

        // Assert
        desenvolvedorObtido.Should().NotBeNull();
        desenvolvedorObtido.Nome.Should().Be("Maria Souza");
    }

    [Fact]
    public async Task Deve_Atualizar_Desenvolvedor_Com_Sucesso()
    {
        // Arrange
        var desenvolvedorAtualizado = new Desenvolvedor
        {
            CodigoFuncionario = _desenvolvedorBase.CodigoFuncionario,
            Nome = "João Pedro",
            Nivel = NivelEnum.Senior,
            Salario = 45000.75m,
            Empresa = "Tech Corp"
        };

        // Act
        await _repositorio.AtualizarAsync(_desenvolvedorBase.CodigoFuncionario, desenvolvedorAtualizado);
        var desenvolvedorObtido = await _repositorio.ObterAsync(_desenvolvedorBase.CodigoFuncionario);

        // Assert
        desenvolvedorObtido.Should().NotBeNull();
        desenvolvedorObtido.Nome.Should().Be("João Pedro");
        desenvolvedorObtido.Salario.Should().Be(45000.75m);
    }

    [Fact]
    public async Task Deve_Remover_Desenvolvedor_Com_Sucesso()
    {
        // Act
        await _repositorio.RemoverAsync(_desenvolvedorBase.CodigoFuncionario);
        var desenvolvedorObtido = await _repositorio.ObterAsync(_desenvolvedorBase.CodigoFuncionario);

        // Assert
        desenvolvedorObtido.Should().BeNull();
    }

    [Fact]
    public async Task Deve_Obter_Desenvolvedor_Com_Sucesso()
    {
        // Act
        var desenvolvedorObtido = await _repositorio.ObterAsync(_desenvolvedorBase.CodigoFuncionario);

        // Assert
        desenvolvedorObtido.Should().NotBeNull();
        desenvolvedorObtido.CodigoFuncionario.Should().Be(12345);
    }

    [Fact]
    public async Task Deve_Listar_Desenvolvedores_Com_Sucesso()
    {
        // Arrange
        var novoDesenvolvedor = new Desenvolvedor
        {
            CodigoFuncionario = 67890,
            Nome = "Maria Souza",
            Nivel = NivelEnum.Pleno,
            Salario = 35000.25m,
            Empresa = "Dev Inc"
        };

        await _repositorio.AdicionarAsync(novoDesenvolvedor);

        // Act
        var resultado = await _repositorio.ListarAsync(
            nome: "João",
            empresa: "Tech Corp",
            nivel: NivelEnum.Senior);

        // Assert
        resultado.Should().NotBeNull();
        resultado.Count.Should().Be(1);
        resultado[0].Nome.Should().Be("João Silva");
    }
}