using ProjetoLoja.Models;

namespace ProjetoLoja.Services
{
    public class ClienteService
    {
        Cliente[] clientes = new Cliente[100];
        int contador = 0;

        public void Menu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n--- CLIENTES ---");
                Console.WriteLine("1. Incluir");
                Console.WriteLine("2. Alterar");
                Console.WriteLine("3. Excluir");
                Console.WriteLine("4. Consultar");
                Console.WriteLine("0. Voltar");
                Console.Write("Escolha: ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1: Incluir(); break;
                    case 2: Alterar(); break;
                    case 3: Excluir(); break;
                    case 4: Consultar(); break;
                }

            } while (opcao != 0);
        }

        void Incluir()
        {
            Console.Write("Código: ");
            int codigo = int.Parse(Console.ReadLine());
            if (ValidadorCodigo.VerificarCodigoDuplicado(clientes, contador, codigo))
            {
                Console.WriteLine("Código já cadastrado para outro cliente.");
                return;
            }
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Console.WriteLine("Informe o endereço:");
            Endereco endereco = EnderecoService.LerEndereco();

            clientes[contador++] = new Cliente(codigo, nome, telefone, endereco);
            Console.WriteLine("Cliente incluído com sucesso.");
        }

        void Alterar()
        {
            Console.Write("Código do cliente: ");
            int codigo = int.Parse(Console.ReadLine());

            for (int i = 0; i < contador; i++)
            {
                if (clientes[i].Codigo == codigo)
                {
                    Console.Write("Novo nome: ");
                    clientes[i].Nome = Console.ReadLine();
                    Console.Write("Novo telefone: ");
                    clientes[i].Telefone = Console.ReadLine();
                    Console.WriteLine("Deseja alterar o endereço? (s/n)");
                    if (Console.ReadLine().Trim().ToLower() == "s")
                    {
                        clientes[i].Endereco = EnderecoService.LerEndereco();
                    }
                    Console.WriteLine("Alterado com sucesso.");
                    return;
                }
            }
            Console.WriteLine("Cliente não encontrado.");
        }

        void Excluir()
        {
            Console.Write("Código do cliente a excluir: ");
            int codigo = int.Parse(Console.ReadLine());

            for (int i = 0; i < contador; i++)
            {
                if (clientes[i].Codigo == codigo)
                {
                    for (int j = i; j < contador - 1; j++)
                        clientes[j] = clientes[j + 1];
                        clientes[contador - 1] = null;
                        contador--;
                        Console.WriteLine("Excluído com sucesso.");
                    return;
                }
            }
            Console.WriteLine("Cliente não encontrado.");
        }

        void Consultar()
        {
            Console.Write("Código do cliente a ser consultado: ");
            int busca = int.Parse(Console.ReadLine());

            for (int i = 0; i < contador; i++)
            {
                if (clientes[i] != null && clientes[i].Codigo == busca)
                {
                    Console.WriteLine($"Código: {clientes[i].Codigo} | Nome: {clientes[i].Nome} | Telefone: {clientes[i].Telefone}");
                    Endereco e = clientes[i].Endereco;
                    Console.WriteLine($"Endereço: {e.Rua}, {e.Numero}, {e.Complemento}, {e.Bairro}, {e.Cep}, {e.Cidade}, {e.Estado}");
                    return;
                }
            }
            Console.WriteLine("Cliente não encontrado.");
        }
    }
}