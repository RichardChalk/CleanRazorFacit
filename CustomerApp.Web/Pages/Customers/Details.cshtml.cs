using CustomerApp.Domain.Interfaces;
using CustomerApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerApp.Web.Pages.Customers
{
    public class DetailsModel : PageModel
    {
        private readonly ICustomerService _service;
        public CustomerVM? Customer { get; private set; }
        public DetailsModel(ICustomerService service) => _service = service;
        public async Task<IActionResult> OnGetAsync(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null) return NotFound();

            Customer = new CustomerVM
            {
                Id = entity.Id,
                Name = entity.Name,
                Age = entity.Age,
                Gender = entity.Gender
                // BirthYear beräknas automatiskt i VM
            };

            return Page();
        }
    }
}
