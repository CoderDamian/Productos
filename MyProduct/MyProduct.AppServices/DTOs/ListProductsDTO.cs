namespace MyProduct.AppServices.DTOs
{
    public class ListProductsDTO
    {
        public int ProductID { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Precio { get; set; }
    }
}
