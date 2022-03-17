namespace ApiPedidos
{
    public class Carrinho
    {
        private static List<Produto> _produtos { get; set; } = new List<Produto> {
            new Produto{ Id = 1, Description = "Produto 01" },
            new Produto{ Id = 2, Description = "Produto 02" },
            new Produto{ Id = 3, Description = "Produto 03" },
        };

        public static List<Produto> Listar(Usuario usuario)
        {
            ValidacoesDeSeguranca(usuario);
            return _produtos;
        }

        

        public static Produto Inserir(Pedido pedido)
        {
            ValidacoesDeSeguranca(pedido.Usuario);
            ValidacoesDeProduto(pedido.Produto);

            // Linq
            var jaExiste = _produtos.Where(p => p.Id == pedido.Produto.Id).Any();

            if (jaExiste)
                throw new Exception($"Cadastro duplicado. O produto {pedido.Produto.Id} já existe.");

            EnviaNotificacaoTimeLogistica();

            _produtos.Add(pedido.Produto);
            return pedido.Produto;
        }

        

        public static Produto Alterar(Pedido pedido)
        {
            ValidacoesDeSeguranca(pedido.Usuario);
            ValidacoesDeProduto(pedido.Produto);

            var produto = pedido.Produto;
            var index = _produtos.FindIndex(p => p.Id == produto.Id);

            if (index == -1)
                throw new Exception($"Produto {produto.Id} não encontrado.");

            _produtos[index] = produto;


            return produto;
        }

        public static void Excluir(Pedido pedido)
        {
            ValidacoesDeSeguranca(pedido.Usuario);

            var id = pedido.Produto.Id;
            var index = _produtos.FindIndex(p => p.Id == id);

            if (index == -1)
                throw new Exception($"Produto {id} não encontrado.");

            _produtos.RemoveAt(index);
        }

        private static void ValidacoesDeSeguranca(Usuario usuario)
        {
            if (!usuario.Autenticado)
                throw new Exception("Por favor faça o login.");

            if (!usuario.Autorizado)
                throw new Exception("Sua conta ainda não foi ativda. Por favor confirme seu email.");
        }

        private static void ValidacoesDeProduto(Produto produto)
        {
            if (produto.Description == "")
                throw new Exception("O campo descrição é obrigatório.");
        }

        private static void EnviaNotificacaoTimeLogistica()
        {
            // mentirinha
        }
    }

    public class Pedido
    {
        public Produto Produto { get; set; }
        public Usuario Usuario { get; set; }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
    }

    public class Usuario {
        public string Nome { get; set; } = "";
        public bool Autenticado { get; set; } = false;
        public bool Autorizado { get; set; } = false;
    }
}
