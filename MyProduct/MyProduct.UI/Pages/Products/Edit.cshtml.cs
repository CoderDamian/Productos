using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyProduct.AppServices.DTOs;
using System.Net.Http;
using System.Text.Json;

namespace MyProduct.UI.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;

        [BindProperty]
        public UpdateProductDTO ProductDTO { get; set; }
        public EditModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://localhost:7175/api/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
        }

        public async Task<IActionResult> OnGet(int id)
        {
            var response = await _httpClient.GetAsync($"product/{id}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                ProductDTO = await JsonSerializer.DeserializeAsync<UpdateProductDTO>(content);
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            return RedirectToPage("./Index");
        }
    }
}
