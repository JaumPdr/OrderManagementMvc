namespace OrderManagementMvc.Models
{
    public class Customer
    {

        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cpf { get; set; }

        public Customer() { }

        public Customer(string name,  string email, string telefone, string cpf)
        {
            Name = name;
            Email = email;
            Telefone = telefone;
            Cpf = cpf;
        }
    }
}
