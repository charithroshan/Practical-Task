using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly BackEndDbContext backEndDbContext;
        public EmployeesController(BackEndDbContext _backEndDbContext)
        {
            this.backEndDbContext = _backEndDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await backEndDbContext.Employees.ToListAsync();
            return Ok(employees);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Employee request)
        {
            request.Id = Guid.NewGuid();
            await backEndDbContext.Employees.AddAsync(request);
            await backEndDbContext.SaveChangesAsync();
            return Ok(request);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult>GetEmployee([FromRoute] Guid id)
        {
            var employee = 
                await backEndDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null) 
            {
                return NotFound();
            };

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateRequest)
        {
           var employee = await backEndDbContext.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            employee.Name = updateRequest.Name;
            employee.Email = updateRequest.Email;
            employee.Salary = updateRequest.Salary;
            employee.Phone = updateRequest.Phone;
            employee.Department = updateRequest.Department;

            await backEndDbContext.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await backEndDbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            backEndDbContext.Employees.Remove(employee);
            await backEndDbContext.SaveChangesAsync();
            return Ok(employee);
        }
    }

}
