using GoodyBank.Shared; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoodyBank.Server.Repository
{
    public interface IEmployeeRepository
    {
        //CRUD
        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
        Task<IEnumerable<Employee>> GetEmployee();
        Task<Employee> GetEmployeeByEmail(string email);
        Task<Employee> AddEmployee(Employee employee);
        Task<IEnumerable<Employee>> UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employee);
    }
}
