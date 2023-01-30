namespace MyProduct.AppServices.DTOs
{
    public class UpdateProductDTO
    {
        public int ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Precio { get; set; }
    }
}
