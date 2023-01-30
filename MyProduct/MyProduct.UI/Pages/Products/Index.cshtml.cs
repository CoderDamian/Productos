using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProduct.AppServices.DTOs;
using System.Text.Json;

namespace MyProduct.UI.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly JsonSerializerOptions _serializerOptions;
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7175/api/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
        }

        [BindProperty]
        public IEnumerable<ListProductsDTO> ProductsList { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var response = await _httpClient.GetAsync("product").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using var content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                ProductsList = await JsonSerializer.DeserializeAsync<IEnumerable<ListProductsDTO>>(content, _serializerOptions);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            using var response = await _httpClient.DeleteAsync($"product/{id}").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            return Page();
        }
    }
}
