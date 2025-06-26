namespace ProjetoLoja.Models
{
    public class Administrador
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }

        public Administrador(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
        }

        public bool Autenticar(string usuario, string senha)
        {
            return Usuario == usuario && Senha == senha;
        }
    }
}