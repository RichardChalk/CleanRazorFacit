using CustomerApp.Domain;

namespace CustomerApp.Web.ViewModels
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public Gender Gender { get; set; }

        // Calculated field som finns endast i denna VM!
        public int BirthYear => DateTime.Now.Year - Age;
    }
}
