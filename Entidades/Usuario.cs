using System;

namespace trabalhoparte1.Entidades
{
    public abstract class Usuario
    {
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }

        public Usuario(string nomeUsuario, string senha)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
        }

        public bool Autenticar(string usuario, string senha)
        {
            return NomeUsuario == usuario && Senha == senha;
        }

        public abstract string Tipo { get; }
    }
}