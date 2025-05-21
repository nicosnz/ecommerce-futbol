using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_ecommerce.Interfaces
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers();
        Task<ActionResult<Customer>> GetCustomer(int idcustomer);
        Task<Customer> CrearCustomer(Customer customer);
        Task<Customer?> ActualizarCustomer(int id, Customer updatedCustomer);

    }
}