using ProjetoLoja.Models;

namespace ProjetoLoja.Services;

public static class EnderecoService
{
    public static Endereco LerEndereco()
    {
        Console.Write("Rua: ");
        string rua = Console.ReadLine();
        Console.Write("Número: ");
        string numero = Console.ReadLine();
        Console.Write("Complemento: ");
        string complemento = Console.ReadLine();
        Console.Write("Bairro: ");
        string bairro = Console.ReadLine();
        Console.Write("CEP: ");
        string cep = Console.ReadLine();
        Console.Write("Cidade: ");
        string cidade = Console.ReadLine();
        Console.Write("Estado: ");
        string estado = Console.ReadLine();

        return new Endereco(rua, numero, complemento, bairro, cep, cidade, estado);
    }
}
