using System.Reflection;

namespace CustomerApp.Domain
{
    public enum Gender { Male, Female, Other }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}
