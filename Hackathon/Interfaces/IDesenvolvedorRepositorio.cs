using Hackathon.Dtos;
using Hackathon.Dtos.Enumeradores;

namespace Hackathon.Interfaces;

public interface IDesenvolvedorRepositorio
{
    Task AdicionarAsync(Desenvolvedor desenvolvedor);

    Task AtualizarAsync(ulong codigoFuncionario, Desenvolvedor desenvolvedor);

    Task RemoverAsync(ulong codigoFuncionario);

    Task<Desenvolvedor> ObterAsync(ulong codigoFuncionario);

    Task<IList<Desenvolvedor>> ListarAsync(
        string nome,
        string empresa,
        NivelEnum nivel);
}