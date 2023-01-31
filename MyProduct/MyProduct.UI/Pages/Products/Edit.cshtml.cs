using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProduct.AppServices.DTOs;
using System.Net.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Text.Json;

namespace MyProduct.UI.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions _options;

        [BindProperty]
        public UpdateProductDTO ProductDTO { get; set; }
        public EditModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7175/api/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);

            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var response = await _httpClient.GetAsync($"product/{id}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                ProductDTO = await JsonSerializer.DeserializeAsync<UpdateProductDTO>(content, _options);
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var product = new StringContent(JsonSerializer.Serialize(ProductDTO), Encoding.UTF8, Application.Json);

            using var response = await _httpClient.PutAsync($"product/{ProductDTO.ProductID}", product).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return RedirectToPage("./Index");
        }
    }
}
