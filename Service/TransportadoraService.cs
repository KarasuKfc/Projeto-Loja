using ProjetoLoja.Models;

namespace ProjetoLoja.Services
{
    public class TransportadoraService
    {
        Transportadora[] transportadoras = new Transportadora[100];
        int contador = 0;

        public void Menu()
        {
            int opcao;
            do
            {
                Console.WriteLine("\n--- TRANSPORTADORAS ---");
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
            Console.Write("Código da transportadora: ");
            int codigo = int.Parse(Console.ReadLine());
            if (ValidadorCodigo.VerificarCodigoDuplicado(transportadoras, contador, codigo))
            {
                Console.WriteLine("Código já cadastrado para outra transportadora.");
                return;
            }
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço por Km: ");
            double precoPorKm = double.Parse(Console.ReadLine());

            transportadoras[contador++] = new Transportadora(codigo, nome, precoPorKm);
            Console.WriteLine("Transportadora incluída com sucesso.");
        }

        void Alterar()
        {
            Console.Write("Código da transportadora: ");
            int codigo = int.Parse(Console.ReadLine());

            for (int i = 0; i < contador; i++)
            {
                if (transportadoras[i] != null && transportadoras[i].Codigo == codigo)
                {
                    Console.Write("Novo nome: ");
                    transportadoras[i].Nome = Console.ReadLine();
                    Console.Write("Novo preço por Km: ");
                    transportadoras[i].PrecoPorKm = double.Parse(Console.ReadLine());
                    Console.WriteLine("Alterado com sucesso.");
                    return;
                }
            }
            Console.WriteLine("Transportadora não encontrada.");
        }

        void Excluir()
        {
            Console.Write("Código da transportadora a excluir: ");
            int codigo = int.Parse(Console.ReadLine());

            for (int i = 0; i < contador; i++)
            {
                if (transportadoras[i] != null && transportadoras[i].Codigo == codigo)
                {
                    for (int j = i; j < contador - 1; j++)
                        transportadoras[j] = transportadoras[j + 1];
                    transportadoras[contador - 1] = null;
                    contador--;
                    Console.WriteLine("Excluído com sucesso.");
                    return;
                }
            }
            Console.WriteLine("Transportadora não encontrada.");
        }

        void Consultar()
        {
            Console.Write("Código da transportadora a ser consultada: ");
            int codigo = int.Parse(Console.ReadLine());

            for (int i = 0; i < contador; i++)
            {
                if (transportadoras[i] != null && transportadoras[i].Codigo == codigo)
                {
                    Console.WriteLine($"Código: {transportadoras[i].Codigo} | Nome: {transportadoras[i].Nome} | Preço por Km: {transportadoras[i].PrecoPorKm}");
                    return;
                }
            }
            Console.WriteLine("Transportadora não encontrada.");
        }
    }
}
