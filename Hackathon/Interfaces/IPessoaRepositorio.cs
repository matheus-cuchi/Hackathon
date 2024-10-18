using Hackathon.Dtos;

namespace Hackathon.Interfaces;

public interface IPessoaRepositorio
{
    Task AdicionarAsync(Pessoa pessoa);

    Task AtualizarAsync(string documento, Pessoa pessoa);

    Task RemoverAsync(string documento);

    Task<Pessoa> ObterAsync(string documento);

    Task<IList<Pessoa>> ListarAsync(
        string documento,
        string nome,
        DateOnly dataNascimento);
}