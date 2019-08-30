using CRUD.Abstracts;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.DAL
{
    public class EmployeeRepository : IRepository<Employee>
    {
        DBTestContext _db;
        public EmployeeRepository(DBTestContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Employee Entity)
        {
            try
            {
                await _db.Employee.AddAsync(Entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public async Task<IEnumerable<Employee>> ReadAll()
        {

            return await _db.Employee.ToListAsync();
        }

        public async Task<Employee> ReadById(int Id)
        {
            return await _db.Employee.FindAsync(Id);
        }
        public async Task<bool> Update(Employee Entity)
        {
            try
            {
               // Employee emp = await _db.Employee.FindAsync(Entity.Id);
                if(Entity == null)
                {
                    return false;
                }
                _db.Entry(Entity).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return true;
            }
            catch { return false; }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                Employee emp = await _db.Employee.FindAsync(id);
                if (emp == null)
                {
                    return false;
                }
                _db.Employee.Remove(emp);
                await _db.SaveChangesAsync();
                return true;
            }
            catch { return false; }

        }

     

    
    }
}
