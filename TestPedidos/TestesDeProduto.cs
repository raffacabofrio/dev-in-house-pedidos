using ApiPedidos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestPedidos
{
    [TestClass]
    public class TestesDeProduto
    {
        private Pedido _pedidoNovoComProdutoInvalido = new Pedido
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
                Description = ""
            }
        };
        private Pedido _pedidoVelhoComProdutoInvalido = new Pedido
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
                Description = ""
            }
        };
        private Pedido _pedidoComProdutoRepetido = new Pedido
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
                Description = "Produto 01"
            }
        };
        private Pedido _pedidoComProdutoInexistente = new Pedido
        {
            Usuario = new Usuario
            {
                Nome = "Mauro Martins",
                Autorizado = true,
                Autenticado = true
            },
            Produto = new Produto
            {
                Id = 999,
                Description = "Produto 999"
            }
        };

        


        [TestMethod]
        public void NaoDeveIncluirProdutoSemDescricao()
        {

            var deuErro = false;

            try
            {
                Carrinho.Inserir(_pedidoNovoComProdutoInvalido);

            }
            catch
            {
                deuErro = true;
            }

            Assert.IsTrue(deuErro);

        }

        [TestMethod]
        public void NaoDeveAlterarProdutoSemDescricao()
        {

            var deuErro = false;

            try
            {
                Carrinho.Alterar(_pedidoVelhoComProdutoInvalido);

            }
            catch
            {
                deuErro = true;
            }

            Assert.IsTrue(deuErro);

        }

        [TestMethod]
        public void NaoDeveIncluirProdutoRepetido()
        {

            var deuErro = false;

            try
            {
                Carrinho.Inserir(_pedidoComProdutoRepetido);

            }
            catch(Exception ex)
            {
                deuErro = ex.Message.Contains("Cadastro duplicado");
            }

            Assert.IsTrue(deuErro);

        }

        [TestMethod]
        public void NaoDeveAlterarProdutoInexistente()
        {

            var deuErro = false;

            try
            {
                Carrinho.Alterar(_pedidoComProdutoInexistente);

            }
            catch (Exception ex)
            {
                deuErro = ex.Message.Contains("não encontrado.");
            }

            Assert.IsTrue(deuErro);

        }

        [TestMethod]
        public void NaoDeveExcluirProdutoInexistente()
        {

            var deuErro = false;

            try
            {
                Carrinho.Excluir(_pedidoComProdutoInexistente);

            }
            catch (Exception ex)
            {
                deuErro = ex.Message.Contains("não encontrado.");
            }

            Assert.IsTrue(deuErro);

        }

        

    }
}