using ApiPedidos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPedidos
{
    [TestClass]
    public class TestesCaminhoFeliz
    {
        private Pedido _pedidoNovoValido = new Pedido
        {
            Usuario = new Usuario
            {
                Nome = "Mauro Martins",
                Autorizado = true,
                Autenticado = true
            },
            Produto = new Produto
            {
                Id = 4,
                Description = "Produto 4"
            }
        };
        private Pedido _pedidoVelhoValido = new Pedido
        {
            Usuario = new Usuario
            {
                Nome = "Mauro Martins",
                Autorizado = true,
                Autenticado = true
            },
            Produto = new Produto
            {
                Id = 1,
                Description = "Produto 01 - alterado pelo teste"
            }
        };

        [TestMethod]
        public void DeveIncluirProdutoValido()
        {
            var idInseridoEsperado = _pedidoNovoValido.Produto.Id;

            var produtoInserido = Carrinho.Inserir(_pedidoNovoValido);

            Assert.AreEqual(produtoInserido.Id, idInseridoEsperado);

        }

        [TestMethod]
        public void DeveListarComUsuarioValido()
        {
            var idInseridoEsperado = _pedidoNovoValido.Produto.Id;

            var produtos = Carrinho.Listar(_pedidoNovoValido.Usuario);

            Assert.IsTrue(produtos.Count > 0);

        }

        [TestMethod]
        public void DeveAlterarProdutoValido()
        {
            var idAlteradoEsperado = _pedidoVelhoValido.Produto.Id;

            var produtoAlterado = Carrinho.Alterar(_pedidoVelhoValido);

            Assert.AreEqual(produtoAlterado.Id, idAlteradoEsperado);

        }

        [TestMethod]
        public void DeveExcluirProdutoValido()
        {
            var deuErro = false;

            // pequeno ajuste para não quebrar os outros testes.
            var pedidoNovo = _pedidoVelhoValido;
            pedidoNovo.Produto.Id = 6;
            pedidoNovo.Produto.Description = "Produto 06";

            try
            {
                Carrinho.Inserir(pedidoNovo);
                Carrinho.Excluir(pedidoNovo);

            }
            catch
            {
                deuErro = true;
            }

            Assert.IsFalse(deuErro);


        }
    }
}