using Microsoft.AspNetCore.Mvc;


namespace DefaultNamespace;

[ApiController]
[Route("api/[controller]")]
public class PedidosController : ControllerBase
{
    private static readonly List<Pedido> Pedidos = new();

    // Cria um novo pedido
    [HttpPost]
    public IActionResult CriarPedido([FromBody] Pedido novoPedido)
    {
        novoPedido.Id = Pedidos.Count + 1;
        novoPedido.Data = DateTime.UtcNow;
        Pedidos.Add(novoPedido);
        return CreatedAtAction(nameof(ObterPedido), new { id = novoPedido.Id }, novoPedido);
    }

    // Obtém um pedido específico pelo ID
    [HttpGet("{id}")]
    public IActionResult ObterPedido(int id)
    {
        var pedido = Pedidos.FirstOrDefault(p => p.Id == id);
        if (pedido == null)
        {
            return NotFound();
        }
        return Ok(pedido);
    }

    // Lista todos os pedidos
    [HttpGet]
    public IActionResult ListarPedidos()
    {
        return Ok(Pedidos);
    }
}