using ProjetoLoja.Models;
using trabalhoparte1.Entidades;
using trabalhoparte1.Repositorios;
using trabalhoparte1.Service;


class Program
{
    static void Main()
    {
        var produtoRepo = new ProdutoRepositorio();
        var fornecedorRepo = new FornecedorRepositorio();
        var transportadoraRepo = new TransportadoraRepositorio();
        var clienteRepo = new ClienteRepositorio();

        var pedidos = new List<Pedido>();

        var carrinhoService = new CarrinhoService(produtoRepo, transportadoraRepo, pedidos);
        var pedidoService = new PedidoService(pedidos);

        var usuarioService = new UsuarioService(clienteRepo);
        Usuario usuario = usuarioService.Login();

        if (usuario == null) return;

        if (usuario is Administrador)
        {
            var menuAdmin = new MenuAdministrador(produtoRepo, fornecedorRepo, transportadoraRepo, clienteRepo, pedidoService);
            menuAdmin.Exibir();
        }
        else if (usuario is Cliente cliente)
        {
            var menuCliente = new MenuCliente(cliente, carrinhoService);
            menuCliente.Exibir();
        }
    }
}

