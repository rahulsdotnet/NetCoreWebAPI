namespace NetCoreWebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> employees = new List<Employee>() { 
        new Employee
        {
            Address = "Address1",
            City="Hyderabad",
            Email="emp1@test.com",
            Id=1001,
            Name="Employee1",
        },
        new Employee
        {
            Address = "Address2",
            City="Mumbai",
            Email="emp2@test.com",
            Id=1002,
            Name="Employee2",
        },
        new Employee
        {
            Address = "Address3",
            City="Pune",
            Email="emp3@test.com",
            Id=1003,
            Name="Employee3",
        },
        new Employee
        {
            Address = "Address4",
            City="Nagpur",
            Email="emp4@test.com",
            Id=1004,
            Name="Employee4",
        }
        };

        public bool CreateEmployee(Employee employee)
        {
            employees.Add(employee);
            return true;
        }

        public bool DeleteEmployee(int id)
        {
            return true;
        }

        public Employee GetEmployeeById(int id)
        {
           return employees?.Where(emp => emp.Id == id)?.FirstOrDefault();
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public bool UpdateEmployee(Employee employee)
        {
            return true;
        }
    }

    public interface IEmployeeService
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        bool CreateEmployee(Employee employee);
        bool UpdateEmployee(Employee employee);
        bool DeleteEmployee(int id);
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}
