using CustomerApp.Domain.Interfaces;
using CustomerApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerApp.Web.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerService _service;
        [BindProperty] public CustomerVM Customer { get; set; } = new();

        public CreateModel(ICustomerService service) => _service = service;

        public void OnGet()
        {
            // bara returnera sidan
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            // Mappa från ViewModel till entitet
            var entity = new Domain.Customer
            {
                Name = Customer.Name,
                Age = Customer.Age,
                Gender = Customer.Gender
            };

            await _service.AddAsync(entity);

            return RedirectToPage("Index");
        }
    }
}
