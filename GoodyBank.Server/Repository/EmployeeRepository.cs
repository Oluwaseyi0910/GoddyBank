using GoodyBank.Server.Model;
using GoodyBank.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodyBank.Server.Repository
{
    //SOLID
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly GoodyBankDbContext _dbContext;
        public EmployeeRepository(GoodyBankDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            //Step1:
            //Get Table
            var result = await _dbContext.Employees.AddAsync(employee);
            _dbContext.SaveChanges();
            return result.Entity;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var result = await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (result != null)
            {
                _dbContext.Employees.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            var listOfEmployee = await _dbContext.Employees.ToListAsync();
            return listOfEmployee;
            
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await _dbContext.Employees
                .FirstOrDefaultAsync<Employee>(e => e.Email == email);
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = _dbContext.Employees;
            if (! string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                            && e.LastName.Contains(name));
            }
            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }
            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await _dbContext.SaveChangesAsync();

                return result;
            }
            return null;

        }

        Task<IEnumerable<Employee>> IEmployeeRepository.UpdateEmployee(Employee employee)
        {
            throw new System.NotImplementedException();
        }
    }


}
