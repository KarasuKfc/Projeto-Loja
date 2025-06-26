using trabalhoparte1.Entidades;

namespace ProjetoLoja.Models
{
    public class Fornecedor : IEntidadeComCodigo
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public Endereco Endereco { get; set; }

        public Fornecedor(int codigo, string nome, string cnpj, Endereco endereco)
        {
            Codigo = codigo;
            Nome = nome;
            Cnpj = cnpj;
            Endereco = endereco;
        }
    }
}