using trabalhoparte1.Entidades;

namespace ProjetoLoja.Models
{
    public class Cliente : Usuario
    {
        public String NomeCompleto { get; set; }
        public String Endereco { get; set; }

        public Cliente(string nomeUsuario, string senha, string nomeCompleto, string endereco)
            : base(nomeUsuario, senha)
        {
            NomeCompleto = nomeCompleto;
            Endereco = endereco;
        }

        public override string Tipo => "Cliente";

        public override string ToString()
        {
            return $"{NomeCompleto}, Usuário: {NomeUsuario}, Endereço: {Endereco}";
        }
    }
}