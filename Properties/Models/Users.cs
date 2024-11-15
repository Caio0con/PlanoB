namespace DefaultNamespace;

public class Users
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}

public class Pedido
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }
    public List<string>  Produtos { get; set; }
    public DateTime Data { get; set; }
    public double ValorTotal { get; set; }
}