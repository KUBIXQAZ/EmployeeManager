namespace EmployeeManager.DTOs
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Pesel { get; set; }

        public Employee(int id, string name, string surname, string email, string phone, string pesel)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            Pesel = pesel;
        }
    }
}