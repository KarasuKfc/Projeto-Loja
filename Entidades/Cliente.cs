using trabalhoparte1.Entidades;

namespace ProjetoLoja.Models
{
    public class Cliente : IEntidadeComCodigo
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }

        public Cliente(int codigo, string nome, string telefone, Endereco endereco)
        {
            Codigo = codigo;
            Nome = nome;
            Telefone = telefone;
            Endereco = endereco;
        }
    }
}