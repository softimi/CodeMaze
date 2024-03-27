﻿using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        /*public async Task<IEnumerable<Employee>> GetEmployeesAsync
            (Guid companyId, EmployeeParameters 
            employeeParameters, bool trackChanges) =>*/
        /*public async Task<IEnumerable<Employee>> GetEmployeesAsync
            (Guid companyId, EmployeeParameters
            employeeParameters, bool trackChanges) =>

            //await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
            //   .OrderBy(e => e.Name).ToListAsync();

        await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges)
             .OrderBy(e => e.Name)
             .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
             .Take(employeeParameters.PageSize)
             .ToListAsync();*/

        public async Task<PagedList<Employee>> GetEmployeesAsync
            (Guid companyId, EmployeeParameters
            employeeParameters, bool trackChanges)
        {
            var employees = await FindByCondition(e => 
            e.CompanyId.Equals(companyId), trackChanges)
                .OrderBy(e => e.Name)
                .ToListAsync();

            return PagedList<Employee>
            .ToPagedList(employees, employeeParameters.PageNumber,
           employeeParameters.PageSize);

        }

        // The following is a more efficient way for bigger tables with millions of rows
        /*public async Task<PagedList<Employee>> 
            GetEmployeesAsync(Guid companyId, EmployeeParameters
            employeeParameters, bool trackChanges)
        {
            var employees = await FindByCondition(e => 
            e.CompanyId.Equals(companyId), trackChanges)
            .OrderBy(e => e.Name)
            .Skip((employeeParameters.PageNumber - 1) * employeeParameters.PageSize)
            .Take(employeeParameters.PageSize)
            .ToListAsync();

            var count = await FindByCondition(e => e.CompanyId.Equals(companyId), trackChanges
            ).CountAsync();

            return new PagedList<Employee>(employees, count,
            employeeParameters.PageNumber, employeeParameters.PageSize);
        }*/


        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) => 
             await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(id), 
                trackChanges)
                    .SingleOrDefaultAsync();

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) => Delete(employee);

    }
}
