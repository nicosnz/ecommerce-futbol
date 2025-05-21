using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_ecommerce.Interfaces;
using backend_ecommerce.Models;
using backend_ecommerce.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_ecommerce.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CustomerController:ControllerBase
{
    private readonly ICustomerService _service;

    public CustomerController(ICustomerService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<List<Customer>>GetCustomers()
    {
        return await _service.GetCustomers();
    }

    [HttpGet("{idcustomer:int}")]

    public async Task<ActionResult<Customer>> GetCustomer(int idcustomer)
    {
        try
        {
            var customer = await _service.GetCustomer(idcustomer);
            return Ok(customer);
        }
        catch (CustomerNotFound ex)
        {
            return NotFound(new { mensaje = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
    {
        try
        {
            var nuevoCliente = await _service.CrearCustomer(customer);
            return CreatedAtAction(nameof(GetCustomer), new { idcustomer = nuevoCliente.Id }, nuevoCliente);

        }
        catch (CustomerDuplicado ex)
        {
            return Conflict(new { mensaje = ex.Message });
        }
    }
    [HttpPut("{id:int}")]
    public async  Task<ActionResult>PutCustomer(int id,Customer customer)
    {
        var updatedCustomer = await _service.ActualizarCustomer(id, customer);
        return CreatedAtAction(nameof(GetCustomer), new { idcustomer = updatedCustomer.Id }, updatedCustomer);
    }

}
