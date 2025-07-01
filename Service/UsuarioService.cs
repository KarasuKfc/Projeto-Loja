using System;
using trabalhoparte1.Repositorios;
using trabalhoparte1.Entidades;
using System.Collections.Generic;

namespace trabalhoparte1.Service
{
    public class UsuarioService
    {
        private List<Usuario> usuarios;

        public UsuarioService(ClienteRepositorio clienteRepo)
        {
            usuarios = new List<Usuario>();

            //Adm padrao
            usuarios.Add(new Administrador("admin", "123", "Administrador Padrão"));

            //add todos clientes cadastrados
            foreach (var c in clienteRepo.ListarTodos())
            {
                usuarios.Add(c);
            }
        }

        public Usuario Login()
        {
            Console.WriteLine("=== Login ===");
            Console.Write("Usuário: ");
            string user = Console.ReadLine();

            Console.Write("Senha: ");
            string pass = Console.ReadLine();

            foreach (var u in usuarios)
            {
                if (u.Autenticar(user, pass))
                {
                    Console.WriteLine($"Bem-vindo, {u.NomeUsuario}!");
                    return u;
                }
                    Console.WriteLine("Usuário ou senha inválidos.");
            }
            Console.WriteLine("Usuário ou senha inválidos.");
            return null;
        }
    }
}
