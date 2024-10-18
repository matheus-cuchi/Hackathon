using Hackathon.Dtos;
using Hackathon.Dtos.Enumeradores;
using Hackathon.Interfaces;

namespace Hackathon.Implementacao;

public class DesenvolvedorRepositorio : IDesenvolvedorRepositorio
{
    public async Task AdicionarAsync(Desenvolvedor desenvolvedor)
    { }

    public async Task AtualizarAsync(ulong codigoFuncionario, Desenvolvedor desenvolvedor)
    { }

    public async Task RemoverAsync(ulong codigoFuncionario)
    { }

    public async Task<Desenvolvedor> ObterAsync(ulong codigoFuncionario)
    {
        return null;
    }

    public async Task<IList<Desenvolvedor>> ListarAsync(
        string nome,
        string empresa,
        NivelEnum nivel)
    {
        return null;
    }
}