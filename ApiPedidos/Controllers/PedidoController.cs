using Microsoft.AspNetCore.Mvc;

namespace ApiPedidos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly ILogger<PedidoController> _logger;
        private Usuario _usuario;

        public PedidoController(ILogger<PedidoController> logger)
        {
            _logger = logger;

            _usuario = new Usuario
            {
                Nome = "Mauro Martins",
                Autenticado = true,
                Autorizado = true
            };
        }

        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(Carrinho.Listar(_usuario));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("Inserir")]
        public IActionResult Inserir(Produto produto)
        {
            try
            {
                var pedido = new Pedido
                {
                    Produto = produto,
                    Usuario = _usuario
                };

                Carrinho.Inserir(pedido);
                return new ObjectResult(produto) { StatusCode = StatusCodes.Status201Created };
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Alterar")]
        public IActionResult Alterar(Produto produto)
        {
            try
            {
                var pedido = new Pedido
                {
                    Produto = produto,
                    Usuario = _usuario
                };

                var produtos = Carrinho.Alterar(pedido);
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
                var pedido = new Pedido
                {
                    Produto = new Produto { Id = id },
                    Usuario = _usuario
                };

                Carrinho.Excluir(pedido);
                return Ok("Produto excluído com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }

    
}