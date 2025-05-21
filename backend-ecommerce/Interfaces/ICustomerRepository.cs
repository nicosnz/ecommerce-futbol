using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_ecommerce.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> ObtenerClientes();
        Task<Customer> ObtenerCliente(int idcustomer);
        Task<Customer> CrearCliente(Customer customer);
        Task<Customer> ActualizarCliente(Customer customer);
        Task<Customer> ObtenerClientePorEmail(string email);

    }
}