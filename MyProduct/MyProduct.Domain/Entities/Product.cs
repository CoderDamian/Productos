namespace MyProduct.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Precio { get; set; }
    }
}