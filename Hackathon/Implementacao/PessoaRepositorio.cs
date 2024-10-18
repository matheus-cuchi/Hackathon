using Hackathon.Dtos;
using Hackathon.Interfaces;

namespace Hackathon.Implementacao;

public class PessoaRepositorio : IPessoaRepositorio
{
    public async Task AdicionarAsync(Pessoa pessoa)
    { }

    public async Task AtualizarAsync(string documento, Pessoa pessoa)
    { }

    public async Task RemoverAsync(string documento)
    { }

    public async Task<Pessoa> ObterAsync(string documento)
    {
        return null;
    }

    public async Task<IList<Pessoa>> ListarAsync(
        string documento,
        string nome,
        DateOnly dataNascimento)
    {
        return null;
    }
}