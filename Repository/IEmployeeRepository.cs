using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCore203.Models;

namespace AspNetCore203.Repository {
    public interface IEmployeeRepository {
        Task<IEnumerable<Employee>> GetEmployeesAsync ();
        Task<Employee> GetEmployeeAsync (Guid id);
        Task<Employee> InsertEmployeeAsync (Employee entity);
        Task<bool> UpdateEmployeeAsync (Employee entity);
        Task<bool> DeleteEmployeeAsync (Guid id);
        Task<bool> EmployeeExist (Guid id);
        Task<bool> SaveAsync ();
    }
}