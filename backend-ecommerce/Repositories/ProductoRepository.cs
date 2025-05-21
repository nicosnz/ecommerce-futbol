using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_ecommerce.Interfaces;
using backend_ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_ecommerce.Repositories
{
    public class ProductoRepository : IProductRepository
    {
        private readonly EcommercePolerasContext _context;
        public ProductoRepository(EcommercePolerasContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> ObtenerProductos()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> ObtenerProducto(int idProducto)
        {
            var producto = await _context.Products.FirstOrDefaultAsync(x => x.Id == idProducto);
            return producto!;

        }
        public async Task<Product> CrearProducto(Product producto)
        {
            _context.Products.Add(producto);
            await _context.SaveChangesAsync();
            return producto;

        }
        public async Task<Product> ActualizarProducto(Product producto)
        {
            _context.Products.Update(producto);
            await _context.SaveChangesAsync();
            return producto;

        }
        public async Task<Product> ObtenerProductoPorNombre(string nombre)
        {
            var producto = await _context.Products.FirstOrDefaultAsync(c => c.Nombre == nombre);
            if (producto == null)
            {
                // No se encontró producto con ese nombre
                Console.WriteLine("Producto no encontrado");
            }
            else
            {
                Console.WriteLine("Producto encontrado: " + producto.Nombre);
            }
            return producto;


        }
    }
}