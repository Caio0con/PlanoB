using Microsoft.AspNetCore.Mvc;

namespace DefaultNamespace;

[ApiController]
[Route("api/[controller]")]

public class PedidosController : ControllerBase
{
    private static readonly List<Pedido> Pedidos = new ();
    
    [HttpGet]
    public IActionResult CriarPedido([FromBody] Pedido novoPedido)
    {
        novoPedido.Id = Pedidos.Count + 1;
        novoPedido.Data = DateTime.UtcNow;
        Pedidos.Add(novoPedido);
        return CreatedAtAction(nameof(ObterPedido), new { id = novoPedido.Id }, novoPedido);
    }
    
    [HttpGet("{id}")]
    public IActionResult ObterPedido(int id)
    {
        var pedido = Pedidos.FirstOrDefault(pedido => pedido.Id == id);
        if (pedido == null)
        {
            return NotFound();
        }
        return Ok(pedido);
    }

    [HttpGet]
    public IActionResult ListarPedidos()
    {
        return Ok(Pedidos);
    }
}