using Domain.Dtos;

namespace Domain.Model
{
    public class Customer
    {
        public Customer()
        {
        }

        public Customer(CustomerDto customerDto)
        {
            Name = customerDto.Name;
            Age = customerDto.Age;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public void Update(CustomerDto customerDto)
        {
            Name = customerDto.Name;
            Age = customerDto.Age;
        }
    }
}