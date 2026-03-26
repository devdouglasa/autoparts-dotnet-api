
namespace api_dotnet.Models
{
    public enum MovementType
    {
        Inbound = 1,  // Entrada (Compra/Devolução)
        Outbound = 2  // Saída (Venda/Perda)
    }
    public class StockMovement
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public MovementType Type { get; set; }
        public string Reason { get; set; } // Ex: "Sale", "Restock", "Damage"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}