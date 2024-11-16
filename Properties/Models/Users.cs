namespace DefaultNamespace;

public class Users
{
    public int UsuarioId { get; set; }
    public string Nome { get; set; }
    
}

public class Pedido
{
    public int Id { get; set; }
    public int UsuarioId { get; }
    public List<string>  Produtos { get; set; }
    // public DateTime Data { get; set; }
    // public double ValorTotal { get; set; }
}