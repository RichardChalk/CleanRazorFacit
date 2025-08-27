using CustomerApp.Domain;
using CustomerApp.Domain.Interfaces;
using CustomerApp.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerApp.Web.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly ICustomerService _service;
        public IList<CustomerVM> Customers { get; private set; } = new List<CustomerVM>();
        public IndexModel(ICustomerService service) => _service = service;
        public async Task OnGetAsync()
        {
            var entities = await _service.GetAllAsync();

            Customers = entities.Select(c => new CustomerVM
            {
                Id = c.Id,
                Name = c.Name,
                Age = c.Age,
                Gender = c.Gender
                // BirthYear beräknas automatiskt i VM
            }).ToList();
        }
    }
}
