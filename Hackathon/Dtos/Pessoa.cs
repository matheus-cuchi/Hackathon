using Hackathon.Dtos.Enumeradores;

namespace Hackathon.Dtos;

public class Pessoa
{
    public string Documento { get; set; }
    public DateOnly DataNascimento { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
}