using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_ecommerce.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CustomerController:ControllerBase
{
    private readonly EcommercePolerasContext _context;
    public CustomerController(EcommercePolerasContext context)
    {   
        _context = context;
    }

    [HttpGet]
    public async Task<List<Customer>>GetCustomers()
    {
        return await _context.Customers.ToListAsync();
    }
        
    [HttpGet("{idcustomer:int}")]

    public async Task<ActionResult<Customer>>GetCustomer(int idcustomer)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == idcustomer );
        if(customer == null)
        {
            return NotFound();
        }
        return customer;
    }
    [HttpPost]
    public async  Task<ActionResult<Customer>>PostCustomer(Customer customer)
    {
        var nuevoCliente = new Customer
        {
        FirstName = customer.FirstName,
        LastName = customer.LastName,
        Email = customer.Email,
        PasswordHash = customer.PasswordHash,
        Telefono = customer.Telefono
        };

        _context.Customers.Add(nuevoCliente);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCustomer), new { idcustomer = nuevoCliente.Id }, nuevoCliente);
    }
    // [HttpPut("{id:int}")]
    // public async  Task<ActionResult>PutCustomer(int id,Customer customer)
    // {
    //     var existeCustomer = await _context.Customers.FirstOrDefaultAsync(x=>x.Id == id);
    //     if(existeCustomer == null)
    //     {
    //         return NotFound();
    //     }

        
    //     existeCustomer.FirstName = customer.FirstName;
    //     existeCustomer.LastName = customer.LastName;
    //     existeCustomer.Email = customer.Email;
    //     existeCustomer.Telefono = customer.Telefono;
    

    //     _context.Customers.Update(existeCustomer);
    //     await _context.SaveChangesAsync();
    //     return CreatedAtAction(nameof(GetCustomer), new { idcustomer = nuevoCliente.Id }, nuevoCliente);
    // }

}
