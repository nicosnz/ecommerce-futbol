using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_ecommerce.Controllers;
using backend_ecommerce.Interfaces;
using backend_ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_ecommerce.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository repository)
        {
            customerRepository = repository;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await customerRepository.ObtenerClientes();
        }
        public async Task<ActionResult<Customer>> GetCustomer(int idcustomer)
        {
            var existeCustomer = await customerRepository.ObtenerCliente(idcustomer);
            if (existeCustomer == null)
            {
                throw new CustomerNotFound(idcustomer);
            }
            return existeCustomer;
        }

        public async Task<Customer> CrearCustomer(Customer customer)
        {
            var existeCliente = customerRepository.ObtenerClientePorEmail(customer.Email);
            if (existeCliente != null)
            {
                throw new CustomerDuplicado(customer.Email);
            }
            return await customerRepository.CrearCliente(customer);
        }
        public async Task<Customer?> ActualizarCustomer(int id, Customer updatedCustomer)
        {
            var existeCustomer = await customerRepository.ObtenerCliente(id);
            if(existeCustomer == null)
            {
                throw new CustomerNotFound(id);
            }


            existeCustomer.FirstName = updatedCustomer.FirstName;
            existeCustomer.LastName = updatedCustomer.LastName;
            existeCustomer.Email = updatedCustomer.Email;
            existeCustomer.Telefono = updatedCustomer.Telefono;
            return await customerRepository.ActualizarCliente(existeCustomer);
        }


    }
}