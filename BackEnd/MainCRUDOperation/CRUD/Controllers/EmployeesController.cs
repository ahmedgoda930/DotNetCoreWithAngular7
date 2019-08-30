using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;
using Microsoft.AspNetCore.Cors;
using CRUD.Abstracts;
using CRUD.Business;
using CRUD.DAL;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DBTestContext _context;

        private readonly EmployeeBL _EmployeeBL;
        public EmployeesController(DBTestContext context)
        {
            _EmployeeBL = new EmployeeBL(context);
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            var allemp = await _EmployeeBL.GetAll();
            return new List<Employee>(allemp);
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _EmployeeBL.GetById(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }
            employee.Id = id;
            if (await _EmployeeBL.Edit(employee))
                return Ok();
            else
                return NoContent();
            //_context.Entry(employee).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!EmployeeExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

           //return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if(await _EmployeeBL.Add(employee))
                return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
            else
                return NoContent();

        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            if (await _EmployeeBL.Delete(id))
                return Ok();
            else
                return NotFound();

            //return employee;
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }
    }
}
