using CRUD.Abstracts;
using CRUD.DAL;
using CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Business
{
    public class EmployeeBL
    {
        private IRepository<Employee> _repository;
        private readonly DBTestContext context;

        //Property Injection
        //public IRepository<Employee> employeeDataObject
        //{
        //    set
        //    {
        //        this._repository = value;
        //    }
        //    get
        //    {
        //        if (employeeDataObject == null)
        //        {
        //            throw new Exception("Employee is not initialized");
        //        }
        //        else
        //        {
        //            return _repository;
        //        }
        //    }
        //}

        //IRepository<Employee> obj
        //Constractor Injection
        public EmployeeBL(DBTestContext context)
        {
            _repository = new EmployeeRepository(context);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _repository.ReadAll();
        }

        public async Task<Employee> GetById(int Id)
        {
            return await _repository.ReadById(Id);
        }

        public async Task<bool> Add(Employee employee)
        {
            if (await _repository.Create(employee))
                return true;
            else
                return false;          
        }

        public async Task<bool> Edit(Employee employee)
        {
            if (await _repository.Update(employee))
                return true;
            else
                return false;
        }

        public async Task<bool> Delete(int id)
        {
            if (await _repository.Delete(id))
                return true;
            else
                return false;
        }
    }
}
