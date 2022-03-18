using ApiPedidos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPedidos
{
    [TestClass]
    public class TestesDeSeguranca
    {
        private Pedido _pedidoUsuarioNaoAutenticado = new Pedido
        {
            Usuario = new Usuario
            {
                Nome = "",
                Autorizado = false,
                Autenticado = false
            },
            Produto = new Produto
            {
                Id = 4,
                Description = "Produto 04"
            }
        };
        private Pedido _pedidoUsuarioNaoAutorizado = new Pedido
        {
            Usuario = new Usuario
            {
                Nome = "Deywid Felipe Lemes Chaves",
                Autorizado = false,
                Autenticado = true
            },
            Produto = new Produto
            {
                Id = 4,
                Description = "Produto 04"
            }
        };

        [TestMethod]
        public void UsuarioNaoAutenticadoNaoDeveIncluir()
        {

            var deuErro = false;

            try
            {
                Carrinho.Inserir(_pedidoUsuarioNaoAutenticado);

            }
            catch
            {
                deuErro = true;
            }

            Assert.IsTrue(deuErro);

        }

        [TestMethod]
        public void UsuarioNaoAutenticadoNaoDeveListar()
        {
            var deuErro = false;

            try
            {
                Carrinho.Listar(_pedidoUsuarioNaoAutenticado.Usuario);
            }
            catch
            {
                deuErro = true;
            }

            Assert.IsTrue(deuErro);

        }

        [TestMethod]
        public void UsuarioNaoAutenticadoNaoDeveAlterar()
        {

            var deuErro = false;

            try
            {
                Carrinho.Alterar(_pedidoUsuarioNaoAutenticado);

            }
            catch
            {
                deuErro = true;
            }

            Assert.IsTrue(deuErro);

        }

        [TestMethod]
        public void UsuarioNaoAutenticadoNaoDeveExcluir()
        {

            var deuErro = false;

            try
            {
                Carrinho.Excluir(_pedidoUsuarioNaoAutenticado);

            }
            catch
            {
                deuErro = true;
            }

            Assert.IsTrue(deuErro);

        }




        [TestMethod]
        public void UsuarioNaoAutorizadoNaoDeveIncluir()
        {

            var deuErro = false;

            try
            {
                Carrinho.Inserir(_pedidoUsuarioNaoAutorizado);

            }
            catch
            {
                deuErro = true;
            }

            Assert.IsTrue(deuErro);

        }

        [TestMethod]
        public void UsuarioNaoAutorizadoNaoDeveListar()
        {
            var deuErro = false;

            try
            {
                Carrinho.Listar(_pedidoUsuarioNaoAutorizado.Usuario);
            }
            catch
            {
                deuErro = true;
            }

            Assert.IsTrue(deuErro);

        }

        [TestMethod]
        public void UsuarioNaoAutorizadoNaoDeveAlterar()
        {

            var deuErro = false;

            try
            {
                Carrinho.Alterar(_pedidoUsuarioNaoAutorizado);

            }
            catch
            {
                deuErro = true;
            }

            Assert.IsTrue(deuErro);

        }

        [TestMethod]
        public void UsuarioNaoAutorizadoNaoDeveExcluir()
        {

            var deuErro = false;

            try
            {
                Carrinho.Excluir(_pedidoUsuarioNaoAutorizado);

            }
            catch
            {
                deuErro = true;
            }

            Assert.IsTrue(deuErro);

        }
    }
}