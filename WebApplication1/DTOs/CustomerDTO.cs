namespace WebApplication1.DTOs
{
    public class CustomerDTO
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
    }

    public class CreateCustomerDTO
    {
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; }
    }

    public class UpdateCustomerDTO
    {
        public string? Name { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? Gender { get; set; }
    }
}
