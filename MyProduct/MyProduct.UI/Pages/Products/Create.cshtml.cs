using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProduct.AppServices.DTOs;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace MyProduct.UI.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty]
        public CreateProductDTO ProductDTO { get; set; }

        public CreateModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7175/api/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var product = new StringContent(JsonSerializer.Serialize(ProductDTO), Encoding.UTF8, Application.Json);

            using var response = await _httpClient.PostAsync("Product", product).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}
