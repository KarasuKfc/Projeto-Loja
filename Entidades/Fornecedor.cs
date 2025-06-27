using trabalhoparte1.Entidades;

namespace ProjetoLoja.Models
{
    public class Fornecedor
    {
        public int Cnpj { get; set; }
        public String Nome { get; set; }
        public String Endereco { get; set; }

        public Fornecedor(int cnpj, string nome, string endereco)
        {
            Cnpj = cnpj;
            Nome = nome;
            Endereco = endereco;
        }

        public override string ToString()
        {
            return $"{Cnpj} - Nome: {Nome}, Endereço: {Endereco}";
        }
    }
//parei no passo 7 - esse que tem que fazer
}