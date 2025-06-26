using ProjetoLoja.Models;

namespace ProjetoLoja.Services
{
    public class FornecedorService
    {
        static Fornecedor[] fornecedores = new Fornecedor[100];
        static int contador = 0;

        public void Menu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n--- FORNECEDORES ---");
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
            Console.Write("Código do fornecedor: ");
            int codigo = int.Parse(Console.ReadLine());
            if (ValidadorCodigo.VerificarCodigoDuplicado(fornecedores, contador, codigo))
            {
                Console.WriteLine("Código já cadastrado para outro fornecedor.");
                return;
            }
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("CNPJ: ");
            string cnpj = Console.ReadLine();

            Console.WriteLine("Informe o endereço:");
            Endereco endereco = EnderecoService.LerEndereco();

            fornecedores[contador++] = new Fornecedor(codigo, nome, cnpj, endereco);
            Console.WriteLine("Fornecedor incluído com sucesso.");
        }

        void Alterar()
        {
            Console.Write("Código do fornecedor a ser alterado: ");
            int codigo = int.Parse(Console.ReadLine());

            for (int i = 0; i < contador; i++)
            {
                if (fornecedores[i].Codigo == codigo)
                {
                    Console.Write("Novo nome: ");
                    fornecedores[i].Nome = Console.ReadLine();
                    Console.Write("Novo CNPJ: ");
                    fornecedores[i].Cnpj = Console.ReadLine();
                    Console.WriteLine("Deseja alterar o endereço? (s/n)");
                    if (Console.ReadLine().Trim().ToLower() == "s")
                    {
                        fornecedores[i].Endereco = EnderecoService.LerEndereco();
                    }
                    Console.WriteLine("Alterado com sucesso.");
                    return;
                }
            }
            Console.WriteLine("Fornecedor não encontrado.");
        }

        void Excluir()
        {
            Console.Write("Código do fornecedor a ser excluído: ");
            int codigo = int.Parse(Console.ReadLine());

            for (int i = 0; i < contador; i++)
            {
                if (fornecedores[i].Codigo == codigo)
                {
                    for (int j = i; j < contador - 1; j++)
                        fornecedores[j] = fornecedores[j + 1];
                        fornecedores[contador - 1] = null;
                        contador--;
                        Console.WriteLine("Excluído com sucesso.");
                    return;
                }
            }
            Console.WriteLine("Fornecedor não encontrado.");
        }

        void Consultar()
        {
            Console.Write("Código do fornecedor a ser consultado: ");
            int busca = int.Parse(Console.ReadLine());

            for (int i = 0; i < contador; i++)
            {
                if (fornecedores[i] != null && fornecedores[i].Codigo == busca)
                {
                    Console.WriteLine($"Código: {fornecedores[i].Codigo} | Nome: {fornecedores[i].Nome} | CNPJ: {fornecedores[i].Cnpj}");
                    Endereco e = fornecedores[i].Endereco;
                    Console.WriteLine($"Endereço: {e.Rua}, {e.Numero}, {e.Complemento}, {e.Bairro}, {e.Cep}, {e.Cidade}, {e.Estado}");
                    return;
                }
            }
            Console.WriteLine("Fornecedor não encontrado.");
        }
        public static bool VerificaFornecedorExistente()
        {
            return contador > 0;
        }
        public static bool VerificaFornecedorExistente(int codigoFornecedor)
        {
            if (codigoFornecedor <= 0) return false; 
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (fornecedores[i].Codigo == codigoFornecedor)
                {
                    encontrado = true;
                }
            }
            return encontrado;
        }
        public static Fornecedor ObterFornecedorPorCodigo(int codigoFornecedor)
        {
            if (codigoFornecedor <= 0) return null; 
            for (int i = 0; i < contador; i++)
            {
                if (fornecedores[i].Codigo == codigoFornecedor)
                {
                    return fornecedores[i];
                }
            }
            return null;
        }
    }
}