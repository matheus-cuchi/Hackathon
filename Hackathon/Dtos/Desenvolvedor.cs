using Hackathon.Dtos.Enumeradores;

namespace Hackathon.Dtos;

public class Desenvolvedor
{
    public ulong CodigoFuncionario { get; set; }
    public string Nome { get; set; }
    public NivelEnum Nivel { get; set; }
    public decimal Salario { get; set; }
    public string Empresa { get; set; }
}