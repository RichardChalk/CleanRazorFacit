using CustomerApp.Domain.Interfaces;
using CustomerApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerApp.Web.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly ICustomerService _service;
        [BindProperty] public CustomerVM Customer { get; set; } = default!;
        public EditModel(ICustomerService service) => _service = service;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            Customer = new CustomerVM
            {
                Id = existing.Id,
                Name = existing.Name,
                Age = existing.Age,
                Gender = existing.Gender
                // BirthYear räknas automatiskt i VM
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            // uppdatera entiteten med värden från ViewModel
            existing.Name = Customer.Name;
            existing.Age = Customer.Age;
            existing.Gender = Customer.Gender;

            await _service.UpdateAsync(existing);
            return RedirectToPage("Index");
        }
    }
}
