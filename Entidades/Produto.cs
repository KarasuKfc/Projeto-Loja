using trabalhoparte1.Entidades;

namespace ProjetoLoja.Models
{
    public class Produto : IEntidadeComCodigo
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }
        public String Descricao { get; set; }
        public Fornecedor Fornecedor { get; set; }

        public Produto(int codigo, string nome, String descricao, int estoque, double preco)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
            //Fornecedor = fornecedor;
        }

        public override string ToString()
        {
            return $"{Codigo} - {Nome} - {Descricao} - R$ {Preco:F2} - Estoque: {Estoque}";
        }
    }
}