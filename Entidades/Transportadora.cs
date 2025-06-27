

namespace ProjetoLoja.Models
{
    public class Transportadora
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Telefone { get; set; }
        public double ValorFrete { get; set; }

        public Transportadora(int id, string nome, string telefone, double valorFrete)
        {
            Id = id;
            Nome = nome;
            Telefone = telefone;
            ValorFrete = valorFrete;
        }

        public override string ToString()
        {
            return $"{Id} - Nome: {Nome}, Telefone: {Telefone}, Valor do Frete: {ValorFrete:C}";
        }
    }
}