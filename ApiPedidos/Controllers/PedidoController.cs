using Microsoft.AspNetCore.Mvc;

namespace ApiPedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<PedidoController> _logger;

        public PedidoController(ILogger<PedidoController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            return Ok(Carrinho.Listar());
        }

        [HttpPost("Inserir")]
        public IActionResult Inserir(Produto produto)
        {
            Carrinho.Inserir(produto);
            return new ObjectResult(produto) { StatusCode = StatusCodes.Status201Created };

        }

        [HttpPut("Alterar")]
        public IActionResult Alterar(Produto produto)
        {
            try
            {
                var produtos = Carrinho.Alterar(produto);
                return NoContent(); //Sucesso
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

        }

        [HttpDelete("Excluir")]
        public IActionResult Excluir([FromBody] int id)
        {
            try
            {
                Carrinho.Excluir(id);
                return Ok("Produto excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }

    public class Produto
    {
        public int Id { get; set; }
        public string Description { get; set; } = "";
    }

    public class Carrinho
    {
        private static List<Produto> _produtos { get; set; } = new List<Produto> {
            new Produto{ Id = 1, Description = "Produto 01" },
            new Produto{ Id = 2, Description = "Produto 02" },
            new Produto{ Id = 3, Description = "Produto 03" },
        };

        public static List<Produto> Listar()
        {
            return _produtos;
        }

        public static Produto Inserir(Produto produto)
        {
            _produtos.Add(produto);
            return produto;
        }

        public static Produto Alterar(Produto produto)
        {
            var index = _produtos.FindIndex(p => p.Id == produto.Id);

            if (index == -1)
                throw new Exception($"Produto {produto.Id} não encontrado.");

            _produtos[index] = produto;


            return produto;
        }

        public static void Excluir(int id)
        {
            var index = _produtos.FindIndex(p => p.Id == id);

            if (index == -1)
                throw new Exception($"Produto {id} não encontrado.");

            _produtos.RemoveAt(index);
        }
    }
}