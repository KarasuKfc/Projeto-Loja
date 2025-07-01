using System;

namespace trabalhoparte1.Entidades
{
    public class Administrador : Usuario
    {
        public String Nome { get; set; }

        public Administrador(String nomeUsuario, String senha, String nome)
            : base(nomeUsuario, senha)
        {
            Nome = nome;
        }

        public override String Tipo => "Administrador";

        public override string ToString()
        {
            return $"{Nome} | Usuário: {NomeUsuario} (Administrador)";
        }
    }
}
