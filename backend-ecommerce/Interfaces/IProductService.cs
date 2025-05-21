using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_ecommerce.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> ObtenerProductos();
        Task<ActionResult<Product>> ObtenerProducto(int idProducto);
        Task<Product> CrearProducto(Product producto);
        Task<Product?> ActualizarProducto(int id, Product productoActualizado);


    }
}