using Domain.Model;

namespace Domain.Dtos
{
    public class CustomerDto
    {
        public CustomerDto()
        {
        }

        public CustomerDto(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Age = customer.Age;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}