using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_ecommerce.Models;

namespace backend_ecommerce.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> ObtenerProductos();
        Task<Product> ObtenerProducto(int idProducto);
        Task<Product> CrearProducto(Product producto);
        Task<Product> ActualizarProducto(Product producto);
        Task<Product> ObtenerProductoPorNombre(string nombre);

    }
}