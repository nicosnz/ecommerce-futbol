using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_ecommerce.Interfaces;
using backend_ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_ecommerce.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly EcommercePolerasContext _context;
        public CustomerRepository(EcommercePolerasContext context)
        {
            _context = context;
        }
        public async Task<List<Customer>> ObtenerClientes()
        {
            return await _context.Customers.ToListAsync();

        }
        public async Task<Customer> ObtenerCliente(int idcustomer)
        {

            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == idcustomer);
            return customer!;
        }
        public async Task<Customer> CrearCliente(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> ActualizarCliente(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> ObtenerClientePorEmail(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
        }



        
        
    }
}